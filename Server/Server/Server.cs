using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server {
    public partial class Server : Form {
        private TcpListener server;
        private Thread serverListen;
        private Thread clientListen;
        private int globalConnection = 0;
        private string globalRoomCode;
        private SemaphoreSlim sem = new SemaphoreSlim(1, 1);
        private Dictionary<string, int> numConnection = new Dictionary<string, int>();
        private Dictionary<string, List<TcpClient>> rooms = new Dictionary<string, List<TcpClient>>();
        private Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
        private Dictionary<string, List<string>> packets = new Dictionary<string, List<string>>();

        public Server() {
            InitializeComponent();
            server = new TcpListener(IPAddress.Any, 12345);
            server.Start();
            rtbShow.Text = "Server is running on port 12345\r\nWaiting for connection...\r\n";
        }

        private void Server_Load(object sender, EventArgs e) {
            serverListen = new Thread(() => {
                while (true) {
                    TcpClient client = server.AcceptTcpClient();
                    appendText("New client connected from " + client.Client.RemoteEndPoint + "\r\n");
                    clientListen = new Thread(() => Listen(client));
                    clientListen.IsBackground = true;
                    clientListen.Start();
                }
            });
            serverListen.IsBackground = true;
            serverListen.Start();
        }

        private void Listen(TcpClient client) {
            while (client.Connected) {
                if (client.Available > 0) {
                    string message = "";
                    while (client.Available > 0) {
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    }
                    appendText(client.Client.RemoteEndPoint + ": " + message + "\r\n");
                    AnalyzeMessage(message, client);
                }
            }
        }

        private async void AnalyzeMessage(string message, TcpClient client) {
            string[] Payload = message.Split(':');
            switch (Payload[0]) {
                case "CONNECT":
                    string[] data = Payload[1].Split('-');
                    if (!numConnection.ContainsKey(data[0]))
                        numConnection[data[0]] = 0;
                    numConnection[data[0]]++;
                    if (!users.ContainsKey(data[0]))
                        users[data[0]] = new Dictionary<string, int>();
                    users[data[0]].Add(data[1], numConnection[data[0]]);
                    if (!rooms.ContainsKey(data[0]))
                        rooms[data[0]] = new List<TcpClient>();
                    rooms[data[0]].Add(client);
                    if (!packets.ContainsKey(data[0]))
                        packets[data[0]] = new List<string>();
                    string cmd = "INFO_CON:" + data[0] + "-" + numConnection[data[0]] + "-" + data[1] + "-" + users[data[0]][data[1]];
                    SendData(cmd, client);
                    HistorySync(packets, data[0], client);
                    packets[data[0]].Add(cmd);
                    Broadcast(cmd, data[0], client);
                    break;
                case "DISCONNECT":
                    data = Payload[1].Split('-');
                    packets[data[0]].Clear();
                    users[data[0]].Remove(data[1]);
                    rooms[data[0]].Remove(client);
                    int temp = --numConnection[data[0]];
                    List<string> keys = users[data[0]].Keys.ToList();
                    for (int i = 0; i < keys.Count; i++) {
                        users[data[0]][keys[i]]--;
                        string str = data[0] + "-" + numConnection[data[0]] + "-" + keys[i] + "-" + users[data[0]][keys[i]];
                        cmd = "INFO_DISCON:" + str;
                        packets[data[0]].Add("INFO_CON:" + str);
                        Broadcast(cmd, data[0], client);
                    }
                    if (temp == 0) {
                        DeleteRoom(data[0]);
                    }
                    break;
                case "START":
                    packets[Payload[1]].Clear();
                    Broadcast("START:" + Payload[1], Payload[1], client);
                    break;
                case "CONNECT_MATCH":
                    Broadcast("SYNC:", Payload[1], client);
                    break;
                case "FIND":
                    data = Payload[1].Split('-');
                    try {
                        await sem.WaitAsync();
                        if (globalConnection == 0) {
                            globalRoomCode = data[0];
                            globalConnection = 1;
                        } else if (globalConnection > 4) {
                            globalConnection = 0;
                        } else {
                            if (data[0] != globalRoomCode) {
                                DeleteRoom(data[0]);
                                numConnection[globalRoomCode] = globalConnection;
                                users[globalRoomCode].Add(data[1], numConnection[globalRoomCode]);
                                rooms[globalRoomCode].Add(client);
                                cmd = "INFO_CON:" + globalRoomCode + "-" + numConnection[globalRoomCode] + "-" + data[1] + "-" + users[globalRoomCode][data[1]];
                                SendData(cmd, client);
                                HistorySync(packets, globalRoomCode, client);
                                packets[globalRoomCode].Add(cmd);
                                Broadcast(cmd, globalRoomCode, client);
                                if (globalConnection == 4) {
                                    SendData("START:" + globalRoomCode, client);
                                    Broadcast("START:" + globalRoomCode, globalRoomCode, client);
                                }
                            }
                        }
                        globalConnection++;
                    } finally {
                        sem.Release();
                    }
                    break;
            }
        }

        private async void DeleteRoom(string roomCode) {
            packets.Remove(roomCode);
            users.Remove(roomCode);
            rooms.Remove(roomCode);
            numConnection.Remove(roomCode);
            using (HttpClient httpClient = new HttpClient()) {
                try {
                    string url = "https://olympiawebservice.azurewebsites.net/api/Room?idRoom=" + roomCode;
                    await httpClient.DeleteAsync(url);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SendData(string message, TcpClient client) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(100);
        }

        private void Broadcast(string message, string roomCode, TcpClient sender) {
            for (int i = 0; i < rooms[roomCode].Count; i++) {
                TcpClient client = rooms[roomCode][i];
                if (!client.Connected || client == null) {
                    rooms[roomCode].Remove(client);
                } else if (client != sender) {
                    SendData(message, client);
                }
                Thread.Sleep(100);
            }
        }

        private void appendText(string text) {
            if (InvokeRequired) {
                Invoke(new Action<string>(appendText), text);
                return;
            }
            rtbShow.AppendText(text);
        }

        private void HistorySync(Dictionary<string, List<string>> data, string roomCode, TcpClient client) {
            if (data[roomCode].Count > 0) {
                foreach (string mess in data[roomCode]) {
                    SendData(mess, client);
                }
                Thread.Sleep(100);
            }
        }

        private void Server_Closing(object sender, FormClosingEventArgs e) {
            server.Stop();
            if (serverListen.IsAlive)
                serverListen.Abort();
        }
    }
}

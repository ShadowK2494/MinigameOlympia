using MinigameOlympia.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MinigameOlympia {
    public partial class PhongCho : Form {
        public Player player;
        public Image image;
        public string roomCode;
        private TcpClient client;
        private Thread receive;
        private int numConnection = 0;
        public PhongCho() {
            InitializeComponent();
        }

        private void PhongCho_Load(object sender, EventArgs e) {
            lblRoomCode.Text = roomCode;
            Connect();
            SendData("CONNECT:" + lblRoomCode.Text + "-" + player.Username, client);
            PostMatch();
        }

        private void SendData(string message, TcpClient client) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(100);
        }

        private void ptbHome_Click(object sender, EventArgs e) {
            foreach (Form form in Application.OpenForms) {
                if (form.Name == "GiaoDienChinh") {
                    form.Visible = true;
                    break;
                }
            }
            SendData("DISCONNECT:" + lblRoomCode.Text + "-" + player.Username, client);
            Thread.Sleep(1000);
            Close();
        }

        private void Connect() {
            client = new TcpClient("127.0.0.1", 12345);
            receive = new Thread(() => ReceiveMessage(client));
            receive.IsBackground = true;
            receive.Start();
        }

        private async Task<byte[]> getAvatar(string username) {
            Player pTemp = new Player();
            HttpClient httpClient = new HttpClient();
            try {
                string url = "http://localhost:2804/api/Player/username?lookup=" + username;
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    pTemp = JsonConvert.DeserializeObject<Player>(jsonContent);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return pTemp.Avatar;
        }

        private Image LoadImage(byte[] b) {
            if (b.Length == 0)
                return Properties.Resources.anhdaidien;
            Image res;
            using (MemoryStream ms = new MemoryStream(b)) {
                res = Image.FromStream(ms);
            }
            return res;
        }

        private void RestoreDefault() {
            lblPlayer2.Text = "Player 2";
            lblPlayer2.ForeColor = Color.White;
            lblPlayer3.Text = "Player 3";
            lblPlayer3.ForeColor = Color.White;
            lblPlayer4.Text = "Player 4";
            lblPlayer4.ForeColor = Color.White;
            ptbPlayer2.Image = Properties.Resources.plus;
            ptbPlayer3.Image = Properties.Resources.plus;
            ptbPlayer4.Image = Properties.Resources.plus;
        }

        private void ReceiveMessage(TcpClient tcpClient) {
            while (true) {
                if (client == null || !client.Connected)
                    continue;
                else {
                    if (client.Available > 0) {
                        string message = "";
                        while (client.Available > 0) {
                            byte[] buffer = new byte[1024];
                            try {
                                NetworkStream stream = client.GetStream();
                                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                                message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                                AnalyzingMessage(message, tcpClient);
                            } catch (Exception) {

                            }
                        }
                    }
                }
            }
        }

        private async void AnalyzingMessage(string mess, TcpClient tcpClient) {
            string[] Payload = mess.Split(':');
            switch (Payload[0]) {
                case "INFO_CON":
                    string[] data = Payload[1].Split('-');
                    numConnection = int.Parse(data[0]);
                    byte[] avatarByte = await getAvatar(data[1]);
                    foreach (Control c in panelMain.Controls) {
                        if (c is Label) {
                            Label l = (Label)c;
                            if (l.Tag.ToString() == data[2]) {
                                if (data[1] == player.Username) {
                                    l.Text = player.Username;
                                    l.ForeColor = Color.Yellow;
                                } else {
                                    l.Text = data[1];
                                }
                            }
                        } else if (c is PictureBox) {
                            PictureBox p = (PictureBox)c;
                            if (p.Tag.ToString() == data[2]) {
                                if (data[1] == player.Username)
                                    p.Image = image;
                                else
                                    p.Image = LoadImage(avatarByte);
                            }
                        }
                    }
                    break;
                case "INFO_DISCON":
                    RestoreDefault();
                    data = Payload[1].Split('-');
                    numConnection = int.Parse(data[0]);
                    avatarByte = await getAvatar(data[1]);
                    foreach (Control c in panelMain.Controls) {
                        if (c is Label) {
                            Label l = (Label)c;
                            if (l.Tag.ToString() == data[2]) {
                                if (data[1] == player.Username) {
                                    l.Text = player.Username;
                                    l.ForeColor = Color.Yellow;
                                } else {
                                    l.Text = data[1];
                                }
                            }
                        } else if (c is PictureBox) {
                            PictureBox p = (PictureBox)c;
                            if (p.Tag.ToString() == data[2]) {
                                if (data[1] == player.Username)
                                    p.Image = image;
                                else
                                    p.Image = LoadImage(avatarByte);
                            }
                        }
                    }
                    break;
            }
        }

        private async void PostMatch() {
            HttpClient httpClient = new HttpClient();
            try {
                string url = "http://localhost:2804/api/Match?idPlayer=" + player.IDPlayer + "&idRoom=" + lblRoomCode.Text;
                await httpClient.PostAsync(url, null);
            } catch (Exception ex) {

            }
        }

        private void PhongCho_FormClosing(object sender, FormClosingEventArgs e) {
            if (client.Connected)
                client.Close();
            if (receive.IsAlive)
                receive.Abort();
        }
    }
}

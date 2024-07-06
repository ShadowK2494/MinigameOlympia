using MinigameOlympia.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class KetQua : Form {
        public TcpClient client;
        public string roomCode;
        public Player player;
        private Thread receive;
        private SoundPlayer sound;
        private bool isDone = false;
        private System.Windows.Forms.Timer endTimer = new System.Windows.Forms.Timer();
        public KetQua() {
            InitializeComponent();
            endTimer.Interval = 10000;
            endTimer.Tick += endTimer_Tick;
        }

        private void Result_Load(object sender, EventArgs e) {
            sound = new SoundPlayer(Properties.Resources.Result);
            sound.Play();
            receive = new Thread(() => ReceiveMessage(client));
            receive.IsBackground = true;
            receive.Start();
            SendData($"WINNER:{roomCode}-{player.Username}", client);
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
                case "WINNER":
                    string[] data = Payload[1].Split('-');
                    byte[] avatarByte = await getAvatar(data[0]);
                    pictureBox_avt.Image = LoadImage(avatarByte);
                    if (data[0] == player.Username) {
                        lblYourScore.Visible = false;
                        player.WinCount++;
                        string jsonContent = JsonConvert.SerializeObject(player);
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        using (HttpClient client = new HttpClient()) {
                            try {
                                await client.PutAsync("https://olympiawebservice.azurewebsites.net/api/Player", content);
                                isDone = true;
                                endTimer.Interval = 2000;
                            } catch (Exception ex) {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    } else {
                        lblYourScore.Text = $"Điểm của bạn: {data[2]}";
                        isDone = true;
                    }
                    label_name.Text = data[0];
                    label_score.Text = data[1];
                    Invoke(new MethodInvoker(delegate {
                        endTimer.Start();
                    }));
                    break;
            }
        }

        private void SendData(string message, TcpClient tcpClient) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
        }

        private async Task<byte[]> getAvatar(string username) {
            Player pTemp = new Player();
            HttpClient httpClient = new HttpClient();
            try {
                string url = "https://olympiawebservice.azurewebsites.net/api/Player/username?lookup=" + username;
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

        private void endTimer_Tick(object sender, EventArgs e) {
            if (isDone) {
                endTimer.Stop();
                foreach (Form form in Application.OpenForms) {
                    if (form.Name == "GiaoDienChinh") {
                        form.Visible = true;
                        ((GiaoDienChinh)form).suspendEvent.Set();
                        break;
                    }
                }
                Close();
            }
        }

        private void Result_FormClosing(object sender, FormClosingEventArgs e) {
            if (receive.IsAlive)
                receive.Abort();
            if (client.Connected) {
                SendData($"END:{roomCode}-{player.Username}", client);
                client.Close();
            }
            sound.Stop();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class Answer : Form {
        public TcpClient client;
        public string roomCode;
        public int round = 0;
        private bool isTrue;
        private string answer;
        private Thread receive;
        private SoundPlayer sound;
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();
        public Answer() {
            InitializeComponent();
            countdownTimer.Interval = 5000;
            countdownTimer.Tick += countdownTimer_Tick;
        }

        public bool IsGetPic() {
            return isTrue;
        }

        public string GetAnswer() {
            return answer;
        }

        private void countdownTimer_Tick(object sender, EventArgs e) {
            countdownTimer.Stop();
            foreach (Form form in Application.OpenForms) {
                if (round == 1) {
                    if (form.Name == "Vong1") {
                        Invoke(new MethodInvoker(delegate {
                            form.Visible = true;
                        }));
                        break;
                    }
                } else {
                    if (form.Name == "Vong2") {
                        Invoke(new MethodInvoker(delegate {
                            form.Visible = true;
                        }));
                        break;
                    }
                }
            }
            Close();
        }

        private void ShowAnswer_Load(object sender, EventArgs e) {
            sound = new SoundPlayer(Properties.Resources.ShowAns);
            sound.Play();
            Thread.Sleep(1000);
            SendData($"GET_ANSWER:{roomCode}", client);
            receive = new Thread(() => ReceiveMessage(client));
            receive.IsBackground = true;
            receive.Start();
            countdownTimer.Start();
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

        private void AnalyzingMessage(string mess, TcpClient tcpClient) {
            string[] Payload = mess.Split(':');
            switch (Payload[0]) {
                case "PLAYER_ANS":
                    string[] data = Payload[1].Split('-');
                    int t = int.Parse(data[0]);
                    if (t == 0) {
                        isTrue = false;
                    } else {
                        isTrue = true;
                    }
                    answer = data[1];
                    string jsonData = mess.Substring(14 + answer.Length);
                    var recvData = JsonConvert.DeserializeObject<List<List<string>>>(jsonData);
                    LoadScreen(recvData);
                    break;
            }
        }

        private void LoadScreen(List<List<string>> list) {
            int i = 0;
            while (i < list.Count) {
                //Invoke(new MethodInvoker(delegate {
                if (i == 0) {
                    lbUsername1.Text = list[i][0];
                    lbAnswer1.Text = list[i][1];
                    lbTime1.Text = list[i][2];
                    lbScore1.Text = list[i][3];
                    if (list[i][4] == "1") {
                        panel1.BackColor = Color.Lime;
                    } else {
                        panel1.BackColor = Color.Red;
                    }
                } else if (i == 1) {
                    lbUsername2.Text = list[i][0];
                    lbAnswer2.Text = list[i][1];
                    lbTime2.Text = list[i][2];
                    lbScore2.Text = list[i][3];
                    if (list[i][4] == "1") {
                        panel2.BackColor = Color.Lime;
                    } else {
                        panel2.BackColor = Color.Red;
                    }
                } else if (i == 2) {
                    lbUsername3.Text = list[i][0];
                    lbAnswer3.Text = list[i][1];
                    lbTime3.Text = list[i][2];
                    lbScore3.Text = list[i][3];
                    if (list[i][4] == "1") {
                        panel3.BackColor = Color.Lime;
                    } else {
                        panel3.BackColor = Color.Red;
                    }
                } else if (i == 3) {
                    lbUsername4.Text = list[i][0];
                    lbAnswer4.Text = list[i][1];
                    lbTime4.Text = list[i][2];
                    lbScore4.Text = list[i][3];
                    if (list[i][4] == "1") {
                        panel4.BackColor = Color.Lime;
                    } else {
                        panel4.BackColor = Color.Red;
                    }
                }
                //}));
                i++;
            }
        }

        private void SendData(string message, TcpClient client) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(100);
        }

        private void ShowAnswer_FormClosing(object sender, FormClosingEventArgs e) {
            if (receive.IsAlive) {
                receive.Abort();
            }
            sound.Stop();
        }
    }
}

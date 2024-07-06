using LibVLCSharp.Shared;
using Microsoft.AspNetCore.Mvc;
using MinigameOlympia.Models;
using MinigameOlympia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class Vong2 : Form {
        public TcpClient client;
        public string roomCode;
        public Player player;
        public List<string> players = new List<string>();
        public List<Image> avatars = new List<Image>();
        private Thread receive;
        private int question = 0;
        private int total = 0;
        private bool isVVW = false;
        private bool isCountdown = false;
        private bool isAnswer = false;
        private bool isEnd = false;
        private SoundPlayer sound;
        private DateTime startTime = new DateTime();
        private VerticalProgressbar progressbar = new VerticalProgressbar();
        private ManualResetEvent suspendEvent = new ManualResetEvent(true);
        private System.Windows.Forms.Timer startTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();
        public Vong2() {
            InitializeComponent();
            progressbar.Location = new Point(286, 12);
            progressbar.Size = new Size(34, 434);
            progressbar.Minimum = 0;
            progressbar.ForeColor = Color.Blue;
            Controls.Add(progressbar);
            startTimer.Interval = 5000;
            countdownTimer.Interval = 1000;
            startTimer.Tick += startTimer_Tick;
            countdownTimer.Tick += countdownTimer_Tick;
        }

        private void Round2_FormClosing(object sender, FormClosingEventArgs e) {
            if (receive.IsAlive) {
                receive.Abort();
            }
        }

        private void Round2_Load(object sender, EventArgs e) {
            receive = new Thread(() => ReceiveMessage(client));
            receive.IsBackground = true;
            receive.Start();
            LoadScreen();
            SendData($"GET_POINT_FN:{roomCode}", client);
            Thread.Sleep(2000);
            SendData($"ROUND2:{roomCode}", client);
        }

        private void LoadScreen() {
            lblPlayer1.Text = players[0];
            lblPlayer2.Text = players[1];
            lblPlayer3.Text = players[2];
            lblPlayer4.Text = players[3];
            ptbPlayer1.Image = avatars[0];
            ptbPlayer2.Image = avatars[1];
            ptbPlayer3.Image = avatars[2];
            ptbPlayer4.Image = avatars[3];
            if (player.Username == players[0]) {
                lblPlayer1.ForeColor = Color.Yellow;
            } else if (player.Username == players[1]) {
                lblPlayer2.ForeColor = Color.Yellow;
            } else if (player.Username == players[2]) {
                lblPlayer3.ForeColor = Color.Yellow;
            } else {
                lblPlayer4.ForeColor = Color.Yellow;
            }
        }

        private void ReceiveMessage(TcpClient tcpClient) {
            while (true) {
                suspendEvent.WaitOne();
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
                case "POINT":
                    string[] data = Payload[1].Split('-');
                    //Invoke(new MethodInvoker(delegate {
                    for (int i = 0; i < data.Length; i++) {
                        if (i == 0) {
                            lblPointPlayer1.Text = data[i];
                        } else if (i == 1) {
                            lblPointPlayer2.Text = data[i];
                        } else if (i == 2) {
                            lblPointPlayer3.Text = data[i];
                        } else {
                            lblPointPlayer4.Text = data[i];
                        }
                    }
                    //}));
                    break;
                case "QUEST_R2":
                    Invoke(new MethodInvoker(delegate {
                        sound = new SoundPlayer(Properties.Resources.TT_Open);
                        sound.Play();
                        Payload[1] += $":{Payload[2]}";
                        data = Payload[1].Split('^');
                        int t = int.Parse(data[0]);
                        question = t;
                        gbQuestion.Text = $"Câu hỏi {t + 1}: {data[1]}";
                        isEnd = false;
                        isAnswer = false;
                        tbAnswer.Text = "";
                        btnAnswer.Enabled = true;
                        if (t < 3) {
                            isEnd = true;
                            ptbQuestion.Visible = true;
                            vvwQuestion.Visible = false;
                            ptbQuestion.Load(data[2]);
                            isVVW = false;
                        } else {
                            ptbQuestion.Visible = false;
                            vvwQuestion.Visible = true;
                            var libVLC = new LibVLC();
                            var media = new Media(libVLC, new Uri(data[2]));
                            vvwQuestion.MediaPlayer = new LibVLCSharp.Shared.MediaPlayer(media) {
                                EnableHardwareDecoding = true
                            };
                            vvwQuestion.MediaPlayer.EndReached += OnEndReached;
                            isVVW = true;
                            vvwQuestion.MediaPlayer.Play();
                        }
                        int time = int.Parse(data[3]);
                        progressbar.Maximum = time;
                        if (time == 10)
                            sound = new SoundPlayer(Properties.Resources.TT_10s);
                        else if (time == 20)
                            sound = new SoundPlayer(Properties.Resources.TT_20s);
                        else if (time == 30) {
                            sound = new SoundPlayer(Properties.Resources.TT_30s);
                        } else
                            sound = null;
                    }));
                    Invoke(new MethodInvoker(delegate {
                        startTimer.Start();
                    }));
                    break;
            }
        }

        private void SendData(string message, TcpClient client) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(100);
        }

        private void countdownTimer_Tick(object sender, EventArgs e) {
            if (progressbar.Value < progressbar.Maximum) {
                progressbar.Value++;
                isCountdown = true;
            } else {
                if (!isAnswer) {
                    btnAnswer.Enabled = false;
                    SendData($"ANSWER_R2:{roomCode}-{player.Username}---{question}", client);
                }
                if (isEnd) {
                    total++;
                    isCountdown = false;
                    countdownTimer.Stop();
                    progressbar.Value = 0;
                    suspendEvent.Reset();
                    Answer show = new Answer();
                    show.client = client;
                    show.roomCode = roomCode;
                    show.round = 2;
                    show.ShowDialog();
                    Visible = false;
                    suspendEvent.Set();
                    if (total < 4) {
                        SendData($"GET_POINT_FN:{roomCode}", client);
                        Thread.Sleep(1000);
                        SendData($"QUEST_R2:{roomCode}-{total}", client);
                    } else {
                        KetQua result = new KetQua();
                        result.client = client;
                        result.roomCode = roomCode;
                        result.player = player;
                        result.Show();
                        Close();
                    }
                }
            }
        }

        private void OnEndReached(object sender, EventArgs e) {
            isEnd = true;
        }

        private void startTimer_Tick(object sender, EventArgs e) {
            startTimer.Stop();
            startTime = DateTime.Now;
            btnAnswer.Visible = true;
            countdownTimer.Start();
            if (sound != null) {
                sound.Play();
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e) {
            if (tbAnswer.Text != "") {
                btnAnswer.Enabled = false;
                isAnswer = true;
                TimeSpan time = DateTime.Now - startTime;
                string str = tbAnswer.Text.Replace(":", "");
                SendData($"ANSWER_R2:{roomCode}-{player.Username}-{str}-" +
                    $"{time.TotalSeconds.ToString("0.00")}-{question}", client);
            }
        }

        private void Guide_Click(object sender, EventArgs e) {
            InstructionRound2 form = new InstructionRound2();
            form.Show();
        }
    }
}

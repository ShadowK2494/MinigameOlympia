using MinigameOlympia.Models;
using MinigameOlympia;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MinigameOlympia {
    public partial class QuestionRound1 : Form {
        public string data;
        public TcpClient client;
        public string roomCode;
        public Player player;
        public bool isTerminated;
        private string[] analyzedData;
        private bool isReady = false;
        private bool isQuestDone = false;
        private TimeSpan timeLeft;
        private TimeSpan totalTime;
        private DateTime startTime;
        private SoundPlayer sound;
        private System.Windows.Forms.Timer startTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();
        private bool isAnswer = false;
        public QuestionRound1() {
            InitializeComponent();
            startTimer.Interval = 3000;
            countdownTimer.Interval = 1000;
            startTimer.Tick += startTimer_Tick;
            countdownTimer.Tick += countdownTimer_Tick;
        }

        public bool IsQuestDone() {
            return isQuestDone;
        }

        private void QuestionRound1_Load(object sender, EventArgs e) {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
            analyzedData = data.Split('*');
            isReady = true;
            Clock.Invalidate();
            lblQuestion.Text = analyzedData[1];
            totalTime = new TimeSpan(0, 0, 15);
            timeLeft = totalTime;
            startTimer.Start();
            if (isTerminated) {
                tbAnswer.Enabled = false;
                btnAnswer.Enabled = false;
            }
        }

        private void startTimer_Tick(object sender, EventArgs e) {
            startTimer.Stop();
            startTime = DateTime.Now;
            sound = new SoundPlayer(Properties.Resources.VCNV_15s);
            sound.Play();
            btnAnswer.Visible = true;
            countdownTimer.Start();
            Clock.Invalidate();
        }

        private void countdownTimer_Tick(object sender, EventArgs e) {
            if (timeLeft.TotalSeconds > 0) {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                Clock.Invalidate();
            } else {
                countdownTimer.Stop();
                isQuestDone = true;
                if (!isAnswer) {
                    SendData($"ANSWER_R1:{roomCode}-{player.Username}---{analyzedData[0]}", client);
                }
                Close();
            }

        }

        private void QuestionArea_Paint(object sender, PaintEventArgs e) {
            if (isReady) {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                int numChars = int.Parse(analyzedData[2]);
                int x = (QuestionArea.Width / 40 - numChars) * 20;
                for (int i = 0; i < numChars; i++) {
                    using (SolidBrush brush = new SolidBrush(Color.Blue)) {
                        g.FillEllipse(brush, x, 0, 35, 35);
                    }
                    x += 40;
                }
            }
        }

        private void Clock_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, Clock.Width, Clock.Height);
            g.FillEllipse(Brushes.LightGray, rect);
            float percentage = (float)timeLeft.TotalSeconds / (float)totalTime.TotalSeconds;
            int sweepAngle = (int)(360 * percentage);
            g.FillPie(Brushes.Blue, rect, -90, sweepAngle);
            g.DrawEllipse(Pens.Black, rect);
            using (Font font = new Font("Arial", 20, FontStyle.Bold)) {
                string text = timeLeft.ToString(@"ss");
                SizeF textSize = g.MeasureString(text, font);
                PointF location = new PointF();
                location.X = (Clock.Width - textSize.Width) / 2;
                location.Y = (Clock.Height - textSize.Height) / 2;
                g.DrawString(text, font, Brushes.Black, location);
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e) {
            if (tbAnswer.Text != "") {
                btnAnswer.Enabled = false;
                isAnswer = true;
                TimeSpan time = DateTime.Now - startTime;
                string str = tbAnswer.Text.Replace(":", "");
                SendData($"ANSWER_R1:{roomCode}-{player.Username}-{str}-" +
                    $"{time.TotalSeconds.ToString("0.00")}-{analyzedData[0]}", client);
            }
        }

        private void SendData(string message, TcpClient client) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(100);
        }
    }
}

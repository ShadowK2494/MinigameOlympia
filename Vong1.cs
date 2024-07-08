using MinigameOlympia.Models;
using MinigameOlympia;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Configuration;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class Vong1 : Form {
        public TcpClient client;
        public string roomCode;
        public Player player;
        public Image avatar;
        public int score = 0;
        private Thread receive;
        private bool ready = false;
        private bool draw = false;
        private bool ignore = false;
        private bool isAnswer = false;
        private bool isPress = false;
        private bool isTerminated = false;
        private int indexPlayer = 0;
        private string playerTurn;
        private int turn = 0;
        private string answer;
        private int num = 0;
        private int numGuess = 0;
        private int remainPlayer = 4;
        private SoundPlayer sound;
        private TimeSpan timeLeft;
        private TimeSpan bonusTimeLeft;
        private TimeSpan finalTimeLeft;
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countdownBonusTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countdownFinalTimer = new System.Windows.Forms.Timer();
        private List<List<string>> graphics = new List<List<string>>();
        private ManualResetEvent suspendEvent = new ManualResetEvent(true);
        private List<string> players = new List<string>();
        private List<Image> avatars = new List<Image>();
        private List<Button> remainButton = new List<Button>();
        private Dictionary<string, List<int>> Questions = new Dictionary<string, List<int>>();
        public Vong1() {
            InitializeComponent();
            countdownTimer.Interval = 1000;
            countdownBonusTimer.Interval = 1000;
            countdownFinalTimer.Interval = 1000;
            countdownTimer.Tick += countdownTimer_Tick;
            countdownBonusTimer.Tick += countdownBonusTimer_Tick;
            countdownFinalTimer.Tick += countdownFinalTimer_Tick;
            remainButton = new List<Button> {
                btnQuest1, btnQuest2, btnQuest3, btnQuest4
            };
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

        private void Round1_Load(object sender, EventArgs e) {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
            Invoke(new MethodInvoker(delegate {
                sound = new SoundPlayer(Properties.Resources.VCNV_OpenCNV);
                sound.Play();
            }));
            Cursor = Cursors.WaitCursor;
            SendData("INFO_START:" + roomCode, client);
            receive = new Thread(() => ReceiveMessage(client));
            receive.IsBackground = true;
            receive.Start();
            Thread.Sleep(1000);
            SendData("GET_QA_R1:" + roomCode, client);
            timeLeft = new TimeSpan(0, 0, 7);
            bonusTimeLeft = new TimeSpan(0, 0, 5);
            finalTimeLeft = new TimeSpan(0, 0, 5);
            Cursor = Cursors.Default;
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

        private async void AnalyzingMessage(string mess, TcpClient tcpClient) {
            string[] Payload = mess.Split(':');
            switch (Payload[0]) {
                case "INFO_START":
                    string[] data = Payload[1].Split('-');
                    //Invoke(new MethodInvoker(async delegate {
                    for (int i = 0; i < data.Length; i++) {
                        players.Add(data[i]);
                        if (i == 0) {
                            lblPlayer1.Text = data[i];
                            if (data[i] == player.Username) {
                                indexPlayer = i + 1;
                                lblPlayer1.ForeColor = Color.Yellow;
                                ptbPlayer1.Image = avatar;
                                avatars.Add(avatar);
                            } else {
                                byte[] avatarByte = await getAvatar(data[i]);
                                Image img = LoadImage(avatarByte);
                                ptbPlayer1.Image = img;
                                avatars.Add(img);
                            }
                        } else if (i == 1) {
                            lblPlayer2.Text = data[i];
                            if (data[i] == player.Username) {
                                indexPlayer = i + 1;
                                lblPlayer2.ForeColor = Color.Yellow;
                                ptbPlayer2.Image = avatar;
                                avatars.Add(avatar);
                            } else {
                                byte[] avatarByte = await getAvatar(data[i]);
                                Image img = LoadImage(avatarByte);
                                ptbPlayer2.Image = img;
                                avatars.Add(img);
                            }
                        } else if (i == 2) {
                            lblPlayer3.Text = data[i];
                            if (data[i] == player.Username) {
                                indexPlayer = i + 1;
                                lblPlayer3.ForeColor = Color.Yellow;
                                ptbPlayer3.Image = avatar;
                                avatars.Add(avatar);
                            } else {
                                byte[] avatarByte = await getAvatar(data[i]);
                                Image img = LoadImage(avatarByte);
                                ptbPlayer3.Image = img;
                                avatars.Add(img);
                            }
                        } else {
                            lblPlayer4.Text = data[i];
                            if (data[i] == player.Username) {
                                indexPlayer = i + 1;
                                lblPlayer4.ForeColor = Color.Yellow;
                                ptbPlayer4.Image = avatar;
                                avatars.Add(avatar);
                            } else {
                                byte[] avatarByte = await getAvatar(data[i]);
                                Image img = LoadImage(avatarByte);
                                ptbPlayer4.Image = img;
                                avatars.Add(img);
                            }
                        }
                    }
                    //}));
                    break;
                case "IMAGE_QA":
                    Payload[1] += $":{Payload[2]}";
                    data = Payload[1].Split('*');
                    lblInfoCNV.Text = $"Chướng ngại vật gồm có {data[1]} ký tự";
                    AddText(1, $"Chướng ngại vật gồm có {data[1]} ký tự\r\n");
                    questionPicture.Load(data[0]);
                    break;
                case "QA":
                    string jsonData = mess.Substring(3);
                    Questions = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(jsonData);
                    ready = true;
                    QuestionArea.Invalidate();
                    break;
                case "TURN":
                    data = Payload[1].Split('-');
                    playerTurn = data[0];
                    turn = int.Parse(data[1]);
                    AddText(1, $"Lượt của người chơi {playerTurn}\r\n");
                    break;
                case "QUEST_R1":
                    OpenFormnQuestionRound1(int.Parse(Payload[1]));
                    break;
                case "QUEST_R1_FN":
                    OpenFormnQuestionRound1(int.Parse(Payload[1]));
                    SendData($"GET_POINT_FN:{roomCode}", client);
                    break;
                case "POINT":
                    data = Payload[1].Split('-');
                    for (int i = 0; i < data.Length; i++) {
                        Invoke(new MethodInvoker(delegate {
                            if (i == 0) {
                                lblPointPlayer1.Text = data[i];
                            } else if (i == 1) {
                                lblPointPlayer2.Text = data[i];
                            } else if (i == 2) {
                                lblPointPlayer3.Text = data[i];
                            } else {
                                lblPointPlayer4.Text = data[i];
                            }
                        }));
                    }
                    if (numGuess == 4) {
                        AddText(1, "5 giây cuối cùng trước khi câu hỏi số 5 xuất hiện!\r\n");
                        Invoke(new MethodInvoker(delegate {
                            countdownBonusTimer.Start();
                        }));
                    } else if (numGuess == 5) {
                        AddText(1, "5 giây suy nghĩ cuối cùng!\r\n");
                        Invoke(new MethodInvoker(delegate {
                            countdownFinalTimer.Start();
                        }));
                    }
                    break;
                case "BELL":
                    //Invoke(new MethodInvoker(delegate {
                    sound = new SoundPlayer(Properties.Resources.VCNC_Bell);
                    sound.Play();
                    isPress = true;
                    btnQuest1.Enabled = false;
                    btnQuest2.Enabled = false;
                    btnQuest3.Enabled = false;
                    btnQuest4.Enabled = false;
                    Bell.Enabled = false;
                    AddText(0, $"Người chơi {Payload[1]} đã nhấn chuông và có 7 giây để gõ câu " +
                        $"trả lời chướng ngại vật\r\n");
                    //}));
                    break;
                case "ANS_BELL":
                    data = Payload[1].Split('-');
                    AddText(0, $"Người chơi {data[0]} đã trả lời: {data[1]}\r\n");
                    break;
                case "REP_BELL":
                    //Invoke(new MethodInvoker(delegate {
                    data = Payload[1].Split('-');
                    if (data[0] == "0") {
                        isTerminated = true;
                        AddText(1, "Bạn đã bị loại!\r\n");
                        btnQuest1.Enabled = false;
                        btnQuest2.Enabled = false;
                        btnQuest3.Enabled = false;
                        btnQuest4.Enabled = false;
                        Bell.Enabled = false;
                        isPress = false;
                        remainPlayer--;
                        if (player.Username != playerTurn)
                            AddText(1, $"Lượt của người chơi {playerTurn}\r\n");
                        else {
                            if (numGuess < 4 && remainPlayer != 0)
                                SendData($"GET_TURN_FN:{roomCode}-{turn}", client);
                        }
                        if (remainPlayer == 0) {
                            AddText(1, "Không còn người chơi, vòng thi kết thúc\r\n");
                            SendData($"ANSWER_R1_FN:{roomCode}", client);
                        }
                    } else {
                        AddText(1, $"Đáp án chính xác, bạn nhận được {data[1]} điểm!\r\n");
                        FlipPic(data[2], data[3]);
                        NextRound();
                    }
                    //}));
                    break;
                case "REP_BELL_OTHER":
                    //Invoke(new MethodInvoker(delegate {
                    data = Payload[1].Split('-');
                    if (data[0] == "0") {
                        remainPlayer--;
                        isPress = false;
                        AddText(0, $"Không chính xác! Người chơi {data[1]} bị loại!\r\n");
                        btnAnswer.Enabled = true;
                        foreach (Button b in remainButton) {
                            b.Enabled = true;
                        }
                        if (!isTerminated)
                            Bell.Enabled = true;
                        if (remainPlayer == 0) {
                            AddText(1, "Không còn người chơi, vòng thi kết thúc\r\n");
                            SendData($"ANSWER_R1_FN:{roomCode}", client);
                        } else {
                            if (data[1] == playerTurn) {
                                SendData($"GET_TURN_FN:{roomCode}-{turn}", client);
                            } else {
                                if (numGuess < 4)
                                    AddText(1, $"Lượt của người chơi {playerTurn}\r\n");
                            }
                        }
                    } else {
                        AddText(0, $"Chính xác! Người chơi {data[1]} nhận được {data[2]} điểm\r\n");
                        FlipPic(data[3], data[4]);
                        NextRound();
                    }
                    //}));
                    break;
                case "POINT_CNV":
                    //Invoke(new MethodInvoker(delegate {
                    data = Payload[1].Split('-');
                    if (data[0] == "1") {
                        lblPointPlayer1.Text = data[1];
                    } else if (data[0] == "2") {
                        lblPointPlayer2.Text = data[1];
                    } else if (data[0] == "3") {
                        lblPointPlayer3.Text = data[1];
                    } else {
                        lblPointPlayer4.Text = data[1];
                    }
                    //}));
                    break;
                case "ANSWER_R1_FN":
                    data = Payload[1].Split('-');
                    FlipPic(data[0], data[1]);
                    NextRound();
                    break;
            }
        }

        private void NextRound() {
            Invoke(new MethodInvoker(delegate {
                btnQuest1.Enabled = false;
                btnQuest2.Enabled = false;
                btnQuest3.Enabled = false;
                btnQuest4.Enabled = false;
                Bell.Enabled = false;
                Thread.Sleep(5000);
                InfoRound info = new InfoRound();
                info.round = 2;
                info.client = client;
                info.roomCode = roomCode;
                info.player = player;
                info.image = avatar;
                info.players = players;
                info.avatars = avatars;
                info.Show();
                Close();
            }));
        }

        private void FlipPic(string cnv, string note) {
            //Invoke(new MethodInvoker(delegate {
            sound = new SoundPlayer(Properties.Resources.VCNV_True);
            sound.Play();
            lblInfoCNV.Text = cnv;
            Invoke(new MethodInvoker(delegate {
                lblAns.Text = note;
                lblAns.Visible = true;
            }));
            coverPicture1.Visible = false;
            coverPicture2.Visible = false;
            coverPicture3.Visible = false;
            coverPicture4.Visible = false;
            coverPicture5.Visible = false;
            lblPic1.Visible = false;
            lblPic2.Visible = false;
            lblPic3.Visible = false;
            lblPic4.Visible = false;
            lblPic5.Visible = false;
            //}));
        }

        private void AddText(int select, string text) {
            if (InvokeRequired) {
                Invoke(new Action<int, string>(AddText), select, text);
                return;
            }
            if (select == 0) {
                rtbGuide.AppendText(text);
            } else {
                rtbGuide.Text = text;
            }
        }

        private string GetQuestion(int number) {
            List<string> qkeys = Questions.Keys.ToList();
            var quest = Questions[qkeys[number]];
            return number + "*" + qkeys[number] + "*" + quest[0];
        }

        private void SendData(string message, TcpClient client) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(100);
        }

        private void Round1_FormClosing(object sender, FormClosingEventArgs e) {
            sound.Stop();
            if (receive.IsAlive)
                receive.Abort();
        }

        private void OpenFormnQuestionRound1(int number) {
            //Invoke(new MethodInvoker(delegate {
            if (number == 0) {
                btnQuest1.Enabled = false;
                remainButton.Remove(btnQuest1);
            } else if (number == 1) {
                btnQuest2.Enabled = false;
                remainButton.Remove(btnQuest2);
            } else if (number == 2) {
                btnQuest3.Enabled = false;
                remainButton.Remove(btnQuest3);
            } else if (number == 3) {
                btnQuest4.Enabled = false;
                remainButton.Remove(btnQuest4);
            }
            QuestionRound1 form = new QuestionRound1();
            form.data = GetQuestion(number);
            form.client = client;
            form.roomCode = roomCode;
            form.player = player;
            form.isTerminated = isTerminated;
            Visible = false;
            form.WindowState = FormWindowState.Normal;
            form.Activate();
            form.ShowDialog();
            if (form.IsQuestDone()) {
                suspendEvent.Reset();
                Answer show = new Answer();
                show.client = client;
                show.roomCode = roomCode;
                show.round = 1;
                show.WindowState = FormWindowState.Normal;
                show.Activate();
                show.ShowDialog();
                numGuess++;
                if (show.IsGetPic()) {
                    sound = new SoundPlayer(Properties.Resources.VNCV_OpenAns);
                    sound.Play();
                    ShowPicAndDrawAns(number, show.GetAnswer());
                } else {
                    sound = new SoundPlayer(Properties.Resources.VCNV_False);
                    sound.Play();
                    IgnoreAnswer(number);
                }
                suspendEvent.Set();
            }
            //}));
        }

        private void ShowPicAndDrawAns(int number, string ans) {
            answer = ans;
            num = number;
            draw = true;
            ignore = false;
            if (number == 0) {
                coverPicture1.Visible = false;
                lblPic1.Visible = false;
            } else if (number == 1) {
                coverPicture2.Visible = false;
                lblPic2.Visible = false;
            } else if (number == 2) {
                coverPicture3.Visible = false;
                lblPic3.Visible = false;
            } else if (number == 3) {
                coverPicture4.Visible = false;
                lblPic4.Visible = false;
            } else {
                coverPicture5.Visible = false;
                lblPic5.Visible = false;
                draw = false;
            }
            QuestionArea.Invalidate();
        }

        private void IgnoreAnswer(int number) {
            num = number;
            ignore = true;
            draw = false;
            if (number == 4)
                ignore = false;
            QuestionArea.Invalidate();
        }

        private void btnQuest1_Click(object sender, EventArgs e) {
            if (playerTurn != player.Username) {
                AddText(0, "Chưa tới lượt!\r\n");
            } else {
                sound = new SoundPlayer(Properties.Resources.VCNV_Select);
                sound.Play();
                SendData($"QUEST_R1:{roomCode}-0", client);
                OpenFormnQuestionRound1(0);
                SendData($"GET_POINT:{roomCode}", client);
                Thread.Sleep(1000);
                if (numGuess < 4) {
                    SendData($"GET_TURN:{roomCode}-{turn}", client);
                }
            }
        }

        private void btnQuest2_Click(object sender, EventArgs e) {
            if (playerTurn != player.Username) {
                AddText(0, "Chưa tới lượt!\r\n");
            } else {
                sound = new SoundPlayer(Properties.Resources.VCNV_Select);
                sound.Play();
                SendData($"QUEST_R1:{roomCode}-1", client);
                OpenFormnQuestionRound1(1);
                SendData($"GET_POINT:{roomCode}", client);
                Thread.Sleep(1000);
                if (numGuess < 4) {
                    SendData($"GET_TURN:{roomCode}-{turn}", client);
                }
            }
        }

        private void btnQuest3_Click(object sender, EventArgs e) {
            if (playerTurn != player.Username) {
                AddText(0, "Chưa tới lượt!\r\n");
            } else {
                sound = new SoundPlayer(Properties.Resources.VCNV_Select);
                sound.Play();
                SendData($"QUEST_R1:{roomCode}-2", client);
                OpenFormnQuestionRound1(2);
                SendData($"GET_POINT:{roomCode}", client);
                Thread.Sleep(1000);
                if (numGuess < 4) {
                    SendData($"GET_TURN:{roomCode}-{turn}", client);
                }
            }
        }

        private void btnQuest4_Click(object sender, EventArgs e) {
            if (playerTurn != player.Username) {
                AddText(0, "Chưa tới lượt!\r\n");
            } else {
                sound = new SoundPlayer(Properties.Resources.VCNV_Select);
                sound.Play();
                SendData($"QUEST_R1:{roomCode}-3", client);
                OpenFormnQuestionRound1(3);
                SendData($"GET_POINT:{roomCode}", client);
                Thread.Sleep(1000);
                if (numGuess < 4) {
                    SendData($"GET_TURN:{roomCode}-{turn}", client);
                }
            }
        }

        private void QuestionArea_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            List<string> cmd = new List<string>();
            float x = 0, y = 0;
            if (graphics.Count != 0) {
                DrawGraphics(graphics, g);
            }
            if (ready) {
                List<string> qkeys = Questions.Keys.ToList();
                List<int> quest;
                for (int i = 0; i < 4; i++) {
                    quest = Questions[qkeys[i]];
                    x = 40 + ((15 - quest[0]) / 2 + quest[1]) * 40;
                    for (int j = 0; j < quest[0]; j++) {
                        using (SolidBrush brush = new SolidBrush(Color.Blue)) {
                            if (i == 0) {
                                y = btnQuest1.Location.Y;
                            } else if (i == 1) {
                                y = btnQuest2.Location.Y;
                            } else if (i == 2) {
                                y = btnQuest3.Location.Y;
                            } else {
                                y = btnQuest4.Location.Y;
                            }
                            g.FillEllipse(brush, x, y, 35, 35);
                        }
                        cmd = new List<string> {
                           "0", "Blue", x.ToString(), y.ToString()
                        };
                        graphics.Add(cmd);
                        x += 40;
                    }
                }
                ready = false;
            }
            if (draw) {
                List<string> qkeys = Questions.Keys.ToList();
                List<int> quest = Questions[qkeys[num]];
                x = 40 + ((15 - quest[0]) / 2 + quest[1]) * 40;
                answer = answer.Replace(" ", "").ToUpper();
                for (int j = 0; j < quest[0]; j++) {
                    using (Font font = new Font("Arial", 18, FontStyle.Bold)) {
                        SizeF textSize = g.MeasureString(answer[j].ToString(), font);
                        PointF location = new PointF();
                        location.X = x + (35 - textSize.Width) / 2;
                        if (num == 0) {
                            location.Y = btnQuest1.Location.Y + (35 - textSize.Height) / 2;
                        } else if (num == 1) {
                            location.Y = btnQuest2.Location.Y + (35 - textSize.Height) / 2;
                        } else if (num == 2) {
                            location.Y = btnQuest3.Location.Y + (35 - textSize.Height) / 2;
                        } else {
                            location.Y = btnQuest4.Location.Y + (35 - textSize.Height) / 2;
                        }
                        g.DrawString(answer[j].ToString(), font, Brushes.White, location);
                        cmd = new List<string> {
                               "1", "White", answer[j].ToString(), location.X.ToString(), location.Y.ToString()
                        };
                    }
                    graphics.Add(cmd);
                    x += 40;
                }
            }
            if (ignore) {
                List<string> qkeys = Questions.Keys.ToList();
                List<int> quest = Questions[qkeys[num]];
                x = 40 + ((15 - quest[0]) / 2 + quest[1]) * 40;
                for (int j = 0; j < quest[0]; j++) {
                    using (SolidBrush brush = new SolidBrush(Color.Gray)) {
                        if (num == 0) {
                            y = btnQuest1.Location.Y;
                        } else if (num == 1) {
                            y = btnQuest2.Location.Y;
                        } else if (num == 2) {
                            y = btnQuest3.Location.Y;
                        } else {
                            y = btnQuest4.Location.Y;
                        }
                        g.FillEllipse(brush, x, y, 35, 35);
                    }
                    cmd = new List<string> {
                        "0", "Gray", x.ToString(), y.ToString()
                    };
                    graphics.Add(cmd);
                    x += 40;
                }
            }
        }

        private void DrawGraphics(List<List<string>> list, Graphics g) {
            Color color = Color.White;
            foreach (var item in list) {
                color = Color.FromName(item[1]);
                if (item[0] == "0") {
                    using (SolidBrush brush = new SolidBrush(color)) {
                        g.FillEllipse(brush, float.Parse(item[2]), float.Parse(item[3]), 35, 35);
                    }
                } else {
                    using (SolidBrush brush = new SolidBrush(color)) {
                        using (Font font = new Font("Arial", 18, FontStyle.Bold)) {
                            g.DrawString(item[2], font, brush, float.Parse(item[3]), float.Parse(item[4]));
                        }
                    }
                }
            }
        }

        private void Guide_Click(object sender, EventArgs e) {
            InstructionRound1 form = new InstructionRound1();
            form.Show();
        }

        private void Bell_Click(object sender, EventArgs e) {
            sound = new SoundPlayer(Properties.Resources.VCNC_Bell);
            sound.Play();
            tbAnswer.Visible = true;
            btnAnswer.Visible = true;
            btnQuest1.Enabled = false;
            btnQuest2.Enabled = false;
            btnQuest3.Enabled = false;
            btnQuest4.Enabled = false;
            Bell.Enabled = false;
            isPress = true;
            AddText(1, $"Bạn có 7 giây để gõ câu trả lời chướng ngại vật\r\n");
            SendData($"BELL:{roomCode}-{player.Username}", client);
            countdownTimer.Start();
        }

        private void countdownTimer_Tick(object sender, EventArgs e) {
            if (timeLeft.TotalSeconds > 0) {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
            } else {
                countdownTimer.Stop();
                tbAnswer.Visible = false;
                Bell.Enabled = false;
                if (!isAnswer)
                    SendData($"ANS_BELL:{roomCode}-{player.Username}--{numGuess}", client);
            }
        }

        private void countdownBonusTimer_Tick(object sender, EventArgs e) {
            if (bonusTimeLeft.TotalSeconds > 0) {
                if (!isPress) {
                    bonusTimeLeft = bonusTimeLeft.Subtract(TimeSpan.FromSeconds(1));
                }
            } else {
                countdownBonusTimer.Stop();
                AddText(0, "Đã hết 5 giây, bây giờ là câu hỏi gợi ý cuối cùng\r\n");
                SendData($"QUEST_R1_FN:{roomCode}-4", client);
            }
        }

        private void countdownFinalTimer_Tick(object sender, EventArgs e) {
            if (finalTimeLeft.TotalSeconds > 0) {
                if (!isPress) {
                    finalTimeLeft = finalTimeLeft.Subtract(TimeSpan.FromSeconds(1));
                }
            } else {
                countdownFinalTimer.Stop();
                AddText(0, "Đã hết 5 giây cuối cùng, không ai trả lời được chướng ngại vật\r\n");
                SendData($"ANSWER_R1_FN:{roomCode}", client);
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e) {
            if (tbAnswer.Text != "") {
                isAnswer = true;
                SendData($"ANS_BELL:{roomCode}-{player.Username}-{tbAnswer.Text}-{numGuess}", client);
                btnAnswer.Visible = false;
            }
        }
    }
}

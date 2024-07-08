using MinigameOlympia.Models;
using MinigameOlympia;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class PhongCho : Form {
        public Player player;
        public Image image;
        public string roomCode;
        public bool isAdmin = true;
        public TcpClient client;
        private Thread receive;
        private int numConnection = 0;
        public List<List<Player>> friendList;
        private PictureBox addButton;
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();

        public PhongCho() {
            InitializeComponent();
            countdownTimer.Interval = 5000;
            countdownTimer.Tick += countdownTimer_Tick;
        }

        private void countdownTimer_Tick(object sender, EventArgs e) {
            countdownTimer.Stop();
            addButton.Enabled = true;
        }

        private void PhongCho_Load(object sender, EventArgs e) {
            lblRoomCode.Text = roomCode;
            if (!isAdmin)
                BtnStart.Visible = false;
            else {
                lblPlayer1.Text = player.Username;
                lblPlayer1.ForeColor = Color.Yellow;
                ptbPlayer1.Image = image;
            }
            LoadFriendList();
            Connect();
            SendData("CONNECT:" + lblRoomCode.Text + "-" + player.Username, client);
            PostMatch();
        }

        private void LoadFriendList() {
            if (friendList != null && friendList[0] != null) {
                friendList[0].Sort((p1, p2) => p2.WinCount.CompareTo(p1.WinCount));
                int y = 0;
                for (int i = 0; i < friendList[0].Count; i++) {
                    Panel pn = new Panel() {
                        Location = new Point(0, y),
                        BorderStyle = BorderStyle.Fixed3D,
                        Size = new Size(233, 81)
                    };
                    pnFriend.Controls.Add(pn);
                    PictureBox ptb1 = new PictureBox() {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = Properties.Resources.add,
                        Location = new Point(190, 45),
                        BorderStyle = BorderStyle.None,
                        Size = new Size(22, 22),
                        Cursor = Cursors.Hand,
                        Tag = i
                    };
                    ptb1.Click += Add_Player;
                    pn.Controls.Add(ptb1);
                    PictureBox ptb2 = new PictureBox() {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = LoadImage(friendList[0][i].Avatar),
                        Dock = DockStyle.Left,
                        BorderStyle = BorderStyle.Fixed3D,
                        Size = new Size(81, 81),
                        Cursor = Cursors.Hand,
                        Tag = i
                    };
                    ptb2.Click += Information;
                    pn.Controls.Add(ptb2);
                    Label lb = new Label() {
                        AutoSize = true,
                        Location = new Point(95, 14),
                        Text = friendList[0][i].Username,
                        Font = new Font("Microsoft Sans Serif", 12F),
                        ForeColor = Color.White
                    };
                    pn.Controls.Add(lb);
                    y += 81;
                }
            }
        }

        private void Add_Player(object sender, EventArgs e) {
            PictureBox ptb = (PictureBox)sender;
            Player p = friendList[0][int.Parse(ptb.Tag.ToString())];
            addButton = ptb;
            ptb.Enabled = false;
            SendData($"INVITE:{roomCode}-{p.Username}-{player.Username}", client);
            countdownTimer.Start();
        }

        private void Information(object sender, EventArgs e) {
            PictureBox ptb = (PictureBox)sender;
            Player p = friendList[0][int.Parse(ptb.Tag.ToString())];
            HoSoNV profile = new HoSoNV();
            profile.self = player.Username;
            profile.player = p;
            profile.image = ptb.Image;
            profile.ShowDialog();
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
                    ((GiaoDienChinh)form).suspendEvent.Set();
                    break;
                }
            }
            SendData("DISCONNECT:" + roomCode + "-" + player.Username, client);
            Thread.Sleep(1000);
            Close();
        }

        private void Connect() {
            //client = new TcpClient("127.0.0.1", 12345);
            receive = new Thread(() => ReceiveMessage(client));
            receive.IsBackground = true;
            receive.Start();
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
                case "REP_INVITE":
                    if (Payload[1] == "0") {
                        MessageBox.Show("Người chơi này chưa online!");
                    } else if (Payload[1] == "1") {
                        MessageBox.Show("Người chơi này đã vào phòng khác!");
                    } else if (Payload[1] == "2") {
                        MessageBox.Show("Người chơi đã từ chối tham gia phòng!");
                    } else {
                        MessageBox.Show("Người chơi đã đồng ý vào phòng!");
                    }
                    break;
                case "INFO_CON":
                    string[] data = Payload[1].Split('-');
                    roomCode = data[0];
                    numConnection = int.Parse(data[1]);
                    byte[] avatarByte = await getAvatar(data[2]);
                    int i = 0;
                    foreach (Control c in panelMain.Controls) {
                        if (c is Label) {
                            Label l = (Label)c;
                            if (l.Tag.ToString() == data[3]) {
                                i++;
                                if (data[2] == player.Username) {
                                    if (!isAdmin) {
                                        l.Text = player.Username;
                                        l.ForeColor = Color.Yellow;
                                        lblRoomCode.Text = roomCode;
                                    }
                                } else {
                                    l.Text = data[2];
                                    l.ForeColor = Color.White;
                                }
                            }
                        } else if (c is PictureBox) {
                            PictureBox p = (PictureBox)c;
                            if (p.Tag.ToString() == data[3]) {
                                i++;
                                if (data[2] == player.Username) {
                                    if (!isAdmin) {
                                        p.Image = image;
                                    }
                                } else
                                    p.Image = LoadImage(avatarByte);
                            }
                        }
                        if (i == 2)
                            break;
                    }
                    break;
                case "INFO_DISCON":
                    RestoreDefault();
                    var list = JsonConvert.DeserializeObject<List<string>>(Payload[1]);
                    foreach (var item in list) {
                        data = item.Split('-');
                        numConnection = int.Parse(data[1]);
                        if (numConnection == 1) {
                            if (InvokeRequired) {
                                Invoke(new MethodInvoker(delegate {
                                    BtnStart.Visible = true;
                                }));
                            } else {
                                BtnStart.Visible = true;
                            }
                        }
                        avatarByte = await getAvatar(data[2]);
                        i = 0;
                        foreach (Control c in panelMain.Controls) {
                            Invoke(new MethodInvoker(delegate {
                                if (c is Label) {
                                    Label l = (Label)c;
                                    if (l.Tag.ToString() == data[3]) {
                                        i++;
                                        if (data[2] == player.Username) {
                                            l.Text = player.Username;
                                            l.ForeColor = Color.Yellow;
                                        } else {
                                            l.Text = data[2];
                                            l.ForeColor = Color.White;
                                        }
                                    }
                                } else if (c is PictureBox) {
                                    PictureBox p = (PictureBox)c;
                                    if (p.Tag.ToString() == data[3]) {
                                        i++;
                                        if (data[2] == player.Username)
                                            p.Image = image;
                                        else
                                            p.Image = LoadImage(avatarByte);
                                    }
                                }
                            }));
                            if (i == 2)
                                break;
                        }
                    }
                    break;
                case "START":
                    roomCode = Payload[1];
                    //if (InvokeRequired) {
                    Invoke(new MethodInvoker(delegate {
                        InfoRound info = new InfoRound();
                        info.round = 1;
                        info.client = client;
                        info.roomCode = roomCode;
                        info.player = player;
                        info.image = image;
                        info.Show();
                        Close();
                    }));
                    //}
                    break;
                case "SYNC":
                    SendData("FIND:" + roomCode + "-" + player.Username, client);
                    lblInfo.Visible = true;
                    break;
            }
        }

        private async void PostMatch() {
            using (HttpClient httpClient = new HttpClient()) {
                try {
                    string url = "https://olympiawebservice.azurewebsites.net/api/Match?idPlayer=" + player.IDPlayer + "&idRoom=" + lblRoomCode.Text;
                    await httpClient.PostAsync(url, null);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PhongCho_FormClosing(object sender, FormClosingEventArgs e) {
            if (receive.IsAlive)
                receive.Abort();
        }

        private void BtnStart_Click(object sender, EventArgs e) {
            if (numConnection == 4) {
                SendData("START:" + roomCode, client);
                InfoRound info = new InfoRound();
                info.round = 1;
                info.client = client;
                info.roomCode = roomCode;
                info.player = player;
                info.image = image;
                info.Show();
                Close();
            } else {
                SendData("CONNECT_MATCH:" + roomCode, client);
                SendData("FIND:" + roomCode + "-" + player.Username, client);
                lblInfo.Visible = true;
            }
        }
    }
}

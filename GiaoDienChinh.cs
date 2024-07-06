using MinigameOlympia.Models;
using MinigameOlympia;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using static System.Net.WebRequestMethods;

namespace MinigameOlympia {
    public partial class GiaoDienChinh : Form {
        public string username;
        public Image image;
        public Player player;
        public string roomCode = "";
        public ManualResetEvent suspendEvent = new ManualResetEvent(true);
        private List<List<Player>> friendList = null;
        private List<Player> players = new List<Player>();
        private Player findPlayer = null;
        private List<Player> requestPlayer = new List<Player>();
        private TcpClient tcpClient;
        private Thread receive;

        public GiaoDienChinh() {
            InitializeComponent();
        }

        private void Connect() {
            tcpClient = new TcpClient("0.tcp.ap.ngrok.io", 15965);
            receive = new Thread(() => ReceiveMessage(tcpClient));
            receive.IsBackground = true;
            receive.Start();
        }

        private void SendData(string message, TcpClient client) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            Thread.Sleep(100);
        }

        private void ReceiveMessage(TcpClient tcpClient) {
            while (true) {
                suspendEvent.WaitOne();
                if (tcpClient == null || !tcpClient.Connected)
                    continue;
                else {
                    if (tcpClient.Available > 0) {
                        string message = "";
                        while (tcpClient.Available > 0) {
                            byte[] buffer = new byte[1024];
                            try {
                                NetworkStream stream = tcpClient.GetStream();
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
                case "INVITE":
                    string[] data = Payload[1].Split('-');
                    DialogResult result = MessageBox.Show($"Người chơi {data[1]} mời bạn vào phòng {data[0]}. " +
                        $"Đồng ý tham gia không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) {
                        suspendEvent.Reset();
                        SendData($"REP_INVITE:1-{data[1]}", tcpClient);
                        Invoke(new MethodInvoker(delegate {
                            PhongCho room = new PhongCho();
                            room.player = player;
                            room.image = image;
                            room.friendList = friendList;
                            room.client = tcpClient;
                            room.roomCode = data[0];
                            room.isAdmin = false;
                            room.Show();
                            Visible = false;
                        }));
                    } else if (result == DialogResult.No) {
                        SendData($"REP_INVITE:0-{data[1]}", tcpClient);
                    }
                    break;
            }
        }

        private void ptbAvatar_Click(object sender, EventArgs e) {
            HoSoNV profile = new HoSoNV();
            profile.self = username;
            profile.player = player;
            profile.image = image;
            profile.ShowDialog();
        }

        private async Task<Player> getPlayerAsync(string username) {
            player = null;
            HttpClient client = new HttpClient();
            try {
                string url = "https://olympiawebservice.azurewebsites.net/api/Player/username?lookup=" + username;
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    player = JsonConvert.DeserializeObject<Player>(jsonContent);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return player;
        }

        private async Task getAvatar() {
            await getPlayerAsync(username);

            byte[] imgData = player.Avatar;
            using (MemoryStream ms = new MemoryStream(imgData)) {
                image = Image.FromStream(ms);
                ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                ptbAvatar.Image = image;
            }
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

        private void btnEnter_Click(object sender, EventArgs e) {
            TypeCode tc = new TypeCode();
            tc.player = player;
            tc.image = image;
            tc.friendList = friendList;
            tc.client = tcpClient;
            tc.ShowDialog();
            if (tc.getIsExit()) {
                suspendEvent.Reset();
                Visible = false;
            }
        }

        private async Task getFriend() {
            await getAvatar();
            HttpClient client = new HttpClient();
            try {
                string url = "https://olympiawebservice.azurewebsites.net/api/Player/Friend/id?lookup=" + player.IDPlayer;
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    friendList = JsonConvert.DeserializeObject<List<List<Player>>>(jsonContent);
                    if (friendList[0].Count != 0) {
                        pnFriendList.Visible = true;
                    } else {
                        friendList[0] = null;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task GetAllPlayer() {
            HttpClient client = new HttpClient();
            try {
                string url = "https://olympiawebservice.azurewebsites.net/api/Player";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    players = JsonConvert.DeserializeObject<List<Player>>(jsonContent);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task SortPlayer() {
            await GetAllPlayer();
            players.Sort((p1, p2) => p2.WinCount.CompareTo(p1.WinCount));
        }

        private async Task SortFriend() {
            await getFriend();
            if (friendList[0] != null)
                friendList[0].Sort((p1, p2) => p2.WinCount.CompareTo(p1.WinCount));
        }

        private async void LoadRank() {
            Cursor = Cursors.WaitCursor;
            pnRank.Controls.Clear();
            await SortPlayer();
            int y = 0;
            for (int i = 0; i < players.Count; i++) {
                Panel pn = new Panel() {
                    Location = new Point(0, y),
                    BorderStyle = BorderStyle.Fixed3D,
                    Size = new Size(233, 81)
                };
                if (players[i].Username.ToUpper() == username.ToUpper())
                    pn.BackColor = Color.Green;
                pnRank.Controls.Add(pn);
                PictureBox ptb = new PictureBox() {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = LoadImage(players[i].Avatar),
                    Dock = DockStyle.Left,
                    BorderStyle = BorderStyle.Fixed3D,
                    Size = new Size(81, 81),
                    Cursor = Cursors.Hand,
                    Tag = i
                };
                ptb.Click += Information_All;
                pn.Controls.Add(ptb);
                Label lb1 = new Label() {
                    AutoSize = true,
                    Location = new Point(95, 14),
                    Text = players[i].Username,
                    Font = new Font("Microsoft Sans Serif", 12F),
                    ForeColor = Color.White
                };
                pn.Controls.Add(lb1);
                Label lb2 = new Label() {
                    AutoSize = true,
                    Location = new Point(95, 43),
                    Text = players[i].WinCount.ToString(),
                    Font = new Font("Microsoft Sans Serif", 12F),
                    ForeColor = Color.White
                };
                pn.Controls.Add(lb2);
                y += 81;
            }
            Cursor = Cursors.Default;
        }

        private async void GiaoDienChinh_Load(object sender, EventArgs e) {
            Connect();
            Cursor = Cursors.WaitCursor;
            btnCreateRoom.Enabled = false;
            btnEnter.Enabled = false;
            LoadRank();
            await SortFriend();
            SendData("ONLINE:" + player.Username, tcpClient);
            if (friendList.Count == 1 && friendList[0] != null) {
                for (int i = 0; i < friendList[0].Count; i++) {
                    PictureBox ptb = new PictureBox() {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = LoadImage(friendList[0][i].Avatar),
                        Dock = DockStyle.Top,
                        BorderStyle = BorderStyle.Fixed3D,
                        Size = new Size(81, 81),
                        Cursor = Cursors.Hand,
                        Tag = i
                    };
                    ptb.Click += Information;
                    pnFriendList.Controls.Add(ptb);
                }
            }
            btnCreateRoom.Enabled = true;
            btnEnter.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e) {
            SendData("OFFLINE:" + username, tcpClient);
            foreach (Form form in Application.OpenForms) {
                if (form.Name == "RootForm") {
                    form.Visible = true;
                    break;
                }
            }
            tcpClient.Close();
            Close();
        }

        private void Information(object sender, EventArgs e) {
            PictureBox ptb = (PictureBox)sender;
            Player p = friendList[0][int.Parse(ptb.Tag.ToString())];
            HoSoNV profile = new HoSoNV();
            profile.self = username;
            profile.player = p;
            profile.image = ptb.Image;
            profile.ShowDialog();
        }

        private void Information_All(object sender, EventArgs e) {
            PictureBox ptb = (PictureBox)sender;
            Player p = players[int.Parse(ptb.Tag.ToString())];
            HoSoNV profile = new HoSoNV();
            profile.self = username;
            profile.player = p;
            profile.image = ptb.Image;
            profile.ShowDialog();
        }

        private void Information_Find(object sender, EventArgs e) {
            PictureBox ptb = (PictureBox)sender;
            HoSoNV profile = new HoSoNV();
            profile.self = username;
            profile.player = findPlayer;
            profile.image = ptb.Image;
            profile.ShowDialog();
        }

        private void Information_Request(object sender, EventArgs e) {
            PictureBox ptb = (PictureBox)sender;
            Player p = requestPlayer[int.Parse(ptb.Tag.ToString())];
            HoSoNV profile = new HoSoNV();
            profile.self = username;
            profile.player = p;
            profile.image = ptb.Image;
            profile.ShowDialog();
        }

        private async void btnCreateRoom_Click(object sender, EventArgs e) {
            suspendEvent.Reset();
            PhongCho room = new PhongCho();
            room.player = player;
            room.image = image;
            room.friendList = friendList;
            room.client = tcpClient;
            await CreateRoomCode();
            room.roomCode = roomCode;
            room.Show();
            Visible = false;
        }

        private async Task CreateRoomCode() {
            Random random = new Random();
            HttpClient client = new HttpClient();
            try {
                string url = "https://olympiawebservice.azurewebsites.net/api/Room";
                var response = await client.PostAsync(url, null);
                if (response.IsSuccessStatusCode) {
                    var res = await response.Content.ReadAsStringAsync();
                    JObject keyValuePairs = JObject.Parse(res);
                    JToken roomRes = keyValuePairs["idRoom"];
                    roomCode = roomRes.Value<string>();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuide_Click(object sender, EventArgs e) {
            GuideScreen screen = new GuideScreen();
            Visible = false;
            screen.Show();
        }

        private void LoadFind() {
            if (findPlayer != null) {
                Panel pn = new Panel() {
                    Location = new Point(0, 0),
                    BorderStyle = BorderStyle.Fixed3D,
                    Size = new Size(233, 81)
                };
                pnResultFind.Controls.Add(pn);
                if (findPlayer.Username != username) {
                    PictureBox ptb1 = new PictureBox() {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = Properties.Resources.add,
                        Location = new Point(190, 45),
                        BorderStyle = BorderStyle.None,
                        Size = new Size(22, 22),
                        Cursor = Cursors.Hand,
                    };
                    ptb1.Click += Add_Friend;
                    pn.Controls.Add(ptb1);
                }
                PictureBox ptb2 = new PictureBox() {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = LoadImage(findPlayer.Avatar),
                    Dock = DockStyle.Left,
                    BorderStyle = BorderStyle.Fixed3D,
                    Size = new Size(81, 81),
                    Cursor = Cursors.Hand,
                };
                ptb2.Click += Information_Find;
                pn.Controls.Add(ptb2);
                Label lb1 = new Label() {
                    AutoSize = true,
                    Location = new Point(95, 14),
                    Text = findPlayer.Username,
                    Font = new Font("Microsoft Sans Serif", 12F),
                    ForeColor = Color.White
                };
                pn.Controls.Add(lb1);
                Label lb2 = new Label() {
                    AutoSize = true,
                    Location = new Point(95, 43),
                    Text = findPlayer.WinCount.ToString(),
                    Font = new Font("Microsoft Sans Serif", 12F),
                    ForeColor = Color.White
                };
                pn.Controls.Add(lb2);
            }
        }

        private async void Add_Friend(object sender, EventArgs e) {
            ((PictureBox)sender).Enabled = false;
            using (HttpClient client = new HttpClient()) {
                try {
                    string url = $"https://olympiawebservice.azurewebsites.net/api/Friend?idPlayer={player.IDPlayer}&idFriend={findPlayer.IDPlayer}";
                    await client.PostAsync(url, null);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void btnFind_Click(object sender, EventArgs e) {
            pnResultFind.Controls.Clear();
            if (tbFind.Text != "") {
                Cursor = Cursors.WaitCursor;
                using (HttpClient client = new HttpClient()) {
                    try {
                        string url = $"https://olympiawebservice.azurewebsites.net/api/Player/username?lookup={tbFind.Text}";
                        var response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode) {
                            var res = await response.Content.ReadAsStringAsync();
                            findPlayer = JsonConvert.DeserializeObject<Player>(res);
                            if (findPlayer == null) {
                                try {
                                    url = $"https://olympiawebservice.azurewebsites.net/api/Player/id?lookup={tbFind.Text}";
                                    response = await client.GetAsync(url);
                                    if (response.IsSuccessStatusCode) {
                                        res = await response.Content.ReadAsStringAsync();
                                        findPlayer = JsonConvert.DeserializeObject<Player>(res);
                                    }
                                } catch (Exception ex) {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            LoadFind();
                        }
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private async void LoadRequest() {
            pnRequest.Controls.Clear();
            Cursor = Cursors.WaitCursor;
            using (HttpClient client = new HttpClient()) {
                try {
                    string url = $"https://olympiawebservice.azurewebsites.net/api/Friend/Request/{player.IDPlayer}";
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode) {
                        var res = await response.Content.ReadAsStringAsync();
                        requestPlayer = JsonConvert.DeserializeObject<List<Player>>(res);
                        if (requestPlayer.Count != 0) {
                            int y = 0;
                            for (int i = 0; i < requestPlayer.Count; i++) {
                                Panel pn = new Panel() {
                                    Location = new Point(0, y),
                                    BorderStyle = BorderStyle.Fixed3D,
                                    Size = new Size(233, 81)
                                };
                                pnRequest.Controls.Add(pn);
                                PictureBox ptb1 = new PictureBox() {
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    Image = Properties.Resources.Cross,
                                    Location = new Point(168, 45),
                                    BorderStyle = BorderStyle.None,
                                    Size = new Size(22, 22),
                                    Tag = i,
                                    Cursor = Cursors.Hand,
                                };
                                ptb1.Click += UnacceptFriend;
                                pn.Controls.Add(ptb1);
                                PictureBox ptb2 = new PictureBox() {
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    Image = Properties.Resources.Tick,
                                    Location = new Point(190, 45),
                                    BorderStyle = BorderStyle.None,
                                    Size = new Size(22, 22),
                                    Tag = i,
                                    Cursor = Cursors.Hand,
                                };
                                ptb2.Click += AcceptFriend;
                                pn.Controls.Add(ptb2);
                                PictureBox ptb3 = new PictureBox() {
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    Image = LoadImage(requestPlayer[i].Avatar),
                                    Dock = DockStyle.Left,
                                    BorderStyle = BorderStyle.Fixed3D,
                                    Size = new Size(81, 81),
                                    Tag = i,
                                    Cursor = Cursors.Hand,
                                };
                                ptb3.Click += Information_Request;
                                pn.Controls.Add(ptb3);
                                Label lb1 = new Label() {
                                    AutoSize = true,
                                    Location = new Point(95, 14),
                                    Text = requestPlayer[i].Username,
                                    Font = new Font("Microsoft Sans Serif", 12F),
                                    ForeColor = Color.White
                                };
                                pn.Controls.Add(lb1);
                                Label lb2 = new Label() {
                                    AutoSize = true,
                                    Location = new Point(95, 43),
                                    Text = requestPlayer[i].WinCount.ToString(),
                                    Font = new Font("Microsoft Sans Serif", 12F),
                                    ForeColor = Color.White
                                };
                                pn.Controls.Add(lb2);
                                y += 81;
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            Cursor = Cursors.Default;
        }

        private async void AcceptFriend(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            PictureBox ptb = (PictureBox)sender;
            Panel pn = (Panel)ptb.Parent;
            Player p = requestPlayer[int.Parse(ptb.Tag.ToString())];
            using (HttpClient client = new HttpClient()) {
                try {
                    string url = $"https://olympiawebservice.azurewebsites.net/api/Friend?idPlayer={player.IDPlayer}&idFriend={p.IDPlayer}";
                    var response = await client.PutAsync(url, null);
                    if (response.IsSuccessStatusCode) {
                        pn.Enabled = false;
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            Cursor = Cursors.Default;
        }

        private async void UnacceptFriend(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            PictureBox ptb = (PictureBox)sender;
            Panel pn = (Panel)ptb.Parent;
            Player p = requestPlayer[int.Parse(ptb.Tag.ToString())];
            using (HttpClient client = new HttpClient()) {
                try {
                    string url = $"https://olympiawebservice.azurewebsites.net/api/Friend?idSelf={player.IDPlayer}&idFriend={p.IDPlayer}";
                    var response = await client.DeleteAsync(url);
                    if (response.IsSuccessStatusCode) {
                        pn.Enabled = false;
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            Cursor = Cursors.Default;
        }

        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabCtrl.SelectedIndex == 0) {
                LoadRank();
            } else if (tabCtrl.SelectedIndex == 2) {
                LoadRequest();
            }
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e) {
            if (receive.IsAlive) {
                receive.Abort();
            }
            if (tcpClient.Connected) {
                tcpClient.Close();
            }
        }
    }
}

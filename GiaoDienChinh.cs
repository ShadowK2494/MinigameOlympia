using MinigameOlympia.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class GiaoDienChinh : Form {
        public string username;
        public Image image;
        public Player player;
        private List<List<Player>> friendList = new List<List<Player>>();
        private List<Player> players = new List<Player>();
        public string roomCode = "";

        public GiaoDienChinh() {
            InitializeComponent();
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
            tc.ShowDialog();
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

        private async void GiaoDienChinh_Load(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor;
            await SortPlayer();
            int y = 0;
            for (int i = 0; i < players.Count; i++) {
                Panel pn = new Panel() {
                    Location = new Point(0, y),
                    BorderStyle = BorderStyle.Fixed3D,
                    Size = new Size(233, 81)
                };
                if (players[i].Username == username)
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

            await SortFriend();
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
            Cursor = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e) {
            foreach (Form form in Application.OpenForms) {
                if (form.Name == "RootForm") {
                    form.Visible = true;
                    break;
                }
            }
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

        private async void btnCreateRoom_Click(object sender, EventArgs e) {
            PhongCho room = new PhongCho();
            room.player = player;
            room.image = image;
            room.friendList = friendList;
            await CreateRoomCode();
            room.roomCode = roomCode;
            Visible = false;
            room.ShowDialog();
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
    }
}

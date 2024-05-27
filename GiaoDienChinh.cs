using MinigameOlympia.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MinigameOlympia {
    public partial class GiaoDienChinh : Form {
        private string username;
        private Thread get;
        private event EventHandler<Player> playerDataSent;
        private event EventHandler<Player> playerDataSent1;
        private event EventHandler<Image> imageSent;
        private event EventHandler<Image> imageSent1;
        private Image image;
        private Player player;
        public GiaoDienChinh() {
            InitializeComponent();
            Thread.Sleep(2000);
            get = new Thread(new ThreadStart(getAvatar));
            get.IsBackground = true;
            get.Start();
        }

        private void ptbAvatar_Click(object sender, EventArgs e) {
            HoSoNV profile = new HoSoNV();
            playerDataSent += profile.MainScreen_Player;
            playerDataSent?.Invoke(this, player);
            imageSent += profile.MainScreen_Image;
            imageSent?.Invoke(this, image);
            profile.ShowDialog();
        }

        public void CreateAvatar_username(object sender, string data) {
            if (data != "")
                username = data;
        }

        public void LogIn_username(object sender, string data) {
            if (data != "")
                username = data;
        }

        public void CreateNewPassword_username(object sender, string data) {
            if (data != "")
                username = data;
        }

        private async Task<Player> getPlayerAsync(string username) {
            player = null;
            HttpClient client = new HttpClient();
            try {
                string url = "http://localhost:2804/api/Player/username?lookup=" + username;
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    player = JsonConvert.DeserializeObject<Player>(jsonContent);
                }
            } catch (Exception ex) {

            }
            return player;
        }

        private async void getAvatar() {
            Thread.Sleep(1000);
            Player player = await getPlayerAsync(username);

            byte[] imgData = player.Avatar;
            using (MemoryStream ms = new MemoryStream(imgData)) {
                image = Image.FromStream(ms);
                ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                ptbAvatar.Image = image;
            }
        }

        private void MainScreenClosing(object sender, FormClosingEventArgs e) {
            if (get.IsAlive) {
                get.Abort();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e) {
            PhongCho room = new PhongCho();
            playerDataSent1 += room.MainScreen_Player;
            playerDataSent1?.Invoke(this, player);
            imageSent1 += room.MainScreen_Image;
            imageSent1?.Invoke(this, image);
            room.ShowDialog();
        }
    }
}

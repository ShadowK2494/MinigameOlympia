using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinigameOlympia.Models;
using Newtonsoft.Json;

namespace MinigameOlympia {
    public partial class TaoAvatar : Form {
        public PlayerSignUp newPlayer;
        private bool selected = false;
        public TaoAvatar() {
            InitializeComponent();
        }

        // Tạo tái khoản + avatar + chuyển đến form Giao diện chính
        private async void btnSubmit_Click(object sender, EventArgs e) {
            if (!rdbSelect.Checked) {
                if (!rdbDefault.Checked)
                    MessageBox.Show("Bạn chưa chọn hình đại diện", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    await PostPlayerAsync(newPlayer);
                    GiaoDienChinh mainScreen = new GiaoDienChinh();
                    mainScreen.username = newPlayer.Username;
                    mainScreen.Show();
                    Close();
                }
            } else {
                if (!selected)
                    MessageBox.Show("Bạn chưa chọn hình đại diện", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    await PostPlayerAsync(newPlayer);
                    GiaoDienChinh mainScreen = new GiaoDienChinh();
                    mainScreen.username = newPlayer.Username;
                    mainScreen.Show();
                    Close();
                }
            }
        }

        // Sự kiện radio button Mặc định
        private void rdbDefault_Click(object sender, EventArgs e) {
            if (rdbSelect.Checked) {
                rdbSelect.Checked = false;
                rdbDefault.Checked = true;
            }
            ptbAvatar.Image = Properties.Resources.anhdaidien;
            ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            byte[] avatarData;
            using (MemoryStream ms = new MemoryStream()) {
                ptbAvatar.Image.Save(ms, ptbAvatar.Image.RawFormat);
                avatarData = ms.ToArray();
            }
            newPlayer.Avatar = avatarData;
        }

        // Sự kiện radio button Tải ảnh lên
        private void rdbSelect_Click(object sender, EventArgs e) {
            if (rdbDefault.Checked) {
                rdbDefault.Checked = false;
                rdbSelect.Checked = true;
            }
            ptbAvatar.Image = Properties.Resources.plus;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Picture files (*.jpg, *.png, *.jpeg)|*.jpg; *.png; *.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK) {
                selected = true;
                string location = ofd.FileName;
                Image avatar = Image.FromFile(location);
                ptbAvatar.Image = avatar;
                byte[] avatarData;
                using (MemoryStream ms = new MemoryStream()) {
                    ptbAvatar.Image.Save(ms, ptbAvatar.Image.RawFormat);
                    avatarData = ms.ToArray();
                }
                newPlayer.Avatar = avatarData;
            } else
                selected = false;
        }

        // Thêm tài khoản người chơi vào cơ sở dữ liệu
        private async Task PostPlayerAsync(PlayerSignUp player) {
            string jsonContent = JsonConvert.SerializeObject(player);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient()) {
                try {
                    var response = await client.PostAsync("https://olympiawebservice.azurewebsites.net/api/Player", content);
                    if (response.IsSuccessStatusCode) {
                        MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

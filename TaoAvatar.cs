using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinigameOlympia.Models;
using Newtonsoft.Json;

namespace MinigameOlympia {
    public partial class TaoAvatar : Form {
        private PlayerSignUp newPlayer = new PlayerSignUp();
        private bool selected = false;
        private event EventHandler<string> usernameSent;
        public TaoAvatar() {
            InitializeComponent();
        }

        // Nhận dữ liệu người chơi từ form Đăng ký
        public void DangKy_DataSent(object sender, string[] data) {
            newPlayer.Name = data[0];
            newPlayer.Username = data[1];
            newPlayer.Password = data[2];
            int gender = int.Parse(data[3]);
            if (gender == 0)
                newPlayer.Gender = Gender.Male;
            else if (gender == 1)
                newPlayer.Gender = Gender.Female;
            else
                newPlayer.Gender = Gender.Other;
            newPlayer.Email = data[4];
            newPlayer.PhoneNumber = data[5];
        }

        // Tạo tái khoản + avatar + chuyển đến form Giao diện chính
        private void btnSubmit_Click(object sender, EventArgs e) {
            if (!rdbSelect.Checked) {
                if (!rdbDefault.Checked)
                    MessageBox.Show("Bạn chưa chọn hình đại diện", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    PostPlayerAsync(newPlayer);
                    Close();
                    GiaoDienChinh mainScreen = new GiaoDienChinh();
                    usernameSent += mainScreen.CreateAvatar_username;
                    usernameSent?.Invoke(this, newPlayer.Username);
                    mainScreen.Show();
                }
            } else {
                if (!selected)
                    MessageBox.Show("Bạn chưa chọn hình đại diện", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    PostPlayerAsync(newPlayer);
                    Close();
                    GiaoDienChinh mainScreen = new GiaoDienChinh();
                    usernameSent += mainScreen.CreateAvatar_username;
                    usernameSent?.Invoke(this, newPlayer.Username);
                    mainScreen.Show();
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
            HttpClient client = new HttpClient();
            try {
                var response = await client.PostAsync("https://86db-203-205-32-65.ngrok-free.app/api/Player", content);
                if (response.IsSuccessStatusCode) {
                    MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using MinigameOlympia.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class TaoLaiMatKhau : Form {
        public string email;
        private bool isOKPassword = false;
        private bool isOKRePass = false;
        private bool showPass = true;
        private bool showRePass = true;
        public TaoLaiMatKhau() {
            InitializeComponent();
        }

        private string HashPassword(string password) {
            password += "group17";
            // Tạo đối tượng SHA256
            using (SHA256 sha256 = SHA256.Create()) {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes) {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void BackToSignInForm(object sender, EventArgs args) {
            foreach (Form form in Application.OpenForms) {
                if (form.Name == "DangNhap") {
                    form.Visible = true;
                    break;
                }
            }
            Close();
        }


        private async Task<Player> getPlayerAsync(string email) {
            Player player = null;
            using (HttpClient client = new HttpClient()) {
                try {
                    string url = "https://olympiawebservice.azurewebsites.net/api/Player/email?lookup=" + email;
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode) {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        player = JsonConvert.DeserializeObject<Player>(jsonContent);
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            return player;
        }

        // Kiểm tra điều kiện của "Nhập mật khẩu"
        private void PasswordTextbox(object sender, EventArgs e) {
            tbPassword.MaxLength = 20;
            if (showPass)
                tbPassword.PasswordChar = '●';
            else
                tbPassword.PasswordChar = '\0';
            if (tbPassword.Text == "") {
                lblAlertPassword.Text = "ⓘ Mật khẩu không được để trống";
                lblAlertPassword.Visible = true;
                isOKPassword = false;
            } else {
                foreach (char c in tbPassword.Text) {
                    if (c == ' ') {
                        lblAlertPassword.Text = "ⓘ Mật khẩu không được chứa dấu cách";
                        lblAlertPassword.Visible = true;
                        isOKPassword = false;
                        break;
                    } else
                        lblAlertPassword.Visible = false;
                }
                isOKPassword = true;
            }
        }

        // Kiểm tra điều kiện của "Nhập lại mật khẩu"
        private void RePasswordTextbox(object sender, EventArgs e) {
            tbRePass.MaxLength = 20;
            if (showRePass)
                tbRePass.PasswordChar = '●';
            else
                tbRePass.PasswordChar = '\0';
            if (tbRePass.Text == "") {
                lblAlertRePass.Text = "ⓘ Mật khẩu không được để trống";
                lblAlertRePass.Visible = true;
                isOKRePass = false;
            } else {
                if (tbRePass.Text != tbPassword.Text) {
                    lblAlertRePass.Text = "ⓘ Mật khẩu không trùng khớp";
                    lblAlertRePass.Visible = true;
                    isOKRePass = false;
                } else {
                    lblAlertRePass.Visible = false;
                    isOKRePass = true;
                }
            }
        }

        // Hiển thị hoặc không hiển thị mật khẩu trong "Nhập mật khẩu"
        private void ptbPassword_Click(object sender, EventArgs e) {
            if (showPass) {
                tbPassword.PasswordChar = '\0';
                ptbPassword.Image = Properties.Resources.HidePass;
                showPass = false;
            } else {
                tbPassword.PasswordChar = '●';
                ptbPassword.Image = Properties.Resources.ShowPass;
                showPass = true;
            }
        }

        // Hiển thị hoặc không hiển thị mật khẩu trong "Nhập lại mật khẩu"
        private void ptbRePass_Click(object sender, EventArgs e) {
            if (showRePass) {
                tbRePass.PasswordChar = '\0';
                ptbRePass.Image = Properties.Resources.HidePass;
                showRePass = false;
            } else {
                tbRePass.PasswordChar = '●';
                ptbRePass.Image = Properties.Resources.ShowPass;
                showRePass = true;
            }
        }

        private async void btnSubmit_ClickAsync(object sender, EventArgs e) {
            if (isOKPassword && isOKRePass) {
                Player player = await getPlayerAsync(email);
                player.Password = HashPassword(tbPassword.Text);
                string jsonContent = JsonConvert.SerializeObject(player);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient()) {
                    try {
                        var response = await client.PutAsync("https://olympiawebservice.azurewebsites.net/api/Player", content);
                        if (response.IsSuccessStatusCode) {
                            MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GiaoDienChinh mainScreen = new GiaoDienChinh();
                            mainScreen.username = player.Username;
                            mainScreen.Show();
                            Close();
                        }
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}

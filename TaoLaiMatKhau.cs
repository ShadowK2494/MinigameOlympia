using MinigameOlympia.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class TaoLaiMatKhau : Form {
        private string email;
        private bool isOKPassword = false;
        private bool isOKRePass = false;
        private bool showPass = true;
        private bool showRePass = true;
        private event EventHandler<string> usernameSent;
        private QuenMK _forgetPassword;
        public TaoLaiMatKhau(QuenMK forgetPassword) {
            InitializeComponent();
            _forgetPassword = forgetPassword;
        }

        public void ForgetPassword_Email(object sender, string data) {
            email = data;
        }

        private void BackToForgetPasswordForm(object sender, EventArgs args) {
            Close();
            _forgetPassword.Visible = true;
        }


        private async Task<Player> getPlayerAsync(string email) {
            Player player = null;
            HttpClient client = new HttpClient();
            try {
                string url = "http://localhost:2804/api/Player/email?lookup=" + email;
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    player = JsonConvert.DeserializeObject<Player>(jsonContent);
                }
            } catch (Exception ex) {

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
            Thread.Sleep(5000);
            if (isOKPassword && isOKRePass) {
                Player player = await getPlayerAsync(email);
                player.Password = tbPassword.Text;
                string jsonContent = JsonConvert.SerializeObject(player);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                try {
                    var response = await client.PutAsync("http://localhost:2804/api/Player", content);
                    if (response.IsSuccessStatusCode) {
                        MessageBox.Show("Thay đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        GiaoDienChinh mainScreen = new GiaoDienChinh();
                        usernameSent += mainScreen.CreateNewPassword_username;
                        usernameSent?.Invoke(this, player.Username);
                        mainScreen.Show();
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

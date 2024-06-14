﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinigameOlympia.Models;
using MinigameOlympia;
using System.Security.Cryptography;

namespace MinigameOlympia {
    public partial class DangNhap : Form {
        private RootForm _rootForm { get; set; }
        private bool isOKUsername = false;
        private bool isOKPassword = false;
        private bool showPass = true;
        private event EventHandler<string> usernameSent;
        public DangNhap(RootForm rootForm) {
            InitializeComponent();
            _rootForm = rootForm;
        }

        // Quay về Root Form
        private void BackToRootForm(object sender, EventArgs args) {
            Close();
            _rootForm.Visible = true;
        }

        private async void tbUsername_TextChanged(object sender, EventArgs e) {
            if (tbUsername.Text == "") {
                lblAlertUsername.Text = "ⓘ Username không được để trống";
                lblAlertUsername.Visible = true;
                isOKUsername = false;
            } else {
                HttpClient client = new HttpClient();
                try {
                    string url = "https://olympiawebservice.azurewebsites.net/api/Player/username?lookup=" + tbUsername.Text.Trim();
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode) {
                        lblAlertUsername.Text = "ⓘ Username không tồn tại";
                        lblAlertUsername.Visible = true;
                        isOKUsername = false;
                    } else {
                        lblAlertUsername.Visible = false;
                        isOKUsername = true;
                    }
                } catch (Exception ex) {

                }
            }
        }

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

        // Phương thức băm mật khẩu bằng SHA-256
        private string HashPassword(string password)
        {
            password += "group17";
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // Phương thức xác thực mật khẩu đã băm
        private bool VerifyHashedPassword(string hashedPassword, string password)
        {
            string hashOfInput = HashPassword(password);

            return StringComparer.OrdinalIgnoreCase.Compare(hashedPassword, hashOfInput) == 0;
        }


        private async void btnSignIn_Click(object sender, EventArgs e) {
            if (isOKUsername && isOKPassword) {
                HttpClient client = new HttpClient();
                try {
                    string url = "https://olympiawebservice.azurewebsites.net/api/Player/username?lookup=" + tbUsername.Text.Trim();
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode) {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        Player player = JsonConvert.DeserializeObject<Player>(jsonContent);
                        if (VerifyHashedPassword(player.Password, tbPassword.Text)) {
                            Close();
                            GiaoDienChinh mainScreen = new GiaoDienChinh();
                            usernameSent += mainScreen.LogIn_username;
                            usernameSent?.Invoke(this, tbUsername.Text);
                            mainScreen.Show();
                        } else {
                            lblAlertPassword.Text = "ⓘ Sai mật khẩu";
                            lblAlertPassword.Visible = true;
                        }
                    }
                } catch (Exception ex) {

                }
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e) {
            Close();
            DangKy signUp = new DangKy(_rootForm);
            signUp.Show();
        }

        private void ForgetPassword(object sender, EventArgs e) {
            Visible = false;
            QuenMK forgetPassword = new QuenMK();
            forgetPassword.Show();
        }
    }
}

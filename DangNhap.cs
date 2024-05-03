using Newtonsoft.Json;
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
using Newtonsoft.Json;
using MinigameOlympia.Models;

namespace MinigameOlympia
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void PasswordTextbox(object sender, EventArgs e) {
            tbPassword.MaxLength = 20;
            tbPassword.PasswordChar = '●';
            tbPassword.CharacterCasing = CharacterCasing.Lower;
        }

        private async void btnSignIn_Click(object sender, EventArgs e) {
            HttpClient client = new HttpClient();
            try {
                string url = "http://localhost:2804/api/Player/username?lookup=" + tbUsername.Text.Trim();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    Player player = JsonConvert.DeserializeObject<Player>(jsonContent);
                    if (tbPassword.Text.Trim() == player.Password) {
                        MessageBox.Show("Sign in successfully");
                        Close();
                        GiaoDienChinh giaoDienChinh = new GiaoDienChinh();
                        giaoDienChinh.Show();
                    } else {
                        MessageBox.Show("Wrong password");
                    }
                } else {
                    MessageBox.Show("Player doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {

            }
        }

        private void btnSignUp_Click(object sender, EventArgs e) {
            //Close();
            //DangKy dangKy = new DangKy();
            //dangKy.Show();
        }

        private void ForgetPassword(object sender, EventArgs e) {
            //Close();
            //QuenMK quenMK = new QuenMK();
            //quenMK.Show();
        }
    }
}

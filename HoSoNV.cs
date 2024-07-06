using MinigameOlympia.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class HoSoNV : Form {
        public string self;
        public Player player;
        public Image image;
        private bool isEdit = false;
        public HoSoNV() {
            InitializeComponent();
        }

        private void HoSoNV_Load(object sender, EventArgs e) {
            tbUsername.Text = player.Username;
            tbID.Text = player.IDPlayer;
            tbPhone.Text = player.PhoneNumber;
            tbEmail.Text = player.Email;
            tbWinCount.Text = player.WinCount.ToString();
            ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbAvatar.Image = image;
            if (self.ToUpper() != player.Username.ToUpper()) {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnGGForm.Visible = false;
            }
        }

        private void btnGGForm_Click(object sender, EventArgs e) {
            string url = "https://forms.gle/CudEUTRPV9XN27Pm6";
            try {
                Process.Start(new ProcessStartInfo {
                    FileName = "chrome.exe",
                    Arguments = url,
                    UseShellExecute = true
                });
            } catch (Exception ex) {
                MessageBox.Show("Could not open the website. Make sure Google Chrome is installed. Error: " + ex.Message);
            }
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

        private async void btnEdit_Click(object sender, EventArgs e) {
            isEdit = true;
            if (btnEdit.Text == "Chỉnh sửa") {
                btnEdit.Text = "Xong";
                tbUsername.BackColor = Color.White;
                tbPhone.BackColor = Color.White;
                tbEmail.BackColor = Color.White;
                tbUsername.ReadOnly = false;
                tbPhone.ReadOnly = false;
                tbEmail.ReadOnly = false;
            } else {
                player.Username = tbUsername.Text;
                player.Email = tbEmail.Text;
                player.PhoneNumber = tbPhone.Text;
                string jsonContent = JsonConvert.SerializeObject(player);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient()) {
                    try {
                        Cursor = Cursors.WaitCursor;
                        var response = await client.PutAsync("https://olympiawebservice.azurewebsites.net/api/Player", content);
                        if (response.IsSuccessStatusCode) {
                            MessageBox.Show("Thay đổi thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor = Cursors.Default;
                            isEdit = false;
                            btnEdit.Text = "Chỉnh sửa";
                            tbUsername.BackColor = Color.LightSteelBlue;
                            tbPhone.BackColor = Color.LightSteelBlue;
                            tbEmail.BackColor = Color.LightSteelBlue;
                            tbUsername.ReadOnly = true;
                            tbPhone.ReadOnly = true;
                            tbEmail.ReadOnly = true;
                        }
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void ptbAvatar_Click(object sender, EventArgs e) {
            if (isEdit) {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Picture files (*.jpg, *.png, *.jpeg)|*.jpg; *.png; *.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    string location = ofd.FileName;
                    Image avatar = Image.FromFile(location);
                    ptbAvatar.Image = avatar;
                    byte[] avatarData;
                    using (MemoryStream ms = new MemoryStream()) {
                        ptbAvatar.Image.Save(ms, ptbAvatar.Image.RawFormat);
                        avatarData = ms.ToArray();
                    }
                    player.Avatar = avatarData;
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e) {
            using (HttpClient client = new HttpClient()) {
                try {
                    Cursor = Cursors.WaitCursor;
                    var response = await client.DeleteAsync($"https://olympiawebservice.azurewebsites.net/api/Player?idPlayer={player.IDPlayer}");
                    if (response.IsSuccessStatusCode) {
                        MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int i = 0; i < Application.OpenForms.Count; i++) {
                            var form = Application.OpenForms[i];
                            if (form.Name == "RootForm") {
                                form.Visible = true;
                            } else {
                                form.Close();
                                i--;
                            }
                        }
                        Cursor = Cursors.Default;
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

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
using System.Net;

namespace MinigameOlympia
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void CheckName(object sender, EventArgs e) {
            
        }

        private void CheckPhone(object sender, EventArgs e) {
            if (tbPhone.Text == "") {
                MessageBox.Show("Phone number field is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPhone.Focus();
            } else {
                if (tbPhone.Text.Length > 10) {
                    MessageBox.Show("Invalid phone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbPhone.Focus();
                } else {
                    foreach (char c in tbPhone.Text) {
                        if (c < '0' && c > '9') {
                            MessageBox.Show("Invalid phone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbPhone.Focus();
                            break;
                        }
                    }
                }
            }
        }

        private void BackToRootForm(object sender, EventArgs args) {
            //Close();
            //RootForm rootForm = new RootForm();
            //rootForm.Show();
        }

        private async void btnSubmit_Click(object sender, EventArgs e) {
            PlayerSignUp newPlayer = new PlayerSignUp(
                tbName.Text.Trim(), 
                tbUsername.Text.Trim(),
                tbPassword.Text.Trim(),
                cbbGender.SelectedIndex,
                tbEmail.Text.Trim(),
                tbPhone.Text.Trim());
            string jsonContent = JsonConvert.SerializeObject(newPlayer);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            try {
                var response = await client.PostAsync("http://localhost:2804/api/Player", content);
                if (response.IsSuccessStatusCode) {
                    MessageBox.Show("Create account successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    GiaoDienChinh giaoDienChinh = new GiaoDienChinh();
                    giaoDienChinh.Show();
                } else if ((int)response.StatusCode == 422) {
                    try {
                        string url = "http://localhost:2804/api/Player/username?lookup=" + tbUsername.Text.Trim();
                        response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode) {
                            MessageBox.Show("Username already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } catch (Exception ex) {

                    }

                    try {
                        string url = "http://localhost:2804/api/Player/email?lookup=" + tbEmail.Text.Trim();
                        response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode) {
                            MessageBox.Show("Email already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } catch (Exception ex) {

                    }

                    try {
                        string url = "http://localhost:2804/api/Player/phone?lookup=" + tbPhone.Text.Trim();
                        response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode) {
                            MessageBox.Show("Phone number already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } catch (Exception ex) {

                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void PasswordTextbox(object sender, EventArgs e) {
            tbPassword.MaxLength = 20;
            tbPassword.PasswordChar = '●';
            tbPassword.CharacterCasing = CharacterCasing.Lower;
            if (tbPassword.Text == "") {
                lblAlertPassword.Text = "* Password field is blank";
                lblAlertPassword.Visible = true;
            } else {
                foreach (char c in tbPassword.Text) {
                    if (c == ' ') {
                        lblAlertPassword.Text = "* Password mustn't contain space";
                        lblAlertPassword.Visible = true;
                        break;
                    } else
                        lblAlertPassword.Visible = false;
                }
            }
        }

        private void RePasswordTextbox(object sender, EventArgs e) {
            tbRePass.MaxLength = 20;
            tbRePass.PasswordChar = '●';
            tbRePass.CharacterCasing = CharacterCasing.Lower;
            if (tbRePass.Text == "") {
                lblAlertRePass.Text = "* Password field is blank";
                lblAlertRePass.Visible = true;
            } else {
                foreach (char c in tbRePass.Text) {
                    if (c == ' ') {
                        lblAlertRePass.Text = "* Password mustn't contain space";
                        lblAlertRePass.Visible = true;
                        break;
                    }
                }
            }
        }

        private void cbbGender_TextChanged(object sender, EventArgs e) {
            ComboBox cbb = (ComboBox)sender;
            int index = cbb.FindString(cbb.Text.Trim());
            if (index < 0) {
                MessageBox.Show("Lựa chọn không phù hợp!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e) {
            if (tbName.Text == "") {
                lblAlertName.Text = "* Name field is blank";
                lblAlertName.Visible = true;
            } else {
                string temp = tbName.Text.Replace(" ", "");
                foreach (char c in temp) {
                    if (!(c >= 'A' && c <= 'Z') && !(c >= 'a' && c <= 'z')) {
                        lblAlertName.Text = "* Only contain letters";
                        lblAlertName.Visible = true;
                        break;
                    } else
                        lblAlertName.Visible = false;
                }
            }
        }
    }
}

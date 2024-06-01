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
using Unidecode.NET;
using System.Net.Mail;
using System.Xml.Schema;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using MinigameOlympia;

namespace MinigameOlympia {
    public partial class DangKy : Form {
        private bool isOKName = false;
        private bool isOKUsername = false;
        private bool isOKPassword = false;
        private bool isOKRePassword = false;
        private bool isOKEmail = false;
        private bool isOKPhone = false;
        private bool isOKGender = false;
        private bool showPass = true;
        private bool showRePass = true;
        private event EventHandler<string> EmailSent;
        private bool isEmailVerify;
        private event EventHandler<string[]> DataSent;
        private RootForm _rootForm { get; set; }
        public DangKy(RootForm rootForm) {
            InitializeComponent();
            _rootForm = rootForm;
        }

        // Quay về Root Form
        private void BackToRootForm(object sender, EventArgs args) {
            Close();
            _rootForm.Visible = true;
        }

        // Lấy dữ liệu kết quả xác thực bên form Xác thực email
        private void VerifyEmail_isValid(object sender, bool data) {
            isEmailVerify = data;
        }

        // Chuyển đến form xác thực email
        private async void btnSubmit_Click(object sender, EventArgs e) {
            if (isOKName && isOKUsername && isOKPassword && isOKRePassword && isOKEmail && isOKPhone && isOKGender) {

                string data = tbEmail.Text;
                VerifyEmail verifyEmail = new VerifyEmail();
                EmailSent += verifyEmail.SignUp_EmailSent;
                EmailSent?.Invoke(this, data);

                verifyEmail.isValid += VerifyEmail_isValid;
                verifyEmail.ShowDialog();
                if (isEmailVerify) {
                    Visible = false;
                    string[] playerData = {
                        tbName.Text.Trim(),
                        tbUsername.Text.Trim(),
                        tbPassword.Text.Trim(),
                        cbbGender.SelectedIndex.ToString(),
                        tbEmail.Text.Trim(),
                        tbPhone.Text.Trim()
                    };
                    TaoAvatar createAvatar = new TaoAvatar();
                    DataSent += createAvatar.DangKy_DataSent;
                    DataSent?.Invoke(this, playerData);
                    Close();
                    createAvatar.Show();
                }
            } else {
                MessageBox.Show("Thông tin chưa hợp lệ", "Lỗi tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                isOKRePassword = false;
            } else {
                if (tbRePass.Text != tbPassword.Text) {
                    lblAlertRePass.Text = "ⓘ Mật khẩu không trùng khớp";
                    lblAlertRePass.Visible = true;
                    isOKRePassword = false;
                } else {
                    lblAlertRePass.Visible = false;
                    isOKRePassword = true;
                }
            }
        }

        // Kiểm tra điều kiện của "Giới tính"
        private void cbbGender_TextChanged(object sender, EventArgs e) {
            ComboBox cbb = (ComboBox)sender;
            int index = cbb.FindString(cbb.Text.Trim());
            if (index < 0) {
                lblAlertGender.Text = "ⓘ Lựa chọn không phù hợp";
                lblAlertGender.Visible = true;
                isOKGender = false;
            } else {
                lblAlertGender.Visible = false;
                isOKGender = true;
            }
        }

        // Kiểm tra điều kiện của "Họ và tên"
        private void tbName_TextChanged(object sender, EventArgs e) {
            if (tbName.Text == "") {
                lblAlertName.Text = "ⓘ Tên không được để trống";
                lblAlertName.Visible = true;
                isOKName = false;
            } else {
                string temp = tbName.Text.Replace(" ", "");
                foreach (char c in temp.Unidecode()) {
                    if (!(c >= 'A' && c <= 'Z') && !(c >= 'a' && c <= 'z')) {
                        lblAlertName.Text = "ⓘ Chỉ được chứa các kí tự chữ";
                        lblAlertName.Visible = true;
                        isOKName = false;
                    } else
                        lblAlertName.Visible = false;
                }
                isOKName = true;
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

        // Kiểm tra điều kiện của "Username"
        private async void tbUsername_TextChanged(object sender, EventArgs e) {
            if (tbUsername.Text == "") {
                lblAlertUsername.Text = "ⓘ Username không được để trống";
                lblAlertUsername.Visible = true;
                isOKUsername = false;
            } else {
                HttpClient client = new HttpClient();
                try {
                    string url = "https://86db-203-205-32-65.ngrok-free.app/api/Player/username?lookup=" + tbUsername.Text.Trim();
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode) {
                        lblAlertUsername.Text = "ⓘ Username đã tồn tại";
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

        // Kiểm tra định dạng của email
        private bool IsValidEmail(string email) {
            try {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            } catch (FormatException) {
                return false;
            }
        }

        // Kiểm tra điều kiện của "Email"
        private async void tbEmail_TextChangedAsync(object sender, EventArgs e) {
            if (tbEmail.Text == "") {
                lblAlertEmail.Text = "ⓘ Email không được để trống";
                lblAlertEmail.Visible = true;
                isOKEmail = false;
            } else {
                if (!IsValidEmail(tbEmail.Text)) {
                    lblAlertEmail.Text = "ⓘ Email không hợp lệ";
                    lblAlertEmail.Visible = true;
                    isOKEmail = false;
                } else {
                    HttpClient client = new HttpClient();
                    try {
                        string url = "https://86db-203-205-32-65.ngrok-free.app/api/Player/email?lookup=" + tbEmail.Text.Trim();
                        var response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode) {
                            lblAlertEmail.Text = "ⓘ Email đã được sử dụng";
                            lblAlertEmail.Visible = true;
                            isOKEmail = false;
                        } else {
                            lblAlertEmail.Visible = false;
                            isOKEmail = true;
                        }
                    } catch (Exception ex) {

                    }
                }
            }
        }

        // Kiểm tra định dạng của số điện thoại
        private bool IsValidPhone(string phone) {
            if (phone.Length != 10)
                return false;
            foreach (char c in phone) {
                if (c < '0' || c > '9') {
                    return false;
                }
            }
            return true;
        }

        // Kiểm tra điều kiện của "Số điện thoại"
        private async void tbPhone_TextChanged(object sender, EventArgs e) {
            if (tbPhone.Text == "") {
                lblAlertPhone.Text = "ⓘ Số điện thoại không được để trống";
                lblAlertPhone.Visible = true;
                isOKPhone = false;
            } else {
                if (!IsValidPhone(tbPhone.Text)) {
                    lblAlertPhone.Text = "ⓘ Số điện thoại không hợp lệ";
                    lblAlertPhone.Visible = true;
                    isOKPhone = false;
                } else {
                    HttpClient client = new HttpClient();
                    try {
                        string url = "https://86db-203-205-32-65.ngrok-free.app/api/Player/phone?lookup=" + tbPhone.Text.Trim();
                        var response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode) {
                            lblAlertPhone.Text = "ⓘ Số điện thoại đã được sử dụng";
                            lblAlertPhone.Visible = true;
                            isOKPhone = false;
                        } else {
                            lblAlertPhone.Visible = false;
                            isOKPhone = true;
                        }
                    } catch (Exception ex) {

                    }
                }
            }
        }
    }
}

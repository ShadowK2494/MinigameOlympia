using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Threading;
using System.Net.Http;
using System.Drawing.Text;

namespace MinigameOlympia {
    public partial class QuenMK : Form {
        private DangNhap _logIn { get; set; }
        private int otp;
        private Thread updateUI;
        private bool isOKEmail = false;
        private event EventHandler<string> EmailSent;
        public QuenMK(DangNhap logIn) {
            InitializeComponent();
            _logIn = logIn;
        }

        private void BackToLogInForm(object sender, EventArgs args) {
            Close();
            _logIn.Visible = true;
        }

        // Gửi mã OTP
        private void SendOTP(string email) {
            try {
                Random random = new Random();
                otp = random.Next(100000, 999999);
                var fromAddr = new MailAddress("minigameolympia@gmail.com");
                var toAddr = new MailAddress(email);
                const string fromPass = "nykchlcckwiivfsb";
                const string subject = "Xác thực email tạo lại mật khẩu";
                string body = "OTP: " + otp.ToString();

                var smtp = new SmtpClient {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddr.Address, fromPass),
                    Timeout = 200000
                };
                using (var message = new MailMessage(fromAddr, toAddr) {
                    Subject = subject,
                    Body = body
                }) {
                    smtp.Send(message);
                }
                MessageBox.Show("OTP đã được gửi qua email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        // Xác thực mã OTP
        private void btnSubmit_Click(object sender, EventArgs e) {
            if (otp.ToString() == tbOTP.Text) {
                string data = tbEmail.Text;
                Close();
                TaoLaiMatKhau createNewPassword = new TaoLaiMatKhau(this);
                EmailSent += createNewPassword.ForgetPassword_Email;
                EmailSent?.Invoke(this, data);
                createNewPassword.Show();
            } else {
                MessageBox.Show("Mã OTP không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Giao diện thay đổi khi gửi mã OTP
        private void btnSendOTP_Click(object sender, EventArgs e) {
            if (isOKEmail) {
                SendOTP(tbEmail.Text);
                btnSendOTP.Enabled = false;
                updateUI = new Thread(() => {
                    for (int i = 30; i > 0; i--) {
                        appendText_btnSendOTP($"Gửi lại mã ({i}s)");
                        Thread.Sleep(1000);
                    }
                    appendText_btnSendOTP("Gửi lại mã");
                    btnSendOTP.Enabled = true;
                });
                updateUI.IsBackground = true;
                updateUI.Start();
            }
        }

        private void appendText_btnSendOTP(string text) {
            if (InvokeRequired) {
                Invoke(new Action<string>(appendText_btnSendOTP), text);
                return;
            }
            btnSendOTP.Text = text;
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
                        string url = "http://localhost:2804/api/Player/email?lookup=" + tbEmail.Text.Trim();
                        var response = await client.GetAsync(url);
                        if (!response.IsSuccessStatusCode) {
                            lblAlertEmail.Text = "ⓘ Email chưa được đăng ký";
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

        // Đóng luồng khi đóng form
        private void ForgetPasswordClosing(object sender, FormClosingEventArgs e) {
            if (updateUI.IsAlive)
                updateUI.Abort();
        }
    }
}

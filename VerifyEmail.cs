using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MinigameOlympia {
    public partial class VerifyEmail : Form {
        private string email;
        private int otp;
        public event EventHandler<bool> isValid;
        private Thread updateUI;
        public VerifyEmail() {
            InitializeComponent();
        }

        // Nhận dữ liệu email từ form Đăng ký
        public void SignUp_EmailSent(object sender, string data) {
            email = data;
        }

        // Gửi mã OTP
        private void SendOTP(string email) {
            try {
                Random random = new Random();
                otp = random.Next(100000, 999999);
                var fromAddr = new MailAddress("minigameolympia@gmail.com");
                var toAddr = new MailAddress(email);
                const string fromPass = "nykchlcckwiivfsb";
                const string subject = "Xác thực đăng ký email";
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

        // Khi xác thực email thành công gửi tín hiệu cho form Đăng ký
        public void IsValidEmail(bool data) {
            isValid?.Invoke(this, data);
        }

        // Xác thực mã OTP
        private void btnSubmit_Click(object sender, EventArgs e) {
            bool data;
            if (otp.ToString() == tbOTP.Text) {
                MessageBox.Show("Xác thực email thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                data = true;
                IsValidEmail(true);
                Close();
            } else {
                MessageBox.Show("Mã OTP không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsValidEmail(false);
            }
        }

        // Giao diện thay đổi khi gửi mã OTP
        private void btnSendOTP_Click(object sender, EventArgs e) {
            SendOTP(email);
            lblCaption.Text = "Nhập OTP được gửi trong email";
            btnSendOTP.Enabled = false;
            updateUI = new Thread(() => {
                for (int i = 30; i > 0; i--) {
                    appendText_btnSendOTP($"Gửi lại mã ({i}s)");
                    Thread.Sleep(1000);
                }
                appendText_btnSendOTP("Gửi lại mã");
                btnSendOTP.Enabled = true;
                appendText_lblCaption("Nhấn gửi mã để lấy mã xác thực");
            });
            updateUI.IsBackground = true;
            updateUI.Start();
        }

        private void appendText_btnSendOTP(string text) {
            if (InvokeRequired) {
                Invoke(new Action<string>(appendText_btnSendOTP), text);
                return;
            }
            btnSendOTP.Text = text;
        }

        // Hiển thị chữ trên luồng cao hơn (nếu cần)
        private void appendText_lblCaption(string text) {
            if (InvokeRequired) {
                Invoke(new Action<string>(appendText_lblCaption), text);
                return;
            }
            lblCaption.Text = text;
        }

        // Đóng luồng khi đóng form
        private void VerifyEmail_Closing(object sender, FormClosingEventArgs e) {
            if (updateUI.IsAlive)
                updateUI.Abort();
        }
    }
}

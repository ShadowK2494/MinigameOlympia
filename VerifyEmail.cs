using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class VerifyEmail : Form {
        public string email;
        private int otp;
        private bool isValid;
        private Thread updateUI;
        public VerifyEmail() {
            InitializeComponent();
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
                //MessageBox.Show(otp.ToString());
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
        public bool IsValidEmail() {
            return isValid;
        }

        // Xác thực mã OTP
        private void btnSubmit_Click(object sender, EventArgs e) {
            if (otp.ToString() == tbOTP.Text) {
                MessageBox.Show("Xác thực email thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isValid = true;
                Close();
            } else {
                MessageBox.Show("Mã OTP không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
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

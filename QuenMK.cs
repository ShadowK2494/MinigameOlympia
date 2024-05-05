using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia
{
    public partial class QuenMK : Form
    {
        public QuenMK()
        {
            InitializeComponent();
        }
        Random random = new Random();
        int otp;


        private void buttonSend_Click(object sender, EventArgs e)
        {
            // Tao ma OTP random
            try
            {
                otp = random.Next(100000, 1000000);
                var fromAddress = new MailAddress("minigameolympia@gmail.com");
                var toAddress = new MailAddress(textBoxEmail.ToString()); //user's mail
                const string frompass = "nykchlcckwiivfsb";
                const string subject = "OTP code";
                string nofi = "Xin vui lòng nhập mã OTP sau vào ô xác nhận trong chương trình để có thể tạo lại mật khẩu. Không chia sẻ mã OTP này với bất kỳ ai.";
                string body = otp.ToString() + nofi;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, frompass),
                    Timeout = 200000

                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,

                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("OTP đã được gửi. Hãy kiểm tra hộp thư của bạn!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            if (otp.ToString().Equals(textBoxCode.Text))
            {
                MessageBox.Show("Xác minh thành công!");
                TaoLaiMatKhau nextForm = new TaoLaiMatKhau(); //Di chuyển đến form tại lại mật khẩu
                nextForm.show();
            }
            else
            {
                MessageBox.Show("Mã OTP không chính xác");
            }
        }
    }
}

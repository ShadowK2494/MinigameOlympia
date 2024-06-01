using MinigameOlympia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class HoSoNV : Form {
        private Player player;
        private Image image;
        private Thread load;
        public HoSoNV() {
            InitializeComponent();
            Thread.Sleep(5000);
            load = new Thread(new ThreadStart(loadScreen));
            load.IsBackground = true;
            load.Start();
        }

        public void MainScreen_Player(object sender, Player data) {
            player = data;
        }

        public void MainScreen_Image(object sender, Image data) {
            image = data;
        }

        private void loadScreen() {
            appendText_lblUsername(player.Username);
            tbPhone.Text = player.PhoneNumber;
            tbEmail.Text = player.Email;
            tbWinCount.Text = player.WinCount.ToString();
            ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbAvatar.Image = image;
        }

        private void appendText_lblUsername(string text) {
            if (InvokeRequired) {
                Invoke(new Action<string>(appendText_lblUsername), text);
                return;
            }
            tbUsername.Text = text;
        }

        private void ProfileClosing(object sender, FormClosingEventArgs e) {
            if (load.IsAlive)
                load.Abort();
        }

        private void btnGGForm_Click(object sender, EventArgs e)
        {
            string url = "https://forms.gle/CudEUTRPV9XN27Pm6"; 
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "chrome.exe",
                    Arguments = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open the website. Make sure Google Chrome is installed. Error: " + ex.Message);
            }
        }
    }
}

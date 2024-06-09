using MinigameOlympia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        public void MainScreen_Player(object sender, Player data) {
            player = data;
        }

        public void MainScreen_Image(object sender, Image data) {
            image = data;
        }

        private void appendText_lblUsername(string text) {
            if (InvokeRequired) {
                Invoke(new Action<string>(appendText_lblUsername), text);
                return;
            }
            tbUsername.Text = text;
        }

        private void HoSoNV_Load(object sender, EventArgs e) {
            tbUsername.Text = player.Username;
            tbID.Text = player.IDPlayer;
            tbPhone.Text = player.PhoneNumber;
            tbEmail.Text = player.Email;
            tbWinCount.Text = player.WinCount.ToString();
            ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbAvatar.Image = image;
        }
    }
}

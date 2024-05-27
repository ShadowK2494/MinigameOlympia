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
    public partial class PhongCho : Form {
        private Player player;
        private Image image;
        private Thread load;
        public PhongCho() {
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
            lblPlayer1.Text = player.Username;
            ptbPlayer1.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbPlayer1.Image = image;
        }


        private void RoomClosing(object sender, FormClosingEventArgs e) {
            if (load.IsAlive)
                load.Abort();
        }
    }
}

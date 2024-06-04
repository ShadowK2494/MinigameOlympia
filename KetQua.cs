using MinigameOlympia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia
{
    public partial class KetQua : Form
    {
        private Player topPlayer;
        private Image avatarImage;
        public KetQua()
        {
            InitializeComponent();
            LoadTopPlayer();
            DisplayTopPlayer();
        }
        private void LoadTopPlayer()
        {
            Vong2 vong2 = new Vong2();
            List<Player> players = vong2.GetPlayerScores();
            topPlayer = players.OrderByDescending(p => p.Score).FirstOrDefault();
        }
        private void DisplayTopPlayer()
        {
            if (topPlayer != null)
            {
                label_name.Text = $"Username: {topPlayer.Username}";
                label_score.Text = $"Score: {topPlayer.Score}";

                using (MemoryStream ms = new MemoryStream(topPlayer.Avatar))
                {
                    avatarImage = Image.FromStream(ms);
                    pictureBox_avt.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_avt.Image = avatarImage;
                }
            }
        }
    }
}

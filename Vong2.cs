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
    public partial class Vong2 : Form
    {
        private Player player;
        public Vong2()
        {
            InitializeComponent();
        }

        private void Vong2_Load(object sender, EventArgs e)
        {

        }
        public List<Player> GetPlayerScores()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player
            {
                Username = groupBox_user1.Text,
                Score = int.Parse(label_score1.Text),
                Avatar = GetAvatarBytes(ptbAvatar1.Image)
            });

            players.Add(new Player
            {
                Username = groupBox_user2.Text,
                Score = int.Parse(label_score2.Text),
                Avatar = GetAvatarBytes(ptbAvatar2.Image)
            });

            players.Add(new Player
            {
                Username = groupBox_user3.Text,
                Score = int.Parse(label_score3.Text),
                Avatar = GetAvatarBytes(ptbAvatar3.Image)
            });

            players.Add(new Player
            {
                Username = groupBox_user4.Text,
                Score = int.Parse(label_score4.Text),
                Avatar = GetAvatarBytes(ptbAvatar4.Image)
            });

            return players;
        }

        private byte[] GetAvatarBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

    }
}

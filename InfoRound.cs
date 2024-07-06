using MinigameOlympia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class InfoRound : Form {
        public int round;
        public string roomCode;
        public TcpClient client;
        public Player player;
        public Image image;
        public Timer startTimer = new Timer();
        public List<string> players = new List<string>();
        public List<Image> avatars = new List<Image>();
        private SoundPlayer sound;
        public InfoRound() {
            InitializeComponent();
            startTimer.Interval = 5000;
            startTimer.Tick += startTimer_Tick;
        }

        private void startTimer_Tick(object sender, EventArgs e) {
            startTimer.Stop();
            if (round == 1) {
                Vong1 vong1 = new Vong1();
                vong1.Text = $"Vượt chướng ngại vật - {roomCode}";
                vong1.client = client;
                vong1.roomCode = roomCode;
                vong1.player = player;
                vong1.avatar = image;
                vong1.Show();
                Close();
            }
            if (round == 2) {
                Vong2 vong2 = new Vong2();
                vong2.Text = $"Tăng tốc - {roomCode}";
                vong2.client = client;
                vong2.roomCode = roomCode;
                vong2.player = player;
                vong2.players = players;
                vong2.avatars = avatars;
                vong2.Show();
                Close();
            }
        }

        private void InfoRound_Load(object sender, EventArgs e) {
            if (round == 1) {
                lblInfoRound.Text = "Vượt chướng ngại vật";
                Invoke(new MethodInvoker(delegate {
                    sound = new SoundPlayer(Properties.Resources.Intro);
                    sound.Play();
                }));
            } else {
                lblInfoRound.Text = "Tăng tốc";
                Invoke(new MethodInvoker(delegate {
                    sound = new SoundPlayer(Properties.Resources.Intro);
                    sound.Play();
                }));
            }
            startTimer.Start();
        }

        private void InfoRound_FormClosing(object sender, FormClosingEventArgs e) {
            sound.Stop();
        }
    }
}

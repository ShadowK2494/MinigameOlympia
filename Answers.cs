using MinigameOlympia.Models;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MinigameOlympia.Models;
using System.Threading;

namespace MinigameOlympia
{
    public partial class Answers : Form
    {
        public Player player1, player2, player3, player4;
        private Thread load;
        public Answers()
        {
            InitializeComponent();
        }

        private void Answers_Load(object sender, EventArgs e)
        {
            lbUsername1 =  player1.Username;
            lbUsername2 =  player2.Username;
            lbUsername3 =  player3.Username;
            lbUsername4 =  player4.Username;

        }
    }
}

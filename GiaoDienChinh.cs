using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia
{
    public partial class GiaoDienChinh : Form
    {
        public GiaoDienChinh()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HoSoNV hoSoNV = new HoSoNV();
            hoSoNV.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DSBanBe dSBanBe = new DSBanBe();
            dSBanBe.ShowDialog();
        }
    }
}

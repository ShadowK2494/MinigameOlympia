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
    public partial class RootForm : Form
    {
        public RootForm()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e) {
            //Visible = false;
            //DangNhap dangNhap = new DangNhap();
            //dangNhap.Show();
        }

        private void btnDangKy_Click(object sender, EventArgs e) {
            Visible = false;
            DangKy dangKy = new DangKy();
            dangKy.Show();
        }

        private void RootFormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }
    }
}

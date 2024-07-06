using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia {
    public partial class GuideScreen : Form {
        public GuideScreen() {
            InitializeComponent();
        }

        private void btnCreateRoom_Click(object sender, EventArgs e) {
            InstructionRound1 form = new InstructionRound1();
            form.ShowDialog();
        }

        private void btnEnter_Click(object sender, EventArgs e) {
            InstructionRound2 form = new InstructionRound2();
            form.ShowDialog();
        }

        private void btnGuide_Click(object sender, EventArgs e) {
            foreach (Form form in Application.OpenForms) {
                if (form.Name == "GiaoDienChinh") {
                    form.Visible = true;
                    break;
                }
            }
            Close();
        }
    }
}

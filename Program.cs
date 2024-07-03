using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigameOlympia
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Vong1());
            Application.ApplicationExit += Application_Exit;
            Application.Exit();
        }

        private static void Application_Exit(object sender, EventArgs e) {
            foreach (Form form in Application.OpenForms) {
                form.Close();
                //Application.Exit();
            }
        }
    }
}

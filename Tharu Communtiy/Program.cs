using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tharu_Communtiy
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

            Form1 loginForm = new Form1();
            loginForm.ShowDialog();

            if (loginForm.DialogResult == DialogResult.OK)
            {
                string username = (string)loginForm.Tag;  
                Application.Run(new HomePage(username));
            }
        }
    }
}

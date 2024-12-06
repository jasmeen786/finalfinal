using System;
using System.Windows.Forms;

namespace TaskManagementApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show LoginForm when the app starts
            Application.Run(new Form1());
        }
    }
}

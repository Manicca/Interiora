using System;
using System.Windows.Forms;

namespace InterioraClient
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);
            Application.Run(new LoginForm());
        }
    }
}

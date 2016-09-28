using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;

namespace Layered_App
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // TODO: IoC instead of direct instanciation
            ILoginRepository loginRepo = new XmlLoginRepository();
            MainForm mainForm = new MainForm(loginRepo);

            Application.Run(mainForm);
        }
    }
}

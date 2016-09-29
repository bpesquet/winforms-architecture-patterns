using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;

namespace MVP_PassiveView_App
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
            View.MainForm mainForm = new View.MainForm();
            Presenter.MainPresenter mainPresenter = new Presenter.MainPresenter(loginRepo, mainForm);

            Application.Run(mainForm);
        }
    }
}

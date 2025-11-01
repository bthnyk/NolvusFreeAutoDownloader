using System;
using System.Windows.Forms;
using Dark.Net;

namespace NolvusFreeAutoDownloader
{
    internal static partial class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DarkNet.Instance.SetCurrentProcessTheme(Theme.Auto);

            Form mainForm = new NfadMainForm();

            DarkNet.Instance.SetWindowThemeForms(mainForm, Theme.Auto);
            LanguageManager.Initialize();

            Application.Run(mainForm);
        }
    }
}

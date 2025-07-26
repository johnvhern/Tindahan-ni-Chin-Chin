using System;
using System.Windows.Forms;

namespace Tindahan_ni_Chin_Chin
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string licenseKey = Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);

            Database.DatabaseCreation.InitializeDatabase();
            //Database.DatabaseCreation.addProduct();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.LoginForm());
        }
    }
}

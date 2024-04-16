using PsychTestsMilitary.Services.Singletons;
using System;
using PsychTestsMilitary.Services;
using System.Windows;

namespace PsychTestsMilitary.ViewModels
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static void ExitApp()
        {
            Current.Shutdown();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LicenseManager.Validate();
            //MessageBox.Show((LicenseManager.CheckOnTrialTimeLeft() ? "All is OK" : "Trial end!"));
            TechniquesDBSingleton.Instance.Init();
            AdditionalInfoDBSingleton.Instance.Init();
        }
    }
}

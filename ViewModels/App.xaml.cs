using PsychTestsMilitary.Services.Singletons;
using System;
using System.Windows;

namespace PsychTestsMilitary.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
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

            TechniquesDBSingleton.Instance.Init();
            AdditionalInfoDBSingleton.Instance.Init();
        }
    }
}

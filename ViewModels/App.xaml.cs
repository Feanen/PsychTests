using PsychTestsMilitary.Services.Singletons;
using PsychTestsMilitary.Services.Contexts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

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
            TechniquesDBSingleton.Instance.TechniquesContext = new TechniquesContext();
            AdditionalInfoDBSingleton.Instance.AddInfoContext = new AdditionalInfoContext();
            app.InitializeComponent();
            app.Run();
        }

        public static void ExitApp()
        {
            Current.Shutdown();
        }
    }
}

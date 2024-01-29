using PsychTestsMilitary.Constructors;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.Services.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PsychTestsMilitary.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AppExit(object sender, EventArgs e)
        {
            App.ExitApp();
        }

        private void AppRegistration(object sender, EventArgs e)
        {
            RegistrationForm form = new RegistrationForm();
            form.Show(); this.Close();
        }

        private void AppChoosingTests(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.Show(); this.Close();
        }

        private void Authorization(object sender, EventArgs e)
        {
            AuthorizationWindow window = new AuthorizationWindow();
            window.Owner = this;
            window.ShowDialog();

        }

        private void DeveloperToolsClick(object sender, RoutedEventArgs e)
        {
            DeveloperToolsConstructor window1 = new DeveloperToolsConstructor();
            window1.Show(); this.Close();
        }
    }
}

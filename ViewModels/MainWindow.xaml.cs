using PsychTestsMilitary.Constructors;
using System;
using System.Windows;

namespace PsychTestsMilitary.ViewModels
{
    public partial class MainWindow : BaseWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AppExit(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

        private void AppRegistration(object sender, EventArgs e)
        {
            RegistrationForm form = new RegistrationForm();
            form.Show();
            base.Close();
        }

        private void AppChoosingTests(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.Show();
            base.Close();
        }

        private void Authorization(object sender, EventArgs e)
        {
            AuthorizationWindow window = new AuthorizationWindow();
            //window.Owner = this;
            window.ShowDialog();

        }

        private void DeveloperToolsClick(object sender, RoutedEventArgs e)
        {
            DeveloperToolsConstructor window1 = new DeveloperToolsConstructor();
            window1.Show(); 
            base.Close();
        }
    }
}

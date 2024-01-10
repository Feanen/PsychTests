using System.Windows;

namespace PsychTestsMilitary.ViewModels
{
    public partial class SuccessMessageBox : Window
    {
        public string SuccessMessage { get; set; }

        public SuccessMessageBox(string successMessage)
        {
            InitializeComponent();
            SuccessMessage = successMessage;
            DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void GoToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

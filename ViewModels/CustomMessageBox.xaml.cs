using System.Windows;

namespace PsychTestsMilitary.ViewModels
{
    public partial class CustomMessageBox : Window
    {
        public string ErrorMessage { get; set; }

        public CustomMessageBox(string errorMessage)
        {
            InitializeComponent();
            ErrorMessage = errorMessage;
            DataContext = this;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PsychTestsMilitary.ViewModels
{
    public partial class LicenseExpiredWindow : BaseWindowWithEditableFields
    {
        public LicenseExpiredWindow()
        {
            InitializeComponent();
            Closing += WindowClosing;
        }
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            Application.Current.Shutdown();
        }

        protected override void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Application.Current.Shutdown();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

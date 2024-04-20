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
        }
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            Close();
        }

        protected override void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Close();
        }
    }
}

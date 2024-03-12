using PsychTestsMilitary.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PsychTestsMilitary.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class SuperUserValidationWindow : BaseWindowWithEditableFields
    {
        public SuperUserValidationWindow()
        {
            InitializeComponent();
        }
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "accept":
                    CheckSUPassword();
                    break;
                case "cancel":
                    DialogResult = false;
                    this.Close();
                    break;
            }
        }

        private void CheckSUPassword()
        {
            if (PasswordHasher.CheckOnSuperUserPassword(password.Password))
            {
                DialogResult = true;
                this.Close();
            }
        }

        protected override void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CheckSUPassword();
        }
    }
}

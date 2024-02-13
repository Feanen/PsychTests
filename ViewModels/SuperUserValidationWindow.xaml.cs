using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

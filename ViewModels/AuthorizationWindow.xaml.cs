using PsychTestsMilitary.Constructors;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.Services.Singletons;
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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "accept":
                    VerifyAccountAndPassword(login.Text, password.Password);
                    break;
                case "cancel":
                    this.Close();
                    break;
            }
        }
        private void VerifyAccountAndPassword(string login, string pwd)
        {
            using (AccountContext context = new AccountContext())
            {
                if (!context.CheckOnUniqueAccount(login))
                {
                    MessageBox.Show("No user with login: " + login);
                } else
                {
                    bool isUser = PasswordHasher.CheckOnUserPassword(pwd);

                    if (((bool)isPsychologist.IsChecked ^ isUser) && context.CheckOnCorrectPassword(pwd))
                    {
                        CurrentUserSingleton.CurrentAcc = context.CurrentAccount;

                        ShowNextWindow(isUser);
                    }
                    else
                    {
                        MessageBox.Show("Invalid password");
                    }
                }
            }
        }

        private void ShowNextWindow(bool isUser)
        {
            this.Close();
            Owner.Hide();

            Window wind = null;

            if (isUser)
                wind = new UserForm();
            else
                wind = new DeveloperToolsConstructor();

            wind.Show();
        }

        private void CheckedPsychologystCB(object sender, RoutedEventArgs e)
        {
            password.IsEnabled = true;
            password.Background = Brushes.White;
        }

        private void UncheckedPsychologistCB(object sender, RoutedEventArgs e)
        {
            password.IsEnabled = false;
            password.Background = Brushes.Gray;
            password.Password = "";
        }
    }
}

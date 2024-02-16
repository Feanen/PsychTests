﻿using PsychTestsMilitary.Constructors;
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
    public partial class AuthorizationWindow : BaseWindowWithEditableFields
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
                    base.Close();
                    break;
            }
        }
        private void VerifyAccountAndPassword(string login, string pwd)
        {
            using (AccountContext context = new AccountContext())
            {
                if (!context.CheckOnUniqueAccount(login))
                    MessageBox.Show("No user with login: " + login);
                else
                {
                    bool isUser = PasswordHasher.CheckOnUserPassword(pwd);

                    if (((bool)isPsychologist.IsChecked ^ isUser) && context.CheckOnCorrectPassword(pwd))
                    {
                        CurrentUserSingleton.CurrentAcc = context.CurrentAccount;
                        ShowNextWindow(isUser);
                    }
                    else
                        MessageBox.Show("Invalid password");
                }
            }
        }

        private void ShowNextWindow(bool isUser)
        {
            Close();
            Owner.Hide();

            Window wind = null;

            if (isUser)
                wind = new UserForm();
            else
                wind = new PsychologistWndow();

            wind.Show();
        }

        private void CheckedPsychologystCB(object sender, RoutedEventArgs e)
        {
            password.Visibility = Visibility.Visible;
        }

        private void UncheckedPsychologistCB(object sender, RoutedEventArgs e)
        {
            password.Visibility = Visibility.Hidden;
            password.Password = string.Empty;
        }

        protected override void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                VerifyAccountAndPassword(login.Text, password.Password);
        }
    }
}

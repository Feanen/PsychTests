﻿using PsychTestsMilitary.Services;
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
    public partial class SuperUserValidationWindow : BaseWindow
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
                    if (PasswordHasher.CheckOnSuperUserPassword(password.Password))
                    {
                        DialogResult = true;
                        this.Close();
                    }
                    else
                        wrongPassInfo.Visibility = Visibility.Visible;
                    break;
                case "cancel":
                    DialogResult = false;
                    this.Close();
                    break;
            }
        }
    }
}

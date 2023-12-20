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
using PsychTestsMilitary.Services.Contexts;

using PsychTestsMilitary.Models;

namespace PsychTestsMilitary.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        AccountContext database;
        public RegistrationForm()
        {
            InitializeComponent();
            database = new AccountContext();
        }

        public void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "backButton":
                    ShowMainWindow();
                    break;
                case "registrationButton":
                    Account acc = CreateAccountData();
                    if (!ValidateAccData(acc)) {
                        Console.WriteLine("ddddddd");
                    } else
                    {
                        ShowMainWindow();
                    }
                    break;
            }
        }

        private Account CreateAccountData()
        {
            return new Account(login.Text, surname.Text, name.Text, fname.Text,
                              (gender.SelectedItem as ComboBoxItem).Content.ToString(), birthday.SelectedDate.ToString().Split(' ')[0],
                              job.Text, spec.Text, rank.Text);
        }

        private void ShowMainWindow()
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private bool ValidateAccData(Account acc) 
        {
            // first step for validating account data
            if (acc.Login.Equals(login.Tag) || acc.Surname.Equals(surname.Tag) ||
                acc.Name.Equals(name.Tag) || acc.FName.Equals(fname.Tag) ||
                acc.Gender.Equals((gender.Items.GetItemAt(0) as ComboBoxItem).Content.ToString()) ||
                acc.Job.Equals(job.Tag) || acc.Spec.Equals(spec.Tag) || acc.Rank.Equals(rank.Tag) || !Date.checkOnCriticalAge(acc.Birthday))
            {
                MessageBox.Show("Невірно вказані дані");
                return false;
            }
            else
            {
                return true;
            } 
        }
        public void FocusOn(object sender, EventArgs e)
        {
            Control textBox = (Control)sender;
            string defaultValue = textBox.Tag as string;
            PlaceholderService placeHolder = new PlaceholderService(textBox);
            placeHolder.GotFocus(sender, e);
        }

        public void FocusOff(object sender, EventArgs e)
        {
            Control textBox = (Control)sender;
            string defaultValue = textBox.Tag as string;
            PlaceholderService placeHolder = new PlaceholderService(textBox);
            placeHolder.LostFocus(sender, e);
        }

        public void DataChanged(object sender, EventArgs e)
        {
            if (sender is DatePicker picker)
            {
                picker.Opacity = 1.0f;
                picker.Focusable = false;
            }
        }
#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public void Loaded(object sender, EventArgs e)
#pragma warning restore CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        {
            this.FocusOff(sender, e);
        }
    }
}

using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.Contexts;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PsychTestsMilitary.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class RegistrationForm : BaseWindowWithEditableFields
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "backButton":
                    ShowMainWindow();
                    break;
                case "registrationButton":
                    if (!ValidateAccData())
                    {
                        MessageBox.Show("Невірно вказані дані");
                    }
                    else
                    {
                        Account acc = CreateAccountData();

                        using (AccountContext db = new AccountContext())
                        {
                            if (db.CheckOnUniqueAccount(acc.login))
                            {
                                MessageBox.Show("Користувач з таким логіном вже існує!");
                                return;
                            }

                            db.Accounts.Add(acc);
                            db.SaveChanges();
                            MessageBox.Show("Реєстрація пройшла успішно!");
                        }
                    }
                    break;
            }
        }

        private void PsychologistCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                if (ShowSUValidationWindow())
                {
                    job.Visibility = spec.Visibility = rank.Visibility = Visibility.Hidden;
                    job.Text = spec.Text = rank.Text = null;
                    pass.Visibility = repass.Visibility = Visibility.Visible;
                }
                else
                {
                    (sender as CheckBox).IsChecked = false;
                }
            }
            else
            {
                job.Visibility = spec.Visibility = rank.Visibility = Visibility.Visible;
                pass.Visibility = repass.Visibility = Visibility.Hidden;
            }
        }

        private bool ShowSUValidationWindow()
        {
            Window suvalidwindow = new SuperUserValidationWindow();
            suvalidwindow.Owner = this;
            return (bool)suvalidwindow.ShowDialog();
        }

        private Account CreateAccountData()
        {
            return new Account(login.Text, surname.Text, name.Text, fname.Text,
                              (gender.SelectedItem as ComboBoxItem).Content.ToString(), birthday.SelectedDate.ToString().Split(' ')[0],
                              job.Text = (job.Text.Equals(job.Tag)) ? null : job.Text,
                              spec.Text = (spec.Text.Equals(spec.Tag)) ? null : spec.Text,
                              rank.Text = (rank.Text.Equals(rank.Tag)) ? null : rank.Text,
                              PasswordHasher.HashPassword(pass.Password));
        }

        private void ShowMainWindow()
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private bool ValidateAccData()
        {
            if ((bool)isPsychologist.IsChecked)
            {
                if (login.Text.Equals(login.Tag) || surname.Text.Equals(surname.Tag) ||
                    name.Text.Equals(name.Tag) || fname.Equals(fname.Tag) ||
                    (gender.SelectedItem as ComboBoxItem).Equals((gender.Items.GetItemAt(0) as ComboBoxItem).Content.ToString()) ||
                    !Date.CheckOnCriticalAge(birthday.SelectedDate.ToString().Split(' ')[0]) || pass.Password != repass.Password)
                { return false; }
                else { return true; }
            }
            else
            {
                if (login.Text.Equals(login.Tag) || surname.Text.Equals(surname.Tag) ||
                    name.Text.Equals(name.Tag) || fname.Equals(fname.Tag) ||
                    (gender.SelectedItem as ComboBoxItem).Equals((gender.Items.GetItemAt(0) as ComboBoxItem).Content.ToString()) ||
                    job.Text.Equals(job.Tag) || spec.Text.Equals(spec.Tag) || rank.Text.Equals(rank.Tag) ||
                    !Date.CheckOnCriticalAge(birthday.SelectedDate.ToString().Split(' ')[0]))
                { return false; }
                else { return true; }
            }
        }

        public void DataChanged(object sender, EventArgs e)
        {
            if (sender is DatePicker picker)
            {
                picker.Opacity = 1.0f;
                picker.Focusable = false;
            }
        }

        protected override void KeyDownHandler(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

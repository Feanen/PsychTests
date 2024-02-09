using PsychTestsMilitary.Models;
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
    /// Логика взаимодействия для PsychologistWndow.xaml
    /// </summary>
    public partial class PsychologistWndow : BaseWindow
    {
        private static AccountTrie accountData = new AccountTrie();
        private static Dictionary<string, string> accounts;

        public PsychologistWndow()
        {
            InitializeComponent();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            accounts = accountData.Autocomplete(text.Text);

            if (accounts != null)
                dropList.ItemsSource = accounts.Values;
        }

        private void DropListSelected(object sender, EventArgs e)
        {
            if (dropList.ItemsSource != null)
            {
                text.Text = dropList.SelectedItem.ToString();
                data.ItemsSource = TechniquesManager.GetUserResults(accounts.Keys.FirstOrDefault());
                dropList.ItemsSource = null;
            }
        }

        private void FocusOn(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
                (sender as TextBox).Text = null;
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "showResults":
                    ResultsManager manager = new ResultsManager();
                    CalculationService calculationService = manager.GetCalculationService((data.SelectedItem as CompletedTechniquesModel).Answers);
                    Window window = calculationService.ShowResults();
                    window.Owner = this;
                    window.ShowDialog();
                    break;
            }
        }
    }
}

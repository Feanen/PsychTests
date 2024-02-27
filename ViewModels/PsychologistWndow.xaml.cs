using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


        private double thumbOffset;

        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            var scrollBar = (ScrollBar)sender;
            thumbOffset = scrollBar.Value;
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var scrollBar = (ScrollBar)sender;
            var offset = thumbOffset - e.VerticalChange;
        }

        private void Thumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            thumbOffset = 0;
        }
    }
}

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
    public partial class PsychologistWindow : BaseWindow
    {
        private static AccountTrie accountData = new AccountTrie();
        private static Dictionary<string, string> accounts;

        public PsychologistWindow()
        {
            InitializeComponent();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            accounts = accountData.Autocomplete(selectedData.Text);

            if (accounts != null)
                dropList.ItemsSource = accounts.Values;
        }

        private void DropListSelected(object sender, EventArgs e)
        {
            if (dropList.ItemsSource != null)
            {
                selectedData.Text = dropList.SelectedItem.ToString();
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
                    CompletedTechniquesModel selectedItem = data.SelectedItem as CompletedTechniquesModel;
                    CalculationService calculationService = manager.GetCalculationService(selectedItem.Answers);
                    Window window = calculationService.ShowResults(selectedData.Text, selectedItem.Answers.Date, selectedItem.Name);
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

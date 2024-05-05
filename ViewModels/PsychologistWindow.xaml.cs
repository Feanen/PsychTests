﻿using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.Singletons;
using PsychTestsMilitary.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace PsychTestsMilitary.ViewModels
{
    public partial class PsychologistWindow : BaseWindow, IFullScreenable
    {
        private static AccountTrie accountData = new AccountTrie();
        private static Dictionary<Account, string> accounts;
        private static Account selectedAcc;
        private double thumbOffset;

        public PsychologistWindow()
        {
            InitializeComponent();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedData.Text = StringFormatter.Format(selectedData.Text);
            selectedData.CaretIndex = selectedData.Text.Length;
            selectedData.ScrollToEnd();
            accounts = accountData.Autocomplete(selectedData.Text);

            if (accounts != null)
                dropList.ItemsSource = accounts.Values;
        }

        private void DropListSelected(object sender, EventArgs e)
        {
            if (dropList.ItemsSource != null)
            {
                selectedData.Text = dropList.SelectedItem.ToString();
                selectedAcc = accounts.Keys.FirstOrDefault();
                CurrentUserSingleton.CurrentAcc = selectedAcc;
                data.ItemsSource = TechniquesManager.GetUserResults(selectedAcc);
                dropList.ItemsSource = null;
            }
        }

        private void FocusOn(object sender, RoutedEventArgs e)
        {
            selectedData.Text = null;

            if (data.HasItems)
                data.ItemsSource = null;
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "showResults":
                    if (data.SelectedItem != null) 
                    {
                        ResultsManager manager = new ResultsManager();
                        CompletedTechniquesModel selectedItem = data.SelectedItem as CompletedTechniquesModel;
                        CalculationService calculationService = manager.GetCalculationService(selectedAcc, selectedItem.Answers);
                        calculationService.CalculationProcess();
                        Window window = calculationService.ShowResults(selectedAcc, selectedItem.Answers.Date, selectedItem.Name);
                        window.Owner = this;
                        window.ShowDialog();  
                    }

                    break;
            }
        }

        private void TooltipClicked(object sender, RoutedEventArgs e)
        {
            Window window = new TooltipWindow();
            window.Owner = this;
            window.ShowDialog();
        }

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

        public void OnFullScreen()
        {
            SetWindowScale(mainGrid, ScreenManager.SetDynamicFullScreen());
        }
    }
}

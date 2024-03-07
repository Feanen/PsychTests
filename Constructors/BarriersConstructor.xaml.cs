using PsychTestsMilitary.Models.AdditionalModels;
using PsychTestsMilitary.Services.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.Constructors
{
    public partial class BarriersConstructor : Window
    {
        private AdditionalInfoContext context = new AdditionalInfoContext();
        private int index = 0;
        public BarriersConstructor()
        {
            InitializeComponent();
        }


        public void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "back":
                    DeveloperToolsConstructor wnd = new DeveloperToolsConstructor();
                    this.Close();
                    wnd.Show();
                    break;
                case "addPair":
                    AddPair(number.Text, result.Text);
                    int nextBarrIndex = Int32.Parse(number.Text) + 1;
                    number.Text = nextBarrIndex.ToString();
                    result.Text = "";
                    break;
            }
        }

        private void AddPair(string nmbr, string resultD)
        {
            Barrier brr = new Barrier(index++, (scale.SelectedItem as Scale).id, Int32.Parse(nmbr), resultD);
            context.Barriers.Add(brr);
            context.SaveChanges();
            Update();
        }

        private async Task<List<Scale>> GetScales()
        {
            return await context.Scales.ToListAsync();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Scale> scales = await GetScales();
            scale.ItemsSource = scales;
            scale.DisplayMemberPath = "Name";

            Barrier lastRecord = ((context.Barriers.OrderByDescending(q => q.barrierID).FirstOrDefault()) as Barrier);
            index = (lastRecord == null) ? 0 : lastRecord.barrierID;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (scale.SelectedItem != null)
                Update();
        }

        private void Update()
        {
            Scale selectedScale = (Scale)scale.SelectedItem;
        }
    }
}

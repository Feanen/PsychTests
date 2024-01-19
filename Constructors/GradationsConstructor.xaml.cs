using PsychTestsMilitary.Models;
using PsychTestsMilitary.Models.AdditionalModels;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

namespace PsychTestsMilitary.Constructors
{
    public partial class GradationsConstructor : Window
    {
        private AdditionalInfoContext context = new AdditionalInfoContext();
        private int index = 0;
        private int currentIndex = 0;
        public GradationsConstructor()
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
                    AddPair(Int32.Parse(min.Text), Int32.Parse(max.Text));
                    break;
            }
        }

        private void AddPair(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                Gradation grad = new Gradation(index++, (barrierID.SelectedItem as Barrier).barrierID, i);
                context.Gradations.Add(grad);
            }
            
            context.SaveChanges();
            Update();
        }

        private async Task<List<Barrier>> GetBarriers()
        {
            return await context.Barriers.ToListAsync();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Barrier> barriers = await GetBarriers();
            barrierID.ItemsSource = barriers;
            barrierID.DisplayMemberPath = "barrierID";

            Gradation lastRecord = ((context.Gradations.OrderByDescending(q => q.gradationID).FirstOrDefault()) as Gradation);
            index = (lastRecord == null) ? 0 : lastRecord.gradationID;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            min.Text = max.Text = "";
            currentIndex = (sender as ComboBox).SelectedIndex;
            Update();    
        }

        private void Update()
        {
            barrierID.SelectedIndex = currentIndex++;
            Barrier selectedBarrier = (Barrier) barrierID.SelectedItem;
            info.Text = selectedBarrier.Result;
        }
    }
}

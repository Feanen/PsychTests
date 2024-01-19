using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueA : Window
    {
        public TechniqueA() {}

        public TechniqueA(string[] finalResults)
        {
            InitializeComponent();
            Update(finalResults);
        }

        private void Update(string[] fr)
        {
            int index = 0;

            foreach (var tb in grid.Children.OfType<TextBlock>())
            {
                tb.Text = fr[index];
                index++;
            }
        }
    }
}

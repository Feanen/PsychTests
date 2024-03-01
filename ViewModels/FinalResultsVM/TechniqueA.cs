using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueA : BaseResultsWindow
    {
        public TechniqueA() : base() { }

        public TechniqueA(string[] finalResults, string pd, string ctp, string tn) : base(finalResults, pd, ctp, tn)
        {
            InitializeComponent();
            DataContext = this;
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

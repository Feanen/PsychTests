using PsychTestsMilitary.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueI : BaseResultsWindow
    {
        public TechniqueI() : base() { }

        public TechniqueI(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
        {
            InitializeComponent();
            DataContext = this;
        }

        protected override UIElement GetDataElement()
        {
            return grid;
        }

        protected override List<string> GetListOfScales(UIElement element)
        {
            if (element != null)
            {
                if (element is Grid grid)
                {
                    List<string> listOfScales = new List<string>();
                    int index = 0;

                    foreach (var child in grid.Children)
                    {
                        if (child is TextBlock tb && Grid.GetColumn(tb) == 0)
                            listOfScales.Add(tb?.Text.ToString());
                        index++;
                    }

                    return listOfScales;
                }
            }

            return null;
        }
    }
}

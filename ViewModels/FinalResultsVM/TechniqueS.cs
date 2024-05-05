using PsychTestsMilitary.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueS : BaseResultsWindow
    {
        public TechniqueS() : base() { }

        public TechniqueS(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
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
                if (element is Grid grd)
                {
                    List<string> listOfScales = new List<string>();
                    int index = 0;

                    foreach (var child in grd.Children)
                    {
                        if (child is Label label && Grid.GetColumn(label) == 0 && Grid.GetRow(label) != 0)
                            listOfScales.Add(label?.Content.ToString());
                        index++;
                    }

                    return listOfScales;
                }
            }

            return null;
        }
    }
}

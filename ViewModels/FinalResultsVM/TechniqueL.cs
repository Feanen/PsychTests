using PsychTestsMilitary.Models;
using System.Collections.Generic;
using System.Windows;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueL : BaseResultsWindow
    {
        public TechniqueL() : base() { }

        public TechniqueL(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
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
            return new List<string> { string.Empty };
        }
    }
}

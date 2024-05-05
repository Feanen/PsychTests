using PsychTestsMilitary.Models;
using System.Collections.Generic;
using System.Windows;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueH : BaseResultsWindow
    {
        public TechniqueH() : base() { }

        public TechniqueH(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
        {
            InitializeComponent();
            DataContext = this;
        }

        protected override UIElement GetDataElement()
        {
            return grid;
        }
    }
}

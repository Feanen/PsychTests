using PsychTestsMilitary.Models;
using System.Collections.Generic;
using System.Windows;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueF : BaseResultsWindow
    {
        public TechniqueF() : base() { }

        public TechniqueF(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
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

using PsychTestsMilitary.Models;
using System.Collections.Generic;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueT : BaseResultsWindow
    {
        public TechniqueT() : base() { }

        public TechniqueT(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

using PsychTestsMilitary.Models;
using System.Collections.Generic;

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
    }
}

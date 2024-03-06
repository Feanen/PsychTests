using PsychTestsMilitary.Models;
using PsychTestsMilitary.ViewModels;
using System.Collections.Generic;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueD : BaseResultsWindow
    {
        public TechniqueD() : base() { }

        public TechniqueD(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

using PsychTestsMilitary.Models;
using System.Collections.Generic;

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
    }
}

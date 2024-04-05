using PsychTestsMilitary.Models;
using System.Collections.Generic;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueQ : BaseResultsWindow
    {
        public TechniqueQ() : base() { }

        public TechniqueQ(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

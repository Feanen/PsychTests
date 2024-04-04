using PsychTestsMilitary.Models;
using System.Collections.Generic;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueO : BaseResultsWindow
    {
        public TechniqueO() : base() { }

        public TechniqueO(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

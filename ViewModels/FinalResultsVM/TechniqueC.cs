﻿using PsychTestsMilitary.Models;
using System.Collections.Generic;
using System.Windows;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueC : BaseResultsWindow
    {
        public TechniqueC() : base() { }

        public TechniqueC(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
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

using PsychTestsMilitary.Models;
using PsychTestsMilitary.Templates;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueR : BaseResultsWindow
    {
        public TechniqueR() : base() { }

        public TechniqueR(List<ScaleResult> ur, string pd, string ctp, string tn) : base(ur, pd, ctp, tn)
        {
            InitializeComponent();
            DataContext = this;

            ObservableCollection<ScaleResult> scaleResults = new ObservableCollection<ScaleResult>(ur);

            for (int i = 0; i < scaleResults.Count; i++)
                grid.RowDefinitions.Add(new RowDefinition());

            for (int i = 0; i < scaleResults.Count; i++)
            {           
                QuestionAndResultUserControl questionAndResultUserControl = new QuestionAndResultUserControl();
                questionAndResultUserControl.DataContext = scaleResults[i];
                grid.Children.Add(questionAndResultUserControl);
                Grid.SetRow(questionAndResultUserControl, i);
            }
        }

        protected override UIElement GetDataElement()
        {
            throw new System.NotImplementedException();
        }
    }
}

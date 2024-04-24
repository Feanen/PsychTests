using PsychTestsMilitary.Services.Singletons;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels
{
    public partial class TooltipWindow : BaseWindow
    {
        public TooltipWindow() 
        {
            InitializeComponent();
            DataContext = this;

            ObservableCollection<string> techniques = new ObservableCollection<string>(TechniquesDBSingleton.Instance.GetTechniqueContext().Techniques.
                                                                                                             Select(t => t.Name).ToList());
            
            for (int i = 0; i < techniques.Count; i++)
                grid.RowDefinitions.Add(new RowDefinition());

            Style style = (Style)FindResource("ResultsWindowDescriptionStyle");

            for (int i = 0; i < techniques.Count; i++)
            {
                TextBlock tech = new TextBlock();
                tech.Style = style;
                tech.Text = (i + 1) + ". " + techniques[i];
                grid.Children.Add(tech);
                Grid.SetRow(tech, i);
            }
        }
    }
}

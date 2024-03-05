using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels.FinalResults
{
    public partial class TechniqueB : BaseResultsWindow
    {
        public ObservableCollection<DataSet> Results { get; set; }
        public Dictionary<double, string> DataSet
        {
            get { return (Dictionary<double, string>) GetValue(dataSetProperty); }
            set { SetValue(dataSetProperty, value); }
        }

        public static readonly DependencyProperty dataSetProperty =
            DependencyProperty.Register("DataSet", typeof(Dictionary<double, string>), typeof(TechniqueB), new PropertyMetadata(null));


        public TechniqueB() : base() { }

        public TechniqueB(string[] finalResults, string pd, string ctp, string tn) : base(finalResults, pd, ctp, tn)
        {
        }

        public TechniqueB(Dictionary<double, string> dataSet, string pd, string ctp, string tn) : base(dataSet, pd, ctp, tn)
        {
            DataSet = dataSet;
            InitializeComponent();
            DataContext = this;
        }
    }

    internal class DataSet()
    {

    }
}

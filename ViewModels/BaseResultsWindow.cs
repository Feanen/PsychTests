using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels
{
    public abstract class BaseResultsWindow : BaseWindow
    {
        protected string PersonalData
        {
            get { return (string) GetValue(personalData); }
            set { SetValue(personalData, value); }
        }

        protected string CompletedTechniqueDate
        {
            get { return (string) GetValue(completedTechniqueDateProperty); }
            set { SetValue(completedTechniqueDateProperty, ("Дата проходження: " + value)); }
        }

        protected string TechniqueName
        {
            get { return (string) GetValue(techniqueName); }
            set { SetValue(techniqueName, value); }
        }

        public static readonly DependencyProperty techniqueName =
            DependencyProperty.Register("TechniqueName", typeof(string), typeof(BaseResultsWindow), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty completedTechniqueDateProperty =
            DependencyProperty.Register("CompletedTechniqueDate", typeof(string), typeof(BaseResultsWindow), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty personalData =
            DependencyProperty.Register("PersonalData", typeof(string), typeof(BaseResultsWindow), new PropertyMetadata(string.Empty));


        public BaseResultsWindow() : base() { }

        public BaseResultsWindow(string[] finalResults, string pd, string ctp, string tn)
        {
            PersonalData = pd;
            CompletedTechniqueDate = ctp;
            TechniqueName = tn;
        }
    }
}

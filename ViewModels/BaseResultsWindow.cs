using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.ViewModels
{
    public abstract class BaseResultsWindow : BaseWindow
    {
        //----------------------------------------//
        protected List<ScaleResult> UserResults
        {
            get { return (List<ScaleResult>)GetValue(userResultsProperty); }
            set { SetValue(userResultsProperty, value); }
        }

        protected string PersonalData
        {
            get { return (string)GetValue(personalData); }
            set { SetValue(personalData, value); }
        }

        protected string CompletedTechniqueDate
        {
            get { return (string)GetValue(completedTechniqueDateProperty); }
            set { SetValue(completedTechniqueDateProperty, "Дата проходження: " + value); }
        }

        protected string TechniqueName
        {
            get { return (string)GetValue(techniqueName); }
            set { SetValue(techniqueName, value); }
        }

        public static readonly DependencyProperty techniqueName =
            DependencyProperty.Register("TechniqueName", typeof(string), typeof(BaseResultsWindow), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty completedTechniqueDateProperty =
            DependencyProperty.Register("CompletedTechniqueDate", typeof(string), typeof(BaseResultsWindow), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty personalData =
            DependencyProperty.Register("PersonalData", typeof(string), typeof(BaseResultsWindow), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty userResultsProperty =
            DependencyProperty.Register("DataSet", typeof(List<ScaleResult>), typeof(BaseResultsWindow), new PropertyMetadata(null));

        //----------------------------------------//

        public BaseResultsWindow() : base() { }

        public BaseResultsWindow(string[] finalResults, string pd, string ctp, string tn)
        {
            PersonalData = pd;
            CompletedTechniqueDate = ctp;
            TechniqueName = tn;
        }

        public BaseResultsWindow(List<ScaleResult> ur, string pd, string ctp, string tn)
        {
            UserResults = ur;
            PersonalData = pd;
            CompletedTechniqueDate = ctp;
            TechniqueName = tn;
        }

        protected virtual void SaveToClipboardClicked(object sender, RoutedEventArgs e)
        {
            ClipboardManager.SaveToClipboard(GetListOfScales(GetDataElement()), 
                                             TechniqueName, CompletedTechniqueDate,
                                             UserResults);
        }

        protected abstract UIElement GetDataElement();

        protected new void CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected virtual List<string> GetListOfScales(UIElement element)
        {
            if (element != null)
            {
                if (element is Grid grid)
                {
                    List<string> listOfScales = new List<string>();
                    int index = 0;

                    foreach (var child in grid.Children)
                    {
                        if (child is Label label && Grid.GetColumn(label) == 0)
                            listOfScales.Add(label?.Content.ToString());
                        index++;
                    }

                    return listOfScales;
                }
            }

            return null;
        } 
    }
}

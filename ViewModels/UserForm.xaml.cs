using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.Services.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PsychTestsMilitary.ViewModels
{
    public partial class UserForm : BaseWindow
    {
        private List<Dictionary<CheckBox, Technique>> connectionBetweenCheckboxAndTechnique = new List<Dictionary<CheckBox, Technique>>();
        private const byte numberOfTechniquesInAColumn = 5;

        public UserForm()
        {
            InitializeComponent();
            ConnectDictionaryData();
        }

        private void ConnectDictionaryData()
        {
            List<Technique> techniques;
            techniques = TechniquesDBSingleton.Instance.GetTechniqueContext().Techniques.ToList();
            IEnumerator<Technique> enumerator = techniques.GetEnumerator();

            //foreach (UIElement element in grid.Children)
            //{
            //    if (element is CheckBox)
            //    {
            //        if (enumerator.MoveNext())
            //        {
            //            connectionBetweenCheckboxAndTechnique.Add(element as CheckBox, enumerator.Current);
            //        }
            //    } else if (element is TextBlock)
            //    {
            //        if (enumerator.Current != null)
            //        {
            //            (element as TextBlock).Text = enumerator.Current.Name;
            //        }   
            //    }
            //}
            Dictionary<CheckBox, Technique> listOfTechs = new Dictionary<CheckBox, Technique>();
            foreach (Technique technique in techniques)
            {
                if (enumerator.MoveNext())
                {
                    if (listOfTechs.Count.Equals(numberOfTechniquesInAColumn))
                    {
                        connectionBetweenCheckboxAndTechnique.Add(listOfTechs);
                        listOfTechs = new Dictionary<CheckBox, Technique>();
                    }
                    else
                    {
                        listOfTechs.Add(FindName("checkBox" + listOfTechs.Count) as CheckBox, enumerator.Current);
                    }       
                } 
                else
                {
                    connectionBetweenCheckboxAndTechnique.Add(listOfTechs);
                }
            }
        }

        private void BeginButtonClicked(object sender, RoutedEventArgs e)
        {
            Queue<Technique> chosenTests = new Queue<Technique>();

            //foreach (List<KeyValuePair<CheckBox, Technique>> pair in connectionBetweenCheckboxAndTechnique)
            //{
            //    if ((bool) pair.Key.IsChecked)
            //        chosenTests.Enqueue(pair.Value);
            //}

            if (chosenTests.Count > 0)
            {
                TestsQueueSingleton.Instance.Techniques = chosenTests;
                TechniquesManager.RunNextTechnique();
                this.Close();
            }
        }
    }
}

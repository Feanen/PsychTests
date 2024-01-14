using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.Contexts;
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
    public partial class UserForm : Window
    {
        private Dictionary<CheckBox, Technique> connectionBetweenCheckboxAndTechnique = new Dictionary<CheckBox, Technique>();
        public UserForm()
        {
            InitializeComponent();
            ConnectDictionaryData();
        }

        private void ConnectDictionaryData()
        {
           List<Technique> techniques;

            using (TechniquesContext context = new TechniquesContext())
            {
                techniques = context.Techniques.ToList();
            }

            IEnumerator<Technique> enumerator = techniques.GetEnumerator();

            foreach (UIElement element in grid.Children)
            {
                if (element is CheckBox)
                {
                    if (enumerator.MoveNext())
                    {
                        connectionBetweenCheckboxAndTechnique.Add(element as CheckBox, enumerator.Current);
                    }
                } else if (element is TextBlock)
                {
                    if (enumerator.Current != null)
                    {
                        (element as TextBlock).Text = enumerator.Current.Name;
                    }   
                }
            }
        }

        private void BeginButtonClicked(object sender, RoutedEventArgs e)
        {
            Queue<Technique> chosenTests = new Queue<Technique>();

            foreach (KeyValuePair<CheckBox, Technique> pair in connectionBetweenCheckboxAndTechnique)
            {
                if ((bool) pair.Key.IsChecked)
                    chosenTests.Enqueue(pair.Value);
            }

            if (chosenTests.Count > 0)
            {
                TestsQueueSingleton.Instance.Techniques = chosenTests;
                TechniquesManager.RunNextTechnique();
                this.Close();
            }
        }
    }
}

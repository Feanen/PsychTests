using PsychTestsMilitary.Models;
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
        private Dictionary<CheckBox, Technique> connectionBetweenCheckboxAndTechnique;
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

            foreach (UIElement element in stackPanel.Children)
            {
                if (element is CheckBox)
                {

                    connectionBetweenCheckboxAndTechnique.Add(element, techniques.MoveNex)
                }
            }
        }
    }
}

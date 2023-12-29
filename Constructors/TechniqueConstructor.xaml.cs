using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace PsychTestsMilitary.Constructors
{
    /// <summary>
    /// Логика взаимодействия для Technique.xaml
    /// </summary>
    public partial class TechniqueConstructor : Window
    {
        int id = 8;
        public TechniqueConstructor()
        {
            InitializeComponent();
        }

        public void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Technique technique = new Technique(id, this.name.Text, this.instruction.Text);

            using (TechniquesContext context = new TechniquesContext()) 
            { 
                context.Techniques.Add(technique);
                context.SaveChanges();
                name.Text = "";
                instruction.Text = "";
            };

            id++;
        }
    }
}

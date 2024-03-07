using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Contexts;
using System.Windows;

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
            Technique technique = new Technique(id, this.name.Text, this.instruction.Text, 0);

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

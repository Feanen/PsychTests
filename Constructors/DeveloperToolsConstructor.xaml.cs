using PsychTestsMilitary.Services;
using PsychTestsMilitary.Services.TechniqueCalculations;
using PsychTestsMilitary.ViewModels;
using PsychTestsMilitary.ViewModels.FinalResults;
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

namespace PsychTestsMilitary.Constructors
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class DeveloperToolsConstructor : Window
    {
        public DeveloperToolsConstructor()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Window window = null;

            switch (button.Name) {
                case "techniques":
                    window = new TechniqueConstructor();
                    break;
                case "questions":
                    window = new QuestionsConstructor();
                    break;
                case "keys":
                    window = new TechniqueKeysConstructor();
                    break;
                    
                case "back":
                    window = new MainWindow();
                    break;
                case "test":
                    CalculationService calculationService = new TechniqueACalculationService("feanen1", 1);
                    calculationService.CalculationProcess();
                    window = new TechniqueA(calculationService.ShowResults());
                    break;
                case "barriers":
                    window = new BarriersConstructor();
                    break;
                case "gradations":
                    window = new GradationsConstructor();
                    break;
                case "pwds":
                    string result = PasswordHasher.HashPassword("");
                    break;
           }

            window.Show();
            this.Close();
        }
    }
}

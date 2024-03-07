using PsychTestsMilitary.Services;
using PsychTestsMilitary.ViewModels;
using System.Windows;
using System.Windows.Controls;

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

            switch (button.Name)
            {
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
                    //CalculationService calculationService = new TechniqueACalculationService("feanen1", 1);
                    //calculationService.CalculationProcess();
                    //window = new TechniqueA(calculationService.ShowResults());
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

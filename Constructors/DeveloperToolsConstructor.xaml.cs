using PsychTestsMilitary.ViewModels;
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
                case "back":
                    window = new MainWindow();
                    break;
           }

            window.Show();
            this.Close();
        }
    }
}

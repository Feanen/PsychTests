using PsychTestsMilitary.Services;
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
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        public void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "backButton":
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                    break;
                case "registrationButton":
                    break;
            }
        }

        public void FocusOn(object sender, EventArgs e)
        {
            Control textBox = (Control)sender;
            string defaultValue = textBox.Tag as string;
            PlaceholderService placeHolder = new PlaceholderService(textBox);
            placeHolder.GotFocus(sender, e);
        }

        public void FocusOff(object sender, EventArgs e)
        {
            Control textBox = (Control)sender;
            string defaultValue = textBox.Tag as string;
            PlaceholderService placeHolder = new PlaceholderService(textBox);
            placeHolder.LostFocus(sender, e);
        }

        public void DataChanged(object sender, EventArgs e)
        {
            if (sender is DatePicker picker)
            {
                picker.Opacity = 1.0f;
                picker.Focusable = false;
            }
        }
#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public void Loaded(object sender, EventArgs e)
#pragma warning restore CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        {
            this.FocusOff(sender, e);
        }
    }
}

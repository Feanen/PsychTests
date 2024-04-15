using System.Windows;
using System.Windows.Input;

namespace PsychTestsMilitary.ViewModels
{
    public abstract class BaseWindow : Window
    {
        public BaseWindow() : base() { }

        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        protected void MinimizeButtonClicked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        protected void MaximizeButtonClicked(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState != WindowState.Maximized) ? WindowState.Maximized : WindowState.Normal;
        }

        protected void CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            if (Owner == null)
                Application.Current.Shutdown();
            else
                Close();
        }

        protected void ReturnButtonClicked(object sender, RoutedEventArgs e)
        {
            Close();
            new MainWindow().Show();
        }
    }
}

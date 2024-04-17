using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PsychTestsMilitary.ViewModels
{
    public abstract class BaseWindow : Window, INotifyPropertyChanged
    {
        public BaseWindow() : base() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
            new MainWindow().Show();
            Close();
        }
    }
}

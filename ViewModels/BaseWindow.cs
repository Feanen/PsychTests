using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        protected virtual void MaximizeButtonClicked(object sender, RoutedEventArgs e)
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

        protected void SetWindowScale(UIElement control, ScaleTransform scale)
        {
            ScaleTransform st = control.RenderTransform as ScaleTransform;

            if (WindowState == WindowState.Maximized)
                control.RenderTransform = scale;
            else
                control.RenderTransform = new ScaleTransform(1, 1);
        }
    }
}

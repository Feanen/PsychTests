using System;
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

        protected void MaximizeButtonClicked(Object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
                WindowState = WindowState.Maximized;
            else WindowState = WindowState.Normal;
        }

        protected void CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.Owner == null)
                App.Current.Shutdown();
            else
                this.Close();
        }
    }
}

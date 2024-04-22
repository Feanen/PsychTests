using System.Windows;

namespace PsychTestsMilitary.Services
{
    public static class FullScreenManager
    {
        public static WindowState WindowState { get; set; } = WindowState.Normal;

        public static void ToggleFullScreen(Window window)
        {
            WindowState = (WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
            window.WindowState = WindowState;
        }
    }
}

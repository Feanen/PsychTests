using System.Windows.Media;
using System.Windows;
using System;

namespace PsychTestsMilitary.Services
{
    public static class ScreenManager
    {
        public static double ScreenWidth { get; private set; }
        public static double ScreenHeight { get; private set; }

        private static readonly int defaultWidth = 800;
        private static readonly int defaultHeight = 600;
        private static readonly double coeff = 0.1;

        public static void GetScreenParameters()
        {
            ScreenWidth = SystemParameters.PrimaryScreenWidth;
            ScreenHeight = SystemParameters.PrimaryScreenHeight;
        }

        public static ScaleTransform SetDynamicFullScreen()
        {
            double scaleX = Math.Round(ScreenWidth / defaultWidth, 2);
            double scaleY = Math.Round(ScreenHeight / defaultHeight, 2);

            if (scaleX <= 1.0 + coeff || scaleY <= 1.0 + coeff)
                return new ScaleTransform(1.0, 1.0);
            else 
                return new ScaleTransform(scaleX - coeff, scaleY - coeff);
        }
    }
}

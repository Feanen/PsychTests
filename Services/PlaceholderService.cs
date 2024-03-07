using System;
using System.Windows;
using System.Windows.Controls;

namespace PsychTestsMilitary.Services
{
    public class PlaceholderService
    {
        public IInputElement control;
        public PlaceholderService(IInputElement control)
        {
            this.control = control;
        }

        public void GotFocus(object sender, EventArgs e)
        {
            if (sender is IInputElement control)
            {
                Type elementType = control.GetType();

                if (elementType == typeof(TextBox))
                    control = (TextBox)sender;
                else if (elementType == typeof(CheckBox))
                    control = (ComboBox)sender;

                SetValue(control, 1.0f);

            }
        }

        public void LostFocus(object sender, EventArgs e)
        {
            if (control is TextBox)
            {
                TextBox textBox = (TextBox)control;
                if (string.IsNullOrEmpty(textBox.Text) || textBox.Text.Equals(textBox.Tag))
                    SetDefaultValue(textBox, 0.5f);
            }
            else if (control is ComboBox)
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == 0)
                    SetDefaultValue(comboBox, 0.5f);
            }
        }

        private void SetDefaultValue(IInputElement obj, double opacity)
        {
            if (obj is TextBox)
            {
                TextBox textBox = (TextBox)obj;
                textBox.Text = (string)textBox.Tag;
                textBox.Opacity = opacity;
            }
            else if (obj is ComboBox)
            {
                ComboBox comboBox = (ComboBox)obj;
                comboBox.Opacity = opacity;
            }
        }

        private void SetValue(IInputElement obj, double opacity)
        {
            if (obj is TextBox)
            {
                TextBox textBox = (TextBox)obj;
                if (textBox.Text.Equals(textBox.Tag))
                    textBox.Text = null;

                textBox.Opacity = opacity;
            }
            else
            {
                if (obj is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)obj;
                    if (comboBox.SelectedIndex != 0)
                        comboBox.Opacity = opacity;
                }
            }
        }
    }
}

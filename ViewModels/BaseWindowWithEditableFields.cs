using PsychTestsMilitary.Services;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace PsychTestsMilitary.ViewModels
{
    public abstract class BaseWindowWithEditableFields : BaseWindow
    {
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

#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public void Loaded(object sender, EventArgs e)
        {
            FocusOff(sender, e);
        }

        protected abstract void KeyDownHandler(object sender, KeyEventArgs e);
    }
}

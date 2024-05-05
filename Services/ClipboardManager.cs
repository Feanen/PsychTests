using PsychTestsMilitary.Services.Singletons;
using System.Text;
using PsychTestsMilitary.Models;
using System.Collections.Generic;
using System.Windows;

namespace PsychTestsMilitary.Services
{
    public static class ClipboardManager
    {
        public static void SaveToClipboard(List<string> scales, string technique, string passageDate, List<ScaleResult> userResults)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SaveUserInfo());
            sb.Append(FormatWithParagraph());
            sb.Append(FormatWithParagraph());
            sb.Append(FormatWithParagraph(technique));
            sb.Append(FormatWithParagraph(passageDate));
            sb.Append(FormatWithParagraph());
            sb.Append(SaveResults(scales, userResults));

            Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
        }

        private static string SaveUserInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FormatWithParagraph(
                FormatTextToBold("ПІБ пацієнта: ") + CurrentUserSingleton.CurrentAcc.Surname + " " +
                                                     CurrentUserSingleton.CurrentAcc.Name + " " +
                                                     CurrentUserSingleton.CurrentAcc.FName));
            sb.Append(FormatWithParagraph(
                FormatTextToBold("Дата народження: ") + CurrentUserSingleton.CurrentAcc.Birthday));
            sb.Append(FormatWithParagraph(
                FormatTextToBold("Стать: ") + CurrentUserSingleton.CurrentAcc.Gender));
            sb.Append(FormatWithParagraph(
                FormatTextToBold("Спеціальність: ") + CurrentUserSingleton.CurrentAcc.Spec));
            sb.Append(FormatWithParagraph(
                FormatTextToBold("Військове звання: ") + CurrentUserSingleton.CurrentAcc.Rank));
            sb.Append(FormatWithParagraph(
                FormatTextToBold("Посада, підрозділ: ") + CurrentUserSingleton.CurrentAcc.Job));

            return sb.ToString();

            //Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
        }

        private static string SaveResults(List<string> scales, List<ScaleResult> userResults)
        {
            StringBuilder sb = new StringBuilder();

            if (scales.Count.Equals(userResults.Count))
            {
                for (int i = 0; i < scales.Count; i++)
                {
                    sb.Append(FormatWithParagraph(scales[i]));
                    sb.Append(FormatWithParagraph("Результат: " + userResults[i].Result.ToString()));
                    sb.Append(FormatWithParagraph(userResults[i].Description));
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        private static string FormatTextToBold(string text)
        {
            return /*"{\\b " + */text /*+ "\\b0}"*/;
        }

        private static string FormatWithParagraph(string text = null)
        {
            return /*("{\\rtf1\\ansi" + */text + "\n";/* + "{\\par}")*/;
        }
    }
}

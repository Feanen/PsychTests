using System.Text;

namespace PsychTestsMilitary.Services.Utilities
{
    public static class StringFormatter
    {
        public static string Format(string s)
        {       
            s = s?.TrimStart();

            if (!string.IsNullOrEmpty(s))
            {
                char lastSymb = s[s.Length - 1];

                if (s.Length == 1)
                    return char.ToUpper(lastSymb).ToString();

                char predLastSymb = s[s.Length - 2];

                if (predLastSymb == (char) 32)
                {
                    if (predLastSymb != lastSymb)
                    {
                        lastSymb = char.ToUpper(s[s.Length - 1]);
                        return s.Substring(0, s.Length - 1) + lastSymb;
                    }
                    else
                        return s.Substring(0, s.Length - 1);

                }

                    lastSymb = char.ToLower(lastSymb);
                    return s.Substring(0, s.Length - 1) + lastSymb;
            }

            return string.Empty;
        }

        public static string FormatWithoutSpaces(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                string[] parts = s.Split('-');

                for (var i = 0; i < parts.Length; i++)
                {
                    if (string.IsNullOrEmpty(parts[i]))
                        continue;
                    else
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(char.ToUpper(parts[i][0]));

                        for (int j = 1; j < parts[i].Length; j++)
                            stringBuilder.Append(char.ToLower(parts[i][j]));

                        parts[i] = stringBuilder.ToString();
                    }
                }

                return string.Join("-", parts);
            }

            return string.Empty;
        }
    }
}

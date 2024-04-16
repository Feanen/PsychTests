using PsychTestsMilitary.Services.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Services
{
    public static class LicenseManager
    {
        public static int DaysLeft { get; private set; }
        private static readonly string confFileName = "00001";
        private static string confFilePath = "";
        private static readonly int trialDays = 30;
        private static readonly int threshold = 900; //in seconds
        private static string path = "";

        public static void Validate()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appName = Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location);
            string fullPath = Path.Combine(appDataPath, appName);
            Directory.CreateDirectory(fullPath);
            confFilePath = Path.Combine(fullPath, confFileName);
            path = confFilePath;
            СreateConfigFile();
        }

        public static bool CheckOnTrialTimeLeft()
        {
            try
            {
                string[] lines = File.ReadAllLines(path);

                if (lines.All(line => line.All(char.IsDigit)))
                {
                    long trialExpiredTime, previousTime, currentTime;

                    if (!long.TryParse(lines[0], out trialExpiredTime) ||
                        !long.TryParse(lines[1], out previousTime))
                    {
                        return false;
                    }

                    currentTime = UnixTimeConverter.ConvertToUnixTime(DateTime.Now);

                    if (trialExpiredTime - currentTime <= 0 || currentTime + threshold < previousTime)
                        return false;
                    else
                    {
                        lines[1] = currentTime.ToString();
                        DaysLeft = (int) Math.Ceiling( (double) (trialExpiredTime - currentTime) / 86400);
                        WriteToFile(lines);
                        return true;
                    }       
                }
                else
                    return false;
            }
            catch { return false; }
        }

        private async static void WriteToFile(string[] lines)
        {
            await Task.Run(() => {
                File.WriteAllLines(path, lines);
            });
        }

        private static void СreateConfigFile()
        {
            if (!File.Exists(confFilePath))
            {
                string data = (UnixTimeConverter.ConvertToUnixTime(DateTime.Now) +
                               (long)TimeSpan.FromDays(trialDays).TotalSeconds).ToString() + "\n" +
                               UnixTimeConverter.ConvertToUnixTime(DateTime.Now).ToString();
                File.WriteAllText(confFilePath, data);
            }
        }
    }
}

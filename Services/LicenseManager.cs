using Microsoft.Win32;
using PsychTestsMilitary.Services.Utilities;
using PsychTestsMilitary.ViewModels;
using System;
using System.Data.SqlTypes;
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
            //RegistryValidation();
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
                        return false;

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

        private static void RegistryValidation()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\PTSD"))
                {
                    if (key.GetValue("ID") != null)
                    {
                        int x;
                        if (CheckOnCorrectValues(key.GetValue("ID").ToString(), key.GetValue("Auth").ToString()))
                        {
                            if (Int32.TryParse(key.GetValue("ID").ToString(), out x))
                                key.SetValue("Auth", GenerateHexValue(x));
                        }
                        else
                            new LicenseExpiredWindow().ShowDialog();
                    }
                    else
                    {
                        key.SetValue("ID", new Random().Next(trialDays, trialDays * 20));
                        key.SetValue("Auth", GenerateHexValue(Int32.Parse(key.GetValue("ID").ToString())));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при работе с реестром: " + ex.Message);
            }
        }

        private static bool CheckOnCorrectValues(string id, string auth)
        {
            long x = Convert.ToInt64(auth, 16);
            int y = Int32.Parse(id);
            long z = x % y;

            return (x % y) == 0;
        }

        private static string GenerateHexValue(int num)
        {
            return ((new Random().Next(num, Int32.MaxValue / 2)) * num).ToString("X");
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

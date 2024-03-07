using System;

namespace PsychTestsMilitary.Services
{
    public static class Date
    {
        private const int CRITICAL_AGE = 18;
        public static bool CheckOnCriticalAge(string birthday)
        {
            DateTime dateTime = DateTime.Now;
            int[] numbers = new int[3];
            int i = 0;

            foreach (var str in birthday.Split('.'))
            {
                numbers[i] = int.Parse(str);
                i++;
            }

            int differenceInYears = dateTime.Year - numbers[2];
            int differenceInMonths = dateTime.Month - numbers[1];
            int differenceInDays = dateTime.Day - numbers[0];

            if (differenceInYears > CRITICAL_AGE)
                return true;

            else if (differenceInYears == CRITICAL_AGE)
            {

                if (differenceInMonths > 0)
                    return true;

                else if (differenceInMonths == 0)
                {
                    if (differenceInDays > 0)
                        return true;
                }
            }

            return false;
        }
    }
}

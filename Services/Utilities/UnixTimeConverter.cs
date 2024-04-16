using System;

namespace PsychTestsMilitary.Services.Utilities
{
    public static class UnixTimeConverter
    {
        private static readonly DateTime UnixEpochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ConvertToUnixTime(DateTime dateTime)
        {
            TimeSpan ts = dateTime.ToUniversalTime() - UnixEpochTime;
            return (long) ts.TotalSeconds;
        }
    }
}

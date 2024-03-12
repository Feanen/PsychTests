namespace PsychTestsMilitary.Services
{
    public static class PasswordHasher
    {
        private static string HASH = "$2a$11$8lgeuqXhh.s4PWhc.aCAjO8/7IEn5C0UzY5gqdO/1GkxFG0ewY3DC";
        private static string HASH2 = "$2a$11$ASKunzOI0zv9DmgkYXZKzehS41QJaIhedfTuGeNEEn5.4zhS0EMVe";

        public static string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool CheckOnSuperUserPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, HASH);
        }

        public static bool CheckOnUserPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, HASH2);
        }

        public static bool CheckOnPsychPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}

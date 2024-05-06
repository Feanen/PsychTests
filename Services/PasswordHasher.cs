namespace PsychTestsMilitary.Services
{
    public static class PasswordHasher
    {
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

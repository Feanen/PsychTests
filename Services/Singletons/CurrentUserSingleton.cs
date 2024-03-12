using PsychTestsMilitary.Models;

namespace PsychTestsMilitary.Services.Singletons
{
    public class CurrentUserSingleton
    {
        private static CurrentUserSingleton instance;
        private static Account currentAcc = null;

        public static CurrentUserSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentUserSingleton();
                }

                return instance;
            }
        }

        public static Account CurrentAcc { get; set; }
    }
}

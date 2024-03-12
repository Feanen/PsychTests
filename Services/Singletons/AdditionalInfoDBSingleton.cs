using PsychTestsMilitary.Services.Contexts;

namespace PsychTestsMilitary.Services.Singletons
{
    public class AdditionalInfoDBSingleton
    {
        private static AdditionalInfoDBSingleton instance;
        private AdditionalInfoContext context;

        public static AdditionalInfoDBSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdditionalInfoDBSingleton();
                }

                return instance;
            }
        }

        public void Init()
        {
            context = new AdditionalInfoContext();
        }
        public AdditionalInfoContext GetAddInfoContext()
        {
            return context;
        }
    }
}

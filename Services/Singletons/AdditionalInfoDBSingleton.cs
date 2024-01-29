using PsychTestsMilitary.Services.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

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

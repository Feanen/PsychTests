using PsychTestsMilitary.Services.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Services.Singletons
{
    public class AdditionalInfoDBSingleton
    {
        private static AdditionalInfoDBSingleton instance;

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
        public AdditionalInfoContext AddInfoContext { get; set; }
    }
}

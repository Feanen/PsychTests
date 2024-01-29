using PsychTestsMilitary.Services.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Services.Singletons
{
    public class TechniquesDBSingleton
    {
        private static TechniquesDBSingleton instance;
        private TechniquesContext context;

        public static TechniquesDBSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TechniquesDBSingleton();
                }

                return instance;
            }
        }
        public void Init()
        {
            context = new TechniquesContext();
        }
        public TechniquesContext GetTechniqueContext() {
            return context;
        }
    }
}

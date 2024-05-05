using PsychTestsMilitary.Services.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Services.Singletons
{
    public class TechniquesDBSingleton
    {
        private static TechniquesDBSingleton instance;
        private static TechniquesContext context;

        public static TechniquesDBSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TechniquesDBSingleton();
                    GetData();
                }

                return instance;
            }
        }
        public async void Init()
        {
            await Task.Run(() => context = new TechniquesContext());
        }

        private static void GetData()
        {
            using (TechniquesContext ctx = new TechniquesContext())
            {
                var cache = ctx.Techniques.
                    OrderBy(x => x.Id);
            }
        }

        public TechniquesContext GetTechniqueContext()
        {
            return context;
        }
    }
}

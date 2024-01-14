using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.ViewModels;
using PsychTestsMilitary.ViewModels.TemplateViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services
{
    public static class TechniquesManager
    {
        public static void RunNextTechnique()
        {
            if (TestsQueueSingleton.Instance.Techniques.Count != 0)
            {
                Technique tech = TestsQueueSingleton.Instance.Techniques.Dequeue();
                List<Question> questions = GetQuestions(tech);
                Window window = new Window();
                BaseTechniqueMV baseTechniqueMV = new BaseTechniqueMV();
                baseTechniqueMV.Init(tech, questions);
                switch (tech.Type)
                {                 
                    case 1:
                        window = new TechniqueType1(baseTechniqueMV);
                        break;

                }

                window.Show();
            }
        }

        private static List<Question> GetQuestions(Technique tech)
        {
            using (TechniquesContext context = new TechniquesContext())
            {
                return context.Questions.Where( q => q.Technique_id == tech.Id ).ToList();
            }
        }
    }
}

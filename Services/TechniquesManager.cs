using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.Services.Singletons;
using PsychTestsMilitary.ViewModels;
using PsychTestsMilitary.ViewModels.TemplateViewModels;
using System;
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
                Queue<Question> questions = GetQuestions(tech);
                Window window = null;
                BaseTechniqueModel model = new BaseTechniqueModel();
                model.Init(tech, questions);

                switch (tech.Type)
                {                 
                    case 1:
                        window = new TechniqueType1(model);
                        break;
                    case 2:
                        window = new TechniqueType2(model);
                        break;
                }

                if (window != null)
                    window.Show();
            }
        }

        public static void SaveAnswers(int techID, List<UserAnswer> listOfAnswers)
        {
            UserAnswers answers = new UserAnswers("feanen1", techID, JSONStringParser.StringToJSON(listOfAnswers), DateTime.Today.Date);

            using (AccountContext context = new AccountContext())
            {
                context.UserAnswers.Add(answers);
                context.SaveChanges();
            }
        }

        public static List<CompletedTechniquesModel> GetUserResults(string login)
        {
            List<CompletedTechniquesModel> completedTechniquesModels = new List<CompletedTechniquesModel>();

            using (AccountContext context = new AccountContext())
            {
                var answers = context.UserAnswers.Where(q => q.Login == login).ToList();

                foreach (UserAnswers answer in answers)
                {
                    completedTechniquesModels.Add(new CompletedTechniquesModel(
                                                    TechniquesDBSingleton.Instance.GetTechniqueContext().Techniques
                                                    .Where(t => t.Id == answer.TechniqueID)
                                                    .Select(t => t.Name).FirstOrDefault(), answer));
                }
            }

            
            return completedTechniquesModels;
        }

        private static Queue<Question> GetQuestions(Technique tech)
        {
            using (TechniquesContext context = new TechniquesContext())
            {
                return new Queue<Question>(context.Questions.Where(q => q.Technique_id == tech.Id).ToList());
            }
        }
    }
}

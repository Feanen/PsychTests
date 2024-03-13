using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.Services.Singletons;
using PsychTestsMilitary.ViewModels;
using PsychTestsMilitary.ViewModels.TemplateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                    case 3:
                        window = new TechniqueType3(model);
                        break;
                    case 4:
                        window = new TechniqueType4(model);
                        break;
                    case 5:
                        window = new TechniqueType5(model);
                        break;
                }

                if (window != null)
                    window.Show();
            }
        }

        public static void SaveAnswers(int techID, object listOfAnswers)
        {
            Type type = listOfAnswers.GetType();

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type elementType = type.GetGenericArguments()[0];
                MethodInfo method = typeof(JSONStringParser).GetMethod("StringToJSON");
                MethodInfo genericMethod = method.MakeGenericMethod(elementType);
                string jsonString = (string)genericMethod.Invoke(null, new object[] { listOfAnswers });

                UserAnswers answers = new UserAnswers("feanen1", techID, jsonString, DateTime.Today.Date);

                using (AccountContext context = new AccountContext())
                {
                    context.UserAnswers.Add(answers);
                    context.SaveChanges();
                }
            }
        }

        public static List<CompletedTechniquesModel> GetUserResults(Account account)
        {
            List<CompletedTechniquesModel> completedTechniquesModels = new List<CompletedTechniquesModel>();

            using (AccountContext context = new AccountContext())
            {
                var answers = context.UserAnswers.Where(q => q.Login == account.login).ToList();

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

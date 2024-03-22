using Newtonsoft.Json;
using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.Services.Singletons;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services
{
    public abstract class CalculationService : ICalculationService
    {
        protected UserAnswer[] UserAnswers { get; set; }
        protected List<TechniqueKey> techniqueKeys { get; set; }
        protected Account CurrentAccount { get; set; }
        protected UserAnswers Answers { get; }
        protected List<ScaleResult> CalculatedResults { get; set; }

        public CalculationService() { }

        public CalculationService(Account acc, UserAnswers answers)
        {
            UserAnswers = GetAnswers(answers);
            CurrentAccount = acc;
        }

        public CalculationService(UserAnswers answers)
        {
            Answers = answers;
        }

        protected static UserAnswer[] GetAnswers(UserAnswers answers)
        {
            return JsonConvert.DeserializeObject<List<UserAnswer>>(answers.Answers).ToArray();
        }

        protected static List<TechniqueKey> GetKeys(int techID)
        {
            TechniquesContext context = TechniquesDBSingleton.Instance.GetTechniqueContext();

            var keys = context.Keys
            .Where(u => u.Id == techID)
            .Select(u => u.Keys)
            .FirstOrDefault();

            return JsonConvert.DeserializeObject<List<TechniqueKey>>(keys);
        }

        public abstract void CalculationProcess();
        public abstract Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName);

        protected string ShowScaleResult(KeyValuePair<string, int> keyValues)
        {
            return (from barrier in AdditionalInfoDBSingleton.Instance.GetAddInfoContext().Barriers
                    join gradation in AdditionalInfoDBSingleton.Instance.GetAddInfoContext().Gradations on barrier.barrierID equals gradation.barrierID
                    join scale in AdditionalInfoDBSingleton.Instance.GetAddInfoContext().Scales on barrier.id equals scale.id
                    where gradation.Value == keyValues.Value && scale.Name == keyValues.Key
                    select barrier.Result)
                    .FirstOrDefault();
        }

        protected Dictionary<string, int> GetRawScores()
        {
            Dictionary<string, int> rawScores = new Dictionary<string, int>();

            foreach (TechniqueKey key in techniqueKeys)
                rawScores.Add(key.Scale, CalculateRawScoresOnScale(key.Pairs));

            return rawScores;
        }

        protected int GetGenderValue()
        {
            return CurrentAccount.Gender.Equals("Чоловік") ? 0 : 1;
        }

        protected virtual int CalculateRawScoresOnScale(List<QAPair> pairs)
        {
            int result = 0;

            foreach (QAPair pair in pairs)
                result += (pair.AnswerID == UserAnswers[pair.QuestionID - 1].AnswerID) ? 1 : 0;

            return result;
        }
    }
}

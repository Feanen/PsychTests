using Newtonsoft.Json;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Models.AdditionalModels;
using PsychTestsMilitary.Services.Singletons;
using PsychTestsMilitary.ViewModels.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueGCalculationService : CalculationService
    {
        private readonly int[] fixedValues = { 16, 8, 5, 0 };
        private UserMultipleAnswer[] userMultipleAnswers;

        public TechniqueGCalculationService(Account acc, UserAnswers answers)
        {
            CurrentAccount = acc;
            userMultipleAnswers = GetMultAnswers(answers);
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();

            int DpB = userMultipleAnswers.
                    SelectMany(item => item.AnswerID).
                    Sum();

            CalculatedResults.Add(new ScaleResult(DpB, GetScaleResult(DpB, "DpB")));
        }

        private UserMultipleAnswer[] GetMultAnswers(UserAnswers answers)
        {
            return JsonConvert.DeserializeObject<List<UserMultipleAnswer>>(answers.Answers).ToArray();
        }

        private string GetScaleResult(int value, string scale)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, GetGradationValue(value)));
            return (temp != null) ? temp : string.Empty;
        }

        private int GetGradationValue(int value)
        {
            for (int i = 0; i < fixedValues.Length; i++)
                if (value > fixedValues[i])
                    return fixedValues[i];

            return 0;
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueG(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName, userMultipleAnswers);
        }
    }
}

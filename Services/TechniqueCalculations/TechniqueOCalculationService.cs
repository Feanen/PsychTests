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
    public class TechniqueOCalculationService : CalculationService
    {
        private readonly int[] fixedValues = { 15, 9, 4, 0 };

        public TechniqueOCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();

            int Hln = UserAnswers.Sum(item => item.AnswerID);

            CalculatedResults.Add(new ScaleResult(Hln, GetScaleResult(Hln, "Hln")));
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
            return new TechniqueO(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }
    }
}

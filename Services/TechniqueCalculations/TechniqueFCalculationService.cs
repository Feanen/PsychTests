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
    public class TechniqueFCalculationService : CalculationService
    {
        private int[] fixedValues = { 88, 68, 45, 25, 10, 0 };

        public TechniqueFCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();

            int Dp = UserAnswers.Sum(item => item.AnswerID);

            CalculatedResults.Add(new ScaleResult(Dp, GetScaleResult(Dp, "Dp")));
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
            return new TechniqueF(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }
    }
}

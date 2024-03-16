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
    public class TechniqueHCalculationService : CalculationService
    {
        private readonly int[] fixedValues = { 70, 60, 51, 0 };

        public TechniqueHCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();

            double SLM = CalculateTechniqueResult();

            CalculatedResults.Add(new ScaleResult(SLM, GetScaleResult(SLM, "SLM")));
        }

        private string GetScaleResult(double value, string scale)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, GetGradationValue(value)));
            return (temp != null) ? temp : string.Empty;
        }

        private int GetGradationValue(double value)
        {
            for (int i = 0; i < fixedValues.Length; i++)
                if (value >= fixedValues[i])
                    return fixedValues[i];

            return 0;
        }

        private double CalculateTechniqueResult()
        {
            return Math.Round((UserAnswers.Sum(item => item.AnswerID) * 100 / 80d), 2);
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueH(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }
    }
}

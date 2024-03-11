using PsychTestsMilitary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PsychTestsMilitary.ViewModels.FinalResults;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueСCalculationService : CalculationService
    {
        private int[] scaleLFixedValues = { 60, 0 };
        private int[] scaleSrFixedValues = { 75, 60, 39, 24, 0 };

        public TechniqueСCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();
            Dictionary<string, int> rawScores = GetRawScores();

            double L = CalculateScaleLValues(rawScores.ElementAt(0).Value);
            double Sr = CalculateScaleSrValues(rawScores.ElementAt(1).Value);

            CalculatedResults.Add(new ScaleResult(L, GetScaleResult(L, "L1", scaleLFixedValues)));
            CalculatedResults.Add(new ScaleResult(Sr, GetScaleResult(Sr, "Sr", scaleSrFixedValues)));
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueС(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }

        private string GetScaleResult(double value, string scale, int[] array)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, GetGradationValue(value, array)));
            return (temp != null) ? temp : string.Empty;
        }

        private int GetGradationValue(double value, int[] array)
        {
            int v = (int) (value * 100);

            for (int i = 0; i < array.Length; i++)
                if (v > array[i])
                    return array[i];

            return 0;
        }

        private double CalculateScaleLValues(int scores)
        {
            return Math.Round(((float) scores / 10) - 0.16, 2);
        }

        private double CalculateScaleSrValues(int scores)
        {
            double result = Math.Round(((float) scores / 35) + 7e-2, 2);
            return (result > 1) ? 1 : result;
        }
    }
}

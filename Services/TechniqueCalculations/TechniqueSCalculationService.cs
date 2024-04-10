using PsychTestsMilitary.Models;
using PsychTestsMilitary.ViewModels.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueSCalculationService : CalculationService
    {
        private static readonly double[] coeffs = { 1.2, 1.1, 1.2, 1.5, 1, 2.3, 3.2, 1.1, 3.2 };
        public TechniqueSCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();
            Dictionary<string, int> rawScores = GetRawScores();

            for (int i = 0; i < rawScores.Count; i++)
                CalculatedResults.Add(new ScaleResult(Math.Round(rawScores.ElementAt(i).Value * coeffs[i], 1), null));
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueS(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }

        protected override int CalculateRawScoresOnScale(List<QAPair> pairs)
        {
            int result = 0;

            foreach (QAPair pair in pairs)
                result += UserAnswers[pair.QuestionID - 1].AnswerID;

            return result;
        }
    }
}

using PsychTestsMilitary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PsychTestsMilitary.ViewModels.FinalResults;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniquePCalculationService : CalculationService
    {
        private readonly int[] fixedValues = { 11, 8, 0 };

        public TechniquePCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();
            Dictionary<string, int> rawScores = GetRawScores();

            int Anx = rawScores.ElementAt(0).Value;
            int Dep = rawScores.ElementAt(1).Value;

            CalculatedResults.Add(new ScaleResult(Anx, GetScaleResult(Anx, "Anx")));
            CalculatedResults.Add(new ScaleResult(Dep, GetScaleResult(Dep, "Dep")));
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueP(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }

        protected override int CalculateRawScoresOnScale(List<QAPair> pairs)
        {
            int result = 0;

            foreach (QAPair pair in pairs)
                result += UserAnswers[pair.QuestionID - 1].AnswerID;

            return result;
        }

        private string GetScaleResult(int value, string scale)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, GetGradationValue(value)));
            return (temp != null) ? temp : string.Empty;
        }

        private int GetGradationValue(int value)
        {
            for (int i = 0; i < fixedValues.Length; i++)
                if (value >= fixedValues[i])
                    return fixedValues[i];

            return 0;
        }
    }
}

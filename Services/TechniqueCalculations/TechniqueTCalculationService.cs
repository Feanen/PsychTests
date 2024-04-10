using PsychTestsMilitary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PsychTestsMilitary.ViewModels.FinalResults;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueTCalculationService : CalculationService
    {
        private readonly int[] fixedValues = { 16, 13, 10, 7, 4, 0 };

        public TechniqueTCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();
            Dictionary<string, int> rawScores = GetRawScores();

            int Sdm1 = rawScores.ElementAt(0).Value;
            int Sdm2 = rawScores.ElementAt(1).Value;
            int Sdm3 = rawScores.ElementAt(2).Value;
            int Sdm4 = rawScores.ElementAt(3).Value;
            int Sdm5 = rawScores.ElementAt(4).Value;

            CalculatedResults = new List<ScaleResult>
            {
                new ScaleResult(Sdm1, GetScaleResult(Sdm1, "Sdm")),
                new ScaleResult(Sdm2, GetScaleResult(Sdm2, "Sdm")),
                new ScaleResult(Sdm3, GetScaleResult(Sdm3, "Sdm")),
                new ScaleResult(Sdm4, GetScaleResult(Sdm4, "Sdm")),
                new ScaleResult(Sdm5, GetScaleResult(Sdm5, "Sdm")),
            };
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueT(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
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

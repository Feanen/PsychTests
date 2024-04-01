using PsychTestsMilitary.Models;
using PsychTestsMilitary.ViewModels.FinalResults;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueMCalculationService : CalculationService
    {
        public TechniqueMCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();
            Dictionary<string, int> rawScores = GetRawScores();
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(0).Value, null));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(1).Value, null));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(2).Value, null));
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueM(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
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

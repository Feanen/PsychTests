using PsychTestsMilitary.Models;
using PsychTestsMilitary.ViewModels.FinalResults;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueNCalculationService : CalculationService
    {
        public TechniqueNCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
        }

        public override void CalculationProcess()
        {
            Dictionary<string, int> rawScores = GetRawScores();

            CalculatedResults = new List<ScaleResult>
            {
                new ScaleResult(rawScores.ElementAt(4).Value + rawScores.ElementAt(5).Value, null),
                new ScaleResult(rawScores.ElementAt(0).Value + rawScores.ElementAt(1).Value + rawScores.ElementAt(6).Value, null)
            };

            for (int i = 0; i < rawScores.Count; i++)
                CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(i).Value, null));
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueN(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }

        private int GetRTCS(Dictionary<string, int> rawScores)
        {
            return (rawScores.ElementAt(1).Value + rawScores.ElementAt(2).Value + rawScores.ElementAt(3).Value);
        }
    }
}

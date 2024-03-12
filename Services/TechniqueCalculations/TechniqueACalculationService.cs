using PsychTestsMilitary.Models;
using PsychTestsMilitary.ViewModels.FinalResults;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueACalculationService : CalculationService
    {
        private string[] finalResults;
        public TechniqueACalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
        }

        public override void CalculationProcess()
        {
            Dictionary<string, int> rawScores = GetRawScores();
            string D = ShowScaleResult(rawScores.ElementAt(0));
            string PR = ShowScaleResult(rawScores.ElementAt(1));
            string KP = ShowScaleResult(rawScores.ElementAt(2));
            string MN = ShowScaleResult(rawScores.ElementAt(3));
            string VPS = ShowScaleResult(rawScores.ElementAt(4));
            string DAP = ShowScaleResult(rawScores.ElementAt(5));
            string CR = ShowScaleResult(rawScores.ElementAt(6));
            string RTCS = ShowScaleResult(new KeyValuePair<string, int>("RTCS", GetRTCS(rawScores)));

            finalResults = new string[] { D, PR, KP, MN, VPS, DAP, CR, RTCS };
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueA(finalResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }

        private int GetRTCS(Dictionary<string, int> rawScores)
        {
            return (rawScores.ElementAt(1).Value + rawScores.ElementAt(2).Value + rawScores.ElementAt(3).Value);
        }
    }
}

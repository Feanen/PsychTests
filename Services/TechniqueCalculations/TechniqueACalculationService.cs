using PsychTestsMilitary.Models;
using PsychTestsMilitary.ViewModels.FinalResults;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueACalculationService : CalculationService
    {
        //private string[] finalResults;
        public TechniqueACalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();

            Dictionary<string, int> rawScores = GetRawScores();

            int D = rawScores.ElementAt(0).Value;
            int PR = rawScores.ElementAt(1).Value;
            int KP = rawScores.ElementAt(2).Value;
            int MN = rawScores.ElementAt(3).Value;
            int VPS = rawScores.ElementAt(4).Value;
            int DAP = rawScores.ElementAt(5).Value;
            int CR = rawScores.ElementAt(6).Value;
            int RTCS = GetRTCS(rawScores);

            CalculatedResults.Add(new ScaleResult(D, GetScaleResult(D, "D")));
            CalculatedResults.Add(new ScaleResult(PR, GetScaleResult(PR, "PR")));
            CalculatedResults.Add(new ScaleResult(KP, GetScaleResult(KP, "KP")));
            CalculatedResults.Add(new ScaleResult(MN, GetScaleResult(MN, "MN")));
            CalculatedResults.Add(new ScaleResult(VPS, GetScaleResult(VPS, "VPS")));
            CalculatedResults.Add(new ScaleResult(DAP, GetScaleResult(DAP, "DAP")));
            CalculatedResults.Add(new ScaleResult(CR, GetScaleResult(CR, "CR")));
            CalculatedResults.Add(new ScaleResult(RTCS, GetScaleResult(RTCS, "RTCS")));

            /*string D = ShowScaleResult(rawScores.ElementAt(0));
            string PR = ShowScaleResult(rawScores.ElementAt(1));
            string KP = ShowScaleResult(rawScores.ElementAt(2));
            string MN = ShowScaleResult(rawScores.ElementAt(3));
            string VPS = ShowScaleResult(rawScores.ElementAt(4));
            string DAP = ShowScaleResult(rawScores.ElementAt(5));
            string CR = ShowScaleResult(rawScores.ElementAt(6));
            string RTCS = ShowScaleResult(new KeyValuePair<string, int>("RTCS", GetRTCS(rawScores)));*/

            //finalResults = new string[] { D, PR, KP, MN, VPS, DAP, CR, RTCS };
        }

        private string GetScaleResult(int value, string scale)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, value));
            return (temp != null) ? temp : string.Empty;
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueA(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }

        private int GetRTCS(Dictionary<string, int> rawScores)
        {
            return (rawScores.ElementAt(1).Value + rawScores.ElementAt(2).Value + rawScores.ElementAt(3).Value);
        }
    }
}

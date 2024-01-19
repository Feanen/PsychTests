using PsychTestsMilitary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueACalculationService : CalculationService
    {
        private string[] finalResults;
        public TechniqueACalculationService(string login, int techID) : base(login, techID)
        {
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

            finalResults = new string[] {D, PR, KP, MN, VPS, DAP, CR, RTCS};
        }

        public override string[] ShowResults()
        {
            return finalResults;
        }

        private Dictionary<string, int> GetRawScores()
        {
            Dictionary<string, int> rawScores = new Dictionary<string, int>();

            foreach (TechniqueKey key in techniqueKeys)
            {
                rawScores.Add(key.Scale, CalculateRawScoresOnScale(key.Pairs));
            }

            return rawScores;
        }

        private int CalculateRawScoresOnScale(List<QAPair> pairs)
        {
            int result = 0;

            foreach (QAPair pair in pairs)
            {
                result += (pair.AnswerID == userAnswers[pair.QuestionID - 1].AnswerID) ? 1 : 0;
            }

            return result;
        }

        private int GetRTCS(Dictionary<string, int> rawScores)
        {
            return (rawScores.ElementAt(1).Value + rawScores.ElementAt(2).Value + rawScores.ElementAt(3).Value);
        }
    }
}

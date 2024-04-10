using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Singletons;
using PsychTestsMilitary.ViewModels.FinalResults;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueQCalculationService : CalculationService
    {
        private readonly Score[] scores;
        private readonly int[] fixedValuesPsz = { 6, -5 };
        private readonly int[] fixedValuesNeu = { 11, -10 };
        private readonly int fixedValueLiar = 5;

        public double Dep { get; private set; }

        public TechniqueQCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
            int gender = GetGenderValue();

            var temp = AdditionalInfoDBSingleton.Instance.GetAddInfoContext().NeuPsyScores
                .Where(g => g.Gender == gender)
                .Select(sc => new { sc.Question, sc.PosAnswer, sc.NegAnswer })
                .ToArray();
            
            scores = temp.Select(sc => new Score(sc.Question, sc.PosAnswer, sc.NegAnswer)).ToArray();
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();
            Dictionary<string, int> rawScores = GetRawScores();

            int Neu = rawScores.ElementAt(0).Value;
            int Psz = rawScores.ElementAt(1).Value;
            int Liar = rawScores.ElementAt(2).Value;

            CalculatedResults.Add(new ScaleResult(Neu, GetScaleResult(Neu, "Neu", fixedValuesNeu)));
            CalculatedResults.Add(new ScaleResult(Psz, GetScaleResult(Psz, "Psz", fixedValuesPsz)));
            CalculatedResults.Add(new ScaleResult(Liar, GetScaleResult(Liar, "Liar", fixedValueLiar)));
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueQ(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }

        protected override int CalculateRawScoresOnScale(List<QAPair> pairs)
        {
            int result = 0;

            foreach (QAPair pair in pairs)
                result += (UserAnswers[pair.QuestionID - 1].AnswerID == 1) ?
                    scores[pair.QuestionID - 1].PosAnswer :
                    scores[pair.QuestionID - 1].NegAnswer;

            return result;
        }

        private string GetScaleResult(int value, string scale, object fixedValues)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, GetGradationValue(value, fixedValues)));
            return (temp != null) ? temp : string.Empty;
        }

        private int GetGradationValue(int value, object fixedValues)
        {
            switch (fixedValues)
            {
                case int[] array:      
                    for (int i = 0; i < array.Length; i++)
                        if (value >= array[i])
                            return array[i];
                    break;
                    
                case int fxValue:
                    return (value >= fxValue) ? fxValue : 0;
            }

            return 0;
        }
    }

    internal struct Score 
    {
        public int Question { get; }
        public int PosAnswer { get; }
        public int NegAnswer { get; }

        public Score(int quest, int posAnsw, int negAnswer)
        {
            Question = quest;
            PosAnswer = posAnsw;
            NegAnswer = negAnswer;
        }
    }
}

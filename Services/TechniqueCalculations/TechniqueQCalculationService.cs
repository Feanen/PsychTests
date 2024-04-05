using PsychTestsMilitary.Models;
using PsychTestsMilitary.Models.AdditionalModels;
using PsychTestsMilitary.Services.Singletons;
using PsychTestsMilitary.ViewModels.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueQCalculationService : CalculationService
    {
        private readonly Score[] scores;
        private readonly int[] fixedValuesNeu = { 5, -5 };
        private readonly int[] fixedValuesPsz = { 10, -10 };

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

        private string ValidateValue(int value)
        {
            return (value != 0) ? value.ToString() : "-";
        }

        private int SumDictValuesInRange(Dictionary<string, int> rawScores, int begin, int end)
        {
            int result = 0;

            for (int i = begin; i <= end; i++)
            {
                result += rawScores.ElementAt(i).Value;
            }

            return result;
        }

        private int GetTScores(KeyValuePair<string, int> scaleValuePair, int gender)
        {
            var parameter = System.Linq.Expressions.Expression.Parameter(typeof(ConversionScore), "cs");
            var property = System.Linq.Expressions.Expression.Property(parameter, scaleValuePair.Key);
            var propertyValue = System.Linq.Expressions.Expression.Convert(property, typeof(int));
            var constant = System.Linq.Expressions.Expression.Constant(scaleValuePair.Value);
            var equality = System.Linq.Expressions.Expression.Equal(propertyValue, constant);
            var lambda = System.Linq.Expressions.Expression.Lambda<Func<ConversionScore, bool>>(equality, parameter);
            var scores = AdditionalInfoDBSingleton.Instance.GetAddInfoContext().ConversionScores
                .Where(cs => cs.Gender == gender)
                .Where(lambda.Compile());

            return scores.FirstOrDefault()?.Score ?? 0;
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

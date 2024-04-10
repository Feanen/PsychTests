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
    public class TechniqueKCalculationService : CalculationService
    {
        public TechniqueKCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            techniqueKeys = GetKeys(answers.TechniqueID);
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();

            int gender = GetGenderValue();
            Dictionary<string, int> rawScores = GetRawScores();
            int A = GetTScores(rawScores.ElementAt(0), gender);
            int B = GetTScores(rawScores.ElementAt(1), gender);
            int C = GetTScores(rawScores.ElementAt(2), gender);
            int D = GetTScores(rawScores.ElementAt(3), gender);
            int F = GetTScores(rawScores.ElementAt(4), gender);
            int b = GetTScores(rawScores.ElementAt(5), gender);
            int c = GetTScores(rawScores.ElementAt(6), gender);
            int d = GetTScores(rawScores.ElementAt(7), gender);
            int e = GetTScores(rawScores.ElementAt(8), gender);
            int f = GetTScores(rawScores.ElementAt(9), gender);
            int L = GetTScores(rawScores.ElementAt(10), gender);

            int agSum = rawScores.ElementAt(11).Value + rawScores.ElementAt(14).Value;
            int Ag = GetTScores(new KeyValuePair<string, int>(rawScores.ElementAt(11).Key, agSum), gender);

            int diSum = rawScores.ElementAt(12).Value + (12 - rawScores.ElementAt(14).Value);
            int Di = GetTScores(new KeyValuePair<string, int>(rawScores.ElementAt(12).Key, diSum), gender);

            int Dprs = GetTScores(rawScores.ElementAt(13), gender);
            int ptsd = SumDictValuesInRange(rawScores, 0, 4);
            int asd = SumDictValuesInRange(rawScores, 5, 9) + rawScores.ElementAt(0).Value;

            int PTSD = GetTScores(new KeyValuePair<string, int>("PTSD", ptsd), gender);
            int ASD = GetTScores(new KeyValuePair<string, int>("ASD", asd), gender);

            CalculatedResults.Add(new ScaleResult(ptsd, ValidateValue(PTSD)));
            CalculatedResults.Add(new ScaleResult(asd, ValidateValue(ASD)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(13).Value, ValidateValue(Dprs)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(10).Value, ValidateValue(L)));
            CalculatedResults.Add(new ScaleResult(agSum, ValidateValue(Ag)));
            CalculatedResults.Add(new ScaleResult(diSum, ValidateValue(Di)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(0).Value, ValidateValue(A)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(1).Value, ValidateValue(B)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(2).Value, ValidateValue(C)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(3).Value, ValidateValue(D)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(4).Value, ValidateValue(F)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(5).Value, ValidateValue(b)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(6).Value, ValidateValue(c)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(7).Value, ValidateValue(d)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(8).Value, ValidateValue(e)));
            CalculatedResults.Add(new ScaleResult(rawScores.ElementAt(9).Value, ValidateValue(f)));
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueK(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }

        protected override int CalculateRawScoresOnScale(List<QAPair> pairs)
        {
            int result = 0;

            foreach (QAPair pair in pairs)
                result += UserAnswers[pair.QuestionID - 1].AnswerID;

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
}

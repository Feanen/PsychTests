using PsychTestsMilitary.Models;
using PsychTestsMilitary.Models.AdditionalModels;
using PsychTestsMilitary.Services.Singletons;
using PsychTestsMilitary.ViewModels.FinalResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueKCalculationService : CalculationService
    {
        private const int MINIMAL_THRESHOLD = 40;
        private const int MAXIMUM_THRESHOLD = 70;

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
            int Ag = GetTScores(new KeyValuePair<string, int>(rawScores.ElementAt(11).Key, rawScores.ElementAt(11).Value + rawScores.ElementAt(14).Value), gender);
            int Di = GetTScores(new KeyValuePair<string, int>(rawScores.ElementAt(12).Key, rawScores.ElementAt(12).Value + (12 - rawScores.ElementAt(14).Value)), gender);
            int Dprs = GetTScores(rawScores.ElementAt(13), gender);

            int ptsd = A + B + C + D + F;
            int asd = A + b + c + d + e + f;
            int PTSD = GetTScores(new KeyValuePair<string, int>("PTSD", ptsd), gender);
            int ASD = GetTScores(new KeyValuePair<string, int>("ASD", asd), gender);

            /*CalculatedResults.Add(new ScaleResult(L, GetScaleResult(L, "L")));
            CalculatedResults.Add(new ScaleResult(F, GetScaleResult(F, "F")));
            CalculatedResults.Add(new ScaleResult(K, GetScaleResult(K, "K")));
            CalculatedResults.Add(new ScaleResult(Hs, GetScaleResult(Hs, "Hs")));
            CalculatedResults.Add(new ScaleResult(D1, GetScaleResult(D1, "D1")));
            CalculatedResults.Add(new ScaleResult(Hy, GetScaleResult(Hy, "Hy")));
            CalculatedResults.Add(new ScaleResult(Pd, GetScaleResult(Pd, "Pd")));
            CalculatedResults.Add(new ScaleResult(Pa, GetScaleResult(Pa, "Pa")));
            CalculatedResults.Add(new ScaleResult(Pt, GetScaleResult(Pt, "Pt")));
            CalculatedResults.Add(new ScaleResult(Se, GetScaleResult(Se, "Se")));
            CalculatedResults.Add(new ScaleResult(Ma, GetScaleResult(Ma, "Ma")));*/
        }

        private string GetScaleResult(double value, string scale)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, GetGradationValue(value)));
            return (temp != null) ? temp : string.Empty;
        }

        private int GetGradationValue(double value)
        {
            if (value > MAXIMUM_THRESHOLD)
                return MAXIMUM_THRESHOLD;
            if (value < MINIMAL_THRESHOLD)
                return MINIMAL_THRESHOLD;
            return 0;
        }

        private int GetTScores(KeyValuePair<string, int> scaleValuePair, int gender)
        {
            var parameter = System.Linq.Expressions.Expression.Parameter(typeof(ConversionScore), "cs");
            var property = System.Linq.Expressions.Expression.Property(parameter, scaleValuePair.Key);
            var propertyValue = System.Linq.Expressions.Expression.Convert(property, typeof(int)); // Приводим свойство к типу long
            var constant = System.Linq.Expressions.Expression.Constant(scaleValuePair.Value);
            var equality = System.Linq.Expressions.Expression.Equal(propertyValue, constant);
            var lambda = System.Linq.Expressions.Expression.Lambda<Func<ConversionScore, bool>>(equality, parameter);
            var scores = AdditionalInfoDBSingleton.Instance.GetAddInfoContext().ConversionScores
                .Where(cs => cs.Gender == gender)
                .Where(lambda.Compile());

            return scores.FirstOrDefault()?.Score ?? 0;
        }

        private CorrectionFactor GetCorrection(int userCorrectionFactor)
        {
            return AdditionalInfoDBSingleton.Instance.GetAddInfoContext().CorrectionFactors
            .Where(u => u.CorrectionFull == userCorrectionFactor)
            .FirstOrDefault();
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueB(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
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

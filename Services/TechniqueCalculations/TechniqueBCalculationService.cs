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
    public class TechniqueBCalculationService : CalculationService
    {
        private const int MINIMAL_THRESHOLD = 40;
        private const int MAXIMUM_THRESHOLD = 70;

        public TechniqueBCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();

            int gender = GetGenderValue();
            Dictionary<string, int> rawScores = GetRawScores();
            double L = CalculateStandartValues(rawScores.ElementAt(0).Value, GetGenderDifference("L", gender));//ShowScaleResult(rawScores.ElementAt(0));
            double F = CalculateStandartValues(rawScores.ElementAt(1).Value, GetGenderDifference("F", gender));//ShowScaleResult(rawScores.ElementAt(1));
            double K = CalculateStandartValues(rawScores.ElementAt(2).Value, GetGenderDifference("K", gender));//ShowScaleResult(rawScores.ElementAt(2));

            CorrectionFactor correctionFactor = GetCorrection(rawScores.ElementAt(2).Value);

            double Hs = CalculateStandartValues(rawScores.ElementAt(3).Value, GetGenderDifference("Hs", gender), correctionFactor.CorrectionFiftyPercent);//ShowScaleResult(rawScores.ElementAt(3));
            double D1 = CalculateStandartValues(rawScores.ElementAt(4).Value, GetGenderDifference("D1", gender));//ShowScaleResult(rawScores.ElementAt(4));
            double Hy = CalculateStandartValues(rawScores.ElementAt(5).Value, GetGenderDifference("Hy", gender));//ShowScaleResult(rawScores.ElementAt(5));
            double Pd = CalculateStandartValues(rawScores.ElementAt(6).Value, GetGenderDifference("Pd", gender), correctionFactor.CorrectionFourtyPercent);//ShowScaleResult(rawScores.ElementAt(6));
            double Pa = CalculateStandartValues(rawScores.ElementAt(7).Value, GetGenderDifference("Pa", gender));//ShowScaleResult(rawScores.ElementAt(7));
            double Pt = CalculateStandartValues(rawScores.ElementAt(8).Value, GetGenderDifference("Pt", gender), correctionFactor.CorrectionFull);//ShowScaleResult(rawScores.ElementAt(8));
            double Se = CalculateStandartValues(rawScores.ElementAt(9).Value, GetGenderDifference("Se", gender), correctionFactor.CorrectionFull);//ShowScaleResult(rawScores.ElementAt(9));
            double Ma = CalculateStandartValues(rawScores.ElementAt(10).Value, GetGenderDifference("Ma", gender), correctionFactor.CorrectionTwentyPercent);//ShowScaleResult(rawScores.ElementAt(10));

            CalculatedResults.Add(new ScaleResult(L, GetScaleResult(L, "L")));
            CalculatedResults.Add(new ScaleResult(F, GetScaleResult(F, "F")));
            CalculatedResults.Add(new ScaleResult(K, GetScaleResult(K, "K")));
            CalculatedResults.Add(new ScaleResult(Hs, GetScaleResult(Hs, "Hs")));
            CalculatedResults.Add(new ScaleResult(D1, GetScaleResult(D1, "D1")));
            CalculatedResults.Add(new ScaleResult(Hy, GetScaleResult(Hy, "Hy")));
            CalculatedResults.Add(new ScaleResult(Pd, GetScaleResult(Pd, "Pd")));
            CalculatedResults.Add(new ScaleResult(Pa, GetScaleResult(Pa, "Pa")));
            CalculatedResults.Add(new ScaleResult(Pt, GetScaleResult(Pt, "Pt")));
            CalculatedResults.Add(new ScaleResult(Se, GetScaleResult(Se, "Se")));
            CalculatedResults.Add(new ScaleResult(Ma, GetScaleResult(Ma, "Ma")));
        }

        private string GetScaleResult(double value, string scale)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, GetGradationValue(value)));
            return (temp != null) ? temp : String.Empty;
        }

        private int GetGradationValue(double value)
        {
            if (value > MAXIMUM_THRESHOLD)
                return MAXIMUM_THRESHOLD;
            if (value < MINIMAL_THRESHOLD)
                return MINIMAL_THRESHOLD;
            return 0;
        }

        private GenderDifference GetGenderDifference(string scale, int gender)
        {
            return AdditionalInfoDBSingleton.Instance.GetAddInfoContext().GenderDifferences
                .Where(u => u.Scale.Equals(scale) && u.Gender == gender)
                .FirstOrDefault();
        }

        private int GetGenderValue()
        {
            return CurrentAccount.Gender.Equals("Чоловік") ? 0 : 1;
        }

        private CorrectionFactor GetCorrection(int userCorrectionFactor)
        {
            return AdditionalInfoDBSingleton.Instance.GetAddInfoContext().CorrectionFactors
            .Where(u => u.CorrectionFull == userCorrectionFactor)
            .FirstOrDefault();
        }

        private double CalculateStandartValues(int scores, GenderDifference gf, float corrFact = 0)
        {
            return Math.Round(50 + 10 * (scores - gf.Median) / gf.Delta + corrFact, 2);
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueB(CalculatedResults, String.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }
    }
}

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
        private Dictionary<double, string> finalResults;
        private const int MINIMAL_THRESHOLD = 40;
        private const int MAXIMUM_THRESHOLD = 70;

        public TechniqueBCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
        }

        public override void CalculationProcess()
        {
            finalResults = new Dictionary<double, string>();

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

            finalResults.Add(L, GetScaleResult(L, "L"));
            finalResults.Add(F, GetScaleResult(F, "F"));
            finalResults.Add(K, GetScaleResult(K, "K"));
            finalResults.Add(Hs, GetScaleResult(Hs, "Hs"));
            finalResults.Add(D1, GetScaleResult(D1, "D1"));
            finalResults.Add(Hy, GetScaleResult(Hy, "Hy"));
            finalResults.Add(Pd, GetScaleResult(Pd, "Pd"));
            finalResults.Add(Pa, GetScaleResult(Pa, "Pa"));
            finalResults.Add(Pt, GetScaleResult(Pt, "Pt"));
            finalResults.Add(Se, GetScaleResult(Se, "Se"));
            finalResults.Add(Ma, GetScaleResult(Ma, "Ma"));
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
            return new TechniqueB(finalResults, String.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }
    }
}

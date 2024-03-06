using Newtonsoft.Json.Linq;
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
    public class TechniqueDCalculationService : CalculationService
    {
        private const int HIGH_ANXIETY = 45;
        private const int AVERAGE_ANXIETY = 31;
        private const int LOW_ANXIETY = 0;

        public TechniqueDCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();
            AnxietyQuestionsCoefficient[] anxietyQuestionsCoefficients = GetAnxietyQuestionsCoefficients();

            UserAnswer[] arr = new UserAnswer[20];
            AnxietyQuestionsCoefficient[] anxArr = new AnxietyQuestionsCoefficient[20];

            Array.Copy(userAnswers, arr, 20);
            Array.Copy(anxietyQuestionsCoefficients, anxArr, 20);
            int Ra = CalculateSummaryScaleResult(arr, anxArr, 50);

            Array.Copy(userAnswers, 20, arr, 0, 20);
            Array.Copy(anxietyQuestionsCoefficients, 20, anxArr, 0, 20);
            int Pa1 = CalculateSummaryScaleResult(arr, anxArr, 35);

            CalculatedResults.Add(new ScaleResult(Ra, GetScaleResult(Ra, "Ra")));
            CalculatedResults.Add(new ScaleResult(Pa1, GetScaleResult(Pa1, "Pa1")));
        }

        private int CalculateSummaryScaleResult(UserAnswer[] arr, AnxietyQuestionsCoefficient[] coeffs, int constant)
        {
            return arr.Zip(coeffs, (x, y) => x.AnswerID * y.Coeff).Sum() + constant;
        }

        private int GetGradationValue(double value)
        {
            if (value >= HIGH_ANXIETY)
                return HIGH_ANXIETY;
            if (value >= AVERAGE_ANXIETY)
                return AVERAGE_ANXIETY;
            return LOW_ANXIETY;
        }

        private AnxietyQuestionsCoefficient[] GetAnxietyQuestionsCoefficients()
        {
            return AdditionalInfoDBSingleton.Instance.GetAddInfoContext().AnxietyQuestionsCoefficients.ToArray();
        }

        private string GetScaleResult(double value, string scale)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, GetGradationValue(value)));
            return (temp != null) ? temp : String.Empty;
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueD(CalculatedResults, String.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }
    }
}

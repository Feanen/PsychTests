using PsychTestsMilitary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PsychTestsMilitary.ViewModels.FinalResults;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueECalculationService : CalculationService
    {
        private int[] scalesFixedValues = { 81, 61, 41, 21, 0 };

        public TechniqueECalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>();

            int Sc = UserAnswers[0].AnswerID;
            int Ac = UserAnswers[1].AnswerID;
            int Md = UserAnswers[2].AnswerID;
            int Pf = UserAnswers[3].AnswerID;
            int IP = UserAnswers[4].AnswerID;
            int EPT = UserAnswers[5].AnswerID;
            int SR = UserAnswers[6].AnswerID;

            CalculatedResults.Add(new ScaleResult(Sc, GetScaleResult(Sc, "Sc")));
            CalculatedResults.Add(new ScaleResult(Ac, GetScaleResult(Ac, "Ac")));
            CalculatedResults.Add(new ScaleResult(Md, GetScaleResult(Md, "Md")));
            CalculatedResults.Add(new ScaleResult(Pf, GetScaleResult(Pf, "Pf")));
            CalculatedResults.Add(new ScaleResult(IP, GetScaleResult(IP, "IP")));
            CalculatedResults.Add(new ScaleResult(EPT, GetScaleResult(EPT, "EPT")));
            CalculatedResults.Add(new ScaleResult(SR, GetScaleResult(SR, "SR")));
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueE(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }

        private string GetScaleResult(int value, string scale)
        {
            string temp = ShowScaleResult(new KeyValuePair<string, int>(scale, GetGradationValue(value)));
            return (temp != null) ? temp : string.Empty;
        }

        private int GetGradationValue(int value)
        {
            for (int i = 0; i < scalesFixedValues.Length; i++)
                if (value > scalesFixedValues[i])
                    return scalesFixedValues[i];

            return 0;
        }
    }
}

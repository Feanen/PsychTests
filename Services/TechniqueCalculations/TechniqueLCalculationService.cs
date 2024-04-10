using Newtonsoft.Json;
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
    public class TechniqueLCalculationService : CalculationService
    {
        public TechniqueLCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
        }

        public override void CalculationProcess()
        {
            CalculatedResults = new List<ScaleResult>
            {
                new ScaleResult(UserAnswers.Sum(data => data.AnswerID), null)
            };
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueL(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }
    }
}

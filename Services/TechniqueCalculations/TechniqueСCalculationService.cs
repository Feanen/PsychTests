using PsychTestsMilitary.Models;
using System;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueСCalculationService : CalculationService
    {
        public TechniqueСCalculationService(UserAnswers answers) : base(answers)
        {
        }

        public override void CalculationProcess()
        {
            throw new NotImplementedException();
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            throw new NotImplementedException();
        }
    }
}

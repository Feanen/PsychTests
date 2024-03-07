using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.TechniqueCalculations;

namespace PsychTestsMilitary.Services
{
    public class ResultsManager : ICreatingCalculation
    {
        public CalculationService GetCalculationService(Account acc, UserAnswers data)
        {
            switch (data.TechniqueID)
            {
                case 1:
                    return new TechniqueACalculationService(acc, data);
                case 2:
                    return new TechniqueBCalculationService(acc, data);
                case 3:
                    return null;
                case 4:
                    return new TechniqueDCalculationService(acc, data);
                default:
                    return null;
            }
        }
    }
}

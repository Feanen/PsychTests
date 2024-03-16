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
                    return new TechniqueСCalculationService(acc, data);
                case 4:
                    return new TechniqueDCalculationService(acc, data);
                case 5:
                    return new TechniqueECalculationService(acc, data);
                case 6:
                    return new TechniqueFCalculationService(acc, data);
                case 7:
                    return new TechniqueGCalculationService(acc, data);
                case 8:
                    return new TechniqueHCalculationService(acc, data);
                default:
                    return null;
            }
        }
    }
}

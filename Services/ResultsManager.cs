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
                    return new TechniqueCCalculationService(acc, data);
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
                case 9:
                    return new TechniqueICalculationService(acc, data);
                case 10:
                    return new TechniqueJCalculationService(acc, data);
                case 11:
                    return new TechniqueKCalculationService(acc, data);
                case 12:
                    return new TechniqueLCalculationService(acc, data);
                case 13:
                    return new TechniqueMCalculationService(acc, data);
                case 14:
                    return new TechniqueNCalculationService(acc, data);
                case 15:
                    return new TechniqueOCalculationService(acc, data);
                case 16:
                    return new TechniquePCalculationService(acc, data);
                case 17:
                    return new TechniqueQCalculationService(acc, data);
                case 18:
                    return new TechniqueRCalculationService(acc, data);
                default:
                    return null;
            }
        }
    }
}

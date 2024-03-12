using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;

namespace PsychTestsMilitary.Interfaces
{
    public interface ICreatingCalculation
    {
        CalculationService GetCalculationService(Account acc, UserAnswers data);
    }
}

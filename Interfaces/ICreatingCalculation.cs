using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Interfaces
{
    public interface ICreatingCalculation
    {
        CalculationService GetCalculationService(UserAnswers data);
    }
}

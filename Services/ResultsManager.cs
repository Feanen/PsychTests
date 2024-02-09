using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.TechniqueCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Services
{
    public class ResultsManager : ICreatingCalculation
    {
        public CalculationService GetCalculationService(UserAnswers data)
        {
            switch (data.TechniqueID)
            {
                case 1:
                    return new TechniqueACalculationService(data);
                default: 
                    return null;
            }
        }
    }
}

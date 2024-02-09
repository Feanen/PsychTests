using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PsychTestsMilitary.Interfaces
{
    public interface ICalculationService
    {
        void CalculationProcess();
        Window ShowResults();
    }
}

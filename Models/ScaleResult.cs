using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models
{
    public class ScaleResult
    {
        public double Result { get; private set; }
        public string Description { get; private set; }

        public ScaleResult(double result, string description)
        {
            Result = result;
            Description = description;
        }
    }
}

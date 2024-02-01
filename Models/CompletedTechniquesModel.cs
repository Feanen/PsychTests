using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models
{
    public class CompletedTechniquesModel
    {
        public string Name { get; }
        public UserAnswers Answers { get; }

        public CompletedTechniquesModel(string name, UserAnswers data)
        {
            Name = name;
            Answers = data;
        }
    }
}

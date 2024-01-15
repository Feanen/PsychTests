using PsychTestsMilitary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Interfaces
{
    public interface ITechniqueData
    {
        void Init(Technique tech, List<Question> quests);
        Question NextQuestion();   
    }
}

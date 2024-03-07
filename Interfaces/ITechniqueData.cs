using PsychTestsMilitary.Models;
using System.Collections.Generic;

namespace PsychTestsMilitary.Interfaces
{
    public interface ITechniqueData
    {
        void Init(Technique tech, Queue<Question> quests);
        Question NextQuestion();
    }
}

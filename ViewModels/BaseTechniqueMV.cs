using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PsychTestsMilitary.ViewModels
{
    public class BaseTechniqueMV : ITechniqueData
    {
        public Technique Technique { get; private set; }
        public List<Question> Questions { get; private set; }

        public void Init(Technique tech, List<Question> quests)
        {
            Technique = tech;
            Questions = quests;
        }
    }
}

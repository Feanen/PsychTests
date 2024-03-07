﻿using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using System.Collections.Generic;

namespace PsychTestsMilitary.ViewModels
{
    public class BaseTechniqueModel : ITechniqueData
    {
        public Technique Technique { get; private set; }
        public Queue<Question> Questions { get; set; }

        public void Init(Technique tech, Queue<Question> quests)
        {
            Technique = tech;
            Questions = quests;
        }

        public Question NextQuestion()
        {
            return (Questions.Count > 0) ? Questions.Dequeue() : null;
        }
    }
}

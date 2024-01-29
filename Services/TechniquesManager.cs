﻿using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.ViewModels;
using PsychTestsMilitary.ViewModels.TemplateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services
{
    public static class TechniquesManager
    {
        public static void RunNextTechnique()
        {
            if (TestsQueueSingleton.Instance.Techniques.Count != 0)
            {
                Technique tech = TestsQueueSingleton.Instance.Techniques.Dequeue();
                Queue<Question> questions = GetQuestions(tech);
                Window window = null;
                BaseTechniqueMV baseTechniqueMV = new BaseTechniqueMV();
                baseTechniqueMV.Init(tech, questions);

                switch (tech.Type)
                {                 
                    case 1:
                        window = new TechniqueType1(baseTechniqueMV);
                        break;
                    case 2:
                        window = new TechniqueType2(baseTechniqueMV);
                        break;
                }

                if (window != null)
                    window.Show();
            }
        }

        public static void SaveAnswers(int techID, List<UserAnswer> listOfAnswers)
        {
            UserAnswers answers = new UserAnswers("feanen1", techID, JSONStringParser.StringToJSON(listOfAnswers), DateTime.Today.Date);

            using (AccountContext context = new AccountContext())
            {
                context.UserAnswers.Add(answers);
                context.SaveChanges();
            }
        }

        private static Queue<Question> GetQuestions(Technique tech)
        {
            using (TechniquesContext context = new TechniquesContext())
            {
                return new Queue<Question>(context.Questions.Where(q => q.Technique_id == tech.Id).ToList());
            }
        }
    }
}

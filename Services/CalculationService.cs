﻿using Newtonsoft.Json;
using PsychTestsMilitary.Interfaces;
using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.Services.Singletons;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PsychTestsMilitary.Services
{
    public abstract class CalculationService : ICalculationService
    {
        protected UserAnswer[] userAnswers {  get; set; }
        protected List<TechniqueKey> techniqueKeys { get; set; }

        public CalculationService(UserAnswers answers) {
            userAnswers = GetAnswers(answers);
            techniqueKeys = GetKeys(answers.TechniqueID);
            CalculationProcess();
        }
        
        protected static UserAnswer[] GetAnswers(UserAnswers answers)
        {
            return JsonConvert.DeserializeObject<List<UserAnswer>>(answers.Answers).ToArray();     
        }

        protected static List<TechniqueKey> GetKeys(int techID)
        {
            TechniquesContext context = TechniquesDBSingleton.Instance.GetTechniqueContext();

            var keys = context.Keys
            .Where(u => u.Id == techID)
            .Select(u => u.Keys)
            .FirstOrDefault();
            
            return JsonConvert.DeserializeObject<List<TechniqueKey>>(keys);
        }

        public abstract void CalculationProcess();
        public abstract Window ShowResults();

        protected string ShowScaleResult(KeyValuePair<string, int> keyValues)
        {
            return (from barrier in AdditionalInfoDBSingleton.Instance.GetAddInfoContext().Barriers
                    join gradation in AdditionalInfoDBSingleton.Instance.GetAddInfoContext().Gradations on barrier.barrierID equals gradation.barrierID
                    join scale in AdditionalInfoDBSingleton.Instance.GetAddInfoContext().Scales on barrier.id equals scale.id
                    where gradation.Value == keyValues.Value && scale.Name == keyValues.Key
                    select barrier.Result)
                    .FirstOrDefault();
        }
    }
}

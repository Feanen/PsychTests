﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PsychTestsMilitary.Models;

namespace PsychTestsMilitary.Services
{
    public static class JSONStringParcer
    {
        public static List<AnswerOption> ParseAnswerOptions(string json)
        {
            AnswerOptions answerOption = JsonConvert.DeserializeObject<AnswerOptions>(json);
            return answerOption?.Options;
        }
    }
}

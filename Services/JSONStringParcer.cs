using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PsychTestsMilitary.Models;

namespace PsychTestsMilitary.Services
{
    public static class JSONStringParser
    {
        public static List<AnswerOption> ParseAnswerOptions(string json)
        {
            AnswerOptions answerOptions = JsonConvert.DeserializeObject<AnswerOptions>(json);
            return answerOptions?.Options;
        }

        public static string StringToJSON<T>(List<T> list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}

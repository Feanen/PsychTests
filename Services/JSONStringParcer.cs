using Newtonsoft.Json;
using PsychTestsMilitary.Models;
using System.Collections.Generic;

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

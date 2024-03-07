using System.Collections.Generic;

namespace PsychTestsMilitary.Models
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class AnswerOptions
    {
        public List<AnswerOption> Options { get; set; }
    }
}

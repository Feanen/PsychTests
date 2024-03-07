using System.ComponentModel.DataAnnotations;

namespace PsychTestsMilitary.Models
{
    public class Question
    {
        [Key] public int qId { get; set; }
        public int Technique_id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string Answer_options { get; set; }

        public Question() { }
        public Question(int id, int number, string description, int tech_id)
        {
            qId = id;
            Number = number;
            Description = description;
            Technique_id = tech_id;
        }
    }
}

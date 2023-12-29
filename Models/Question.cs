using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models
{
    public class Question
    {
        [Key] public int qId { get; set; }
        public int Technique_id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }

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

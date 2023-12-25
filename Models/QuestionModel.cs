using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }

        public QuestionModel() { }
        public QuestionModel(string number, string description, int id)
        {
            Number = number;
            Description = description;
            Id = id;
        }
    }
}

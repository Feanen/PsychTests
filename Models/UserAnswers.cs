using System;
using System.ComponentModel.DataAnnotations;

namespace PsychTestsMilitary.Models
{
    public class UserAnswers
    {
        [Key] public int id { get; set; }
        public string Login { get; set; }
        public int TechniqueID { get; set; }
        public string Answers { get; set; }
        public string Date { get; set; }

        public UserAnswers() { }

        public UserAnswers(string login, int techniqueID, string answers, DateTime dt)
        {
            Login = login;
            TechniqueID = techniqueID;
            Answers = answers;
            Date = dt.ToString().Substring(0, 10);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models
{
    public class UserAnswers
    {
        [Key] public int id { get; set; }

        public string Login {  get; set; }
        public int TechniqueID { get; set; }
        public string Answers { get; set; }
        public UserAnswers(string login, int techniqueID, string answers)
        {
            Login = login;
            TechniqueID = techniqueID;
            Answers = answers;
        }
    }
}

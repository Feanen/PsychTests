using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models
{
    public class Account
    {
        private string login { get; set; }
        private string surname { get; set; }
        private string name { get; set; }
        private string fname { get; set; }
        private string gender { get; set; }
        private string birthday { get; set; }
        private string job { get; set; }
        private string spec { get; set; }
        private string rank { get; set; }

        public Account() { }

        public Account(string login, string surname, string name, string fname, string gender, string birthday, string job, string spec, string rank)
        {
            this.login = login;
            this.surname = surname;
            this.name = name;
            this.fname = fname;
            this.gender = gender;
            this.birthday = birthday;
            this.job = job;
            this.spec = spec;
            this.rank = rank;
        }
    }
}

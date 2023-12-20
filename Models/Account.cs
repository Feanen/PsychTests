using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models
{
    public class Account
    {
        private string login;
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

        public string Login
        {
            get { return this.login; }
            set { this.login = value; }
        }

        public string Surname
        {
            get { return this.surname; }
            set { this.surname = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string FName
        {
            get { return this.fname; }
            set { this.fname = value; }
        }

        public string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public string Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        public string Job
        {
            get { return this.job; }
            set { this.job = value; }
        }

        public string Spec
        {
            get { return this.spec; }
            set { this.spec = value; }
        }

        public string Rank
        {
            get { return this.rank; }
            set { this.rank = value; }
        }
    }
}

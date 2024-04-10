﻿using System.ComponentModel.DataAnnotations;

namespace PsychTestsMilitary.Models
{
    public class Account
    {
        [Key] public string login { get; set; }
        private string surname, name, fname, gender, birthday, job, spec, rank, password;

        public Account() { }

        public Account(string login, string surname, string name, string fname, string gender, string birthday, string job, string spec, string rank, string pass)
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
            this.password = pass;
        }

        public string Surname
        {
            get => surname;
            set => surname = value;
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

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
    }
}

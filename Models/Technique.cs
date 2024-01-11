using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models
{
    public class Technique
    {
        public int id;

        public string Name { get; set; }

        public string Instruction { get; set; }

        public int Type { get; set; }

        public Technique() { }
        public Technique(int id, string name, string instruction, int type) 
        { 
            this.id = id;
            Name = name;
            Instruction = instruction; 
            Type = type;
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}

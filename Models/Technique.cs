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
        [Key] public int id { get; set; }

        private string name, instruction;

        public Technique() { }
        public Technique(int id, string name, string instruction) 
        { 
            this.id = id;
            this.name = name;
            this.instruction = instruction; 
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Instruction
        {
            get { return this.instruction; }
            set { this.instruction = value; }
        }

    }
}

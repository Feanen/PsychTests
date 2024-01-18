using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class Scale
    {
        public int id {  get; set; }
        public string Name { get; set; }

        public Scale(string name)
        {
            Name = name;
        }
    }
}

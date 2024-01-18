using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class Barrier
    {
        public int barrierID { get; set; }
        public int Id { get; set; }
        public int Number { get; set; }
        public string Result { get; set; }
        public Barrier( int id, int number, string result ) {
            Id = id;
            Number = number;
            Result = result;
        }
    }
}

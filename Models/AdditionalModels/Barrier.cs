using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class Barrier
    {
        [Key]
        public int barrierID { get; set; }
        public int id { get; set; }
        public int Number { get; set; }
        public string Result { get; set; }

        public Barrier() { }
        public Barrier(int barrID, int ident, int number, string result ) {
            barrierID = barrID;
            id = ident;
            Number = number;
            Result = result;
        }
    }
}

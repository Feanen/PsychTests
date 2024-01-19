using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace PsychTestsMilitary.Models
{
    public class Key
    {
        [Key] public int keyId { get; set; }
        public int Id { get; set; }
        public string Keys { get; set; }

        public Key(int id, string key)
        {
            Id = id;
            Keys = key;
        }
    }
}

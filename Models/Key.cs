using System.ComponentModel.DataAnnotations;

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

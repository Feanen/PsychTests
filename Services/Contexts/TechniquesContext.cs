using PsychTestsMilitary.Models;
using System.Data.Entity;

namespace PsychTestsMilitary.Services.Contexts
{
    public class TechniquesContext : DbContext
    {
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Key> Keys { get; set; }
        public TechniquesContext() : base("TechniquesConnection") { }

    }
}

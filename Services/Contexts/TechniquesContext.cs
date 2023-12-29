using PsychTestsMilitary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Services.Contexts
{
    public class TechniquesContext : DbContext
    {
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<Question> Questions { get; set; }
        public TechniquesContext() : base("TechniquesConnection") {}
      
    }
}

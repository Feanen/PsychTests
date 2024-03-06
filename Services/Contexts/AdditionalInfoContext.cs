using PsychTestsMilitary.Models.AdditionalModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychTestsMilitary.Services.Contexts
{
    public class AdditionalInfoContext : DbContext
    {
        public DbSet<Scale> Scales { get; set; }
        public DbSet<Barrier> Barriers { get; set; }
        public DbSet<Gradation> Gradations { get; set; }
        public DbSet<CorrectionFactor> CorrectionFactors { get; set; }
        public DbSet<GenderDifference> GenderDifferences { get; set; }
        public DbSet<AnxietyQuestionsCoefficient> AnxietyQuestionsCoefficients { get; set; }

        public AdditionalInfoContext() : base("AdditionalInfoConnection") {}
    }
}

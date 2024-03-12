using PsychTestsMilitary.Models.AdditionalModels;
using System.Data.Entity;

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

        public AdditionalInfoContext() : base("AdditionalInfoConnection") { }
    }
}

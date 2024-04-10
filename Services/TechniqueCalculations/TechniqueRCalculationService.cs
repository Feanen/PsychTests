using PsychTestsMilitary.Models;
using PsychTestsMilitary.Services.Contexts;
using PsychTestsMilitary.ViewModels.FinalResults;
using System.Linq;
using System.Windows;

namespace PsychTestsMilitary.Services.TechniqueCalculations
{
    public class TechniqueRCalculationService : CalculationService
    {
        public TechniqueRCalculationService(Account acc, UserAnswers answers) : base(acc, answers)
        {
            Answers = answers;
        }

        public override void CalculationProcess()
        {
            string[] questDesc;

            using (TechniquesContext techniquesContext = new TechniquesContext())
            {
                questDesc = techniquesContext.Questions.
                    Where(quest => quest.Technique_id.Equals(Answers.TechniqueID)).
                    OrderBy(order => order.Number).
                    Select(tb => tb.Description).
                    ToArray();
            }

            CalculatedResults = UserAnswers.
                OrderByDescending(rec => rec.AnswerID).
                Select(ans => new ScaleResult(ans.AnswerID, questDesc.ElementAt(ans.QuestionID - 1))).
                ToList();
        }

        public override Window ShowResults(Account personalData, string completedTechniqueDate, string techniqueName)
        {
            return new TechniqueR(CalculatedResults, string.Join(" ", personalData.Surname, personalData.Name, personalData.FName, personalData.Birthday),
                                                            completedTechniqueDate, techniqueName);
        }
    }
}

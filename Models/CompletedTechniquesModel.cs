namespace PsychTestsMilitary.Models
{
    public class CompletedTechniquesModel
    {
        public string Name { get; }
        public UserAnswers Answers { get; }

        public CompletedTechniquesModel(string name, UserAnswers data)
        {
            Name = name;
            Answers = data;
        }
    }
}

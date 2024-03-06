namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class AnxietyQuestionsCoefficient
    {
        public int id { get; set; }
        public int Coeff { get; set; }

        public AnxietyQuestionsCoefficient() { }

        public AnxietyQuestionsCoefficient(int coeff)
        {
            Coeff = coeff;
        }
    }
}

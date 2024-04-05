using System.ComponentModel.DataAnnotations;

namespace PsychTestsMilitary.Models.AdditionalModels
{
    public class NeuPsyScore
    {
        [Key]
        public int id { get; set; }
        public int Question { get; set; }
        public int Gender { get; set; }
        public int PosAnswer { get; set; }
        public int NegAnswer { get; set; }

        public NeuPsyScore() {}
        public NeuPsyScore(int id, int question, int gender, int posAnswer, int negAnswer)
        {
            Question = question;
            Gender = gender;
            PosAnswer = posAnswer;
            NegAnswer = negAnswer;
        }
    }
}

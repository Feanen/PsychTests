using System.Collections.Generic;

namespace PsychTestsMilitary.Models
{
    public class TechniqueKey
    {
        public string Scale { get; set; }

        public List<QAPair> Pairs { get; set; }

        public TechniqueKey(string scale) { this.Scale = scale; }
    }

    // class represents pair of questions ID and correct answers ID on it
    public class QAPair
    {
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }

        public QAPair(int questionID, int answerID)
        {
            QuestionID = questionID;
            AnswerID = answerID;
        }
    }
}

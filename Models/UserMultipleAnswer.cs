using System.Collections.Generic;

namespace PsychTestsMilitary.Models
{
    public class UserMultipleAnswer
    {
        public int QuestionID { get; set; }
        public List<int> AnswerID { get; set; }

        public UserMultipleAnswer(int questID, List<int> answerID)
        {
            QuestionID = questID;
            AnswerID = answerID;
        }
    }
}

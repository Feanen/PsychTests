namespace PsychTestsMilitary.Models
{
    public class UserAnswer
    {
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }
        public UserAnswer(int questID, int answerID = -1)
        {
            QuestionID = questID;
            AnswerID = answerID;
        }
    }
}

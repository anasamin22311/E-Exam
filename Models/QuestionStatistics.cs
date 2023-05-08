namespace E_Exam.Models
{
    public class QuestionStatistics
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
    }
}

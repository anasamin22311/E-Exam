namespace E_Exam.Models
{
    public class ExamQuestion
    {
        public ExamQuestion()
        {
            StudentAnswers = new List<StudentAnswer>();
        }
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}

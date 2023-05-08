namespace E_Exam.Models
{
    public class StudentAnswer
    {
        public int Id { get; set; }
        public int ExamQuestionId { get; set; }
        public ExamQuestion ExamQuestion { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}

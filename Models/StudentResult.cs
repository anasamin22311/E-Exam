namespace E_Exam.Models
{
    public class StudentResult
    {
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }
    }
}

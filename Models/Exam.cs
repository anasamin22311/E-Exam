using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class Exam
    {
        public Exam()
        {
            ExamQuestions = new List<ExamQuestion>();
            UserExams = new List<UserExam>();
        }
        
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int AllowedTime { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<UserExam> UserExams { get; set; }
    }
}

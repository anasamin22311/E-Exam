using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class SubjectProfessor
    {
        [Key]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Exam.Models
{

    public class UserExam
    {
        public int Id { get; set; } // Add a new surrogate key

        [MaxLength(256)] // Limit the UserId size
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
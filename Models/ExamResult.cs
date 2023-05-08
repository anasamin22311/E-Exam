using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class ExamResult
    {   
        public int Id { get; set; }
        public int StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int Score { get; set; }
        public DateTime Timestamp { get; set; }
    }
}


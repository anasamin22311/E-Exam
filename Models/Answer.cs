using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}

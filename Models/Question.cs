using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public QuestionType Type { get; set; } // MCQ or TrueFalse
        public DifficultyLevel Difficulty { get; set; } // A, B, or C
        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public enum QuestionType
        {
            MCQ,
            TrueFalse
        }

        public enum DifficultyLevel
        {
            A,
            B,
            C
        }
    }
}

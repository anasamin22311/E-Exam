using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class ExamStructure
    {
        public int Id { get; set; }
        public Chapter Chapter { get; set; }
        public int TotalQuestions { get; set; }
        public int MCQQuestions { get; set; }
        public int TFQuestions { get; set; }
        public int CategoryA { get; set; }
        public int CategoryB { get; set; }
        public int CategoryC { get; set; }
        public int ChapterId { get; set; }
    }
}

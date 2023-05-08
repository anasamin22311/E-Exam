using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class MCQQuestion : Question
    {
        public string CorrectAnswer { get; set; }
        public Options Choices { get; set; }
        public enum Options
        {
            a,
            b,
            c,
            d
        }
    }
}

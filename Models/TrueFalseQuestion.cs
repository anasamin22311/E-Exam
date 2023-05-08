using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }
    }
}

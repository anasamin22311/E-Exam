using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class Subject
    {
        public Subject()
        {
            Chapters = new List<Chapter>();
            Exams = new List<Exam>();
            SubjectProfessors = new List<SubjectProfessor>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Level { get; set; }
        [Required]
        public string Department { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<SubjectProfessor> SubjectProfessors { get; set; }
    }
}

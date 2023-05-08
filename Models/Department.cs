using System.ComponentModel.DataAnnotations;

namespace E_Exam.Models
{
    public class Department
    {
        public Department()
        {
            Subjects = new List<Subject>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }
        public List<Subject> Subjects { get; set; }
        public int LevelId { get; set; }

    }
}

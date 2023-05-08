using Microsoft.AspNetCore.Identity;

namespace E_Exam.Models
{
    public class Professor : ApplicationUser
    {
        public byte[] Photo { get; set; }
        public string PhoneNumber { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }
        public ICollection<SubjectProfessor> SubjectProfessors { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}

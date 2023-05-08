using Microsoft.AspNetCore.Identity;

namespace E_Exam.Models
{

    public class Student : ApplicationUser
    {
        public Level Level { get; set; }
        public Department Department { get; set; }
        public int LevelId { get; set; }
        public int DepartmentId { get; set; }

    }
}

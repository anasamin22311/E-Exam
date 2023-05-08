using Microsoft.AspNetCore.Identity;

namespace E_Exam.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserExams = new List<UserExam>();
            StudentRanks = new List<StudentRank>();
            StudentResults = new List<StudentResult>();
            ExamResults = new List<ExamResult>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        // public UserRole Role { get; set; } // "Admin", "Professor", or "Student"
        public ICollection<UserExam> UserExams { get; set; }
        public ICollection<StudentResult> StudentResults { get; set; }
        public ICollection<StudentRank> StudentRanks { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
        //public enum UserRole
        //{
        //    Admin,
        //    Professor,
        //    Student
        //}
    }
}

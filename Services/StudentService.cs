using E_Exam.Models;

namespace E_Exam.Services
{
    public class StudentService : IStudentService
    {
        public Task<List<ExamResult>> GetPreviousResultsAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> SelectSubjectAsync(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> SignInAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> SignUpAsync(ApplicationUser student)
        {
            throw new NotImplementedException();
        }

        public Task<Exam> StartExamAsync(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamResult> SubmitExamAsync(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}

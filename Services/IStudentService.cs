using E_Exam.Models;

namespace E_Exam.Services
{
    public interface IStudentService
    {
        Task<ApplicationUser> SignUpAsync(ApplicationUser student);
        Task<ApplicationUser> SignInAsync(string username, string password);
        Task<Subject> SelectSubjectAsync(int studentId, int subjectId);
        Task<Exam> StartExamAsync(int studentId, int subjectId);
        Task<ExamResult> SubmitExamAsync(Exam exam);
        Task<List<ExamResult>> GetPreviousResultsAsync(int studentId);
    }
}

using E_Exam.Models;

namespace E_Exam.Services
{
    public interface IExamService
    {
        Task<Exam> GenerateExamAsync(int studentId, int subjectId);
        Task<bool> ValidateExamConstraintsAsync(Exam exam);
        Task SetExamStartEndTimeAsync(int subjectId, DateTime startTime, DateTime endTime);
    }
}

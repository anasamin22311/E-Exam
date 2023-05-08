using E_Exam.Models;

namespace E_Exam.Services
{
    public class ExamService : IExamService
    {
        public Task<Exam> GenerateExamAsync(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task SetExamStartEndTimeAsync(int subjectId, DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateExamConstraintsAsync(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}

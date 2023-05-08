using E_Exam.Models;

namespace E_Exam.Services
{
    public interface IResultService
    {
        Task<ExamResult> SaveResultAsync(Exam exam);
        Task<StudentRank> GetStudentRankAsync(int studentId);
        Task<List<QuestionResult>> GetQuestionResultsAsync(int questionId);
    }
}

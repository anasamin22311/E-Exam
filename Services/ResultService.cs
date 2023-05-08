using E_Exam.Models;

namespace E_Exam.Services
{
    public class ResultService : IResultService
    {
        public Task<List<QuestionResult>> GetQuestionResultsAsync(int questionId)
        {
            throw new NotImplementedException();
        }

        public Task<StudentRank> GetStudentRankAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<ExamResult> SaveResultAsync(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}

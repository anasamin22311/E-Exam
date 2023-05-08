using E_Exam.Models;

namespace E_Exam.Services
{
    public class QuestionService : IQuestionService
    {
        public Task<Question> AddEditQuestionAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public Task AddQuestionsAsync(List<Question> questions)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionStatistics> GetQuestionStatisticsAsync(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}

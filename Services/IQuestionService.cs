using E_Exam.Models;

namespace E_Exam.Services
{
    public interface IQuestionService
    {
        Task AddQuestionsAsync(List<Question> questions);
        Task<Question> AddEditQuestionAsync(Question question);
        Task<QuestionStatistics> GetQuestionStatisticsAsync(int questionId);
    }
}

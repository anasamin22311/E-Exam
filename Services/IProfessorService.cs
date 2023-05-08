using E_Exam.Models;

namespace E_Exam.Services
{
    public interface IProfessorService
    {
        Task AddEditChapterAsync(Chapter chapter);
        Task OrganizeExamStructureAsync(ExamStructure examStructure);
        Task SetExamTimeAsync(int subjectId, TimeSpan time);
        Task AddEditQuestionAsync(Question question);
        Task<List<StudentResult>> GetStudentResultsAsync(int subjectId);
    }
}

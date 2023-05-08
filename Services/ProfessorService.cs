using E_Exam.Models;

namespace E_Exam.Services
{
    public class ProfessorService : IProfessorService
    {
        public Task AddEditChapterAsync(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public Task AddEditQuestionAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentResult>> GetStudentResultsAsync(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task OrganizeExamStructureAsync(ExamStructure examStructure)
        {
            throw new NotImplementedException();
        }

        public Task SetExamTimeAsync(int subjectId, TimeSpan time)
        {
            throw new NotImplementedException();
        }
    }
}

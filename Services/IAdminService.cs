using E_Exam.Models;

namespace E_Exam.Services
{
    public interface IAdminService
    {
        Task AddEditLevelAsync(Level level);
        Task AddEditDepartmentAsync(Department department);
        Task AddEditSubjectAsync(Subject subject);
        Task GetProfessorsAsync();
        Task ApproveProfessorAsync(int professorId);
        Task AssignSubjectToProfessorAsync(int professorId, int subjectId);
    }
}

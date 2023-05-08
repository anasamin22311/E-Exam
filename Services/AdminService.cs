using E_Exam.Models;

namespace E_Exam.Services
{
    public class AdminService : IAdminService
    {
        public Task AddEditDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public Task AddEditLevelAsync(Level level)
        {
            throw new NotImplementedException();
        }

        public Task AddEditSubjectAsync(Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task ApproveProfessorAsync(int professorId)
        {
            throw new NotImplementedException();
        }

        public Task AssignSubjectToProfessorAsync(int professorId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task GetProfessorsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using E_Exam.Models;

namespace E_Exam.Services
{
    public interface IAuthenticationService
    {
        Task<ApplicationUser> AuthenticateAsync(string username, string password);
        Task<ApplicationUser> RegisterAsync(ApplicationUser user);
        Task<bool> AuthorizeAsync(ApplicationUser user, string requiredRole);
    }
}

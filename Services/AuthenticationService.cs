using E_Exam.Models;

namespace E_Exam.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<ApplicationUser> AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AuthorizeAsync(ApplicationUser user, string requiredRole)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> RegisterAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}

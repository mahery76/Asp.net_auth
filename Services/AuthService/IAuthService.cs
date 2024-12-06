using backend.Models;

namespace backend.Services.AuthService
{
    public interface IAuthService
    {
        public Task<User> Login(string email, string password);
        public Task<User> Register(User user);
    }
}
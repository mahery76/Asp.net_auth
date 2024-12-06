using backend.Models;

namespace backend.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> GetUsers();
    }
}
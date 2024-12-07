using RestoMvc.Models;

namespace RestoMvc.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> GetUsers();
    }
}
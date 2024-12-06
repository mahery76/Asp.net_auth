using backend.Models;
using Microsoft.AspNetCore.Mvc;
using backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            List<User> Users = await _userService.GetUsers();
            return Ok(Users);
        }
    }
}
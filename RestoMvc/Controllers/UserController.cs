using RestoMvc.Models;
using Microsoft.AspNetCore.Mvc;
using RestoMvc.Services.UserService;
using Microsoft.AspNetCore.Authorization;

namespace RestoMvc.Controllers
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
        public async Task<ActionResult<List<User>>> GetUsers()
        {
           var users = await _userService.GetUsers();
            if(users == null || users.Count == 0)
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }
    }
}
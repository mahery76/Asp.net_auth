using backend.Models;
using backend.Services.AuthService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace backend.Controllers
{
    [Route("[Controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // post: auth/login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {
            if(String.IsNullOrEmpty(user.UserName))
            {
                return BadRequest (new {message = "email address need to entered"});
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                return BadRequest (new {message = "Password need to entered"});
            }

            User loggedInUser = await _authService.Login(user.UserName, user.Password);

            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }
            return BadRequest(new {message = "User login unsuccessful"});
        }

        // POST: auth/register
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser user)
        {
            if (String.IsNullOrEmpty(user.Name))
            {
                return BadRequest(new { message = "Name needs to entered" });
            }
            else if (String.IsNullOrEmpty(user.UserName))
            {
                return BadRequest(new { message = "User name needs to entered" });
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            User userToRegister = new(user.UserName, user.Name, user.Password, user.Role);

            User registeredUser = await _authService.Register(userToRegister);

            User loggedInUser = await _authService.Login(registeredUser.UserName, user.Password);

            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }

            return BadRequest(new { message = "User registration unsuccessful" });
        }

        // GET: auth/test
        [Authorize(Roles = "Everyone")]
        [HttpGet]
        public IActionResult Test()
        {
            string token = Request.Headers["Authorization"];
            if(token.StartsWith("Bearer"))
            {

                token = token.Substring("Bearer ".Length).Trim();
                Console.WriteLine(token + "this is the token");
            }
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwt = handler.ReadJwtToken(token);
            var claims = new Dictionary<string, string>();
            foreach(var claim in jwt.Claims)
            {
                claims.Add(claim.Type, claim.Value);
            }
            return Ok(claims);
        } 
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthServer.Core;

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginAsync(LoginRequest request)
        {
            // Validate user credentials
            var isValid = await _userService.ValidateCredentialsAsync(request.Username, request.Password);
            if (!isValid)
                return BadRequest("Invalid username or password.");

            // Generate JWT token
            var token = await _authService.GenerateTokenAsync(request.Username);
            return Ok(token);
        }


    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

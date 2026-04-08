using Microsoft.AspNetCore.Mvc;
using SnakeBE.Domain;
using SnakeBE.Domain.Application.Interfaces;

namespace SnakeBE.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticateController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var response = await authService.Login(loginModel);
            
            if (response.AuthData != null) 
                return Ok(response);
            return Unauthorized(); 
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var response = await authService.Register(registerModel);

            if (response.Status != "200")
                return Conflict(response.Message);        
            return Created();
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel registerModel)
        {
            var response = await authService.RegisterAdmin(registerModel);
            if (response.Status != "200")
                return Conflict(response.Message);
            return Created();
        }
    }
}
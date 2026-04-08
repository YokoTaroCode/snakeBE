using Microsoft.AspNetCore.Mvc;
using SnakeBE.Domain;
using SnakeBE.Domain.Application.Interfaces;
using SnakeBE.Domain.dto;

namespace SnakeBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetSingleAsync(int id)
        {
            return userService.GetSingleAsync(id)
                .ContinueWith(task => (IActionResult)Ok(task.Result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.DeleteUser(id);
            return NoContent();
        }
    }
}

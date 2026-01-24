using B_Infrastructure.dto;
using B_Infrastructure.dtodotnet;
using B_Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace A_snakeBE.Controllers
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

        [HttpPost]
        public async Task<IActionResult> CreateGameAsync([FromBody] UserDto game)
        { 
            await userService.CreateGameAsync(game);
            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await userService.DeleteUser(id);
            return NoContent();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using SnakeBE.Infrastructure.dto;
using SnakeBE.Infrastructure.Repository.Interfaces;

namespace A_snakeBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController(IGameService gameService): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var gamesDto = await gameService.GetAllAsync();
            return Ok(gamesDto);
        }

        [HttpGet("games/{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            GameDto? gameDto = await gameService.GetSingleAsync(id);
            return gameDto != null ? Ok(gameDto) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameAsync([FromBody] GameDto game)
        {
            await gameService.CreateGameAsync(game);
            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await gameService.DeleteGame(id);
            return NoContent();
        }
    }
}


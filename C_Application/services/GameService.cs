using B_Infrastructure.Interfaces;
using SnakeBE.Domain;
using SnakeBE.Infrastructure.dto;
using SnakeBE.Infrastructure.Repository.Interfaces;

namespace SnakeBE.Application.services
{
    public class GameService : IGameService
    {

        private readonly IGameRepo _gameRepo;
        private readonly IUserRepo _userRepo;

        public GameService(IGameRepo gameRepo, IUserRepo userRepo)
        {
            _gameRepo = gameRepo;
            _userRepo = userRepo;
        }

        public async Task CreateGameAsync(GameDto gameDto, CancellationToken ct = default)
        {
            var user = await _userRepo.GetSingleAsync(gameDto.UserId, ct)
                ?? throw new KeyNotFoundException($"Nessun utente con ID {gameDto.UserId} associato al gioco con ID {gameDto.Id}");

           await _gameRepo.CreateGameAsync(new Game
            {
                User = user,
                UserId = user.UserId,
                Points = gameDto.Points,
                Time = gameDto.Time,
                Date = gameDto.Date,
           }, ct);

           await _gameRepo.SaveAsync(ct);
        }
        public async Task DeleteGame(int id, CancellationToken ct = default)
        {
            var game = await _gameRepo.GetSingleAsync(id,ct) ?? 
                throw new KeyNotFoundException($"Impossibile eliminare il gioco con ID {id} perchè non esiste nel contesto");

            _gameRepo.DeleteGame(game);
            await _gameRepo.SaveAsync(ct);
        }

        public async Task<IEnumerable<GameDto>> GetAllAsync(CancellationToken ct = default)
        {
            var games = await _gameRepo.GetAllAsync(ct);

            return games.Select(g => new GameDto
            {
                Id = g.GameId,
                UserId = g.UserId,
                Points = g.Points,
                Time = g.Time,
                Date = g.Date,
            });
        }
        public async Task<GameDto?> GetSingleAsync(int id, CancellationToken ct = default)
        {
            var game = await _gameRepo.GetSingleAsync(id,ct)
                ?? throw new KeyNotFoundException($"Il gioco con ID {id} non esiste nel contest");
            

            return new GameDto
            {
                Id = game.GameId,
                UserId = game.UserId,
                Points = game.Points,
                Time = game.Time,
                Date = game.Date,
            };
        }
    }
}

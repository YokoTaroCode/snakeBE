using B_Infrastructure.dto;
using B_Infrastructure.Interfaces;
using B_Infrastructure.repos;
using D_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure.services
{
    internal class GameService : IGameService
    {

        private readonly GameRepo _gameRepo;
        private readonly UserRepo _userRepo;

        public GameService(GameRepo gameRepo, UserRepo userRepo)
        {
            _gameRepo = gameRepo;
            _userRepo = userRepo;
        }

        public async Task CreateGameAsync(GameDto gameDto)
        {
            var user = await _userRepo.GetSingleAsync(gameDto.UserId)
                ?? throw new Exception("User non trovato");

           await _gameRepo.CreateGameAsync(new Game
            {
                User = user,
                UserId = user.UserId,
                Points = gameDto.Points,
                Time = gameDto.Time
            });
        }
        public async Task DeleteGame(int id)
        {
            var game = await _gameRepo.GetSingleAsync(id) ?? 
                throw new Exception("Game non trovato");

            _gameRepo.DeleteGame(game);
        }

        public async Task<IEnumerable<GameDto>> GetAllAsync()
        {
            var games = await _gameRepo.GetAllAsync();

            return games.Select(g => new GameDto
            {
                UserId = g.UserId,
                Points = g.Points,
                Time = g.Time,
                Date = DateTime.Now,
            });

        }
        public async Task<GameDto?> GetSingleAsync(int id)
        {
            var game = await _gameRepo.GetSingleAsync(id)
                ?? throw new Exception("Game non trovato");
            ;

            return new GameDto
            {
                UserId = game.UserId,
                Points = game.Points,
                Time = game.Time,
                Date = DateTime.Now,
            };
        }
    }
}

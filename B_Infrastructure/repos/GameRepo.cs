using B_Infrastructure.db;
using D_Domain;
using Microsoft.EntityFrameworkCore;

namespace B_Infrastructure.repos
{
    public class GameRepo(SnakeDbContext ctx) : IGameRepo
    {

        private readonly SnakeDbContext _ctx = ctx;

        public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken ct = default)
        { 
            return await _ctx.Games
                .Include(g => g.User)
                .ToListAsync(ct);
        }

        public async Task<Game?> GetSingleAsync(int id, CancellationToken ct = default)
        {
            return await _ctx.Games.FindAsync(id,ct);
        } 

        public async Task CreateGameAsync(Game game, CancellationToken ct = default)
        {

            await _ctx.Games.AddAsync(game,ct);
        }
        public void DeleteGame(Game game)
        {
             _ctx.Remove(game);
        }
        public Task SaveAsync(CancellationToken ct = default)
        {
            return _ctx.SaveChangesAsync(ct);
        }
    }
}

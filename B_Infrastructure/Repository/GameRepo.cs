using B_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using SnakeBE.Domain;
using SnakeBE.Infrastructure.db;

namespace SnakeBE.Infrastructure.Repository
{
    public class GameRepo(SnakeDbContext ctx) : IGameRepo
    {
        public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken ct = default) 
            => await ctx.Games.Include(g => g.User).ToListAsync(ct);
        public async Task<Game?> GetSingleAsync(int id, CancellationToken ct = default) 
            => await ctx.Games.FindAsync([id, ct], ct);

        public async Task CreateGameAsync(Game game, CancellationToken ct = default) 
            => await ctx.Games.AddAsync(game,ct);
        public void DeleteGame(Game game) 
            => ctx.Remove(game);
        public Task SaveAsync(CancellationToken ct = default) 
            => ctx.SaveChangesAsync(ct);
        
    }
}

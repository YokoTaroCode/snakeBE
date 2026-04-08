using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SnakeBE.Domain;
using SnakeBE.Domain.Repository.Interfaces;
using SnakeBE.Infrastructure.db;
using System.Numerics;

namespace SnakeBE.Infrastructure.Repository
{
    public class UserRepo(SnakeDbContext ctx) : IUserRepo
    {
        public async Task CreateUserAsync(Player player, CancellationToken ct = default)
            => await ctx.AddAsync(player, ct);
        public async Task DeleteIdentityUserAsync(string identityId, CancellationToken ct = default)
            => await ctx.Users.Where(u => u.Id == identityId).ExecuteDeleteAsync(ct); 
        public async Task<IEnumerable<Player>> GetAllAsync(CancellationToken ct = default)
            => await ctx.Players.Include(u => u.Games).ToListAsync(ct);
        public async Task<Player?> GetSingleAsync(int id, CancellationToken ct = default)
            =>  await ctx.Players.Include(p => p.Games).FirstOrDefaultAsync(p => p.UserId == id, ct);
        public Task SaveAsync(CancellationToken ct = default)
            => ctx.SaveChangesAsync(ct);
        public void UpdateUser(Player player)
            => ctx.Players.Update(player);
    }
}

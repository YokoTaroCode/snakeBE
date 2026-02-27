using Microsoft.EntityFrameworkCore;
using SnakeBE.Domain;
using SnakeBE.Infrastructure.db;
using SnakeBE.Infrastructure.Repository.Interfaces;

namespace SnakeBE.Infrastructure.Repository
{
    public class UserRepo(SnakeDbContext ctx) : IUserRepo
    {
        public async Task CreateUserAsync(User user, CancellationToken ct = default) 
            => await ctx.AddAsync(user,ct); 
        public void DeleteUser(User user)
            => ctx.Remove(user);
        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default)
            => await ctx.Users.Include(u => u.Games).ToListAsync(ct);
        public async Task<User?> GetSingleAsync(int id, CancellationToken ct = default)
            => await ctx.Users.FindAsync([id,ct],ct);
        public Task SaveAsync(CancellationToken ct = default)
            => ctx.SaveChangesAsync(ct);
        public void UpdateUser(User user)
            => ctx.Users.Update(user);
    }
}

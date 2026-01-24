using B_Infrastructure.db;
using B_Infrastructure.Interfaces;
using D_Domain;
using Microsoft.EntityFrameworkCore;

namespace B_Infrastructure.repos
{
    public class UserRepo(SnakeDbContext ctx) : IUserRepo
    {
        private readonly SnakeDbContext _ctx = ctx;

        public async Task CreateUserAsync(User user, CancellationToken ct = default)
        {
           await _ctx.AddAsync(user,ct); 
        }
        public void DeleteUser(User user)
        {
            _ctx.Remove(user);
        }
        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default)
        {
            return await _ctx.Users
                .Include(u => u.Games)
                .ToListAsync(ct);
        }
        public async Task<User?> GetSingleAsync(int id, CancellationToken ct = default)
        {
            return await _ctx.Users.FindAsync(id,ct);
        }
        public Task SaveAsync(CancellationToken ct = default)
        {
            return _ctx.SaveChangesAsync(ct);
        }
        public void UpdateUser(User user)
        {
            _ctx.Users.Update(user);
        }
    }
}

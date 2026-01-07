using B_Infrastructure.db;
using B_Infrastructure.Interfaces;
using D_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure.repos
{
    public class UserRepo : IUserRepo
    {
        private readonly SnakeDbContext _ctx;
        public async Task CreateUserAsync(User user)
        {
           await _ctx.AddAsync(user); 
        }
        public void DeleteUser(User user)
        {
            _ctx.Remove(user);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _ctx.Users
                .Include(u => u.Games)
                .ToListAsync();
        }
        public async Task<User?> GetSingleAsync(int id)
        {
            return await _ctx.Users.FindAsync(id);
        }
        public Task SaveAsync()
        {
            return _ctx.SaveChangesAsync();
        }
        public void UpdateUser(User user)
        {
            _ctx.Users.Update(user);
        }
    }
}

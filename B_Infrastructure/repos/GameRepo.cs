using B_Infrastructure.db;
using B_Infrastructure.dto;
using B_Infrastructure.Interfaces;
using D_Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure.repos
{
    public class GameRepo : IgameRepo
    {

        private readonly SnakeDbContext _ctx;

        public GameRepo(SnakeDbContext ctx) { 
            this._ctx = ctx;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        { 
            return await _ctx.Games
                .Include(g => g.User)
                .ToListAsync();
        }

        public async Task<Game?> GetSingleAsync(int id)
        {
            return await _ctx.Games.FindAsync(id);
        } 

        public async Task CreateGameAsync(Game game)
        {

            await _ctx.Games.AddAsync(game);
        }
        public void DeleteGame(Game game)
        {
             _ctx.Remove(game);
        }
        public Task SaveAsync()
        {
            return _ctx.SaveChangesAsync();
        }
    }
}

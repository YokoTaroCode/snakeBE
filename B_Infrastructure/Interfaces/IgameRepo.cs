using D_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure
{
    public interface IgameRepo
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game?> GetSingleAsync(int id);
        Task CreateGameAsync(Game game);
        void DeleteGame(Game game);
        Task SaveAsync();

    }
}

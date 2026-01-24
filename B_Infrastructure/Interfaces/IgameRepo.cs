using D_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure
{
    public interface IGameRepo
    {
        Task<IEnumerable<Game>> GetAllAsync(CancellationToken ct = default);
        Task<Game?> GetSingleAsync(int id, CancellationToken ct = default);
        Task CreateGameAsync(Game game, CancellationToken ct = default);
        void DeleteGame(Game game);
        Task SaveAsync(CancellationToken ct = default);

    }
}

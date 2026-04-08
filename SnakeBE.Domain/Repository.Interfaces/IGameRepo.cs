using SnakeBE.Domain;
using SnakeBE.Domain.dto;

namespace SnakeBE.Domain.Repository.Interfaces
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

using SnakeBE.Domain.dto;

namespace SnakeBE.Domain.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllAsync(CancellationToken ct = default);
        Task<GameDto?> GetSingleAsync(int id, CancellationToken ct = default);
        Task CreateGameAsync(GameDto gameDto, CancellationToken ct = default);
        Task DeleteGame(int id, CancellationToken ct = default);
    }
}

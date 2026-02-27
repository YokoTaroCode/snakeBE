using SnakeBE.Infrastructure.dto;

namespace SnakeBE.Infrastructure.Repository.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken ct = default);
        Task<UserDto?> GetSingleAsync(int id, CancellationToken ct = default);
        Task CreateGameAsync(UserDto userDto, CancellationToken ct = default);
        Task DeleteUser(int id, CancellationToken ct = default);
    }
}

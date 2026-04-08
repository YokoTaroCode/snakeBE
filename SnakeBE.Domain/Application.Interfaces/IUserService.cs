using SnakeBE.Domain.dto;

namespace SnakeBE.Domain.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto?>> GetAllAsync(CancellationToken ct = default);
        Task<UserDto?> GetSingleAsync(int id, CancellationToken ct = default);
        Task CreateIdentifiedUserAsync(IdentifiedUserCreateModel userDto, CancellationToken ct = default);
        Task DeleteUser(int id, CancellationToken ct = default);
    }
}

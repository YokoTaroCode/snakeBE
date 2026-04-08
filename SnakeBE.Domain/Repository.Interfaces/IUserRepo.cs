using SnakeBE.Domain;
using SnakeBE.Domain.dto;
using System.Security.Principal;

namespace SnakeBE.Domain.Repository.Interfaces
{
    public interface IUserRepo
    {
        Task CreateUserAsync(Player user, CancellationToken ct = default);
        Task<IEnumerable<Player>> GetAllAsync(CancellationToken ct = default);
        Task<Player?> GetSingleAsync(int id, CancellationToken ct = default);

        //Task<Player?> GetSingleByIdentityIdAsync(string identityId, CancellationToken ct = default);
        Task SaveAsync(CancellationToken ct = default);
        void UpdateUser(Player player);
        Task DeleteIdentityUserAsync(string IdentityId, CancellationToken ct = default);

    }
}


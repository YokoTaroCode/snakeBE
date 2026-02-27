using SnakeBE.Domain;

namespace SnakeBE.Infrastructure.Repository.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default);
        Task<User?> GetSingleAsync(int id , CancellationToken ct = default);
        Task CreateUserAsync(User user, CancellationToken ct = default);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task SaveAsync(CancellationToken ct = default);
    }
}

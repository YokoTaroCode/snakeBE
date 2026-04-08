using SnakeBE.Domain;
using SnakeBE.Domain.Application.Interfaces;
using SnakeBE.Domain.dto;
using SnakeBE.Domain.Repository.Interfaces;

namespace SnakeBE.Application.services
{
    public class UserService(IUserRepo userRepo, Mapper mapper) : IUserService
    {
        public async Task CreateIdentifiedUserAsync(IdentifiedUserCreateModel IdentifiedUser, CancellationToken ct = default)
        {
            var user = mapper.IdentityModelToEntity(IdentifiedUser);
            await userRepo.CreateUserAsync(user, ct);
            await userRepo.SaveAsync(ct);
        }

        public async Task DeleteUser(int id, CancellationToken ct = default)
        {
           var player = await userRepo.GetSingleAsync(id,ct) 
                      ?? throw new KeyNotFoundException($"Impossibile eliminare l'utente con ID {id} perchè non esiste nel contesto");

            await userRepo.DeleteIdentityUserAsync(player.IdentityUserId, ct);
            await userRepo.SaveAsync(ct);
        }

        public async Task<IEnumerable<UserDto?>> GetAllAsync(CancellationToken ct = default)
        {
            var users = await userRepo.GetAllAsync(ct);
            return users.Select(mapper.UserToDto);
        }

        public async Task<UserDto?> GetSingleAsync(int id, CancellationToken ct = default)
        {
            var user = await userRepo.GetSingleAsync(id, ct)
                 ?? throw new KeyNotFoundException($"L'utente con ID {id} non esiste nel contesto");

            return mapper.UserToDto(user);

        }
    }
}

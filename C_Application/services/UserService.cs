using SnakeBE.Domain;
using SnakeBE.Infrastructure.dto;
using SnakeBE.Infrastructure.Repository.Interfaces;

namespace SnakeBE.Application.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task CreateGameAsync(UserDto userDto, CancellationToken ct = default)
        {

            await _userRepo.CreateUserAsync(new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                SubDate = DateTime.Now
            }, ct);
            await _userRepo.SaveAsync(ct);
        }

        public async Task DeleteUser(int id, CancellationToken ct = default)
        {
           var user = await _userRepo.GetSingleAsync(id) 
                      ?? throw new KeyNotFoundException($"Impossibile eliminare l'utente con ID {id} perchè non esiste nel contesto");

            _userRepo.DeleteUser(user);
            await _userRepo.SaveAsync(ct);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken ct = default)
        {
            var users = await _userRepo.GetAllAsync(ct);

            return users.Select(u => new UserDto
            {
                Username = u.Username,
                Password = u.Password,
                SubDate = u.SubDate,
                UserId = u.UserId
            });
        }

        public async Task<UserDto?> GetSingleAsync(int id, CancellationToken ct = default)
        {
            var user = await _userRepo.GetSingleAsync(id, ct)
                 ?? throw new KeyNotFoundException($"L'utente con ID {id} non esiste nel contesto");

            return new UserDto
            {
                Username = user.Username,
                UserId = user.UserId,
                Password = user.Password,
                SubDate = user.SubDate,
            };

        }
    }
}

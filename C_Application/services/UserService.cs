using B_Infrastructure.dto;
using B_Infrastructure.Interfaces;
using B_Infrastructure.repos;
using D_Domain;

namespace B_Infrastructure.services
{
    internal class UserService : IUserService
    {
        private readonly UserRepo _userRepo;

        public UserService(GameRepo gameRepo, UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task CreateGameAsync(UserDto userDto)
        {

            await _userRepo.CreateUserAsync(new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                SubDate = DateTime.Now
            });
        }

        public async Task DeleteGame(int id)
        {
           var user = await _userRepo.GetSingleAsync(id) 
                      ?? throw new Exception("User non trovato");

            _userRepo.DeleteUser(user);
       }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();

            return users.Select(u => new UserDto
            {
                Username = u.Username,
                Password = u.Password,
                SubDate = u.SubDate,
                UserId = u.UserId
            });
        }

        public async Task<UserDto?> GetSingleAsync(int id)
        {
            var user = await _userRepo.GetSingleAsync(id)
                 ?? throw new Exception("User non trovato");

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

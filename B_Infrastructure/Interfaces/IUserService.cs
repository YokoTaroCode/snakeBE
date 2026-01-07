using B_Infrastructure.dto;
using D_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetSingleAsync(int id);
        Task CreateGameAsync(UserDto userDto);
        Task DeleteGame(int id);
    }
}

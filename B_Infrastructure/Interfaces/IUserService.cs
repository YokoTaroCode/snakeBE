using B_Infrastructure.dto;
using B_Infrastructure.dtodotnet;
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
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken ct = default);
        Task<UserDto?> GetSingleAsync(int id, CancellationToken ct = default);
        Task CreateGameAsync(UserDto userDto, CancellationToken ct = default);
        Task DeleteUser(int id, CancellationToken ct = default);
    }
}

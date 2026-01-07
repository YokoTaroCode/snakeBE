using B_Infrastructure.dto;
using D_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllAsync();
        Task<GameDto?> GetSingleAsync(int id);
        Task CreateGameAsync(GameDto gameDto);
        Task DeleteGame(int id);
    }
}

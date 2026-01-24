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
        Task<IEnumerable<GameDto>> GetAllAsync(CancellationToken ct = default);
        Task<GameDto?> GetSingleAsync(int id, CancellationToken ct = default);
        Task CreateGameAsync(GameDto gameDto, CancellationToken ct = default);
        Task DeleteGame(int id, CancellationToken ct = default);
    }
}

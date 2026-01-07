using D_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure.Interfaces
{
    internal interface IUserRepo
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetSingleAsync(int id);
        Task CreateUserAsync(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task SaveAsync();
    }
}

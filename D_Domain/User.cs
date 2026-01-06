using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain
{
    public class User
    {
        string Username { get; set; }
        string Password { get; set; }
        string subDate { get; set; }

        public int UserId { get; set; } // k
        public Game[] Games { get; set; } // nav prop
    }
}


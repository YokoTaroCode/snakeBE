using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime SubDate { get; set; }

        public int UserId { get; set; } // k
        public ICollection<Game> Games { get; set; } // nav prop
    }
}


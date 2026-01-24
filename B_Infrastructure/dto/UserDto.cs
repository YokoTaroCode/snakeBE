using D_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure.dtodotnet 
{
    public class UserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public DateTime SubDate { get; set; }
        public int UserId { get; set; } 
    }
}
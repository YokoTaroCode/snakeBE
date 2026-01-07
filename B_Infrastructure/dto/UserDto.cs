using D_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure.dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime SubDate { get; set; }
        public int UserId { get; set; } 
    }
}
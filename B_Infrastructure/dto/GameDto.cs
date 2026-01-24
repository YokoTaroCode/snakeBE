using D_Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Infrastructure.dto
{
    public class GameDto
    {
        public required int Id { get; set; } 
        public int UserId { get; set; } 
        public required int  Points { get; set; }
        public required int Time { get; set; }
        public required DateTime Date { get; set; }
    }
}

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
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; } // fk 
        public int Points { get; set; }
        public int Time { get; set; }
        public DateTime Date { get; set; }
    }
}

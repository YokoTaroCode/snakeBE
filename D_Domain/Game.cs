using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain
{
    public class Game
    {        
        public User? User { get; set; } // mantenere come nullabile?

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; } 
        public int Points { get; set; }
        public int Time  { get; set; }

        [Key]
        public int GameId { get; set; }

        public DateTime Date { get; set; }
    }
}

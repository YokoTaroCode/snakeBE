using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeBE.Domain
{
    public class Game
    {        
        public User? User { get; set; } 

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; } 
        public int Points { get; set; }
        public int Time  { get; set; }

        [Key]
        public int GameId { get; set; }

        public DateTime Date { get; set; }
    }
}

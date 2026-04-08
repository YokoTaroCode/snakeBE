namespace SnakeBE.Domain
{
    public class Player
    {
        public string Username { get; set; }
        public string IdentityUserId { get; set; }
        public DateTime SubDate { get; set; }
        public int UserId { get; set; } 
        public ICollection<Game> Games { get; set; } 
    }

}

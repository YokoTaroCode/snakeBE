namespace SnakeBE.Domain
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


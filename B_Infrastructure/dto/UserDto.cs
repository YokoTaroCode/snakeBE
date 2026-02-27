namespace SnakeBE.Infrastructure.dto
{
    public class UserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public DateTime SubDate { get; set; }
        public int UserId { get; set; } 
    }
}
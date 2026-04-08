namespace SnakeBE.Domain.dto
{
    public class UserDto
    {
        public required string Username { get; set; }
        public DateTime SubDate { get; set; }
        public ICollection<GameDto> Games { get; set; }
        public int UserId { get; set; } 
    }
}
namespace SnakeBE.Infrastructure.dto
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

using SnakeBE.Domain;

namespace SnakeBE
{
    public class Response
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public AuthData? AuthData { get; set; }
    }
}
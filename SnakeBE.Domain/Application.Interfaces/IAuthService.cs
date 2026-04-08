using SnakeBE;
using SnakeBE.Domain;

public interface IAuthService
{
    Task<Response> Login(LoginModel model);
    Task<Response> Register(RegisterModel model);
    Task<Response> RegisterAdmin(RegisterModel model);
}
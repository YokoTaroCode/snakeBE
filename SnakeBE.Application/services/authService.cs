using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SnakeBE.Domain;
using SnakeBE.Domain.Application.Interfaces;
using SnakeBE.Domain.dto;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;

namespace SnakeBE.Application.services
{
    public class AuthService(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        IUserService userService) : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly IConfiguration _configuration = configuration;
        private readonly IUserService _userService = userService;

        public async Task<Response> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.UserName!),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                var token = CreateToken(authClaims);

                return new()
                {
                    Status = "200",
                    Message = "Success",
                    AuthData = new AuthData
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    }
                };
            }

            return new()
            {
                Status = "401",
                Message = "Unauthorized",
                AuthData = null
            }; 
        }

        public async Task<Response> Register(RegisterModel model)
        {
            if (await _userManager.FindByNameAsync(model.Username) != null)
                return new()
                {
                    Status = "409",
                    Message = "Player Already Exist!",
                    AuthData = null
                };

            IdentityUser user = new() 
            {
                SecurityStamp = Guid.NewGuid().ToString(), 
                UserName = model.Username 
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return new()
                {
                    Status = "409",
                    Message = "Player creation failed! Check requirements.",
                    AuthData = null
                };

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            await _userManager.AddToRoleAsync(user!, UserRoles.User);

            await _userService.CreateIdentifiedUserAsync(new IdentifiedUserCreateModel
            {
                Username = model.Username,
                IdentityUserId = user.Id,
            });

            return new()
            {
                Status = "200",
                Message = "Player created successfully!",
                AuthData = null
            };
        }

        public async Task<Response> RegisterAdmin(RegisterModel model)
        {
            var response = await Register(model);
            if (response.Status != "200") return response;

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null)
            {
                var notExistAdmin = !await _roleManager.RoleExistsAsync(UserRoles.Admin);
                var notExistUser = !await _roleManager.RoleExistsAsync(UserRoles.User);

                if (notExistAdmin)
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (notExistUser)
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                await _userManager.AddToRoleAsync(user, UserRoles.User);

                return new()
                {
                    Status = "200",
                    Message = "Admin created successfully!",
                    AuthData = null
                };
            }
            else
            {
                return new()
                {
                    Status = "500",
                    Message = "Admin creation failed!",
                    AuthData = null
                }; ;
            }
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            return new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        }
    }
}
using ECommerce.Application.Services;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Domain.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateAccessToken(AppUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var tokenDescription = new SecurityTokenDescriptor()
        {
            Expires = DateTime.UtcNow.AddMinutes(3),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),

            Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Role, user.Role!),
                new Claim(ClaimTypes.Email, user.Email!)
            })
        };


        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken? token = tokenHandler.CreateToken(tokenDescription);


        return tokenHandler.WriteToken(token);
    }

    public RefreshToken CreateRefreshToken()
    {
        var refreshToken = new RefreshToken()
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            ExpireTime = DateTime.UtcNow.AddMinutes(30),
            CreateTime = DateTime.UtcNow
        };
        return refreshToken;
    }

    public RefreshToken CreateRepasswordToken()
    {
        var repasswordToken = new RefreshToken()
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            ExpireTime = DateTime.UtcNow.AddMinutes(30),
            CreateTime = DateTime.UtcNow
        };
        return repasswordToken;
    }
}

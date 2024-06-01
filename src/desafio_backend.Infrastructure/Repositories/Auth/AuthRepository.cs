using desafio_backend.Domain.Entities;
using desafio_backend.Domain.Enums;
using desafio_backend.Domain.Repositories.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace desafio_backend.Infrastructure.Repositories.Auth;
public class AuthRepository : IAuthRepository
{
    private readonly IConfiguration _configuration;

    public AuthRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Token GenerateToken(long id, string email, AccountType accountType)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Hash, id.ToString()),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, accountType.ToString()),
            new Claim("jti", Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration["jwt:secretKey"]!));

        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddHours(1);

        JwtSecurityToken token = new(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

        return new Token
        {
            Expires = expiration,
            TokenInfo = new JwtSecurityTokenHandler().WriteToken(token),
        };
    }
}

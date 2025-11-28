using BookEaseSuite.Application.Interfaces;
using BookEaseSuite.Domain.Enums;
using BookEaseSuite.Infrastructrue.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookEaseSuite.Infrastructrue.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<TokenService> _logger;

        public TokenService(ILogger<TokenService> logger, IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
            _logger = logger;
        }
        public string GetToken(long id, string email, string userName, UserRole role)
        {
            _logger.LogInformation("Generating JWT token for user {UserId}, email {Email},userName {userName} role {Role}", id, email, userName, role);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,id.ToString()),
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Role,role.ToString()),
                new Claim(ClaimTypes.Name,userName)
            };
            var creds = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: creds
                );
            _logger.LogInformation("JWT token generated for user {UserId}", id);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

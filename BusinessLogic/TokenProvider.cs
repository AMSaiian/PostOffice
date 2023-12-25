using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLogic.Interfaces;
using Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IConfiguration _configuration;

        public TokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public (string, DateTime) CreateToken(Staff userStaff)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var expireTime = DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiryTime"]));

            var options = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: new List<Claim>()
                {
                    new(JwtRegisteredClaimNames.Sub, userStaff.Id.ToString()),
                    new(ClaimTypes.Role, userStaff.Role.ToString()),
                },
                expires:expireTime,
                signingCredentials:signInCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(options);

            return (token, expireTime);
        }
    }
}

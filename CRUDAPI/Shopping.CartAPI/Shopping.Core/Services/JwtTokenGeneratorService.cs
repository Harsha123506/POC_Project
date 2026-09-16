using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shopping.Core.Services
{
    public class JwtTokenGeneratorService
    {
        public JwtTokenGeneratorService()
        {
        }
            public string generateJwtToken(string userName, string Key,string issuer, string audience, string expiry)
            {
            //var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                },
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(expiry)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
            }


        public bool ValidateToken()
        {
            return true;
        }
    }
}

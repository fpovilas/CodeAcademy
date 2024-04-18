using JWTAuth.Service.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JWTAuth.Service
{
    public class JWTService(IConfiguration configuration) : IJWTService
    {
        private readonly IConfiguration _configuration = configuration;

        public string GetJWT(string user)
        {
            List<Claim> claims =
            [
                new Claim(ClaimTypes.Name, user)
            ];
            var secretToken = _configuration.GetSection("Jwt:Key").Value;
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretToken!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddSeconds(600),
                signingCredentials: cred);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

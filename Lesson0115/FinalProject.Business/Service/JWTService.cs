using FinalProject.Business.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinalProject.Business.Service
{
    public class JWTService(IConfiguration configuration) : IJWTService
    {
        public string GetJWT(string user, string role)
        {
            List<Claim> claims =
            [
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Role, role)
            ];

            var secretToken = configuration.GetSection("Jwt:Key").Value;
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretToken!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: configuration.GetSection("Jwt:Issuer").Value,
                audience: configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddSeconds(600),
                signingCredentials: cred);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

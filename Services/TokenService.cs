using FlightDocs.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlightDocs.Services
{
    public class TokenService
    {
        public static string GenerateJSONWebToken(IConfiguration configuration, Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {

                    new Claim("Id", account.Id.ToString()),
                    new Claim("groupId", account.groupId.ToString()),
                    new Claim(ClaimTypes.Email,account.Email),
                        new Claim("Name", account.Name),
                    new Claim("Phone", account.Phone),
                };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                //thoi` han token toi` tai
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
            //in ra token
        }
    }
}

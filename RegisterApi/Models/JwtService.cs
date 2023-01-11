using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.Models
{
    public class JwtService
    {
        public string SecretKey { get; set; }
        public int TokenDuration { get; set; }

        private readonly IConfiguration config;

        public JwtService(IConfiguration _config)
        {
            config = _config;
            this.SecretKey = config.GetSection("jwtConfig").GetSection("Key").Value;
            this.TokenDuration = Int32.Parse(config.GetSection("jwtConfig").GetSection("Duration").Value);
        }

        public string GenerateToken(string id, string name,  string contact, string email)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));

            var signature = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var payload = new[]
            {
                new Claim("id",id),
                new Claim("name",name),
                new Claim("contact",contact),
                new Claim("email",email),
            };
            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: signature
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

           
        }
    }
}

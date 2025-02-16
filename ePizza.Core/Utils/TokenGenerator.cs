using ePizza.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ePizza.Core.Utils
{
    public class TokenGenerator
    {
        //IConfiguration is used to read the values from appsettings.json file.. IMP
        private readonly IConfiguration _configuration;
        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(ValidateUserResponse userResponse)
        {
            string secretKey = _configuration["Jwt:Secret"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity([
                    //new Claim(ClaimTypes.Name,"SampleUser"),
                    //new Claim(ClaimTypes.Email,"abc@gmail.com"),
                    new Claim(ClaimTypes.Name,userResponse.Name),
                    new Claim(ClaimTypes.Email,userResponse.Email),
                    new Claim("IsAdmin","true"),
                    new Claim("Roles",JsonSerializer.Serialize(userResponse.Roles))
                    ]),

                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:TokenExpiryInMinutes"])),
                SigningCredentials = credentials,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var tokenHandler = new JsonWebTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}

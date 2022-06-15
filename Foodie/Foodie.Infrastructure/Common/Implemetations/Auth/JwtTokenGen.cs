

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Foodie.Application.Common.Interfaces.Auth;
using Foodie.Application.Common.Interfaces.Auth.Services;
//using Foodie.Application.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Foodie.Infrastructure.Common.Implemetations.Auth
{
    public class JwtTokenGen : IJwtTokenGen
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGen(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public string GenerateToken(Guid userId, string lastName, string firstName)
        {
            
              var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes("super-secret-key")), 
                SecurityAlgorithms.HmacSha256Signature);
             var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 
            };

            var token = new JwtSecurityToken(
                issuer: "Foodie",
                //audience: "Foodie",
                expires: _dateTimeProvider.GmtNow.AddMinutes(20),
                signingCredentials: signingCredentials,
                claims: claims);

                return new JwtSecurityTokenHandler().WriteToken(token);


        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     var key = Encoding.ASCII.GetBytes("superSecretKey@345");
        //     var tokenDescriptor = new SecurityTokenDescriptor
        //     {
        //         Subject = new ClaimsIdentity(new Claim[]
        //         {
        //             new Claim(ClaimTypes.Name, userId.ToString()),
        //             new Claim(ClaimTypes.NameIdentifier, firstName),
        //             new Claim(ClaimTypes.Surname, lastName)
        //         }),
        //         Expires = DateTime.UtcNow.AddDays(7),
        //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //     };
        //     var token = tokenHandler.CreateToken(tokenDescriptor);
        //     return tokenHandler.WriteToken(token);
        // }
          
        }  
    }
}
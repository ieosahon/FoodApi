

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Foodie.Application.Common.Interfaces.Auth;
using Foodie.Application.Common.Interfaces.Auth.Services;
using Microsoft.Extensions.Options;
//using Foodie.Application.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Foodie.Infrastructure.Common.Implemetations.Auth
{
    public class JwtTokenGen : IJwtTokenGen
    {   
        private readonly JwtSettings _jwtSettings;

        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGen(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettingsOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettingsOptions.Value; // value which is returned from the IOptions<T>
        }
      

        public string GenerateToken(Guid userId, string lastName, string firstName)
        {
            
              var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(_jwtSettings.Secret)), 
                SecurityAlgorithms.HmacSha256Signature);
             var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.GmtNow.AddMinutes(_jwtSettings.ExpireDuration),
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
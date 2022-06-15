
using Foodie.Application.Common.Interfaces.Auth;
//using Foodie.Application.Interfaces.Auth;
using Foodie.Application.Services.Auth.Interface;

namespace Foodie.Application.Services.Auth.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGen _jwtTokenGenerator;

        public AuthService(IJwtTokenGen jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthResult UserLogin(string email, string password)
        {
            return new AuthResult(Guid.NewGuid(),  "firstname", "lastName", email, "token" );
        }

        public AuthResult UserRegister(string firstName, string lastName, string email, string password)
        {
            // TODO: check if user already exists

            // TODO: implement user registration

            // TODO: create jwt token
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), lastName, firstName);

            return new AuthResult(
                userId,  
                firstName, 
                lastName, 
                email, 
                token
                );
        }
    }
}
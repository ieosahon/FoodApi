
using Foodie.Application.Services.Auth.Interface;

namespace Foodie.Application.Services.Auth.Implementation
{
    public class AuthService : IAuthService
    {
        public AuthResult UserLogin(string email, string password)
        {
            return new AuthResult(Guid.NewGuid(),  "firstname", "lastName", email, "token" );
        }

        public AuthResult UserRegister(string firstName, string lastName, string email, string password)
        {
            return new AuthResult(Guid.NewGuid(),  firstName, lastName, email, "token" );
        }
    }
}


namespace Foodie.Application.Services.Auth.Interface
{
    public interface IAuthService
    {
        AuthResult UserLogin(string email, string password);
        AuthResult UserRegister(string firstName, string lastName, string email, string password);
    }
}
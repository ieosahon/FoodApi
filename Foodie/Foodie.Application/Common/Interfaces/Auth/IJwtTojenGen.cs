

namespace Foodie.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGen
    {
        string GenerateToken(Guid userId, string lastName, string firstName);
    }
}
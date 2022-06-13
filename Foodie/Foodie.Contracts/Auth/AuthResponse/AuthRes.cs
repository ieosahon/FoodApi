namespace Foodie.Contracts.Auth.AuthResponse
{
    public record AuthRes
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
namespace Foodie.Contracts.Auth.RegisterResponse
{
    public record RegisterRes
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
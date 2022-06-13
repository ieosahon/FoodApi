namespace Foodie.Contracts.Auth.AuthRequest
{
    public record RegRes
    (
        string FirstName,
        string LastName,
        string Email,
        string Password
    );
    
}
namespace Foodie.Contracts.Auth.AuthRequest
{
    public record RegisterReq
    (
        string FirstName,
        string LastName,
        string Email,
        string Password
    );
    
}
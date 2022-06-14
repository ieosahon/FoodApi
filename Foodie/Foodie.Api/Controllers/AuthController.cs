using Microsoft.AspNetCore.Mvc;
using Foodie.Contracts.Auth.AuthRequest;
using Foodie.Foodie.Contracts.Auth.AuthRequest;
using Foodie.Application.Services.Auth.Interface;
using Foodie.Application.Services.Auth;

namespace Foodie.Api.Controllers

{
    
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterReq req)
        {
            var userResult = _authService.UserRegister(req.FirstName, req.LastName, req.Email, req.Password);
            // map user result values to the api response
            var response = new AuthResult
            (
                userResult.Id,
                userResult.LastName,
                userResult.FirstName,
                userResult.Email,
                userResult.Token
            );
            return Ok(response); 
        }

        [HttpPost("login")]
        public IActionResult Login(LoginReq req)
        {
            var user = _authService.UserLogin(req.Email, req.Password);
            var userResponse = new AuthResult
            (
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Token
            );
            return Ok(userResponse);
        }
    }
}

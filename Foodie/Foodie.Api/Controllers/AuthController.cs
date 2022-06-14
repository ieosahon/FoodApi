using Microsoft.AspNetCore.Mvc;
using Foodie.Contracts.Auth.AuthRequest;
using Foodie.Foodie.Contracts.Auth.AuthRequest;

namespace Foodie.Api.Controllers

{
    
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(RegisterReq req)
        {
            return Ok(req); 
        }

        [HttpPost("login")]
        public IActionResult Login(LoginReq req)
        {
            return Ok(req);
        }
    }
}

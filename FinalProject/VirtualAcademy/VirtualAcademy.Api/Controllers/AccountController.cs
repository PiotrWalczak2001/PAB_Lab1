using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualAcademy.Application.Auth;
using VirtualAcademy.Application.Contracts.Services;

namespace VirtualAcademy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateUserAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateUserAsync(request));
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegisterResponse>> RegisterUserAsync(RegisterRequest request)
        {
            return Ok(await _authenticationService.RegisterUserAsync(request));
        }
    }
}

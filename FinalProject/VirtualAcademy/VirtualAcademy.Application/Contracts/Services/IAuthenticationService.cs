using VirtualAcademy.Application.Auth;

namespace VirtualAcademy.Application.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateUserAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request);
    }
}

using ControlSystem.Contracts.Entities;
using ControlSystem.Contracts.Enums;

namespace ControlSystem.Middleware.Auth
{
    public interface IAuthenticationManager
    {
        User GetUserFromToken(string authToken);

        AuthenticationStatus Authenticate(string authToken, out User user);

        AuthenticationStatus GenerateToken(User user, out string token);
    }
}

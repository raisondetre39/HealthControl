using ControlSystem.Contracts;
using ControlSystem.Contracts.Responses;
using System.Threading.Tasks;

namespace ControlSystem.BL.Auth.Interfaces
{
    public interface IAuthenticationService
    {
        Task<GenerateTokenResult> GenerateToken(AuthModel authModel);

        GenerateTokenResult RefreshToken(string token);
    }
}

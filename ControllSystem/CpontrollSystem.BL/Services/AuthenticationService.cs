using ControlSystem.BL.Auth.Interfaces;
using ControlSystem.BL.Helpers;
using ControlSystem.Contracts;
using ControlSystem.Contracts.Responses;
using ControlSystem.DAL.Interfaces;
using ControlSystem.Contracts.Enums;
using System.Threading.Tasks;
using ControlSystem.Middleware.Auth;

namespace ControlSystem.BL.Auth.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationManager _authenticationManager;

        public AuthenticationService(
            IUnitOfWork unitOfWork,
            IAuthenticationManager authenticationManager)
        {
            _userRepository = unitOfWork.UserRepository;
            _authenticationManager = authenticationManager;
        }

        public async Task<GenerateTokenResult> GenerateToken(AuthModel authModel)
        {
            var user = await _userRepository
                .GetUserByAsync(item => item.Email == authModel.Email
                    && item.Password.CompareHashedStrings(authModel.Password));

            if (user == null)
                return new GenerateTokenResult() { Status = AuthenticationStatus.UserNotFound };


            return new GenerateTokenResult()
            {
                Status = _authenticationManager.GenerateToken(user, out string token),
                Token = token,
                Role = user.Role,
                Id = user.Id
            };
        }

        public GenerateTokenResult RefreshToken(string token)
        {
            string newToken = string.Empty;

            var authenticationResult = _authenticationManager.Authenticate(token, out var user);

            if (user == null)
                return new GenerateTokenResult()
                {
                    Status = AuthenticationStatus.TokenVerificationFailed
                };


            if (authenticationResult == AuthenticationStatus.Success ||
                authenticationResult == AuthenticationStatus.TokenExpired)
            {
                authenticationResult = _authenticationManager.GenerateToken(user, out newToken);
            }

            return new GenerateTokenResult()
            {
                Status = authenticationResult,
                Token = newToken
            };
        }
    }
}

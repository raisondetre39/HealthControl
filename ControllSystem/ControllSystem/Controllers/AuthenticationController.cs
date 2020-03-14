using Amazon.ElasticFileSystem.Model;
using ControlSystem.BL.Auth.Interfaces;
using ControlSystem.Contracts;
using ControlSystem.Contracts.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using System.Threading.Tasks;

namespace ControlSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Create Token for an existing user
        /// </summary>
        /// <param name="authModel">An object containig necessary Login fields</param>
        /// <returns>Jwt token</returns>
        [HttpPost]
        public async Task<ActionResult<string>> Authenticate([FromBody] AuthModel authModel)
        {
            var result = await _authenticationService.GenerateToken(authModel);

            if (result.Status == AuthenticationStatus.UserNotFound)
                throw new BadRequestException("User not found");

            if (result.Status != AuthenticationStatus.Success)
                throw new SecurityException("Access denied");

            return result.Token;
        }

        /// <summary>
        /// Refresh Token for an existing user
        /// </summary>
        /// <param name="jwtToken">An expired token to exchange</param>
        /// <returns>Refreshed jwt token</returns>
        [HttpPost("refresh")]
        public ActionResult<string> RefreshToken(string jwtToken)
        {
            var result = _authenticationService.RefreshToken(jwtToken);

            if (result.Status == AuthenticationStatus.UserNotFound)
                throw new BadRequestException("User not found");

            if (result.Status != AuthenticationStatus.Success)
                throw new SecurityException("Access denied");

            return result.Token;
        }
    }
}

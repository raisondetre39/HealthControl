using Amazon.Lambda.Core;
using ControlSystem.BL.Auth.Interfaces;
using ControlSystem.Contracts;
using ControlSystem.Contracts.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using System.Threading.Tasks;

namespace ControlSystem.WebApi.Auth.AWS.Controllers
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
        public async Task<IActionResult> Authenticate([FromBody] AuthModel authModel)
        {
            var result = await _authenticationService.GenerateToken(authModel);

            if (result.Status == AuthenticationStatus.UserNotFound)
                return BadRequest("User not found");

            if (result.Status != AuthenticationStatus.Success)
                throw new SecurityException("Access denied");

            return Ok(result);
        }

        /// <summary>
        /// Refresh Token for an existing user
        /// </summary>
        /// <param name="jwtToken">An expired token to exchange</param>
        /// <returns>Refreshed jwt token</returns>
        [HttpPost("refresh")]
        public IActionResult RefreshToken(string jwtToken)
        {
            var result = _authenticationService.RefreshToken(jwtToken);

            if (result.Status == AuthenticationStatus.UserNotFound)
                return BadRequest("User not found");

            if (result.Status != AuthenticationStatus.Success)
                throw new SecurityException("Access denied");

            return Ok(result.Token);
        }
    }
}

using ControlSystem.Contracts.Enums;
using ControlSystem.Middleware.Auth;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlSystem.WebApi.Disease.Infrastructure.Security
{
    public class UserAuthorizationAttribute : AuthorizeAttribute
    {
        [Dependency]
        public IAuthenticationManager AuthenticationManager { get; set; }

        /// <summary>
        /// IsAuthorized
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            bool result = false;
            string unauthorizedMessage = string.Empty;

            var authToken = actionContext.Request.Headers
                .FirstOrDefault(p => p.Key.Equals("AuthToken", StringComparison.InvariantCultureIgnoreCase))
                .Value
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(authToken))
                unauthorizedMessage = "Missing AuthToken. Please specify AuthToken in header";
            else
            {
                var user = new Contracts.Entities.User(); 
                var authenticationResult = AuthenticationManager.Authenticate(authToken, out user);  

                if (authenticationResult == AuthenticationStatus.TokenVerificationFailed)
                    unauthorizedMessage = "Invalid token. Log in again to retrieve a valid token";
                else if (authenticationResult == AuthenticationStatus.TokenExpired)
                    unauthorizedMessage = "The token expired. Log in again to retrieve a new token";
                else if (authenticationResult == AuthenticationStatus.Success)
                    result = true;
            }

            if (!result)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                actionContext.Response.Content = new StringContent(unauthorizedMessage);
            }

            return result;
        }
    }
}

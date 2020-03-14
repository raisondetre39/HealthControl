using ControlSystem.Contracts.Entities;
using ControlSystem.Contracts.Enums;
using ControlSystem.Middleware.Auth.Jwt;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Authentication;

namespace ControlSystem.Middleware.Auth
{
    public class AuthenticatinManager : IAuthenticationManager
    {
        private readonly JwtSettings _jwtSettings;
        private const string SecureTokenSettings = "ControlSystem.Middleware.Configs.JwtSettingsConfig.json";

        public AuthenticatinManager()
        {
            using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(SecureTokenSettings)))
            {
                string configJson = reader.ReadToEnd();

                _jwtSettings = JsonConvert.DeserializeObject<JwtSettings>(configJson);
            }
        }

        public static JwtClaims ParseJwtToken(string authToken)
{
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            return decoder.DecodeToObject<JwtClaims>(authToken);
        }

        public AuthenticationStatus Authenticate(string authToken, out User user)
        {
            var result = AuthenticationStatus.Success;
            user = null;

            if (string.IsNullOrWhiteSpace(authToken))
            {
                throw new AuthenticationException("Token is not provided");
            }

            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                JwtClaims jwtClaims = decoder.DecodeToObject<JwtClaims>(authToken);

                user = new User()
                {
                    Id = jwtClaims.Id,
                    Role = jwtClaims.Role,
                    Email = jwtClaims.Email
                };

                if (_jwtSettings.IsEnabled)
                {
                    decoder.Decode(authToken, _jwtSettings.SignatureSecret, verify: true);
                }
                else
                {
                    result = AuthenticationStatus.ClientDisabled;
                }
            }
            catch (TokenExpiredException)
            {
                result = AuthenticationStatus.TokenExpired;
            }
            catch (SignatureVerificationException)
            {
                result = AuthenticationStatus.TokenVerificationFailed;
            }

            return result;
        }

        public AuthenticationStatus GenerateToken(User user, out string token)
        {
            AuthenticationStatus result = AuthenticationStatus.Success;

            token = null;

            if (_jwtSettings.IsEnabled)
            { 
                DateTime unixEpoch = UnixEpoch.Value;

                IDateTimeProvider provider = new UtcDateTimeProvider();

                DateTimeOffset now = provider.GetNow().AddSeconds(_jwtSettings.ExpirationSpan);
                double secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);

                Dictionary<string, object> payload = new Dictionary<string, object>
                {
                    { "exp", secondsSinceEpoch.ToString(CultureInfo.InvariantCulture) },
                    { "Id", user.Id },
                    { "Email", user.Email },
                    { "Role", user.Role }
                };

                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();

                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                token = encoder.Encode(payload, _jwtSettings.SignatureSecret);
    }
            else
            {
                result = AuthenticationStatus.ClientDisabled;
            }


            return result;
        }

        public User GetUserFromToken(string authToken)
        {
            JwtClaims jwtClaims = ParseJwtToken(authToken);

            return new User()
            {
                Id = jwtClaims.Id,
                Email = jwtClaims.Email,
                Role = jwtClaims.Role
            };
        }
    }
}

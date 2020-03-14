namespace ControlSystem.Middleware.Auth.Jwt
{
    public class JwtClaims
    {
        public int Id { get; set; }

        public int Role { get; set; }

        public string Email { get; set; }
    }
}

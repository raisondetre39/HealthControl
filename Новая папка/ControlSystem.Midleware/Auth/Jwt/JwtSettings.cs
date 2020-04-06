namespace ControlSystem.Middleware.Auth
{
    public class JwtSettings
    {
        public bool IsEnabled { get; set; }

        public int ExpirationSpan { get; set; }

        public string SignatureSecret { get; set; }
    }
}

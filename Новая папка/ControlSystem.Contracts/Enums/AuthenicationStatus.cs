namespace ControlSystem.Contracts.Enums
{
    public enum AuthenticationStatus
    {
        Undefined,
        UserNotFound,
        TokenExpired,
        ClientDisabled,
        TokenVerificationFailed,
        Success
    }
}

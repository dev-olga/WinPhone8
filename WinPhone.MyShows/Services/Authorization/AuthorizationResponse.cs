namespace WinPhone.MyShows.Services.Authorization
{
    public enum AuthorizationResponse : int
    {
        OK = 1,
        InvalidCredentials,
        EmptyCredentials,
        Unknown
    }
}

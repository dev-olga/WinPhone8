namespace WinPhone.MyShows.Models.Authorization
{
    using System.Collections.Generic;

    public class AuthorizationResponse
    {
        public AuthorizationCode Code {get; set; }

        public string Token { get; set; }
    }
}

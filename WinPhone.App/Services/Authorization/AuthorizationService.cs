using System.Threading.Tasks;

namespace WinPhone.App.Services
{
    using WinPhone.App.Models;
    using WinPhone.App.Services.Authorization;
    using WinPhone.MyShows.Services.Authorization;

    public class AuthorizationService
    {
        //ToDo: move to model

        private static bool IsLoggedIn = false;

        /// <summary>
        /// The credentials storage.
        /// </summary>
        private CredentialsStorage credentialsStorage;

        private CredentialsStorage CredentialsStorage
        {
            get
            {
                return this.credentialsStorage ?? (this.credentialsStorage = new CredentialsStorage());
            }
        }

        public async Task<bool> LogIn(Credentials credentials, bool remember = false)
        {
            this.LogOut();

            var resp = await(new MyShows.Services.AuthorizationService()).Authorize(credentials.Login, credentials.Password);
            IsLoggedIn = resp == AuthorizationResponse.OK;
            if (IsLoggedIn && remember)
            {
                this.CredentialsStorage.Save(credentials);
            }

            return IsLoggedIn;
        }

        public async Task<bool> LogIn()
        {
            return false;
            //var credentials = this.CredentialsStorage.Get();
            //if (credentials == null)
            //{
            //    IsLoggedIn = false;
            //    return IsLoggedIn;
            //}

            //return await this.LogIn(credentials, true);
        }

        public void LogOut()
        {
            IsLoggedIn = false;
            this.CredentialsStorage.Clear();
        }
    }
}

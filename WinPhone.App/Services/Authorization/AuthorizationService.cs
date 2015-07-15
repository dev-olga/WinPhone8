using System.Threading.Tasks;

namespace WinPhone.App.Services
{
    using System;

    using WinPhone.App.Interfaces;
    using WinPhone.App.Models;
    using WinPhone.App.Services.Authorization;
    using WinPhone.MyShows.Services.Authorization;

    public class AuthorizationService : IAuthorizationService
    {
        /// <summary>
        /// The credentials storage.
        /// </summary>
        private CredentialsStorage credentialsStorage;

        /// <summary>
        /// Gets the user.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Gets a value indicating whether user is logged in.
        /// </summary>
        public bool IsLoggedIn
        {
            get
            {
                return this.User != null;
            }
        }

        /// <summary>
        /// Gets the credentials storage.
        /// </summary>
        private CredentialsStorage CredentialsStorage
        {
            get
            {
                return this.credentialsStorage ?? (this.credentialsStorage = new CredentialsStorage());
            }
        }

        public async Task<bool> LogInAsync(Credentials credentials, bool remember = false)
        {
            this.User = null;

            var resp = await (new MyShows.Services.AuthorizationService()).AuthorizeAsync(
                        credentials.Login,
                        credentials.Password);

            if (resp == AuthorizationResponse.OK)
            {
                this.User = new User(credentials.Login);

                if (remember)
                {
                    this.CredentialsStorage.Save(credentials);
                }
            }

            return this.IsLoggedIn;
        }

        public async Task<bool> LogInAsync()
        {
            var credentials = this.CredentialsStorage.Get();
            if (credentials != null)
            {
                return await this.LogInAsync(credentials, true);
            }

            this.User = null;
            return false;
        }

        public void LogOut()
        {
            this.User = null;
            this.CredentialsStorage.Clear();
        }
    }
}

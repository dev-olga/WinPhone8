﻿using System.Threading.Tasks;

namespace WinPhone.App.Services
{
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.App.Models;
    using WinPhone.App.Services.Authorization;
    using WinPhone.MyShows.Models.Authorization;

    internal class AuthorizationService : IAuthorizationService
    {
        /// <summary>
        /// The credentials storage.
        /// </summary>
        private CredentialsStorage credentialsStorage;

        private readonly IApiProvider apiProvider;

        /// <summary>
        /// The user.
        /// </summary>
        private static User user;

        /// <summary>
        /// Gets the user.
        /// </summary>
        public User User
        {
            get
            {
                return user;
            }

            private set
            {
                user = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether user is logged in.
        /// </summary>
        public bool IsLoggedIn
        {
            get
            {
                return User != null;
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

        private IApiProvider ApiProvider
        {
            get
            {
                return this.apiProvider;
            }
        }

        public AuthorizationService(IApiProvider apiProvider)
        {
            this.apiProvider = apiProvider;
        }

        public async Task<bool> LogInAsync(Credentials credentials, bool remember = false)
        {
            User = null;

            var resp = await this.ApiProvider.AuthorizationService.AuthorizeAsync(
                        credentials.Login,
                        credentials.Password);

            if (resp.Code == AuthorizationCode.OK)
            {
                User = new User(credentials.Login)
                           {
                               AuthorizationToken = resp.Token
                           };

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

            User = null;
            return false;
        }

        public void LogOut()
        {
            User = null;
            this.CredentialsStorage.Clear();
            OfflineProvider.GetOfflineManager().Clear();
        }
    }
}

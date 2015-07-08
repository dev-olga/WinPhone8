using System.Linq;

namespace WinPhone.App.Services.Authorization
{
    using System;

    using Windows.Security.Credentials;

    using WinPhone.App.Models;

    internal class CredentialsStorage
    {
        private string Resource
        {
            get
            {
                return typeof(CredentialsStorage).FullName;
            }
        }

        public void Save(Credentials credentials)
        {
            (new PasswordVault()).Add(new PasswordCredential(this.Resource, credentials.Login, credentials.Password));
        }

        public Credentials Get()
        {
            var passwordCredentials = (new PasswordVault()).FindAllByResource(this.Resource).FirstOrDefault();
            return passwordCredentials == null ? null : new Credentials { Login = passwordCredentials.UserName, Password = passwordCredentials.Password };
        }

        public void Clear()
        {
            var vault = new PasswordVault();
            try
            {
                var credentialsList = vault.FindAllByResource(this.Resource);
                foreach (var item in credentialsList)
                {
                    vault.Remove(item);
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}

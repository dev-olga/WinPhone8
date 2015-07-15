using System.Linq;

namespace WinPhone.App.Services.Authorization
{
    using Windows.Security.Credentials;

    using WinPhone.App.Models;

    internal class CredentialsStorage
    {
        private PasswordVault passwordVault;

        private PasswordVault PasswordVault
        {
            get
            {
                return this.passwordVault ?? (this.passwordVault = new PasswordVault());
            }
        }

        private string Resource
        {
            get
            {
                return typeof(CredentialsStorage).FullName;
            }
        }

        public void Save(Credentials credentials)
        {
            this.PasswordVault.Add(new PasswordCredential(this.Resource, credentials.Login, credentials.Password));
        }

        public Credentials Get()
        {
            var сredentials =
                this.PasswordVault.RetrieveAll().FirstOrDefault(r => r.Resource.Equals(this.Resource));
            if (сredentials == null)
            {
                return null;
            }

            сredentials = this.PasswordVault.Retrieve(сredentials.Resource, сredentials.UserName);
            return new Credentials
                        {
                            Login = сredentials.UserName,
                            Password = сredentials.Password
                        };
        }

        public void Clear()
        {
            foreach (var item in this.PasswordVault.RetrieveAll().Where(r => r.Resource.Equals(this.Resource)))
            {
                this.PasswordVault.Remove(item);
            }
        }
    }
}

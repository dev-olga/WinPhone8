namespace WinPhone.App.ViewModels.Login
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using WinPhone.App.Common;
    using WinPhone.App.Models;
    using WinPhone.App.Services;

    public class LoginViewModel : NotificationObject
    {
        /// <summary>
        /// The authorize command.
        /// </summary>
        private RelayCommand authorizeCommand;

        /// <summary>
        /// The error message.
        /// </summary>
        private string errorMessage;

        private bool remember;

        /// <summary>
        /// The credentials.
        /// </summary>
        private readonly Credentials credentials;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            this.credentials = new Credentials();
        }

        public string Login
        {
            get
            {
                return this.credentials.Login;
            }

            set
            {
                if (this.credentials.Login != value)
                {
                    this.credentials.Login = value;
                    this.NotifyPropertyChanged();
                    this.AuthorizeCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get
            {
                return this.credentials.Password;
            }

            set
            {
                if (this.credentials.Password != value)
                {
                    this.credentials.Password = value;
                    this.NotifyPropertyChanged();
                    this.AuthorizeCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public bool Remember
        {
            get
            {
                return this.remember;
            }
            set
            {
                if (this.remember != value)
                {
                    this.remember = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }

            set
            {
                if (this.errorMessage != value)
                {
                    this.errorMessage = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public RelayCommand AuthorizeCommand
        {
            get
            {
                return this.authorizeCommand ?? (this.authorizeCommand = 
                    new RelayCommand(
                        this.Authorize, () => !string.IsNullOrEmpty(this.Login) && !string.IsNullOrEmpty(this.Password)));
            }
        }

        private async void Authorize()
        {
            var res = await(new AuthorizationService()).LogIn(this.credentials, this.Remember);
            if (res)
            {
                (Window.Current.Content as Frame).Navigate(typeof(MainPage));
            }
            else
            {
                this.Password = string.Empty;
                this.ErrorMessage = "Invalid credentials.";
            }
        }
    }
}

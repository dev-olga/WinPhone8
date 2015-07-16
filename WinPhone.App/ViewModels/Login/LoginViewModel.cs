namespace WinPhone.App.ViewModels.Login
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using WinPhone.App.Common;
    using WinPhone.App.Interfaces;
    using WinPhone.App.Models;

    using WinPhone.App.Views;

    public class LoginViewModel : AuthorizedViewModel 
    {

        /// <summary>
        /// The credentials.
        /// </summary>
        private readonly Credentials credentials;

        /// <summary>
        /// The authorize command.
        /// </summary>
        private RelayCommand authorizeCommand;

        /// <summary>
        /// The error message.
        /// </summary>
        private string errorMessage;

        /// <summary>
        /// The remember flag.
        /// </summary>
        private bool remember;

        private bool processing;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        /// <param name="authorizationService">
        /// The authorization Service.
        /// </param>
        public LoginViewModel(IAuthorizationService authorizationService)
            : base(authorizationService)
        {
            this.credentials = new Credentials();            
        }

        #region Properties
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

        public bool Processing
        {
            get
            {
                return this.processing;
            }
            set
            {
                if (this.processing != value)
                {
                    this.processing = value;
                    this.NotifyPropertyChanged();
                    this.AuthorizeCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public RelayCommand AuthorizeCommand
        {
            get
            {
                return this.authorizeCommand ?? (this.authorizeCommand = new RelayCommand(this.Authorize, () => this.IsValid() && !this.Processing));
            }
        }

        #endregion

        private bool IsValid()
        {
            return !string.IsNullOrEmpty(this.Login) && !string.IsNullOrEmpty(this.Password);
        }

        private async void Authorize()
        {
            this.Processing = true;
            var res = await this.AuthorizationService.LogInAsync(this.credentials, this.Remember);
            if (res)
            {
                (Window.Current.Content as Frame).Navigate(typeof(MainPage));
            }
            else
            {
                this.Password = string.Empty;
                this.ErrorMessage = "Invalid credentials.";
            }
            this.Processing = false;
        }
    }
}

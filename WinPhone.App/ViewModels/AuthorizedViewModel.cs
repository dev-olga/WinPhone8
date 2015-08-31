namespace WinPhone.App.ViewModels
{
    using WinPhone.App.Interfaces;

    internal class AuthorizedViewModel : NotificationViewModel
    {       
        private readonly IAuthorizationService authorizationService;

        protected IAuthorizationService AuthorizationService
        {
            get
            {
                return this.authorizationService;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizedViewModel"/> class.
        /// </summary>
        /// <param name="authorizationService">
        /// The authorization service.
        /// </param>
        public AuthorizedViewModel(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }
    }
}

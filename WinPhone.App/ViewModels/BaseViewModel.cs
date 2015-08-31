namespace WinPhone.App.ViewModels
{
    using WinPhone.App.Interfaces;

    internal class BaseViewModel : AuthorizedViewModel
    {
        private readonly IApiProvider apiProvider;

        public BaseViewModel(IAuthorizationService authorizationService, IApiProvider apiProvider)
            : base(authorizationService)
        {
            this.apiProvider = apiProvider;
        }

        protected IApiProvider ApiProvider
        {
            get
            {
                return this.apiProvider;
            }
        }
    }

}

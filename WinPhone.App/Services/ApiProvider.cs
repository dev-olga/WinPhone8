namespace WinPhone.App.Services
{
    using WinPhone.App.Interfaces;
    using WinPhone.MyShows.Services;

    // TODO: replace all services with interfaces
    internal class ApiProvider : IApiProvider
    {
        private static ProfileService profileService;
        private static ShowsService showsService;
        private static MyShows.Services.AuthorizationService authorizationService;

        public ProfileService ProfileService
        {
            get
            {
                return profileService ?? new ProfileService();
            }
        }

        public ShowsService ShowsService
        {
            get
            {
                return showsService ?? new ShowsService();
            }
        }

        public MyShows.Services.AuthorizationService AuthorizationService
        {
            get
            {
                return authorizationService ?? new MyShows.Services.AuthorizationService();
            }
        }
    }
}

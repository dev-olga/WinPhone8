namespace WinPhone.App.Services
{
    using WinPhone.App.Interfaces;

    // TODO: replace all services with interfaces
    internal class ApiProvider : IApiProvider
    {
        private static MyShows.Services.ProfileService profileService;
        private static MyShows.Services.ShowsService showsService;
        private static MyShows.Services.AuthorizationService authorizationService;

        public MyShows.Services.ProfileService ProfileService
        {
            get
            {
                return profileService ?? new MyShows.Services.ProfileService();
            }
        }

        public MyShows.Services.ShowsService ShowsService
        {
            get
            {
                return showsService ?? new MyShows.Services.ShowsService();
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

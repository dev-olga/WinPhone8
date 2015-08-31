using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.ViewModels
{
    using System.Dynamic;

    using GalaSoft.MvvmLight.Ioc;

    using Microsoft.Practices.ServiceLocation;

    using WinPhone.App.Common.Commands;
    using WinPhone.App.Common.Offline;
    using WinPhone.App.Interfaces;
    using WinPhone.App.Services;
    using WinPhone.App.ViewModels.Login;
    using WinPhone.App.ViewModels.Main;
    using WinPhone.App.ViewModels.ShowDetails;

    internal class ViewModelLocator
    {
        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ShowDetailsViewModel ShowDetails
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShowDetailsViewModel>();
            }
        }
        
        public LogOutCommand LogOutCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogOutCommand>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var offlineStorage = new LocalStorage();
            SimpleIoc.Default.Register<IStorage>(() => offlineStorage);

            var apiProvider = new ApiProvider();
            var authorizationService = new AuthorizationService(apiProvider);
            SimpleIoc.Default.Register<IAuthorizationService>(() => authorizationService);

            SimpleIoc.Default.Register<LoginViewModel>(() => new LoginViewModel(authorizationService));
            SimpleIoc.Default.Register<MainViewModel>(() => new MainViewModel(authorizationService, apiProvider));
            SimpleIoc.Default.Register<ShowDetailsViewModel>(() => new ShowDetailsViewModel(authorizationService, apiProvider));

            SimpleIoc.Default.Register<LogOutCommand>(() => new LogOutCommand(authorizationService));
        }
    }
}

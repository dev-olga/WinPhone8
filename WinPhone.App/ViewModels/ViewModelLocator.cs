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
    using WinPhone.App.Interfaces;
    using WinPhone.App.Services;
    using WinPhone.App.ViewModels.Login;

    public class ViewModelLocator
    {
        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
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

            var authorizationService = new AuthorizationService();

            SimpleIoc.Default.Register<IAuthorizationService>(() => authorizationService, true);

            SimpleIoc.Default.Register<LoginViewModel>(() => new LoginViewModel(authorizationService));

            SimpleIoc.Default.Register<LogOutCommand>(() => new LogOutCommand(authorizationService));
        }
    }
}

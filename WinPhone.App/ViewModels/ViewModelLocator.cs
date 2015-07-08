using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPhone.App.ViewModels
{
    using GalaSoft.MvvmLight.Ioc;

    using Microsoft.Practices.ServiceLocation;

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

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var authorizationService = new AuthorizationService();
            SimpleIoc.Default.Register<IAuthorizationService>(() => authorizationService);

            SimpleIoc.Default.Register<LoginViewModel>(() => new LoginViewModel(authorizationService));
        }
    }
}

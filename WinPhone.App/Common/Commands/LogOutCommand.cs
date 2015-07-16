using System;

namespace WinPhone.App.Common.Commands
{
    using System.Windows.Input;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using WinPhone.App.Interfaces;
    using WinPhone.App.Views;

    public class LogOutCommand : ICommand
    {
        private readonly IAuthorizationService authorizationService;

        private IAuthorizationService AuthorizationService
        {
            get
            {
                return authorizationService;
            }
        }

        public LogOutCommand(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        public bool CanExecute(object parameter)
        {
            return this.AuthorizationService.IsLoggedIn;
        }

        public void Execute(object parameter)
        {
            this.AuthorizationService.LogOut();
            (Window.Current.Content as Frame).Navigate(typeof(LoginPage));
        }

        public event EventHandler CanExecuteChanged;
    }
}

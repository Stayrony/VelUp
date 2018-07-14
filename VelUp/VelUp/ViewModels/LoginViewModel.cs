using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Prism.Navigation;
using VelUp.Helpers;
using VelUp.Services.Authorization;
using VelUp.Resources;
using VelUp.Models;
using VelUp.Resources.Strings;
using Xamarin.Forms;
using VelUp.Views;

namespace VelUp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserDialogs _userDialogsService;
        private readonly INavigationService _navigationService;

        public LoginViewModel(IAuthorizationService authorizationService, IUserDialogs userDialogsService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _authorizationService = authorizationService;
            _userDialogsService = userDialogsService;

            #if DEBUG
            Email = "devamb4@jordencorp.dvgf";
            Password = "123456";
#endif
        }

        private ICommand _LoginCommand;
        public ICommand LoginCommand
        {
            get { return _LoginCommand ?? (_LoginCommand = SingleExecutionCommand.FromFunc(OnLoginCommandAsync)); }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }

        private async Task OnLoginCommandAsync()
        {

            if (string.IsNullOrWhiteSpace(Email))
            {
                await _userDialogsService.AlertAsync(Strings.EnterEmailMessage);
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                await _userDialogsService.AlertAsync(Strings.EnterPasswordMessage);
                return;
            }

            AOResult result;

            using (_userDialogsService.Loading())
            {
                result = await _authorizationService.LoginAsync(Email, Password);
            }

            if (result.IsSuccess)
            {
                await _navigationService.NavigateAsync('/' + nameof(NavigationPage) + '/' + nameof(RootView), useModalNavigation: false);
            }
            else
            {
                await _userDialogsService.AlertAsync(Strings.IncorrectLoginDataMessage);
            }
        }
    }
}

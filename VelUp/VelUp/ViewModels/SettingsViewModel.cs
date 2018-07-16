using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Prism.Navigation;
using VelUp.Helpers;
using VelUp.Models;
using VelUp.Resources.Strings;
using VelUp.Services.Authorization;
using VelUp.Views;
using Xamarin.Forms;

namespace VelUp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly IUserDialogs _userDialogsService;
        private readonly INavigationService _navigationService;

        public SettingsViewModel(IAuthorizationService authorizationService, IUserDialogs userDialogsService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _authorizationService = authorizationService;
            _userDialogsService = userDialogsService;
        }

        #region -- Public properties --

        private ICommand _LogoutCommand;
        public ICommand LogoutCommand
        {
            get { return _LogoutCommand ?? (_LogoutCommand = SingleExecutionCommand.FromFunc(OnLogoutCommandAsync)); }
        }

        #endregion


        #region -- Private helpers --

        private async Task OnLogoutCommandAsync()
        {
            AOResult result;

            using (_userDialogsService.Loading())
            {
                result = await _authorizationService.LogoutAsync();
            }

            if (result.IsSuccess)
            {
                await _navigationService.NavigateAsync('/' + nameof(LoginView), useModalNavigation: false);
            }
            else
            {
                await _userDialogsService.AlertAsync(Strings.SomethingWentWrong);
            }
        }

        #endregion
    }
}

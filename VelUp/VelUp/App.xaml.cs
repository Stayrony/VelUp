using Prism.Navigation;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Ioc;
using Acr.UserDialogs;
using VelUp.Views;
using VelUp.Services.Authorization;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace VelUp
{
    public partial class App : PrismApplication
    {
        public static T Resolve<T>()
        {
            return (Current as App).Container.Resolve<T>();
        }

        public App(Prism.IPlatformInitializer initializer = null) : base(initializer)
        {
            MainPage = new LoginView();
        }

        #region -- Overrides --

        protected override void OnInitialized()
        {
            //ATTENTION! Do not move this code to constructor - we must to load key from storage before choosing first app screen.
            //This code writed by Prism convetion - see http://brianlagunas.com/prism-for-xamarin-forms-6-2-0-preview-3/
            InitializeComponent();
            AppNavigation();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Services
            containerRegistry.RegisterInstance<IUserDialogs>(UserDialogs.Instance);
            containerRegistry.RegisterInstance<IAuthorizationService>(Container.Resolve<AuthorizationService>());

            //Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<RootView>();
            containerRegistry.RegisterForNavigation<SettingsView>();
            containerRegistry.RegisterForNavigation<ExploreView>();
            containerRegistry.RegisterForNavigation<BookmarksView>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //AppCenter.Start("android=5cd11c4f-8f8b-440c-b0de-c82c14d061c1;" + "ios=30fe5e36-7e6a-4b48-8f82-023518e827c9", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion

        #region -- Private helpers --

        private async void AppNavigation()
        {
            //ISignInService signInService = Container.Resolve<SignInService>();

            //if (await signInService.IsAuthorizedAsync())
            //{
            //    await NavigationService.NavigateAsync('/' + nameof(CustomNavigationPage) + '/' + nameof(RootView));
            //}
            //else
            //{
            //    await NavigationService.NavigateAsync('/' + nameof(LoginView), useModalNavigation: false);
            //}
        }

        #endregion
    }
}

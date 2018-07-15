using System;
using Xamarin.Forms;
using Prism.Mvvm;

namespace VelUp.Views
{
    public class RootView : TabbedPage
    {
        private Page SettingsPage = new SettingsView();
        private Page BookmarksPage = new BookmarksView();
        private Page ExplorePage = new ExploreView();

        public RootView()
        {
            Children.Add(ExplorePage);
            Children.Add(BookmarksPage);
            Children.Add(SettingsPage);

            ActiveIconColor = (Color)Application.Current.Resources["activeIcon"];
            ViewModelLocator.SetAutowireViewModel(this, true);
            NavigationPage.SetHasNavigationBar(this, false);

            this.Padding = new Thickness(0, 0, 0, Device.OnPlatform(0, 55, 0));
        }

        #region -- Public properties --

        public static readonly BindableProperty ActiveIconColorProperty =
            BindableProperty.Create(nameof(ActiveIconColor), typeof(Color), typeof(RootView), default(Color));

        public Color ActiveIconColor
        {
            get { return (Color)GetValue(ActiveIconColorProperty); }
            set { SetValue(ActiveIconColorProperty, value); }
        }

        #endregion

        #region -- Overrides --

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var actionsHandler = BindingContext as IViewActionsHandler;
            if (actionsHandler != null)
                actionsHandler.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var actionsHandler = BindingContext as IViewActionsHandler;
            if (actionsHandler != null)
                actionsHandler.OnAppearing();
        }

        #endregion
    }
}

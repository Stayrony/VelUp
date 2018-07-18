using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace VelUp.UITests.AuthorizationTests
{
    public class LogoutTests : BaseTest
    {
        readonly Query _logoutButton, _profileTabButton, _loginButton;

        public LogoutTests(Platform platform) : base(platform)
        {
            _loginButton = x => x.Marked("loginButton");
            _logoutButton = x => x.Marked("logoutButton");
            _profileTabButton = x => x.Marked("profileTabButton");
        }

        [Test]
        [Description("Logout With Valid Credentials")]
        public void Should_SuccessLogout_ForValidAccount()
        {
            if (AppList != null && AppList.Any())
            {
                foreach (var app in AppList)
                {
                    SuccessLoginForValidCredentials(app);

                    TapButton(app, _profileTabButton);

                    TapButton(app, _logoutButton);

                    var loginButtonEnabled = app.Query(_loginButton).FirstOrDefault().Enabled;
                    Assert.AreEqual(true, loginButtonEnabled);
                }
            }
        }
    }
}

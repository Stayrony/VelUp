using System;
using System.Linq;
using NUnit.Framework;
using VelUp.Resources.Strings;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace VelUp.UITests.AuthorizationTests
{
    public class LoginTests : BaseTest
    {
        readonly Query _loginButton, _emailEntry, _passwordEntry;

        public LoginTests(Platform platform) : base(platform)
        {
            _loginButton = x => x.Marked("loginButton");
            _emailEntry = x => x.Marked("emailEntry");
            _passwordEntry = x => x.Marked("passwordEntry");
        }

        [Test]
        [Description("Login With Valid Credentials")]
        public void Should_SuccessLogin_ForValidAccount()
        {
            if (AppList != null && AppList.Any())
            {
                foreach (var item in AppList)
                {
                    SuccessLoginForValidCredentials(item);
                }
            }
        }

        [Test]
        [Description("Login With Empty Password Should Show Alert")]
        public void Should_ShowAlert_ForEmptyPassword()
        {
            if (AppList != null && AppList.Any())
            {
                foreach (var app in AppList)
                {
                    EnterText(app, _emailEntry, ValidUserEmail);
                    TapButton(app, _loginButton);

                    app.WaitForElement(e => e.Text(Strings.EnterPasswordMessage));

                    Assert.AreEqual(Strings.EnterPasswordMessage, app.Query(Strings.EnterPasswordMessage).First().Text);
                    app.Tap(e => e.Text(Strings.Ok));
                }
            }
        }

        [Test]
        [Description("Login With Empty UserEmail Should Show Alert")]
        public void Should_ShowAlert_ForEmptyEmail()
        {
            if (AppList != null && AppList.Any())
            {
                foreach (var app in AppList)
                {
                    EnterText(app, _passwordEntry, ValidUserPassword); ;
                    TapButton(app, _loginButton);

                    app.WaitForElement(e => e.Text(Strings.EnterEmailMessage));

                    Assert.AreEqual(Strings.EnterEmailMessage, app.Query(Strings.EnterEmailMessage).First().Text);
                    app.Tap(e => e.Text(Strings.Ok));
                }
            }
        }

        [Test]
        [Description("Login With Invalid UserEmail And Invalid Password Should Show Alert")]
        public void Should_ShowAlert_ForInValidAccount()
        {
            if (AppList != null && AppList.Any())
            {
                foreach (var app in AppList)
                {
                    EnterText(app, _emailEntry, InValidUserEmail);
                    EnterText(app, _passwordEntry, InValidUserPassword);
                    TapButton(app, _loginButton);

                    app.WaitForElement(e => e.Text(Strings.IncorrectLoginDataMessage));

                    Assert.AreEqual(Strings.IncorrectLoginDataMessage, app.Query(Strings.IncorrectLoginDataMessage).First().Text);
                    app.Tap(e => e.Text(Strings.Ok));
                }
            }
        }

        [Test]
        [Description("Login With Empty UserEmail And Password Should Show Alert")]
        public void Should_ShowAlert_ForEmptyAccount()
        {
            if (AppList != null && AppList.Any())
            {
                foreach (var app in AppList)
                {
                    TapButton(app, _loginButton);

                    app.WaitForElement(e => e.Text(Strings.EnterEmailMessage));

                    Assert.AreEqual(Strings.EnterEmailMessage, app.Query(Strings.EnterEmailMessage).First().Text);
                    app.Tap(e => e.Text(Strings.Ok));
                }
            }
        }

        [Test]
        [Description("Login With Invalid UserEmail Should Show Alert")]
        public void Should_ShowAlert_ForInValidUserEmail()
        {
            if (AppList != null && AppList.Any())
            {
                foreach (var app in AppList)
                {
                    EnterText(app, _emailEntry, InValidUserEmail);
                    EnterText(app, _passwordEntry, ValidUserPassword);
                    TapButton(app, _loginButton);

                    app.WaitForElement(e => e.Text(Strings.IncorrectLoginDataMessage));

                    Assert.AreEqual(Strings.IncorrectLoginDataMessage, app.Query(Strings.IncorrectLoginDataMessage).First().Text);
                    app.Tap(e => e.Text(Strings.Ok));
                }
            }
        }

        [Test]
        [Description("Login With Invalid Password Should Show Alert")]
        public void Should_ShowAlert_ForInValidPassword()
        {
            if (AppList != null && AppList.Any())
            {
                foreach (var app in AppList)
                {
                    EnterText(app, _emailEntry, InValidUserEmail);
                    EnterText(app, _passwordEntry, ValidUserPassword);
                    TapButton(app, _loginButton);

                    app.WaitForElement(e => e.Text(Strings.IncorrectLoginDataMessage));

                    Assert.AreEqual(Strings.IncorrectLoginDataMessage, app.Query(Strings.IncorrectLoginDataMessage).First().Text);
                    app.Tap(e => e.Text(Strings.Ok));
                }
            }
        }
    }
}

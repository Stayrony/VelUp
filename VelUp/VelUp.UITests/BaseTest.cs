using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NUnit.Framework;
using VelUp.Resources.Strings;
using VelUp.UITests.Models;
using VelUp.UITests.Services.Settings;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace VelUp.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class BaseTest
    {
        private static readonly IContainer Container = AppInitializer.Container.Initialize();

        readonly Query _loginButton, _emailEntry, _passwordEntry;
        public List<IApp> AppList { get; private set; } = new List<IApp>();
        public Platform Platform { get; private set; }
        public const int SLEEP_TIME = 2000;

        private DevicesSettings _deviceSettings;
        private ISettingsService _settingsService;

        public string ValidUserEmail { get; set; } = "devamb4@jordencorp.dvgf";
        public string ValidUserPassword { get; set; } = "123456";

        public string InValidUserEmail { get; set; } = "12345@mailinator.com";
        public string InValidUserPassword { get; set; } = "09876543";

        public BaseTest(Platform platform)
        {
            this.Platform = platform;

            _loginButton = x => x.Marked("loginButton");
            _emailEntry = x => x.Marked("emailEntry");
            _passwordEntry = x => x.Marked("passwordEntry");
        }

        //        Naming standards for unit tests is thus:
        //        UnitOfWork_StateUnderTest_ExpectedBehavior

        [SetUp]
        public void BeforeEachTest()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                _settingsService = scope.Resolve<ISettingsService>();
            }

            _deviceSettings = _settingsService.GetDevicesSettings();

            var platformSettings = _deviceSettings.Settings.FirstOrDefault(s => s.Platform == Platform.ToString())
                                   ?? throw new ArgumentNullException("PlatformSettings is null");
            foreach (var item in platformSettings.SerialNumbers)
            {
                AppList.Add(AppInitializer.StartApp(Platform, item, platformSettings.AssemblyPath));
            }
        }

        public void SuccessLoginForValidCredentials(IApp item)
        {
            EnterText(item, _emailEntry, ValidUserEmail);

            EnterText(item, _passwordEntry, ValidUserPassword);

            // ScreenHelper.MakeScreen("Login", nameof(SuccessLoginForValidCredentials), item, Platform);

            TapButton(item, _loginButton);

            //ScreenHelper.MakeScreen("SuccessLoginButtonTapped", nameof(SuccessLoginForValidCredentials), item, Platform);

            // Assert
            AppResult[] result = item.WaitForElement(Strings.Explore);
            Assert.IsTrue(result.Any(), $"Navigation on {Strings.Explore} View");
        }

        public void EnterText(IApp item, Query entryAutomationId, string text)
        {
            System.Threading.Thread.Sleep(SLEEP_TIME);

            item.WaitForElement(entryAutomationId);
            item.EnterText(entryAutomationId, text);
            item.DismissKeyboard();

            System.Threading.Thread.Sleep(SLEEP_TIME);
        }

        public void TapButton(IApp item, Query buttonAutomationID)
        {
            System.Threading.Thread.Sleep(SLEEP_TIME);

            item.WaitForElement(buttonAutomationID);
            item.Flash(buttonAutomationID);
            item.Tap(buttonAutomationID);
        }
    }
}

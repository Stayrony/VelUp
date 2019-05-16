using Autofac;
using VelUp.UITests.Services.Settings;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace VelUp.UITests
{
    public class AppInitializer
    {
        public static class Container
        {
            public static IContainer Initialize()
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<SettingsService>().As<ISettingsService>();

                return builder.Build();
            }
        }

        public static IApp StartApp(Platform platform, string deviceSerial, string appPath)
        {
            if (platform == Platform.Android)
            {
                return ConfigureAndroidApp(deviceSerial, appPath);
            }
            else
            {
                return ConfigureIOSApp(deviceSerial, appPath);
            }
        }

        #region -- Private helpers --

        //the DeviceSerial is needed when there are multiple devices attached

        private static IApp ConfigureAndroidApp(string deviceSerial, string packageName)
        {
            var configurator = ConfigureApp.Android
                                           .EnableLocalScreenshots()
                                           .PreferIdeSettings()
                                           //.DeviceSerial(deviceSerial)
                                           //.ApkFile(appPath);
                                           .InstalledApp(packageName);

            return configurator.StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
        }

        private static IApp ConfigureIOSApp(string deviceSerial, string appPath)
        {
            var configurator = ConfigureApp.iOS
                                           .EnableLocalScreenshots()
                                           .Debug()
                                           .PreferIdeSettings()
                                           //.DeviceIdentifier(deviceSerial)
                                           .InstalledApp(appPath);

            return configurator.StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
        }

        #endregion
    }
}
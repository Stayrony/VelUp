using System;
using System.IO;
using Xamarin.UITest;

namespace VelUp.UITests.Helpers
{
    public class ScreenHelper
    {
        public static void MakeScreen(string screenName, string testsName, IApp app, Platform platform)
        {
            var screen = app.Screenshot(screenName);

            string folderPath = @"../../../VelUp/Artifacts/" + app.Device.DeviceIdentifier + "_" + platform.ToString();

            CreateFolderForScreens(folderPath);

            folderPath = folderPath + "/" + testsName;

            CreateFolderForScreens(folderPath);

            var fileName = DateTime.Now.ToString("g") + ".png";
            fileName = fileName.Replace("/", ":");

            string destinationPath = string.Format(folderPath + "/{0}", screenName + "_" + fileName);
            screen.MoveTo(destinationPath);
        }

        #region -- Private helpers --

        private static void CreateFolderForScreens(string folderName)
        {
            bool isFolderExist = System.IO.Directory.Exists(folderName);

            if (!isFolderExist)
            {
                Directory.CreateDirectory(folderName);
            }
        }

        #endregion
    }
}

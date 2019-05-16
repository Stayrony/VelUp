using System;
using System.IO;
using Newtonsoft.Json;
using VelUp.UITests.Models;

namespace VelUp.UITests.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private DevicesSettings _deviceSettings;

        private const string SETTINGS_NAME = "config.json";

        public SettingsService()
        {
        }

        #region -- ISettingsService implementation --

        public DevicesSettings GetDevicesSettings()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SETTINGS_NAME);

            _deviceSettings = JsonConvert.DeserializeObject<DevicesSettings>(File.ReadAllText(path));

            return _deviceSettings;
        }

        #endregion
    }
}

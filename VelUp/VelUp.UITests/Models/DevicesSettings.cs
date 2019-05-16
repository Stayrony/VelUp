using System;
using Newtonsoft.Json;

namespace VelUp.UITests.Models
{
    public class DevicesSettings
    {
        [JsonProperty("Settings")]
        public DeviceSettingsItem[] Settings { get; set; }
    }
}

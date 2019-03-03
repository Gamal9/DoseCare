using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoseCare.Helper
{
    class AppSettings
    {
        private static ISettings Settings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        private const string LastSettingsKey = "last_email_key";
        private static readonly string SettingsDefault = string.Empty;
        public static string LastUsedKey
        {
            get => Settings.GetValueOrDefault(LastSettingsKey, SettingsDefault);
            set => Settings.AddOrUpdateValue(LastSettingsKey, value);

        }
    }
}

namespace HospitalApp.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants
        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;
        private const string IsLoginKey = "login_key";
        private static readonly bool IsLoginDefault = false;

        private const string AccessTokenKey = "accessTokenKey_key";
        private static readonly string AccessTokenDefault = string.Empty;
        #endregion

        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(SettingsKey, value);
        }

        public static bool IsLogin
        {
            get => AppSettings.GetValueOrDefault(IsLoginKey, IsLoginDefault);
            set => AppSettings.AddOrUpdateValue(IsLoginKey, value);
        }

        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault(AccessTokenKey, AccessTokenDefault);
            set => AppSettings.AddOrUpdateValue(AccessTokenKey, value);
        }
    }
}
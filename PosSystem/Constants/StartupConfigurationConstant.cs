namespace PosSystem.Constants
{
    /// <summary>
    /// MiddlewareConstant is an entity which represents startup middleware constants.
    /// </summary>
    public static class StartupConfigurationConstant
    {
        #region Database Configuration Constants

        public const string CONNECTION_STRING_KEY = "PosSystemDatabase";

        #endregion

        #region Token Based Authentication Constants

        public const string JWT_SETTINGS_CONFIG_KEY = "JWTSettings";

        #endregion
    }
}

namespace knowledge.common.entities.Types.Enums
{
    #region Public Enums
    /// <summary>
    ///     Application modules enumeration.
    /// </summary>
    public enum ApplicationModule
    {
        Api
    }
    #endregion

    #region Public Extension Classes
    /// <summary>
    ///     Extension methods for application modules enumeration.
    /// </summary>
    public static class ApplicationModuleExtensions
    {
        #region Public Methods
        /// <summary>
        ///     Gets the description associated to the specified log module.
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public static string GetDescription(this ApplicationModule module)
        {
            switch (module)
            {
                case ApplicationModule.Api:
                    return "knowledge.api";
                default:
                    return string.Empty;
            }
        }
        #endregion
    }
    #endregion
}

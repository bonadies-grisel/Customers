namespace knowledge.common.entities.Types.Enums
{
    #region Public Enums
    /// <summary>
    ///     Log types enumeration.
    /// </summary>
    public enum LogType
    {
        Trace,
        Exception
    }
    #endregion

    #region Public Extension Classes
    /// <summary>
    ///     Extension methods for log type enumeration.
    /// </summary>
    public static class LogTypeExtensions
    {
        #region Public Methods
        /// <summary>
        ///     Gets the value associated to the specified log type.
        /// </summary>
        /// <param name="logType"></param>
        /// <returns></returns>
        public static int GetValue(this LogType logType)
        {
            switch (logType)
            {
                case LogType.Trace:
                    return 0;
                case LogType.Exception:
                    return 1;
                default:
                    return 0;
            }
        }
        #endregion
    }
    #endregion
}

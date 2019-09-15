namespace UGF.Logs.Editor
{
    /// <summary>
    /// Represents a define of which log compile define to setup.
    /// </summary>
    public struct LogDefineSettings
    {
        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_INFO' define is specified.
        /// </summary>
        public bool Info { get; set; }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_DEBUG' define is specified.
        /// </summary>
        public bool Debug { get; set; }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_WARNING' define is specified.
        /// </summary>
        public bool Warning { get; set; }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_ERROR' define is specified.
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_EXCEPTION' define is specified.
        /// </summary>
        public bool Exception { get; set; }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_INCLUDE_EDITOR' define is specified.
        /// </summary>
        public bool IncludeEditor { get; set; }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_INCLUDE_DEVBUILD' define is specified.
        /// </summary>
        public bool IncludeDevelopmentBuild { get; set; }
    }
}
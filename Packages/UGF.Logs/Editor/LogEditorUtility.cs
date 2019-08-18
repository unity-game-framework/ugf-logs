using System.Collections.Generic;
using UnityEditor;

namespace UGF.Logs.Editor
{
    /// <summary>
    /// Provides utilities to work with logging in editor.
    /// </summary>
    public static class LogEditorUtility
    {
        /// <summary>
        /// Gets the define used to include info logs in release build. (Value is 'UGF_LOG_INFO')
        /// </summary>
        public static string DefineLogInfo { get; } = "UGF_LOG_INFO";

        /// <summary>
        /// Gets the define used to include debug logs in release build. (Value is 'UGF_LOG_DEBUG')
        /// </summary>
        public static string DefineLogDebug { get; } = "UGF_LOG_DEBUG";

        /// <summary>
        /// Gets the define used to include warning logs in release build. (Value is 'UGF_LOG_WARNING')
        /// </summary>
        public static string DefineLogWarning { get; } = "UGF_LOG_WARNING";

        /// <summary>
        /// Gets the define used to include error logs in release build. (Value is 'UGF_LOG_ERROR')
        /// </summary>
        public static string DefineLogError { get; } = "UGF_LOG_ERROR";

        /// <summary>
        /// Gets the define used to include exception logs in release build. (Value is 'UGF_LOG_EXCEPTION')
        /// </summary>
        public static string DefineLogException { get; } = "UGF_LOG_EXCEPTION";

        /// <summary>
        /// Gets the local log settings.
        /// </summary>
        public static LogEditorSettings GetSettings()
        {
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            IEnumerable<string> defines = symbols.Split(';');

            return new LogEditorSettings(defines);
        }

        /// <summary>
        /// Sets changed log settings to apply them to project.
        /// <para>
        /// Applying settings will trigger recompilation.
        /// </para>
        /// </summary>
        /// <param name="settings">The log settings to apply.</param>
        public static void SetSettings(LogEditorSettings settings)
        {
            IEnumerable<string> defines = settings.GetDefines();
            string symbols = string.Join(";", defines);

            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, symbols);
        }
    }
}

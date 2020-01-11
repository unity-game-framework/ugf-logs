using System;
using System.Collections.Generic;
using System.Reflection;
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
        /// Gets the define used to always include logs in 'Editor' whatever other defines are. (Value is 'UGF_LOG_INCLUDE_EDITOR')
        /// </summary>
        public static string DefineIncludeEditor { get; } = "UGF_LOG_INCLUDE_EDITOR";

        /// <summary>
        /// Gets the define used to always include logs in 'Development Build' whatever other defines are. (Value is 'UGF_LOG_INCLUDE_DEVBUILD')
        /// </summary>
        public static string DefineIncludeDevelopmentBuild { get; } = "UGF_LOG_INCLUDE_DEVBUILD";

        /// <summary>
        /// Gets the log settings depends on current build target group.
        /// </summary>
        public static LogDefineSettings GetSettings()
        {
            return GetSettings(EditorUserBuildSettings.selectedBuildTargetGroup);
        }

        /// <summary>
        /// Gets the log settings depends on build target group.
        /// </summary>
        /// <param name="buildTargetGroup">The build target group of the project.</param>
        public static LogDefineSettings GetSettings(BuildTargetGroup buildTargetGroup)
        {
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
            var defines = new HashSet<string>(symbols.Split(';'));
            var settings = new LogDefineSettings();

            SetSettings(defines, ref settings);

            return settings;
        }

        /// <summary>
        /// Sets log settings to apply them to the project for current build target group only.
        /// <para>
        /// Applying settings will trigger recompilation.
        /// </para>
        /// </summary>
        /// <param name="settings">The log settings to apply.</param>
        public static void SetSettings(LogDefineSettings settings)
        {
            SetSettings(settings, EditorUserBuildSettings.selectedBuildTargetGroup);
        }

        /// <summary>
        /// Sets log settings to apply them to the project for specified build target group.
        /// <para>
        /// Applying settings will trigger recompilation.
        /// </para>
        /// </summary>
        /// <param name="settings">The log settings to apply.</param>
        /// <param name="buildTargetGroup">The build target group.</param>
        public static void SetSettings(LogDefineSettings settings, BuildTargetGroup buildTargetGroup)
        {
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
            var defines = new HashSet<string>(symbols.Split(';'));

            GetDefines(defines, settings);

            symbols = string.Join(";", defines);

            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, symbols);
        }

        /// <summary>
        /// Sets log settings to apply them to the project for all known build target groups.
        /// <para>
        /// Applying settings will trigger recompilation.
        /// </para>
        /// </summary>
        /// <param name="settings">The log settings to apply.</param>
        public static void SetSettingsAll(LogDefineSettings settings)
        {
            foreach (BuildTargetGroup buildTargetGroup in InternalGetAllBuildTargetGroupValues())
            {
                SetSettings(settings, buildTargetGroup);
            }
        }

        private static IEnumerable<BuildTargetGroup> InternalGetAllBuildTargetGroupValues()
        {
            Type type = typeof(BuildTargetGroup);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);

            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];

                if (!field.IsDefined(typeof(ObsoleteAttribute)))
                {
                    var buildTargetGroup = (BuildTargetGroup)field.GetValue(null);

                    if (buildTargetGroup != BuildTargetGroup.Unknown)
                    {
                        yield return buildTargetGroup;
                    }
                }
            }
        }

        private static void SetSettings(ICollection<string> defines, ref LogDefineSettings setup)
        {
            setup.Info = defines.Contains(DefineLogInfo);
            setup.Debug = defines.Contains(DefineLogDebug);
            setup.Warning = defines.Contains(DefineLogWarning);
            setup.Error = defines.Contains(DefineLogError);
            setup.Exception = defines.Contains(DefineLogException);
            setup.IncludeEditor = defines.Contains(DefineIncludeEditor);
            setup.IncludeDevelopmentBuild = defines.Contains(DefineIncludeDevelopmentBuild);
        }

        private static void GetDefines(ISet<string> defines, LogDefineSettings setup)
        {
            SetupDefine(defines, DefineLogInfo, setup.Info);
            SetupDefine(defines, DefineLogDebug, setup.Debug);
            SetupDefine(defines, DefineLogWarning, setup.Warning);
            SetupDefine(defines, DefineLogError, setup.Error);
            SetupDefine(defines, DefineLogException, setup.Exception);
            SetupDefine(defines, DefineIncludeEditor, setup.IncludeEditor);
            SetupDefine(defines, DefineIncludeDevelopmentBuild, setup.IncludeDevelopmentBuild);
        }

        private static void SetupDefine(ISet<string> defines, string define, bool state)
        {
            if (state)
            {
                defines.Add(define);
            }
            else
            {
                defines.Remove(define);
            }
        }
    }
}

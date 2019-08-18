﻿using System;
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
        /// Gets the project log settings depends on current build target group.
        /// </summary>
        public static LogEditorSettings GetSettings()
        {
            return GetSettings(EditorUserBuildSettings.selectedBuildTargetGroup);
        }

        /// <summary>
        /// Gets the project log settings depends on build target group.
        /// </summary>
        /// <param name="buildTargetGroup">The build target group of the project.</param>
        public static LogEditorSettings GetSettings(BuildTargetGroup buildTargetGroup)
        {
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
            IEnumerable<string> defines = symbols.Split(';');

            return new LogEditorSettings(defines);
        }

        /// <summary>
        /// Sets log settings to apply them to the project for current build target group only.
        /// <para>
        /// Applying settings will trigger recompilation.
        /// </para>
        /// </summary>
        /// <param name="settings">The log settings to apply.</param>
        public static void SetSettings(LogEditorSettings settings)
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
        public static void SetSettings(LogEditorSettings settings, BuildTargetGroup buildTargetGroup)
        {
            IEnumerable<string> defines = settings.GetDefines();
            string symbols = string.Join(";", defines);

            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, symbols);
        }

        /// <summary>
        /// Sets log settings to apply them to the project for all known build target groups.
        /// <para>
        /// Applying settings will trigger recompilation.
        /// </para>
        /// </summary>
        /// <param name="settings">The log settings to apply.</param>
        public static void SetSettingsAll(LogEditorSettings settings)
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
                        SetSettings(settings, buildTargetGroup);
                    }
                }
            }
        }
    }
}

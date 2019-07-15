using System.Collections.Generic;
using UnityEditor;

namespace UGF.Logs.Editor
{
    public static class LogEditorUtility
    {
        public static string DefineLogInfo { get; } = "UGF_LOG_INFO";
        public static string DefineLogWarning { get; } = "UGF_LOG_WARNING";
        public static string DefineLogError { get; } = "UGF_LOG_ERROR";
        public static string DefineLogException { get; } = "UGF_LOG_EXCEPTION";

        public static LogEditorSettings GetSettings()
        {
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            BuildTargetGroup group = BuildPipeline.GetBuildTargetGroup(target);
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
            IEnumerable<string> defines = symbols.Split(';');

            return new LogEditorSettings(defines);
        }

        public static void SetSettings(LogEditorSettings settings)
        {
            IEnumerable<string> defines = settings.GetDefines();
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            BuildTargetGroup group = BuildPipeline.GetBuildTargetGroup(target);
            string symbols = string.Join(";", defines);

            PlayerSettings.SetScriptingDefineSymbolsForGroup(group, symbols);
        }
    }
}

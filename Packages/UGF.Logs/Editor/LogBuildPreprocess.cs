using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace UGF.Logs.Editor
{
    internal class LogBuildPreprocess : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }

        public void OnPreprocessBuild(BuildReport report)
        {
            if (LogEditorSettings.BuildEnabled && LogEditorSettings.TryGetBuildSettings(report.summary.platformGroup, out LogBuildSettings settings))
            {
                LogEditorSettings.ApplyBuildSettings(report.summary.platformGroup, settings);
            }
        }
    }
}

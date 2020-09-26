using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace UGF.Logs.Editor
{
    internal class LogBuildPostprocess : IPostprocessBuildWithReport
    {
        public int callbackOrder { get; }

        public void OnPostprocessBuild(BuildReport report)
        {
            if (LogEditorSettings.BuildEnabled)
            {
                LogEditorSettings.ClearBuildSettings(report.summary.platformGroup);
                AssetDatabase.SaveAssets();
            }
        }
    }
}

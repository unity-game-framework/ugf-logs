using UGF.Defines.Editor;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace UGF.Logs.Editor
{
    internal class LogBuildPreprocess : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }

        public void OnPreprocessBuild(BuildReport report)
        {
            BuildTargetGroup group = report.summary.platformGroup;

            DefinesBuildEditorUtility.ApplyAll(group, LogEditorSettings.Settings, true);
            AssetDatabase.SaveAssets();
        }
    }
}

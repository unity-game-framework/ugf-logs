using UGF.Defines.Editor;
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
            BuildTargetGroup group = report.summary.platformGroup;

            DefinesBuildEditorUtility.ClearAll(group, LogEditorSettings.Settings);
            AssetDatabase.SaveAssets();
        }
    }
}

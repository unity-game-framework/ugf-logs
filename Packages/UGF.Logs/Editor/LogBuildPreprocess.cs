using UGF.Defines.Editor;
using UGF.EditorTools.Editor.IMGUI.PlatformSettings;
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

            if (LogEditorSettings.Settings.TryGetSettings(group, out DefinesSettings settings))
            {
                DefinesBuildEditorUtility.ApplyDefinesAll(group, settings);
                AssetDatabase.SaveAssets();
            }
        }
    }
}

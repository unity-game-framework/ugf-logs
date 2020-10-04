using UGF.Defines.Editor;
using UGF.EditorTools.Runtime.IMGUI.EnabledProperty;
using UGF.Logs.Runtime;

namespace UGF.Logs.Editor
{
    public static class LogEditorUtility
    {
        public static void SetupDefaultDefines(DefinesSettings settings)
        {
            settings.Defines.Clear();
            settings.Defines.Add(new EnabledProperty<string>(false, LogUtility.LOG_INFO_DEFINE));
            settings.Defines.Add(new EnabledProperty<string>(false, LogUtility.LOG_DEBUG_DEFINE));
            settings.Defines.Add(new EnabledProperty<string>(false, LogUtility.LOG_WARNING_DEFINE));
            settings.Defines.Add(new EnabledProperty<string>(false, LogUtility.LOG_ERROR_DEFINE));
            settings.Defines.Add(new EnabledProperty<string>(false, LogUtility.LOG_EXCEPTION_DEFINE));
        }
    }
}

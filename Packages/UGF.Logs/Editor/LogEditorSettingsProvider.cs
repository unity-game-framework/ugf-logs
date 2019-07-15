using UnityEditor;

namespace UGF.Logs.Editor
{
    internal static class LogEditorSettingsProvider
    {
        [SettingsProvider]
        private static SettingsProvider GetEditor()
        {
            return new LogEditorSettingsProviderEditor();
        }
    }
}

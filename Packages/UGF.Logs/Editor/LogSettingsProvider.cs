using UnityEditor;

namespace UGF.Logs.Editor
{
    internal static class LogSettingsProvider
    {
        [SettingsProvider]
        private static SettingsProvider GetEditor()
        {
            return new LogSettingsProviderEditor();
        }
    }
}

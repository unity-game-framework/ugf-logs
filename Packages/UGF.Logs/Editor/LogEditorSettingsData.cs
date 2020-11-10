using UGF.CustomSettings.Runtime;
using UGF.Defines.Editor;
using UGF.EditorTools.Runtime.IMGUI.PlatformSettings;
using UnityEngine;

namespace UGF.Logs.Editor
{
    public class LogEditorSettingsData : CustomSettingsData
    {
        [SerializeField] private bool m_editorEnabled = true;
        [SerializeField] private PlatformSettings<DefinesSettings> m_settings = new PlatformSettings<DefinesSettings>();

        public bool EditorEnabled { get { return m_editorEnabled; } set { m_editorEnabled = value; } }
        public PlatformSettings<DefinesSettings> Settings { get { return m_settings; } }
    }
}

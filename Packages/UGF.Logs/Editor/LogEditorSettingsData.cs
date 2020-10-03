using System;
using System.Collections.Generic;
using UGF.CustomSettings.Runtime;
using UGF.Defines.Editor;
using UGF.EditorTools.Runtime.IMGUI.PlatformSettings;
using UnityEditor;
using UnityEngine;

namespace UGF.Logs.Editor
{
    internal class LogEditorSettingsData : CustomSettingsData
    {
        [SerializeField] private bool m_editorEnabled = true;
        [SerializeField] private PlatformSettings<DefinesSettings> m_settings = new PlatformSettings<DefinesSettings>();
        [SerializeField] private bool m_buildEnabled = true;
        [SerializeField] private List<Platform> m_platforms = new List<Platform>();

        public bool EditorEnabled { get { return m_editorEnabled; } set { m_editorEnabled = value; } }
        public PlatformSettings<DefinesSettings> Settings { get { return m_settings; } }
        public bool BuildEnabled { get { return m_buildEnabled; } set { m_buildEnabled = value; } }
        public List<Platform> Platforms { get { return m_platforms; } }

        [Serializable]
        public class Platform
        {
            [SerializeField] private BuildTargetGroup m_group;
            [SerializeField] private LogBuildSettings m_settings;

            public BuildTargetGroup Group { get { return m_group; } set { m_group = value; } }
            public LogBuildSettings Settings { get { return m_settings; } set { m_settings = value; } }
        }
    }
}

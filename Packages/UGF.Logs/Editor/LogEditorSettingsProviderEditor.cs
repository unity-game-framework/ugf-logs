using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UGF.Logs.Editor
{
    internal class LogEditorSettingsProviderEditor : SettingsProvider
    {
        private readonly string m_groupPrefKey = "UGF.Logs.Editor.LogEditorSettingsProviderEditor.Group";
        private readonly List<GroupItem> m_groups = new List<GroupItem>();
        private int m_group;
        private SerializedObject m_serializedObject;
        private Styles m_styles;
        private Content m_content = new Content();

        private class GroupItem
        {
            public BuildTargetGroup BuildTargetGroup { get; set; }
            public GUIContent ContentName { get; set; }
            public bool GroupAll { get; set; }
        }

        private class Data : ScriptableObject
        {
            [SerializeField] private LogEditorSettings m_settings = new LogEditorSettings();

            public LogEditorSettings Settings { get { return m_settings; } set { m_settings = value; } }
        }

        private class Styles
        {
            public GUIStyle DropdownButton { get; } = "DropDownButton";
        }

        private class Content
        {
            public GUIContent LogInfoLabel { get; } = new GUIContent("Info", "Determines whether 'UGF_LOG_INFO' define is specified for selected platform.");
            public GUIContent LogDebugLabel { get; } = new GUIContent("Debug", "Determines whether 'UGF_LOG_DEBUG' define is specified for selected platform.");
            public GUIContent LogWarningLabel { get; } = new GUIContent("Warning", "Determines whether 'UGF_LOG_WARNING' define is specified for selected platform.");
            public GUIContent LogErrorLabel { get; } = new GUIContent("Error", "Determines whether 'UGF_LOG_ERROR' define is specified for selected platform.");
            public GUIContent LogExceptionLabel { get; } = new GUIContent("Exception", "Determines whether 'UGF_LOG_EXCEPTION' define is specified for selected platform.");
        }

        public LogEditorSettingsProviderEditor() : base("Project/UGF/Logs", SettingsScope.Project, new[] { "Log" })
        {
            var groupAll = new GroupItem
            {
                ContentName = new GUIContent("All Platforms"),
                GroupAll = true
            };

            m_groups.Add(groupAll);

            foreach (BuildTargetGroup buildTargetGroup in LogEditorUtility.InternalGetAllBuildTargetGroupValues())
            {
                var group = new GroupItem
                {
                    BuildTargetGroup = buildTargetGroup,
                    ContentName = new GUIContent(buildTargetGroup.ToString())
                };

                m_groups.Add(group);
            }
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            Load();
        }

        public override void OnDeactivate()
        {
            if (m_serializedObject != null)
            {
                Save();
            }
        }

        public override void OnGUI(string searchContext)
        {
            if (m_styles == null)
            {
                m_styles = new Styles();
            }

            m_serializedObject.UpdateIfRequiredOrScript();

            GroupItem group = m_groups[m_group];

            SerializedProperty propertyInfo = m_serializedObject.FindProperty("m_settings.m_logInfo");
            SerializedProperty propertyDebug = m_serializedObject.FindProperty("m_settings.m_logDebug");
            SerializedProperty propertyWarning = m_serializedObject.FindProperty("m_settings.m_logWarning");
            SerializedProperty propertyError = m_serializedObject.FindProperty("m_settings.m_logError");
            SerializedProperty propertyException = m_serializedObject.FindProperty("m_settings.m_logException");

            using (new EditorGUI.IndentLevelScope())
            {
                EditorGUILayout.PropertyField(propertyInfo, m_content.LogInfoLabel);
                EditorGUILayout.PropertyField(propertyDebug, m_content.LogDebugLabel);
                EditorGUILayout.PropertyField(propertyWarning, m_content.LogWarningLabel);
                EditorGUILayout.PropertyField(propertyError, m_content.LogErrorLabel);
                EditorGUILayout.PropertyField(propertyException, m_content.LogExceptionLabel);

                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.FlexibleSpace();

                    Rect rect = GUILayoutUtility.GetRect(group.ContentName, m_styles.DropdownButton, GUILayout.MinWidth(100F));

                    if (EditorGUI.DropdownButton(rect, group.ContentName, FocusType.Keyboard, m_styles.DropdownButton))
                    {
                        ShowGroupMenu(rect);
                    }

                    EditorGUILayout.Space();
                }

                if (group.GroupAll || group.BuildTargetGroup == EditorUserBuildSettings.selectedBuildTargetGroup)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.HelpBox("Applying settings will trigger project recompilation.", MessageType.Info);
                }

                if (EditorUserBuildSettings.development)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.HelpBox("Development Build is active, all setting are ignored and all logs included in build.", MessageType.Info);
                }
            }

            if (m_serializedObject.hasModifiedProperties)
            {
                m_serializedObject.ApplyModifiedProperties();

                Save();
            }

            m_serializedObject.ApplyModifiedProperties();
        }

        private void SetGroup(int index)
        {
            if (m_group != index)
            {
                Save();

                m_group = index;

                EditorPrefs.SetInt(m_groupPrefKey, m_group);

                Load();
                Repaint();
            }
        }

        private void Load()
        {
            m_group = EditorPrefs.GetInt(m_groupPrefKey);

            GroupItem group = m_groups[m_group];

            m_serializedObject = group.GroupAll ? LoadDataAll() : LoadData(group.BuildTargetGroup);
        }

        private void Save()
        {
            GroupItem group = m_groups[m_group];
            var data = (Data)m_serializedObject.targetObject;

            if (group.GroupAll)
            {
                LogEditorUtility.SetSettingsAll(data.Settings);
            }
            else
            {
                LogEditorUtility.SetSettings(data.Settings, group.BuildTargetGroup);
            }
        }

        private SerializedObject LoadDataAll()
        {
            var targets = new List<Object>();

            foreach (BuildTargetGroup buildTargetGroup in LogEditorUtility.InternalGetAllBuildTargetGroupValues())
            {
                var data = ScriptableObject.CreateInstance<Data>();

                data.Settings = LogEditorUtility.GetSettings(buildTargetGroup);

                targets.Add(data);
            }

            return new SerializedObject(targets.ToArray());
        }

        private SerializedObject LoadData(BuildTargetGroup buildTargetGroup)
        {
            var data = ScriptableObject.CreateInstance<Data>();

            data.Settings = LogEditorUtility.GetSettings(buildTargetGroup);

            return new SerializedObject(data);
        }

        private void ShowGroupMenu(Rect position)
        {
            var menu = new GenericMenu();

            for (int i = 0; i < m_groups.Count; i++)
            {
                GroupItem group = m_groups[i];

                menu.AddItem(group.ContentName, i == m_group, OnGroupMenuItemSelected, i);
            }

            menu.DropDown(position);
        }

        private void OnGroupMenuItemSelected(object userData)
        {
            int index = (int)userData;

            SetGroup(index);
        }
    }
}

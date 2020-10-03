using System;
using UGF.Defines.Editor;
using UGF.Logs.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Logs.Editor
{
    internal class LogEditorSettingsDrawer : DefinesPlatformSettingsDrawer
    {
        private Styles m_styles;

        private class Styles
        {
            public GUIContent IncludeInBuild { get; } = new GUIContent("Include In Build", "Determines whether to include enabled defines in player build.");
            public GUIContent Log { get; } = new GUIContent("Info", "Determines whether define symbol for Log.Info method is enabled for build.");
            public GUIContent Debug { get; } = new GUIContent("Debug", "Determines whether define symbol for Log.Debug method is enabled for build.");
            public GUIContent Warning { get; } = new GUIContent("Warning", "Determines whether define symbol for Log.Warning method is enabled for build.");
            public GUIContent Error { get; } = new GUIContent("Error", "Determines whether define symbol for Log.Error method is enabled for build.");
            public GUIContent Exception { get; } = new GUIContent("Exception", "Determines whether define symbol for Log.Exception method is enabled for build.");

            public GUIContent GetDefineLabel(string define)
            {
                switch (define)
                {
                    case LogUtility.LOG_INFO_DEFINE: return Log;
                    case LogUtility.LOG_DEBUG_DEFINE: return Debug;
                    case LogUtility.LOG_WARNING_DEFINE: return Warning;
                    case LogUtility.LOG_ERROR_DEFINE: return Error;
                    case LogUtility.LOG_EXCEPTION_DEFINE: return Exception;
                    default:
                    {
                        throw new ArgumentException($"Label not found for specified define: '{define}'.");
                    }
                }
            }
        }

        protected override void OnDrawGUI(Rect position, SerializedProperty propertyGroups)
        {
            if (m_styles == null) m_styles = new Styles();

            base.OnDrawGUI(position, propertyGroups);
        }

        protected override void OnDrawProperties(Rect position, SerializedProperty propertyGroups, string name)
        {
            SerializedProperty propertySettings = OnGetSettings(propertyGroups, name);
            SerializedProperty propertyIncludeInBuild = propertySettings.FindPropertyRelative("m_includeInBuild");

            EditorGUI.PropertyField(position, propertyIncludeInBuild, m_styles.IncludeInBuild);
        }

        protected override void OnDrawElement(Rect position, SerializedProperty propertyGroups, int index)
        {
            string name = GetSelectedGroupName();
            SerializedProperty propertySettings = OnGetSettings(propertyGroups, name);
            SerializedProperty propertyDefines = propertySettings.FindPropertyRelative("m_defines");
            SerializedProperty propertyElement = propertyDefines.GetArrayElementAtIndex(index);
            SerializedProperty propertyEnabled = propertyElement.FindPropertyRelative("m_enabled");
            SerializedProperty propertyValue = propertyElement.FindPropertyRelative("m_value");

            float line = EditorGUIUtility.singleLineHeight;
            float space = EditorGUIUtility.standardVerticalSpacing;

            var propertyPosition = new Rect(position.x, position.y, position.width - line - space, position.height);
            var flagPosition = new Rect(propertyPosition.xMax + space, position.y, line, position.height);

            GUIContent label = m_styles.GetDefineLabel(propertyValue.stringValue);

            Rect enabledPosition = EditorGUI.PrefixLabel(propertyPosition, label);
            var valuePosition = new Rect(enabledPosition.x + line + space, enabledPosition.y, enabledPosition.width - line - space, enabledPosition.height);

            EditorGUI.PropertyField(enabledPosition, propertyEnabled, GUIContent.none);
            EditorGUI.LabelField(valuePosition, propertyValue.stringValue);

            DrawDefineFlag(flagPosition, propertyGroups, index);
        }

        protected override float OnGetPropertiesHeight(SerializedProperty propertyGroups)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        protected override SerializedProperty OnGetSettings(SerializedProperty propertyGroups, string name)
        {
            SerializedProperty propertySettings = base.OnGetSettings(propertyGroups, name);
            SerializedProperty propertyDefines = propertySettings.FindPropertyRelative("m_defines");

            if (propertyDefines.arraySize == 0)
            {
                OnCreateSettings(propertyGroups, name, propertySettings);
            }

            return propertySettings;
        }

        protected override object OnCreateSettingsInstance(string name)
        {
            var settings = (DefinesSettings)base.OnCreateSettingsInstance(name);

            LogEditorUtility.SetupDefaultDefines(settings);

            return settings;
        }
    }
}

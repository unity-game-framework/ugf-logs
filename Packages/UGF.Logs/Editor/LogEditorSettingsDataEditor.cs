using UGF.CustomSettings.Editor;
using UnityEditor;

namespace UGF.Logs.Editor
{
    [CustomEditor(typeof(LogEditorSettingsData), true)]
    internal class LogEditorSettingsDataEditor : CustomSettingsDataEditor
    {
        private SerializedProperty m_propertyEditorEnabled;
        private SerializedProperty m_propertyBuildEnabled;
        private SerializedProperty m_propertyPlatforms;

        private void OnEnable()
        {
            m_propertyEditorEnabled = serializedObject.FindProperty("m_editorEnabled");
            m_propertyBuildEnabled = serializedObject.FindProperty("m_buildEnabled");
            m_propertyPlatforms = serializedObject.FindProperty("m_platforms");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            EditorGUILayout.PropertyField(m_propertyEditorEnabled);
            EditorGUILayout.PropertyField(m_propertyBuildEnabled);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Build Settings", EditorStyles.boldLabel);

            BuildTargetGroup group = EditorGUILayout.BeginBuildTargetSelectionGrouping();

            DrawBuildSettings(group);

            EditorGUILayout.EndBuildTargetSelectionGrouping();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawBuildSettings(BuildTargetGroup group)
        {
            SerializedProperty propertySettings = GetPropertySettings(group);

            DrawBuildSettings(propertySettings);
        }

        private void DrawBuildSettings(SerializedProperty propertySettings)
        {
            SerializedProperty propertyInfo = propertySettings.FindPropertyRelative("m_info");
            SerializedProperty propertyDebug = propertySettings.FindPropertyRelative("m_debug");
            SerializedProperty propertyWarning = propertySettings.FindPropertyRelative("m_warning");
            SerializedProperty propertyError = propertySettings.FindPropertyRelative("m_error");
            SerializedProperty propertyException = propertySettings.FindPropertyRelative("m_exception");

            EditorGUILayout.PropertyField(propertyInfo);
            EditorGUILayout.PropertyField(propertyDebug);
            EditorGUILayout.PropertyField(propertyWarning);
            EditorGUILayout.PropertyField(propertyError);
            EditorGUILayout.PropertyField(propertyException);
        }

        private SerializedProperty GetPropertySettings(BuildTargetGroup group)
        {
            if (!TryGetPropertySettings(group, out SerializedProperty propertySettings))
            {
                propertySettings = AddPropertySettings(group);
            }

            return propertySettings;
        }

        private bool TryGetPropertySettings(BuildTargetGroup group, out SerializedProperty propertySettings)
        {
            for (int i = 0; i < m_propertyPlatforms.arraySize; i++)
            {
                SerializedProperty propertyElement = m_propertyPlatforms.GetArrayElementAtIndex(i);
                SerializedProperty propertyGroup = propertyElement.FindPropertyRelative("m_group");

                if (propertyGroup.intValue == (int)group)
                {
                    propertySettings = propertyElement.FindPropertyRelative("m_settings");
                    return true;
                }
            }

            propertySettings = null;
            return false;
        }

        private SerializedProperty AddPropertySettings(BuildTargetGroup group)
        {
            m_propertyPlatforms.InsertArrayElementAtIndex(m_propertyPlatforms.arraySize);

            SerializedProperty propertyElement = m_propertyPlatforms.GetArrayElementAtIndex(m_propertyPlatforms.arraySize - 1);
            SerializedProperty propertyGroup = propertyElement.FindPropertyRelative("m_group");
            SerializedProperty propertySettings = propertyElement.FindPropertyRelative("m_settings");

            propertyGroup.intValue = (int)group;
            m_propertyPlatforms.serializedObject.ApplyModifiedProperties();

            return propertySettings;
        }
    }
}

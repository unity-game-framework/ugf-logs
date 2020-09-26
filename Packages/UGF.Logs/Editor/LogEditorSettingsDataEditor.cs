using UGF.CustomSettings.Editor;
using UnityEditor;

namespace UGF.Logs.Editor
{
    [CustomEditor(typeof(LogEditorSettingsData), true)]
    internal class LogEditorSettingsDataEditor : CustomSettingsDataEditor
    {
        private SerializedProperty m_propertyEditorEnabled;
        private SerializedProperty m_propertyEditorFilter;
        private SerializedProperty m_propertyBuildEnabled;

        private void OnEnable()
        {
            m_propertyEditorEnabled = serializedObject.FindProperty("m_editorEnabled");
            m_propertyEditorFilter = serializedObject.FindProperty("m_editorFilter");
            m_propertyBuildEnabled = serializedObject.FindProperty("m_buildEnabled");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            serializedObject.ApplyModifiedProperties();
        }
    }
}

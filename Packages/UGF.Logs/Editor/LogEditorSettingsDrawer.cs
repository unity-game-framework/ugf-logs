using System;
using System.Collections.Generic;
using UGF.Defines.Editor;
using UGF.EditorTools.Editor.Defines;
using UGF.EditorTools.Editor.IMGUI.PlatformSettings;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.EditorTools.Editor.Platforms;
using UGF.Logs.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Logs.Editor
{
    internal class LogEditorSettingsDrawer : PlatformSettingsDrawer
    {
        private Styles m_styles;
        private const float PADDING = 5F;

        private class Styles
        {
            public Dictionary<string, GUIContent> DefineLabels { get; } = new Dictionary<string, GUIContent>
            {
                { LogUtility.LOG_INFO_DEFINE, new GUIContent("Info", "Determines whether define symbol for Log.Info method is enabled for build.") },
                { LogUtility.LOG_DEBUG_DEFINE, new GUIContent("Debug", "Determines whether define symbol for Log.Debug method is enabled for build.") },
                { LogUtility.LOG_WARNING_DEFINE, new GUIContent("Warning", "Determines whether define symbol for Log.Warning method is enabled for build.") },
                { LogUtility.LOG_ERROR_DEFINE, new GUIContent("Error", "Determines whether define symbol for Log.Error method is enabled for build.") },
                { LogUtility.LOG_EXCEPTION_DEFINE, new GUIContent("Exception", "Determines whether define symbol for Log.Exception method is enabled for build.") }
            };

            public GUIContent UnknownDefineLabel { get; } = new GUIContent("Unknown");

            public GUIContent FlagOnContent { get; } = new GUIContent(EditorGUIUtility.FindTexture("Valid"), "Define currently included in compile symbols.");
            public GUIContent FlagOffContent { get; } = new GUIContent("X", "Define currently NOT included in compile symbols.");

            public GUIStyle FlagStyle { get; } = new GUIStyle("MiniLabel")
            {
                alignment = TextAnchor.MiddleCenter,
                normal = { textColor = Color.grey }
            };
        }

        public LogEditorSettingsDrawer()
        {
            AllowEmptySettings = false;
            AutoSettingsInstanceCreation = true;
        }

        public string GetSelectedPlatformName()
        {
            return GetSelectedGroupName();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            AddPlatformAllAvailable();

            for (int i = 0; i < PlatformEditorUtility.PlatformsAllAvailable.Count; i++)
            {
                PlatformInfo platform = PlatformEditorUtility.PlatformsAllAvailable[i];

                AddGroupType(platform.Name, typeof(DefinesSettings));
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            ClearGroups();
            ClearGroupTypes();
        }

        protected override void OnDrawGUI(Rect position, SerializedProperty propertyGroups)
        {
            m_styles ??= new Styles();

            base.OnDrawGUI(position, propertyGroups);
        }

        protected override void OnDrawSettings(Rect position, SerializedProperty propertyGroups, string name)
        {
            float height = EditorGUIUtility.singleLineHeight;
            float space = EditorGUIUtility.standardVerticalSpacing;

            SerializedProperty propertySettings = OnGetSettings(propertyGroups, name);

            using (new LabelWidthChangeScope(-PADDING))
            {
                var rectPlatformName = new Rect(position.x, position.y, position.width, height);
                var rectIncludeInBuild = new Rect(position.x, rectPlatformName.yMax + space, position.width, height);
                var rectLog = new Rect(position.x, rectIncludeInBuild.yMax + space, position.width, height);
                var rectDebug = new Rect(position.x, rectLog.yMax + space, position.width, height);
                var rectWarning = new Rect(position.x, rectDebug.yMax + space, position.width, height);
                var rectError = new Rect(position.x, rectWarning.yMax + space, position.width, height);
                var rectException = new Rect(position.x, rectError.yMax + space, position.width, height);

                SerializedProperty propertyIncludeInBuild = propertySettings.FindPropertyRelative("m_includeInBuild");
                SerializedProperty propertyDefines = propertySettings.FindPropertyRelative("m_defines");

                OnDrawSettingsPlatformName(rectPlatformName, propertyGroups, name);

                EditorGUI.PropertyField(rectIncludeInBuild, propertyIncludeInBuild);

                OnDrawDefine(rectLog, propertyDefines, name, LogUtility.LOG_INFO_DEFINE);
                OnDrawDefine(rectDebug, propertyDefines, name, LogUtility.LOG_DEBUG_DEFINE);
                OnDrawDefine(rectWarning, propertyDefines, name, LogUtility.LOG_WARNING_DEFINE);
                OnDrawDefine(rectError, propertyDefines, name, LogUtility.LOG_ERROR_DEFINE);
                OnDrawDefine(rectException, propertyDefines, name, LogUtility.LOG_EXCEPTION_DEFINE);
            }
        }

        protected override float OnGetSettingsHeight(SerializedProperty propertyGroups)
        {
            float height = EditorGUIUtility.singleLineHeight;
            float space = EditorGUIUtility.standardVerticalSpacing;
            float heightDefines = height * 5F + space * 6F;

            return height * 2F + space * 3F + heightDefines + PADDING * 2F;
        }

        private void OnDrawDefine(Rect position, SerializedProperty serializedProperty, string name, string define)
        {
            PlatformInfo platform = PlatformEditorUtility.GetPlatform(name);

            float height = EditorGUIUtility.singleLineHeight;
            float space = EditorGUIUtility.standardVerticalSpacing;

            position.y += space;

            if (TryGetPropertyDefineElement(serializedProperty, define, out SerializedProperty propertyElement))
            {
                SerializedProperty propertyEnabled = propertyElement.FindPropertyRelative("m_enabled");
                SerializedProperty propertyValue = propertyElement.FindPropertyRelative("m_value");

                var rectDefine = new Rect(position.x, position.y, position.width - height + space, height);
                var rectFlag = new Rect(rectDefine.xMax + space, position.y, height, height);

                GUIContent defineLabel = m_styles.DefineLabels.TryGetValue(define, out GUIContent label)
                    ? label
                    : m_styles.UnknownDefineLabel;

                GUIContent flagContent = !string.IsNullOrEmpty(propertyValue.stringValue) && DefinesEditorUtility.HasDefine(propertyValue.stringValue, platform.BuildTargetGroup)
                    ? m_styles.FlagOnContent
                    : m_styles.FlagOffContent;

                Rect rectEnabled = EditorGUI.PrefixLabel(rectDefine, defineLabel);
                var rectValue = new Rect(rectEnabled.x + height + space, rectEnabled.y, rectEnabled.width - height - space, height);

                EditorGUI.PropertyField(rectEnabled, propertyEnabled, GUIContent.none);
                EditorGUI.LabelField(rectValue, propertyValue.stringValue);
                GUI.Label(rectFlag, flagContent, m_styles.FlagStyle);
            }
            else
            {
                GUIContent defineLabel = m_styles.DefineLabels.TryGetValue(define, out GUIContent label)
                    ? label
                    : m_styles.UnknownDefineLabel;

                EditorGUI.LabelField(position, defineLabel.text, $"Define not found: '{define}'");
            }
        }

        private static bool TryGetPropertyDefineElement(SerializedProperty serializedProperty, string define, out SerializedProperty propertyElement)
        {
            if (serializedProperty == null) throw new ArgumentNullException(nameof(serializedProperty));

            for (int i = 0; i < serializedProperty.arraySize; i++)
            {
                propertyElement = serializedProperty.GetArrayElementAtIndex(i);

                SerializedProperty propertyValue = propertyElement.FindPropertyRelative("m_value");

                if (propertyValue.stringValue == define)
                {
                    return true;
                }
            }

            propertyElement = null;
            return false;
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

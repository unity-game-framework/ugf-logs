using UGF.CustomSettings.Editor;

namespace UGF.Logs.Editor.Settings
{
    internal class LogEditorCustomSettings : CustomSettingsEditorPackage<LogEditorSettingsData>
    {
        public LogEditorCustomSettings() : base("UGF.Log", "LogEditorSettings", CustomSettingsEditorUtility.DefaultPackageExternalFolder)
        {
        }

        protected override void Save(LogEditorSettingsData data)
        {
            base.Save(data);

            var settings = new LogDefineSettings
            {
                Info = data.Info,
                Debug = data.Debug,
                Warning = data.Warning,
                Error = data.Error,
                Exception = data.Exception,
                NoEditor = data.NoInEditor,
                NoDevelopmentBuild = data.NoInDevelopmentBuild
            };

            LogEditorUtility.SetSettingsAll(settings);
        }

        protected override LogEditorSettingsData Load()
        {
            LogEditorSettingsData data = base.Load();
            LogDefineSettings settings = LogEditorUtility.GetSettings();

            data.Info = settings.Info;
            data.Debug = settings.Debug;
            data.Warning = settings.Warning;
            data.Error = settings.Error;
            data.Exception = settings.Exception;
            data.NoInEditor = settings.NoEditor;
            data.NoInDevelopmentBuild = settings.NoDevelopmentBuild;

            return data;
        }
    }
}

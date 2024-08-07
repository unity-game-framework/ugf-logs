# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [5.4.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.4.0) - 2024-08-06  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/24?closed=1)  
    

### Added

- Add log instance with label ([#72](https://github.com/unity-game-framework/ugf-logs/issues/72))  
    - Update dependencies: `com.ugf.editortools` to `2.18.0` version.
    - Update package _Unity_ version to `2023.2`.
    - Update package registry to _UPM Hub_.
    - Add `Log.CreateWithLabel()` method and overloads to create logger with label.
    - Add `LogLabeled` class to create logger with label.

## [5.3.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.3.0) - 2022-03-18  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/23?closed=1)  
    

### Added

- Add log with delegate ([#68](https://github.com/unity-game-framework/ugf-logs/issues/68))  
    - Add `Log.Info()`, `Debug()`, `Warning()` and `Error()` methods with message handler.

## [5.2.2](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.2.2) - 2021-11-27  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/22?closed=1)  
    

### Changed

- Update dependencies ([#67](https://github.com/unity-game-framework/ugf-logs/pull/67))  
    - Update dependencies: `com.ugf.editortools` to `2.1.0` version.

## [5.2.1](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.2.1) - 2021-11-27  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/21?closed=1)  
    

### Fixed

- Fix log.logger property accessor ([#65](https://github.com/unity-game-framework/ugf-logs/pull/65))  
    - Update package _Unity_ version to `2021.2`.
    - Add `Log.SetLogger()` and `ClearLogger()` methods to control current logger.
    - Deprecate `Log.Logger` setter, use `Log.SetLogger()` method instead.

## [5.2.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.2.0) - 2021-09-04  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/20?closed=1)  
    

### Added

- Add log instance implementation ([#63](https://github.com/unity-game-framework/ugf-logs/pull/63))  
    - Change dependencies: `com.ugf.defines` to `2.1.5` version.
    - Add `ILog` interface to implement custom loggers and extensions for each type of the log.
    - Add `LogHandled` class as default implementation of `ILog` which use specified `ILogHandler`.
    - Add `LogHandlerEntries` class as implementation of `ILogHandler` to report each log as `LogEntry` structure.
    - Add `LogHandlerUnity` default constructor with _Unity Logger_.
    - Add `LogScope` structure to control usage of `ILog` in specific scope.
    - Add `LogUtility.Format()` method to format collection of `LogEntry` elements.
    - Deprecate `Log.Handler` property, use `Logger` property instead to change logging behaviour.
    - Deprecate `LogHandlerScope` structure, use `LogScope` instead.

## [5.1.4](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.1.4) - 2021-05-25  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/19?closed=1)  
    

### Changed

- Change project settings root name ([#59](https://github.com/unity-game-framework/ugf-logs/pull/59))  
    - Update project to Unity of `2020.3` version.
    - Update package publish registry.
    - Update dependencies: `com.ugf.defines` to `2.1.4` version.
    - Change project settings root name to `Unity Game Framework`.

## [5.1.3](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.1.3) - 2021-01-24  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/18?closed=1)  
    

### Fixed

- Fix auto creation of settings file on editor initialization ([#55](https://github.com/unity-game-framework/ugf-logs/pull/55))  
    - Fix `LogEditorSettings` to check when settings file exists before change log handler enable state.
- Fix logs settings not display ([#54](https://github.com/unity-game-framework/ugf-logs/pull/54))  
    - Update dependencies with required fix: `com.ugf.defines` to `2.1.2` version.

## [5.1.2](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.1.2) - 2021-01-24  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/17?closed=1)  
    

### Changed

- Update defines package ([#50](https://github.com/unity-game-framework/ugf-logs/pull/50))  
    - Update dependencies: `com.ugf.defines` to `2.1.1` version.
    - Update required _Unity_ version to `2020.2.2f1`.

## [5.1.1](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.1.1) - 2021-01-16  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/16?closed=1)  
    

### Fixed

- Fix logs enable in editor do not have effect after editor restart ([#47](https://github.com/unity-game-framework/ugf-logs/pull/47))  
    - Fix log handler does not update enable state after editor restarted.

## [5.1.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.1.0) - 2021-01-15  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/15?closed=1)  
    

### Added

- Add unity logger custom tag write ([#44](https://github.com/unity-game-framework/ugf-logs/pull/44))  
    - Add logging with custom tag for `LogHandlerUnity` when tag unknown.

### Fixed

- Fix LogHandlerBase missing base method invocation ([#43](https://github.com/unity-game-framework/ugf-logs/pull/43))  
    - Fix `LogHandlerBase` missing `OnWrite()` method invocation.

## [5.0.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/5.0.0) - 2021-01-08  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/14?closed=1)  
    

### Removed

- Remove deprecated unity logger ([#39](https://github.com/unity-game-framework/ugf-logs/pull/39))  
    - Remove deprecated properties and methods from `Log` related to _Unity_ logger.
    - Remove `LogScope` disposable structure.

    Read about previous changes: #37

## [4.3.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/4.3.0) - 2021-01-08  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/13?closed=1)  
    

### Added

- Add log handler to replace Unity references ([#37](https://github.com/unity-game-framework/ugf-logs/pull/37))  
    - Add `ILogHandler` interface to implement any type of log handler.
    - Add `LogTags` with major log tags constants, such as `Info`, `Warning`, `Error` and etc.
    - Change `Log` methods to use `Handler` instead of `Logger` property.
    - Deprecate `Log.Logger` property and `Log.Message` methods with _Unity_ `LogType` parameter, use `Handler` and `Message` methods with `tag` argument instead.
    - Deprecate `LogScope` disposable structure. use `LogHandlerScope` instead.

## [4.2.1](https://github.com/unity-game-framework/ugf-logs/releases/tag/4.2.1) - 2021-01-05  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/12?closed=1)  
    

### Fixed

- Fix log arguments stripped with il2cpp builds ([#33](https://github.com/unity-game-framework/ugf-logs/pull/33))  
    - Fix `LogUtility.Format()` formatting arguments were stripped within _IL2CPP_ builds.

## [4.2.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/4.2.0) - 2021-01-05  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/11?closed=1)  
    

### Added

- Add logs formatting with attached exception ([#30](https://github.com/unity-game-framework/ugf-logs/pull/30))  
    - Add `LogUtility.Format()` method to format message with attached exception.
    - Add `Log` methods to log message with attached exception.

## [4.1.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/4.1.0) - 2020-12-03  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/10?closed=1)  
    

### Changed

- Update dependencies ([#27](https://github.com/unity-game-framework/ugf-logs/pull/27))

## [4.0.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/4.0.0) - 2020-11-10  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/9?closed=1)  
    

### Changed

- Update to Unity 2020.2 ([#23](https://github.com/unity-game-framework/ugf-logs/pull/23))  
    - Dependencies updated: `com.ugf.defines` to `2.0.0`.

### Removed

- Remove LogEditorSettings.Save method ([#24](https://github.com/unity-game-framework/ugf-logs/pull/24))  
    - Remove `LogEditorSettings.Save` method, use `LogEditorSettings.Settings.SaveSettings` instead.
    - Change `LogEditorSettingsData` class to be public.
    - Change `LogEditorSettings.Settings` property name to `LogEditorSettings.PlatformSettings`.
    - Change `CustomSettingsEditorPackage<LogEditorSettingsData>` instance to be public and accessible from `LogEditorSettings`.

## [3.0.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/3.0.0) - 2020-10-04  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/8?closed=1)  
    

### Changed

- Update and rework for Unity 2020.1 ([#18](https://github.com/unity-game-framework/ugf-logs/pull/18))  
    - Update project to `Unity 2020.1`.
    - Rework `Log` methods and overloads.
    - Rework project settings GUI and behavior.
    - Rework build pipeline and defines behavior.

## [2.0.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/2.0.0) - 2020-01-11  

- [Commits](https://github.com/unity-game-framework/ugf-logs/compare/1.2.0...2.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/7?closed=1)

### Added
- `LogFilterScope` to control filter log type of the current `Log.Logger`.

### Changed
- Package dependencies:
    - `com.ugf.customsettings`: from `1.0.0` to `2.0.0`.

## [1.2.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/1.2.0) - 2019-11-17  

- [Commits](https://github.com/unity-game-framework/ugf-logs/compare/1.1.0...1.2.0)
- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/6?closed=1)

### Added
- `LogStackTraceScope` to control type of the stacktrace logging inside the scope.

### Changed
- Update to Unity 2019.3.

## [1.1.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/1.1.0) - 2019-09-15  

- [Commits](https://github.com/unity-game-framework/ugf-logs/compare/1.0.0...1.1.0)
- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/5?closed=1)

### Added
- Package dependencies:
    - `com.ugf.customsettings`: from `1.0.0`.
- `Log Settings`: add options to use define settings in `Editor` and `Development Build`.

### Changed
- `Log Settings`: reworked to use `UGF.CustomSettings`.

## [1.0.0](https://github.com/unity-game-framework/ugf-logs/releases/tag/1.0.0) - 2019-08-20  

- [Commits](https://github.com/unity-game-framework/ugf-logs/compare/1.0.0-preview.2...1.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/4?closed=1)

### Changed
- `Log Project Settings`: reworked to support undo/redo and per platform selection.

### Removed
- `Apply and Revert GUI`: now settings applied immediately.

## [1.0.0-preview.2](https://github.com/unity-game-framework/ugf-logs/releases/tag/1.0.0-preview.2) - 2019-08-18  

- [Commits](https://github.com/unity-game-framework/ugf-logs/compare/1.0.0-preview.1...1.0.0-preview.2)
- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/3?closed=1)

### Added
- Package short description.
- Option to apply log settings to all known target build groups.

### Changed
- Update to Unity 2019.2.

## [1.0.0-preview.1](https://github.com/unity-game-framework/ugf-logs/releases/tag/1.0.0-preview.1) - 2019-07-22  

- [Commits](https://github.com/unity-game-framework/ugf-logs/compare/1.0.0-preview...1.0.0-preview.1)
- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/2?closed=1)

### Added
- `Log.Debug` method with `UGF_LOG_DEBUG` conditional symbol.

### Removed
- `Log.Info` and `Log.Message` overloads with tag argument.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-logs/releases/tag/1.0.0-preview) - 2019-07-15  

- [Commits](https://github.com/unity-game-framework/ugf-logs/compare/8eb984f...1.0.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-logs/milestone/1?closed=1)

### Added
- This is a initial release.



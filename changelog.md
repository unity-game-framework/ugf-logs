# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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



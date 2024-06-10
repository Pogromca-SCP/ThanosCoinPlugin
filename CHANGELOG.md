# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [3.1.0] - 2024-06-10

### Changed

- Upgraded project to [NwPluginAPI v13.1.2](https://github.com/northwood-studios/NwPluginAPI/releases/tag/13.1.2).
- Task object is now returned from async job.
- Plugin binds now have explicit access modifiers.

## [3.0.0] - 2023-09-16

### Changed

- Upgraded project to NwPluginAPI v13.1.1.

## [2.2.0] - 2023-07-29

### Fixed

- Async task is now initialized only when the player is supposed to die.

## [2.1.0] - 2023-05-09

### Fixed

- Config is no longer initialized twice.

## [2.0.0] - 2023-04-14

### Changed

- Updated project structure and dependencies handling.

## [1.2.1] - 2023-03-14

### Fixed

- Improved async function handling.
- Config is now removed when the plugin is unloaded.

## [1.2.0] - 2023-03-13

### Fixed

- Config should now properly reload when the plugin is loaded.

## [1.1.0] - 2023-02-27

### Added

- Plugin reload and unload handlers.
- Descriptions for config properties.

### Changed

- Players are now killed after coin toss animation.

## [1.0.0] - 2022-12-26

### Added

- Initial plugin version made with [NwPluginAPI v12.0.0](https://github.com/northwood-studios/NwPluginAPI/releases/tag/12.0.0).
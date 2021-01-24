# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0-preview.1](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.0.0-preview.1) - 2021-01-24  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/3?closed=1)  
    

### Changed

- Update application package ([#14](https://github.com/unity-game-framework/ugf-module-controllers/pull/14))  
    - Update dependencies: `com.ugf.application` to `8.0.0-preview.3` version.

## [2.0.0-preview](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.0.0-preview) - 2021-01-23  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/2?closed=1)  
    

### Added

- Add application events handler ([#11](https://github.com/unity-game-framework/ugf-module-controllers/pull/11))  
    - Add `ControllerModule` to implement of `IApplicationLauncherEventHandler` interface to handler application launcher events for all controllers.

### Changed

- Add controller without description ([#12](https://github.com/unity-game-framework/ugf-module-controllers/pull/12))  
    - Add `ControllerBase` class as default controller implementation without description.
    - Add `ControllerDescribed<TDescription>` class as default controller implementation with description.
    - Add `ControllerDescribedAsset`, `ControllerDescribedComponent` and `ControllerDescribedBuilder` classes as controller builders with description.
    - Change `ControllerAsset` to be default builder without description.
    - Change `ControllerBuilder<T>` to builder without description.
    - Change `ControllerComponent` to builder without description.
    - Remove `ControllerAsset<TController>` and `ControllerAsset<TController, TDescription>` classes.
- Rework provider with updated application ([#9](https://github.com/unity-game-framework/ugf-module-controllers/pull/9))  
    - Add dependencies: `com.ugf.application` of `8.0.0-preview.1` version.
    - Change `ControllerProvider` to work using provider system.
    - Remove `ControllerProvider` initialize methods.



# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0-preview.3](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.0.0-preview.3) - 2021-03-02  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/5?closed=1)  
    

### Removed

- Remove IControllerProvider interface ([#21](https://github.com/unity-game-framework/ugf-module-controllers/pull/21))  
    - Remove `IControllerProvider` and `ControllerProvider` classes and replace by `IProvider<string, IController>` interface.
- Remove IControllerDescribed interface ([#20](https://github.com/unity-game-framework/ugf-module-controllers/pull/20))  
    - Remove `IControllerDescribed` interface and update dependency classes.

## [2.0.0-preview.2](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.0.0-preview.2) - 2021-02-17  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/4?closed=1)  
    

### Changed

- Update to Unity 2021.1 and publish registry ([#17](https://github.com/unity-game-framework/ugf-module-controllers/pull/17))  
    - Update package publish registry.
    - Update dependencies: `com.ugf.application` to `8.0.0-preview.4` version.
    - Update project to Unity of `2021.1` version.

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

## [1.0.0](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/1.0.0) - 2021-01-15  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/1?closed=1)  
    

### Added

- Add controller builders ([#5](https://github.com/unity-game-framework/ugf-module-controllers/pull/5))  
    - Add `ControllerBuilder<TController>` and `ControllerBuilder<TController, TDescription>` builder classes.

### Changed

- Rework to store controllers using string ids ([#3](https://github.com/unity-game-framework/ugf-module-controllers/pull/3))  
    - Rework provider and module to work with `string` as controller _id_ instead of `GlobalId` structure.

## [0.1.0-preview](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/0.1.0-preview) - 2020-12-18  

### Release Notes

- No release notes.



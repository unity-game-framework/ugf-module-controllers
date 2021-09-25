# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0-preview.6](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.0.0-preview.6) - 2021-09-25  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/8?closed=1)  
    

### Added

- Add controllers async initialization ([#29](https://github.com/unity-game-framework/ugf-module-controllers/pull/29))  
    - Add `ControllerModule.InitializeCollection` property to manage initialization order.
    - Add `ControllerModule.Add()` and `ControllerModule.Remove()` methods to automatically add controller to provider and initialization collection.
    - Add `ControllerModuleDescription.UseReverseUninitializationOrder` property to determine uninitialization order.
    - Add `IControllerAsyncInitialize` interface to implement async initialization for controller.
- Add controller collection asset ([#28](https://github.com/unity-game-framework/ugf-module-controllers/pull/28))  
    - Change dependencies: `com.ugf.application` to `8.0.0-preview.9` version and `com.ugf.editortools` to `1.13.1` version.
    - Add `ControllerCollectionAsset` class as _ScriptableObject_ asset with list of controller builders.
    - Add `ControllerCollectionDescription` class to specify collection of controller for module description.
    - Add `ControllerModuleDescription.Collections` property to specify controller collections to create in module.

## [2.0.0-preview.5](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.0.0-preview.5) - 2021-08-22  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/7?closed=1)  
    

### Changed

- Change package.json meta guid ([#25](https://github.com/unity-game-framework/ugf-module-controllers/pull/25))  
    - Regenerate _Guid_ for `package.json` meta file.

## [2.0.0-preview.4](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.0.0-preview.4) - 2021-07-24  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/6?closed=1)  
    

### Added

- Add preview of selected controller in list ([#23](https://github.com/unity-game-framework/ugf-module-controllers/pull/23))  
    - Update dependencies: `com.ugf.application` to `8.0.0-preview.8` version.
    - Add nested inspector display of selected controller from list of controllers in module.

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



# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [4.0.0-preview.2](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/4.0.0-preview.2) - 2022-07-27  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/17?closed=1)  
    

### Added

- Add controller component collect priority ([#81](https://github.com/unity-game-framework/ugf-module-controllers/issues/81))  
    - Add `ControllerComponentCollectPriorityAttribute` attribute class used to mark controller components with sort priority for controller collection component.
    - Add `ControllerComponentCollectPriorityComparer` class as default implementation of comparing of two components with priority attribute.
    - Add `ControllerCollectionEditorUtility.SortByPriority()` method to sort specified collection by priority attributes.
    - Add `ControllerCollectionControllerComponent` inspector _Sort_ button used to sort collection of controllers.
    - Change `ControllerCollectionControllerComponent` inspector _Collect_ and _Collect in Scene_ buttons to additionally sort collected components.

### Fixed

- Fix controller collection collect in prefab mode ([#82](https://github.com/unity-game-framework/ugf-module-controllers/issues/82))  
    - Update dependencies: `com.ugf.application` to `8.3.1`, `com.ugf.runtimetools` to `2.10.0` and `com.ugf.editortools` to `2.8.4` versions.
    - Fix `ControllerCollectionEditorUtility.GetComponents()` methods to skip components without file id.

## [4.0.0-preview.1](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/4.0.0-preview.1) - 2022-07-14  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/16?closed=1)  
    

### Added

- Add tryget extensions with type only ([#75](https://github.com/unity-game-framework/ugf-module-controllers/issues/75))  
    - Add `ControllerInstanceController.TryGet()` extension methods used to get controller by the specified type.
    - Change `ControllerInstanceController.Get<T>()` method name to `GetController<T>()`.
    - Remove `ControllerCollectionController.TryGet()` methods, use `Controllers` property instead.

### Changed

- Change to reset replace when nothing is selected ([#76](https://github.com/unity-game-framework/ugf-module-controllers/issues/76))  
    - Change `ControllerCollectionAsset` class inspector replace to reset when _None_ is selected.

### Fixed

- Fix controllers async initialization queue ([#77](https://github.com/unity-game-framework/ugf-module-controllers/issues/77))  
    - Change `ControllerModule.Controllers` property be defined as _Provider_.
    - Change `ControllerModule` class initialization of initial controllers without ability to add new ones.
    - Remove `ControllerCollection.TryGet()` method support for nested controller collections. 
    - Remove `IControllerModule.Add()` and `Remove()` methods, use `Controllers` property instead.

## [4.0.0-preview](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/4.0.0-preview) - 2022-07-14  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/15?closed=1)  
    

### Changed

- Change string ids to data ([#73](https://github.com/unity-game-framework/ugf-module-controllers/issues/73))  
    - Update dependencies: `com.ugf.application` to `8.3.0` and `com.ugf.editortools` to `2.8.1` versions.
    - Update package _Unity_ version to `2022.1`.
    - Change usage of ids as `GlobalId` structure instead of `string`.

## [3.0.0-preview](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/3.0.0-preview) - 2022-07-10  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/14?closed=1)  
    

### Added

- Add controller collection store by file id ([#70](https://github.com/unity-game-framework/ugf-module-controllers/issues/70))  
    - Update dependencies: `com.ugf.editortools` to `2.6.0` version.
    - Add `ControllerCollectionController.TryGetByFileId()` method and overloads used to get controller by file id.
    - Add `ControllerCollectionController.TryGetByFileId()` method to get possible controllers collection by file id.
    - Add `ControllerCollectionControllerDescription.FileIds` property as collection of file id for each controller.
    - Add `ControllerInstanceController.TryGet()` method and overloads used to get controller by id.
    - Add `ContainerComponentController.TryGet()` method and overloads used to get controller by id.
    - Add `ControllerCollectionEditorUtility` class with methods used to collect controller collections as `ComponentReference<T>` structures.
    - Change `ControllerCollectionControllerComponent` class to store controllers using `ComponentReference<T>` structure.
- Add controller collection combine ([#69](https://github.com/unity-game-framework/ugf-module-controllers/issues/69))  
    - Add `ControllerCollectionControllerAsset.Combine` and `ControllerCollectionControllerComponent.Combine` properties as option to collect all nested controllers into single one.

## [2.2.1](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.2.1) - 2022-07-06  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/13?closed=1)  
    

### Added

- Add container controllers ([#66](https://github.com/unity-game-framework/ugf-module-controllers/issues/66))  
    - Update dependencies: `com.ugf.runtimetools` to `2.9.1` version.
    - Add `ContainerComponentController` abstract class to work with controller initialization from `ContainerComponent` class.
    - Add `ContainerGameObjectController`, `ContainerPrefabController` and `ContainerSceneController` classes as implementation of `ContainerComponentController` controller.
    - Add `ControllerInstanceController.TryGet()` and `Get()` methods with `Type` as argument.
    - Change `ControllerCollection` class to support update `Provider<T, T>` class.
- Add controller replacement collection ([#61](https://github.com/unity-game-framework/ugf-module-controllers/issues/61))  
    - Add `ControllerCollectionAsset` inspector mode to edit replacement for each controller in the list.
- Add controller collection component ([#59](https://github.com/unity-game-framework/ugf-module-controllers/issues/59))  
    - Add `ControllerComponentExtensions.GetController()` methods to get controller related to `ControllerComponent` object.
    - Add `ControllerCollection` class as provider of controllers with ability to initialize each controller in collection.
    - Add `ControllerCollectionController` class as controller that create and initialize collection of other controllers.
    - Add `ControllerCollectionControllerAsset` and `ControllerCollectionControllerComponent` classes as builders of `ControllerCollectionController` class for assets and gameobjects.
    - Add `ControllerCollectionUtility` class with methods to work with controller component collections.
- Add controller instance controller ([#40](https://github.com/unity-game-framework/ugf-module-controllers/issues/40))  
    - Add `ControllerInstanceController` class to control instantiating of the controller.

### Changed

- Change ControllerAsync.InitializeAsync as optional ([#62](https://github.com/unity-game-framework/ugf-module-controllers/issues/62))  
    - Update dependencies: `com.ugf.application` to `8.2.0` version.
    - Add `IControllerAsyncInitialize.IsInitializedAsync` property to get value that determines whether async initialization has been done.
    - Change `ControllerAsync` and `ControllerDescribedAsync` classes to make async initialization optional.

## [2.2.0](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.2.0) - 2022-07-06  

### Release Notes

- No release notes.

## [2.1.1](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.1.1) - 2022-01-12  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/12?closed=1)  
    

### Fixed

- Fix RelativeController get relatives ([#53](https://github.com/unity-game-framework/ugf-module-controllers/issues/53))  
    - Fix `RelativeController` class to use specified target to get relative object.

## [2.1.0](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.1.0) - 2022-01-12  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/11?closed=1)  
    

### Added

- Add relative controller ([#51](https://github.com/unity-game-framework/ugf-module-controllers/issues/51))  
    - Add `RelativeController` and `RelativeController<T>` classes to get access to the relative object of the specified type.
- Add controller instance component relatives collection ([#47](https://github.com/unity-game-framework/ugf-module-controllers/issues/47))  
    - Add `ControllerInstanceComponent.Relatives` property as collection of any object to register relatives for created controller.
- Add ControllerInstanceComponent build singleton property ([#46](https://github.com/unity-game-framework/ugf-module-controllers/issues/46))  
    - Add `ControllerInstanceComponent.BuildAsSingleton` property to determine whether to register created controller by specified id or generate new unique id.
    - Deprecate `ControllerInstanceComponent.BuildUnique` property, use `BuildAsSingleton` property instead.

## [2.0.0](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.0.0) - 2021-11-26  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/10?closed=1)  
    

### Added

- Add ControllerInstanceComponent ([#41](https://github.com/unity-game-framework/ugf-module-controllers/pull/41))  
    - Add `ControllerInstanceComponent` abstract component class used to create instance of the specified controller.
- Add ControllerAsync and ControllerDescribedAsync ([#39](https://github.com/unity-game-framework/ugf-module-controllers/pull/39))  
    - Add `ControllerAsync` and `ControllerDescribedAsync<T>` abstract classes which implements `IControllerAsyncInitialize` interface and supports async initialization.
- Add Application.GetController extension methods ([#38](https://github.com/unity-game-framework/ugf-module-controllers/pull/38))  
    - Add `IApplication.AddController()` and `RemoveController()` extension methods to add and remove controller from existed `IControllerModule` in application.
    - Add `IApplication.GetController()` methods and overloads to get controller by the specified id or controller type.
- Add ObjectRelativesProviderController ([#37](https://github.com/unity-game-framework/ugf-module-controllers/pull/37))  
    - Update package Unity version to `2021.2`.
    - Update dependencies: `com.ugf.application` to `8.0.0` version.
    - Add `ObjectRelativesController<T>` class as controller to store `ObjectRelativesProvider<T>` provider.

### Changed

- Change ControllerInstanceComponent ([#44](https://github.com/unity-game-framework/ugf-module-controllers/pull/44))  
    - Add `ControllerInstanceProviderController` class as controller which stores controller builders for later instance creation.
    - Change `ControllerInstanceComponent` to be non-abstract class and uses `ControllerInstanceProviderController` provider controller to create controller instances.

### Removed

- Remove ControllerCollectionDescription ([#45](https://github.com/unity-game-framework/ugf-module-controllers/pull/45))  
    - Update `ControllerModuleDescription` class to store only collection of builders.
    - Remove `IControllerCollectionDescription` interface and related classes.

## [2.0.0-preview.7](https://github.com/unity-game-framework/ugf-module-controllers/releases/tag/2.0.0-preview.7) - 2021-09-25  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-controllers/milestone/9?closed=1)  
    

### Fixed

- Fix controller module description creation error ([#31](https://github.com/unity-game-framework/ugf-module-controllers/pull/31))  
    - Fix `ControllerModuleAsset` building description error while iterate through collections.

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



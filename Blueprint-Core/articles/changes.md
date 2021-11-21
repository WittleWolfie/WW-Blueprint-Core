# Changelog

## v1.0.0 Release

This release marks completion of the core functionality. There are a lot of breaking changes.

* Core functionality is **complete**:
    * All blueprint types (BlueprintScriptableObject) has its own configurator
    * All Blueprint Components have constructor methods in the supported configurators
    * All Actions have builder methods
    * All Conditions have builder methods
* Other new APIs:
    * Generic Add w/ init for BlueprintComponent, Action, and Condition
    * Blueprint configurators have an EditComponent method
    * Enumerable blueprint field methods include Set in addition to AddTo and RemoveFrom.
* Generated code field types use primitive names when appropriate
* Fixed ConditionsBuilderStoryEx namespace (previously was MiscEx, now is correctly StoryEx)
* Added validation check for duplicate AbilityRankType definitions in ContextRankConfig
* Generated code makes a best effort attempt to define optional parameters and provide safe default values for types which should not be null

### Breaking Changes

A lot of codeode was moved around for consistency and a new DLL reference is required.

* BlueprintTool moved from BlueprintCore.Blueprints to BlueprintCore.Utils
* All BlueprintConfigurators were moved from BlueprintCore.Blueprints to BlueprintCore.Configurators
* Blueprint components are now only exposed in supported configurators
    * i.e. If you don't see a component method in a configurator it means that component is not expected to work with that blueprint type. There's no guarantee since this is based on Owlcat's validation with additional checks added manually to correct issues as they are found.
* New assembly references are required:
    * Owlcat.Runtime.Visual.dll
    * Owlcat.Runtime.UI.dll
* Auto-generated methods provide default values for primitives, nullable types, and specific game types
* ContextRankConfigs API reworked
    * CommonExtensions are now optional parameters on the core functions
    * Adopted the names of the progression types
    * Added param comments for blueprint types

## v0.6.0 Release

* Completed ConditionsBuilder API using auto-generated methods
* Moved SwitchDualCompanion from StoryEx to BasicEx to mirror ContextActionSwitchDualCompanion

## v0.5.0 Release

* Completed ActionsBuilder API using auto-generated methods

## v0.4.1 Release

* New CustomProgression method for ContextRankConfig accepts anonymous tuples for progression entries
    * Current CustomProgression method marked obsolete before removal.
* New LinearProgression method for ContextRankConfig
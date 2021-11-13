# Changelog

## v0.7.0 Release

* Added generic Add functions w/ init for BlueprintComponent, Action, and Condition
* Updated generated code field declarations to use primitive type names
* Fixed ConditionsBuilderStoryEx namespace (previously was MiscEx, now is correctly StoryEx)

### Code Moves

Some code was moved around for consistency.

* BlueprintTool moved from BlueprintCore.Blueprints to BlueprintCore.Utils
* All BlueprintConfigurators were moved from BlueprintCore.Blueprints to BlueprintCore.Configurators

## v0.6.0 Release

* Completed ConditionsBuilder API using auto-generated methods
* Moved SwitchDualCompanion from StoryEx to BasicEx to mirror ContextActionSwitchDualCompanion

## v0.5.0 Release

* Completed ActionsBuilder API using auto-generated methods

## v0.4.1 Release

* New CustomProgression method for ContextRankConfig accepts anonymous tuples for progression entries
    * Current CustomProgression method marked obsolete before removal.
* New LinearProgression method for ContextRankConfig
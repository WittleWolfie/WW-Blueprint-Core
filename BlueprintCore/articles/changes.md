# Changelog

## v2.1.0 Release

* Added new localization system for translation support and simplified text references. See [Text, Logging, and Utils](usage/utils.md) for more details.
* Added static references to in-game blueprints. See [Referencing Blueprints](usage/blueprints.md#referencing-blueprints) for more details.
* Configurators now automatically set safe default values for types which cannot be null
* Methods with a single enumerable or flag parameter use `params` syntax
* Removed configurators for QA related blueprints
* BlueprintUnitProperty logs a warning if `BaseValue` is 0 when using multiplication
* Add more constructors for ContextDurationValue
* Removed Modify field methods for primitive and enum types
    * If you have a use case let me know but this API was not intended to exist
* Specific Type Changes
    * FeatureConfigurator
        * Automatically adds features to the appropriate `BlueprintFeatureSelection`. See [FeatureConfigurator.New()](xref:BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator.New(System.String,System.String,FeatureGroup[])).
        * Automatically sets `IsClassFeature` to true for features with `FeatureGroup.Feat`
    * ProgressionConfigurator
        * Added many convenience method overrides for ease of working with ClassWithLevel, LevelEntry, and ArchetypeWithLevel
        * Removed support for AlternateProgressionType which can only be Div2
        * Automatically sets `ForAllOtherClasses` to `false` when setting or adding to `m_AlternateProgressionClasses`
    * BuffEnchantAnyWeapon is now available in BaseUnitFactConfigurator and all inherited types
    * AddStatBonusIfHasFact replaced by AddStatbonusIfHasFactFixed

### Breaking Changes

* ProgressionConfigurator changed namespace
    * It is now hand tuned so it lives in CustomConfigurators
* Some ContextAction methods were updated with a stricter API
    * `ArmorEnchantPool` and `ShieldArmorEnchantPool` uses `BlueprintArmorEnchantReference` instead of `BlueprintItemEnchantmentReference`
    * `WeaponEnchantPool` and `ShieldWeaponEnchantPool` uses `BlueprintWeaponEnchantmentReference` instead of `BlueprintItemEnchantmentReference`
    * If you were passing in a BlueprintItemEnchantmentReference directly you'll need to update your calls
* `Buffs`, `ItemEnchantments`, and `Features` were removed
    * Replaced by Refs classes. See [Referencing Blueprints](usage/blueprints.md#referencing-blueprints).
* QA Blueprint configurators were removed
    * I don't expect anyone to use these, but if you have a use case let me know.
* Configurators no longer exposes methods for cache fields
    * These are set at runtime by the blueprint, they should not be set manually.
* Methods with a single enumerable parameter use `params` syntax
    * If they currently require a list they must be updated. You can call `ToArray()` on the list.
* AddStatBonusIfHasFact is no longer supported
    * Use AddStatBonusIfHasFactFixed
* Methods for BlueprintProgression.AlternateProgressionType are removed
    * It is always Div2, there is no other value

## v2.0.4 Release

* Fixed an NPE resulting from not specifying optional List or Array parameters

### Breaking Changes

* Fixed a bug incorrectly identifying unique and non-unique components
    * This removes merge handling parameters from non-unique components; you'll need to remove any you have specified

## v2.0.3 Release

### Breaking Changes

* The type `Blueprint<T,  TRef>` has been shortened to `Blueprint<TRef>`
    * You can use a Regex find/replace to fix. In VS:
        * Find: `Blueprint<\w*, `
        * Replace With: `Blueprint<`

## v2.0.2 Release

* Update to 1.3.4e game patch
* Handles GUIDs with uppercase letters
* Type specific handling updates
* New util for creating `UnitConditionExceptions`
* Blueprint field setters use `params` for enumerable types
* Fixed bug with Encyclopedia tagging causing exceptions
* Fixed default merge behavior which was incorrectly set to ComponentMerge.Merge instead of ComponentMerge.Fail

### Breaking Changes

* Namespaces are changes to organize type specific util classes
    * `ContextRankConfigs`
    * `ContextDuration`
    * `ContextValues`
* Blueprint field setters use `params` for enumerable types
    * This breaks for `List<>` fields
* Removed support for `AddStatBonusScaled`
    * This is a legacy type and can be replaced with `AddContextStatBonus`

## v2.0.1 Release

* Reverts `Configurator.Build()` to return the blueprint directly

## v2.0.0 Release

* This is a significant release which is all but guaranteed to require changes to your code when updating.*

### Features

* Flexible Blueprint references
    * BlueprintCore APIs accept blueprints by Guid, Blueprint instance, Blueprint reference, or Name for newly created
      blueprints
* Improved Validation
    * Validator is now up to date with the latest changes in the game validation code
* Removed unused game types from Builder and Configurator APIs
* Improved documentation of games types
    * Examples: Every ActionsBuilder, ConditionsBuilder, and Configurator component method lists up to 3 game blueprints
      which use the implemented type
    * Developer Comments: Taken from attributes in the game code which Owlcat uses to create tooltips and help text in
      their level editor
    * Comments are integrated with the doc comments shown in your IDE
        * In VS you can navigate to the definition of BlueprintCore methods to see the full formatted comments for readability

### Breaking Changes

* Configurator namespaces may have changed to align w/ game code structure
* Method and parameter names changed for ActionsBuilder, ConditionsBuilder, and Configurators
* Validator is no longer static
* Builder and Configurator methods no longer exist for unused game types

### More Details

Two concepts drove the creation of BlueprintCore 2.0:

1. Make it easier to improve and contribute to BlueprintCore, especially with regards to handling of game types
2. Adopt a philosophy of keeping the library as close to the game code as possible

With regards to #1 I will update the contributor docs after release with guidance and examples of how to contribute. In
short, you can provide remarks and instructions on handling game types by editing JSON configuration files. Alternatively,
just share your knowledge in issues on GitHub and I'll do my best to update the library.

For #2 there was a major shift in how the library generates ActionsBuilder, ConditionsBuilder, and Configurator classes.
Previously methods were automatically generated _or_ written by hand entirely. When creating methods by hand I was aggressive
about renaming things to clarify the actual game function.

However, this makes it very hard to do structural improvements since all hand written code requires manual updates.
Additionally a lot of the hand written code was nearly identical to generated code and only existed to rename things.
With this release almost nothing is written by hand. Instead JSON config files allow selective editing of the code
generation behavior.

The end result is both functional and philosophical: method and parameter names map almost 1:1 with the associated type
or field. This makes it easier to take existing knowledge of game code and use it to write BlueprintCore code, as well
as taking BlueprintCore code and find the game code it affects.

### What's Next?

With the major refactoring done I'll resume work on functional library improvements. Please file requests and suggestions
on GitHub, I do read them and try my best to support them. For 2.1 I'm looking into:

* Expanded Tutorial
    * Examples of doing more extensive changes
    * Improved setup instructions and examples of using different BlueprintCore classes and utilities
* Localization improvements
    * Improve API with regards to whether a given string is parsed for tokens
    * Add localization support
    * Reduce boilerplate needed to create and reference LocalizedStrings
* Smarter Configurators for common blueprint types, e.g. CharacterClass, Feature, Ability
    * Create blueprints using existing blueprints as a template, e.g. WizardClass template applies things like 1/2 BAB
      and Saving Throw progressions
    * Combination and creation methods that enforce contracts
    * Automatically add blueprints to appropriate selection groups
* Static Blueprint References for common types
    * Expose an auto-complete list for things like Classes, Archetypes, Feats, and Spells
* Project Setup Tool (Tentative)
    * An automated tool to create a new mod project with BlueprintCore setup
* TTT-Core Support (Tentative)
    * I'd like to provide support for integration w/ TTT-Core without requiring it
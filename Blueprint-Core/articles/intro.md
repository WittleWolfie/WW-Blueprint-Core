# Getting Started

1. Set up your project. If you haven't written mods for any Pathfinder game, start with the [Beginner Guide](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Beginner-Guide) on the [OwlcatModdingWiki](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki).
2. Create a [public assembly](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Publicise-Assemblies).
3. Install [WW-Blueprint-Core](https://www.nuget.org/packages/WW-Blueprint-Core/) using [NuGet](https://docs.microsoft.com/en-us/nuget/what-is-nuget).
    * The package contains a folder named `BlueprintCore` that contains the library source code which is included directly in your project.
4. Make sure your project is configured for .NET 4.7.2 and the latest C# language version.
    * In your .csproj file you should have the following properties:
```xml
<PropertyGroup>
  <LangVersion>latest</LangVersion>
  <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>
</PropertyGroup>
```
5. Add the necessary assembly references from the game install directory:
    * `<WrathInstallDir>/Wrath_Data/Managed/Owlcat.Runtime.Visual.dll`
    * `<WrathInstallDir>/Wrath_Data/Managed/Owlcat.Runtime.UI.dll`
6. You're ready to go!

If you're interested in contributing see [How to Contribute](contributing.md).

## Blueprint Configurators

All blueprint types inheriting from BlueprintScriptableObject have a corresponding configurator. e.g. [BuffConfigurator](xref:BlueprintCore.Blueprints.Configurators.Buffs.BuffConfigurator) is the configurator for `BlueprintBuff`.

If you write a custom blueprint or use one from a mod you can use [BlueprintConfigurator](xref:BlueprintCore.Blueprints.Configurators.BlueprintConfigurator`1). This won't expose fields and supported components for the type but allows use of the basic configurator API and validation with any blueprint type:

To use a configurator:

1. Instantiate a configurator using `For()` or `New()`
    * `For()` creates a configurator for an existing blueprint
    * `New()` creates and registers a new blueprint
2. Modify the blueprint using the configurator methods
3. Commit the configuration with [Configure()](xref:BlueprintCore.Blueprints.Configurators.BaseBlueprintConfigurator`2.Configure)
    * Until this is called, no changes are made to the blueprint
    * After commit the blueprint is validated and any errors are logged as a warning

```C#
BuffConfigurator.New(MyBuffName, MyBuffGuid).AddStatBonus(stat: StatType.Strength, value: 2).Configure();
```
This code will create a new `BlueprintBuff` using the provided name and GUID. When the buff is applied to a unit it
grants +2 to Strength because of the `AddStatBonus` component.

### Common Methods

* [AddComponent](xref:BlueprintCore.Blueprints.Configurators.BaseBlueprintConfigurator`2.AddComponent(Kingmaker.Blueprints.BlueprintComponent))
    * Adds a `BlueprintComponent` of any type
    * Used internally by all configurator methods that add a new component
    * Use this for custom components in your modification
    * All component types in the base game are supported by type specific methods. e.g. `AddStatBonus`
* [AddUniqueComponent](xref:BlueprintCore.Blueprints.Configurators.BaseBlueprintConfigurator`2.AddUniqueComponent(Kingmaker.Blueprints.BlueprintComponent,BlueprintCore.Blueprints.Configurators.BaseBlueprintConfigurator{`0,`1}.ComponentMerge,System.Action{Kingmaker.Blueprints.BlueprintComponent,Kingmaker.Blueprints.BlueprintComponent}))
    * Similar to `AddComponent`, but for components for which only one can exist in a blueprint
    * Supports user defined conflict resolution if multiple components are present. See [ComponentMerge](xref:BlueprintCore.Blueprints.Configurators.BaseBlueprintConfigurator`2.ComponentMerge).
* [RemoveComponents](xref:BlueprintCore.Blueprints.Configurators.BaseBlueprintConfigurator`2.RemoveComponents(System.Func{Kingmaker.Blueprints.BlueprintComponent,System.Boolean}))
    * Removes any components matching the supplied `Func<BlueprintComponent, bool>`
* [EditComponent](xref:BlueprintCore.Blueprints.Configurators.BaseBlueprintConfigurator`2.EditComponent``1(System.Action{``0}))
    * After configuring components, runs the provided `Action` on the first component matching the specified type
* [OnConfigure](xref:BlueprintCore.Blueprints.Configurators.BaseBlueprintConfigurator`2.OnConfigure(System.Action{`0}[]))
    * Executes an `Action` on the blueprint as the last step in configuration

### Modifying Fields

Each configurator exposes methods to set and modify fields. The comment summary for these methods links to the field they modify.

Simple fields such as booleans and integers are usually controlled by methods of the form `SetX()` while more complex or correlated fields have methods enforcing implicit contracts. For example, fields representing flags are often modified using `AddX()` and `RemoveY()` methods.

All blueprint fields should be exposed in their configurator. Some fields are not exposed because they are unused or unnecessary.

### Adding Components

Each `BlueprintComponent` type exposes methods to create and add them to the blueprint. The comment summary for these methods links to the type of component they create, or in some cases modify.

Within the game library you can add any component to any blueprint since they are all stored in a `BlueprintComponent` array. In reality, each component has restrictions on how it is used such as which type of blueprint and whether there can be more than one copy in a blueprint. See the [Blueprints](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints) article on the wiki for more details.

The configurator API enforce these requirements through two mechanisms:

1. Configurators expose methods for components that are flagged as compatible
2. Validation identifies and logs an error if an invalid component is present

This ensures you can see conflicts or problems in existing blueprints as well as your own. However, just because a component is exposed on a configurator does not guarantee it will work. The existing component annotations are not always correct or complete and manual review of the 1000+ components is not feasible. If you detect any conflicts please report it so the API can be updated.

### Quick Example: Fast Healing

The following snippet creates a new `BlueprintBuff` that grants fast healing 1 until combat ends.

```C#
BuffConfigurator.New(Name, Guid)
    .SetDisplayName(DisplayName)
    .SetDescription(Description)
    .SetIcon(Icon)
    .FastHealing(1)
    .RemoveWhenCombatEnds()
    .Configure();
```

## ActionsBuilder and ConditionsBuilder

Actions and conditions in the game are always used in the form of `ActionList` and `ConditionsChecker`. [ActionsBuilder](xref:BlueprintCore.Actions.Builder.ActionsBuilder) and [ConditionsBuilder](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder) provide builder APIs for constructing them.

Basic usage both builders is the same:

1. Instantiate a builder using `New()`
2. Add actions/conditions using builder methods
    * `ConditionsBuilder` has a special method, [UseOr()](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder.UseOr) which results in a `ConditionsChecker` that will pass if any one condition passes. By default all conditions must pass.
3. Build the list with `Build()`
    * When an `ActionList` or `ConditionsChecker` is needed in a library method you do not need to call `Build()`. Instead the builder is passed into the method directly and `Build()` is called by the library.
    * Calling build logs validation errors as a warning.

Builder methods declare the game type they implement in their comment summary.

### Extensions

To limit the number of actions and conditions available when using [ActionsBuilder](xref:BlueprintCore.Actions.Builder.ActionsBuilder) and [ConditionsBuilder](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder), specific types are implemented in extension methods.

Extension methods are logically grouped so most of the time you can include a single extension namespace. The extension groups are the same for both builders:

* AreaEx
    * Extensions involving the game map, dungeons, or locations
    * Types specifically related to the Kingdom and Crusade system are in KingdomEx
* AVEx
    * Extensions involving audiovisual effects such as dialogs, camera, cutscenes, and sounds
    * `ActionsBuilder` only
* BasicEx
    * Extensions for most game mechanics not included in ContextEx
* ContextEx
    * Extensions for `ContextAction` and `ContextCondition` types
    * Some types are implemented in more specific extensions such as KingdomEx
* KingdomEx
    * Extensions for the Kingom and Crusade systems
* MiscEx
    * Extensions that are not game mechanics related and don't fit into other categories
    * Examples include things like achievement related actions
* NewEx
    * Extensions for types provided by BlueprintCore
* StoryEx
    * Extensions related to the story such as companion stories, quests, and etudes
* UpgraderEx
    * Extensions for all `UpgraderOnlyActions` types
    * `ActionsBuilder` only

### Quick Example: Melee Attack

The following snippet creates a new `ActionList` that initiates a melee attack if the target is in melee range.

```
// Extension for MeleeAttack() which is a ContextAction
using BlueprintCore.Actions.Builder.ContextEx;
// Extension for TargetInMeleeRange() which is a new condition in the library
using BlueprintCore.Conditions.Builder.NewEx;

ActionsBuilder.New()
    .Conditional(
        ConditionsBuilder.New().TargetInMeleeRange(),
        ifTrue: ActionsBuilder.New().MeleeAttack())
    .Build();
```

## Referencing Blueprints

When a blueprint reference is required the API accepts a `string` argument. The argument can be the guid for the blueprint or it can be the name of the blueprint if you have registered a name to guid mapping using [BlueprintTool#AddGuidsByName()](xref:BlueprintCore.Utils.BlueprintTool.AddGuidsByName(System.Collections.Generic.Dictionary{System.String,System.String})). Blueprints created using [BlueprintTool#Create(string, string)](xref:BlueprintCore.Utils.BlueprintTool.Create``1(System.String,System.String)) automatically register the name to guid mapping.

The parameter comment declares the type of blueprint reference expected.

## Generated Methods

The majority of the API is implemented using generated code. These methods are identified by the [GeneratedAttribute](BlueprintCore.Utils.GeneratedAttribute).

Generated methods have a parameter for every field in the object, essentially acting as a constructor. To minimize boilerplate generated methods declare most parameters as optional.

This is not an indication of how the object should be used. Optional parameters in a generated method may be required for the object to function. In contrast, non-generated methods expose strict APIs that only declare parameters optional when they are not needed.

If you identify methods in need of manual implementations please report them. This should be reserved for complex objects with a large number of fields or complex requirements for its fields.

## Logging and Utils

### Tools

Tool classes provide simple utility functions, usually related to a specific type. See each class for more details, but some notable uses:

* [BlueprintTool](xref:BlueprintCore.Utils.BlueprintTool)
    * Use this to create, fetch, and provide a name to guid mapping for blueprints
* [ElementTool](xref:BlueprintCore.Utils.ElementTool)
    * Use this to create or initialize types inheriting from `Element`
* [PrereqTool](xref:BlueprintCore.Utils.PrereqTool)
    * Use this to create types inheriting from `Prerequisite`

### Type Constructors

Utility classes are provided to simplify creating game objects.

* [ContextDuration](xref:BlueprintCore.Utils.ContextDuration)
    * Utility for creating `ContextDurationValue`
* [ContextValues](xref:BlueprintCore.Utils.ContextValues)
    * Utility for creating `ContextValue`
* [ContextRankConfigs](xref:BlueprintCore.Blueprints.Components.ContextRankConfigs)
    * Utility for creating `ContextRankConfig`
    
### Logging

[LogWrapper](xref:BlueprintCore.Utils.LogWrapper) wraps the game's `LogChannel` class to provide control over verbose log output. It is used internally for logging within BlueprintCore and is available for use within your modification, but not required.

### Validator

[Validator](xref:BlueprintCore.Utils.Validator) is used by the library to validate method inputs, actions, conditions, blueprint components, and blueprints. Any game objects you create outside of the library can be validated using [Validator#Check()](xref:BlueprintCore.Utils.Validator.Check(System.Object)).
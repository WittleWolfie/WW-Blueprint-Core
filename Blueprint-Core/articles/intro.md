# Getting Started

1. Set up your project. If you haven't written mods for any Pathfinder game, start with the [Beginner Guide](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Beginner-Guide) on the [OwlcatModdingWiki](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki).
2. Create a [public assembly](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Publicise-Assemblies).
3. Install [WW-Blueprint-Core](https://www.nuget.org/packages/WW-Blueprint-Core/) using [NuGet](https://docs.microsoft.com/en-us/nuget/what-is-nuget).
    * The package contains a folder named `BlueprintCore` that contains the library source code which is included directly in your project.
4. You're ready to go!

## Blueprint Configurators

Every supported concrete blueprint type has a corresponding configurator. e.g. [BuffConfigurator](xref:BlueprintCore.Blueprints.Buffs.BuffConfigurator) is the configurator for `BlueprintBuff`.

Basic usage of all configurators is the same:

1. Instantiate a configurator using `For()` or `Create()`
    * `For()` creates a configurator for an existing blueprint
    * `Create()` creates and registers a new blueprint
2. Modify the blueprint using the configurator methods
3. Commit the configuration with [Configure()](xref:BlueprintCore.Blueprints.BlueprintConfigurator`2.Configure)
    * Until this is called, no changes are made to the blueprint
    * After commit the blueprint is validated and any errors are logged as warnings

### Common Methods

* [AddComponent](xref:BlueprintCore.Blueprints.BlueprintConfigurator`2.AddComponent(Kingmaker.Blueprints.BlueprintComponent))
    * Used internally by all configurator methods that add a new component.
    * Adds a `BlueprintComponent` of any type. Prefer using configurator methods whenever possible.
    * Eventually the configurators will support all in-game components, at which point this should only be used for components implemented in your project.
* [AddUniqueComponent](xref:BlueprintCore.Blueprints.BlueprintConfigurator`2.AddUniqueComponent(Kingmaker.Blueprints.BlueprintComponent,BlueprintCore.Blueprints.BlueprintConfigurator{`0,`1}.ComponentMerge,System.Action{Kingmaker.Blueprints.BlueprintComponent,Kingmaker.Blueprints.BlueprintComponent}))
    * Similar to `AddComponent`, but for components for which only one can exist in a blueprint.
    * Supports user defined conflict resolution if multiple components are present. See [ComponentMerge](xref:BlueprintCore.Blueprints.BlueprintConfigurator`2.ComponentMerge).
* [RemoveComponents](xref:BlueprintCore.Blueprints.BlueprintConfigurator`2.RemoveComponents(System.Func{Kingmaker.Blueprints.BlueprintComponent,System.Boolean}))
    * Removes any components matching the supplied `Func<BlueprintComponent, bool>`.
* [OnConfigure](xref:BlueprintCore.Blueprints.BlueprintConfigurator`2.OnConfigure(System.Action{`0}[]))
    * Executes an `Action` on the blueprint as the last step in configuration.

### Modifying Fields

Each configurator exposes methods to set and modify fields. The comment summary for these methods links to the field they modify.

Simple fields such as booleans and integers are usually controlled by methods of the form `SetX()` while more complex or correlated fields have methods enforcing implicit contracts. For example, fields representing flags are often modified using `AddX()` and `RemoveY()` methods.

When a new configurator is added all fields should be exposed. If support for a field is missing either:

1. The game code has been altered by a patch or modification
2. The field is never actually used in-game

### Adding Components

Each `BlueprintComponent` type exposes methods to create and add them to the blueprint. The comment summary for these methods links to the type of component they create, or in some cases modify.

Within the game library you can add any component to any blueprint since they are all stored in a `BlueprintComponent` array. In reality, each component has restrictions on how it is used such as which type of blueprint and whether there can be more than one copy in a blueprint. See the [Blueprints](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints) article on the wiki for more details.

The configurator API attempts to enforce these requirements through two mechanisms:

1. Each component type is added to a blueprint through its own method(s) only exposed by supported blueprint types.
2. Validation identifies and logs an error if any invalid component is present.

Validation is required because the problem may already exist in the blueprint and because the configurator API uses an inheritance structure that mirrors the inheritance of blueprint types. Unfortunately, the component restrictions cannot be implemented with this type of inheritance. In other words: the configurator limits available components for a given blueprint type to the best of its ability but cannot guarantee that all exposed methods work.

### Example: Simple AC Buff

The following snippet creates a new `BlueprintBuff` that grants fast healing 1 until combat ends.

```C#
BuffConfigurator.Create(Name, Guid)
    .SetDisplayName(DisplayName)
    .SetDescription(Description)
    .SetIcon(Icon)
    .FastHealing(1)
    .RemoveWhenCombatEnds()
    .Configure();
```

## ActionsBuilder and ConditionsBuilder

## Referencing Blueprints

## Logging and Utils

# WW-Blueprint-Core

[![NuGet](https://img.shields.io/nuget/v/WW-Blueprint-Core?style=flat-square)](https://www.nuget.org/packages/WW-Blueprint-Core)

**What is BlueprintCore**: A library to simplify modifying Pathfinder: Wrath of the Righteous.

At a glance:

* Builder-style API for creating and modifying Blueprints, Actions, and Conditions
```C#
BuffConfigurator.New(MyBuffName, MyBuffGuid)
  .AddContextStatBonus(StatType.Strength, ContextValues.Constant(2))
  .Configure();
```
* Constructor methods for  Blueprint, Action, Condition, and BlueprintComponent types
    * Lists example blueprints
    * Usage comments from modders and game assembly
    * Guards against null fields
    * API enforces required fields and implicit requirements when possible
        * Implemented with help from modders like you, see [How to Contribute](https://wittlewolfie.github.io/WW-Blueprint-Core/articles/contributing.html).
* Blueprint API limiting BlueprintComponents to usable types
* Runtime validation of blueprints
    * Using game validation and custom logic to validate implicit constraints
* Utility classes
    * Create common types
    * Localization, blueprint management, logging, and more

If you're interested in contributing, see [How to Contribute](https://wittlewolfie.github.io/WW-Blueprint-Core/articles/contributing.html).

For usage see [Getting Started](https://wittlewolfie.github.io/WW-Blueprint-Core/articles/intro.html).

## Features

### Blueprint Configurators

Each Blueprint type has a corresponding configurator, e.g. `BuffConfigurator`, with methods for modifying its fields and components.

When you're done configuring, call `Configure()` to commit your changes and run validation. Validation errors are logged as a warning.

Configurators use method chaining to reduce boilerplate:

```C#
FeatureConfigurator.New(FeatName, FeatGuid)
  .AddBuffSkillBonus(StatType.SkillKnowledgeArcana, 2)
  .AddBuffSkillBonus(StatType.SkillUseMagicDevice, 2)
  .Configure();
```

Configurator methods can set or modify fields and add all supported BlueprintComponent types. Using auto-complete you can quickly search available component types.

The Configure *should* guarantee components work with a given blueprint. This is determined using the game's `AllowedOn` attribute which declares supported blueprint types for each component. This is not always correct so please report any problems with the API: [GitHub Issues](https://github.com/WittleWolfie/WW-Blueprint-Core/issues).

Every effort is made to minimize boilerplate and enforce proper usage of fields and components. Blueprint fields that should not be modified are hidden when reported by a contributor or on [GitHub Issues](https://github.com/WittleWolfie/WW-Blueprint-Core/issues).

Component methods are regularly updated to ignore unused fields and require fields necessary for the component to function. Field types that should not be null are automatically populated with a default to prevent exceptions.

For example, the `FeatureConfigurator` exposes a method `AddPrerequisiteCharacterLevel`:
![AddPreRequisiteCharacterLevel VS Documentation](https://wittlewolfie.github.io/WW-Blueprint-Core/images/configurator_method_example.png)

### ActionList and ConditionsChecker Builders

`ActionsBuilder` is a builder API for `ActionList` and `ConditionsBuilder` is a builder API for `ConditionsChecker`.

BlueprintCore APIs accept builders directly or you can call `Build()` to construct them and run validation. Validation errors are logged as a warning.

Builder methods create Action and Condition types and are defined across extension classes to improve auto-complete searching. Extension classes are logically grouped so most blueprints require only one extension.

For example, `ActionsBuilderKingdomEx` contains builder methods related to the Kingdom and Crusade system and can be referenced by including the namespace `BlueprintCore.Actions.Builder.KingdomEx`:

```C#
using BlueprintCore.Actions.Builder.KingdomEx;

ActionsBuilder.New()
  .ChangeTacticalMorale(ContextValues.Constant(5))
  .Build();
```

Library methods, such as configurators, accept builders directly and call `Build()` internally to minimize boilerplate:

```C#
BuffConfigurator.New(BuffName, BuffGuid)
  .AddRestTrigger(ActionsBuilder.New().AddRandomTrashItem(TrashLootType.Scrolls, 100))
  .Configure();
```

### Utils

Util classes provide type builders, constant references, tools, and more.

#### Tools

Tool classes include methods for common operations. These vary from operations like `CommonTool#Append<>()` for concatening arrays to `BlueprintTool.GetRef<T>()` which creates a blueprint reference directly, without fetching the blueprint.

#### Logging

`LogWrapper` exposes the game's logger for mod usage. This logs output to the game logs which can be viewed using [Remote Console](https://github.com/OwlcatOpenSource/RemoteConsole/releases).

It enables verbose logging for debugging and prefixes logs to filter log output to your mod or BlueprintCore logs.

For example, this code
```C#
LogWrapper logger = LogWrapper.Get("MyMod");
logger.Info("Logger initialized.");
```
logs:
```
BlueprintCore.MyMod: Logger initialized.
```

#### Type Builders

Classes for constructing simple types like `ContextValues` for creating `ContextValue` types or `ContextRankConfigs` for creating `ContextRankConfig` components.

```C#
FeatureConfigurator.New(FeatureName, FeatureGuid)
  .AddContextRankConfig(ContextRankConfigs.BaseAttack().WithBonusValueProgression(2))
  .Build();
```

Utility classes provide functionality to simplify modifying the game and ensure correct use of game types.

## Usage

BlueprintCore is available as a [NuGet package](https://www.nuget.org/packages/WW-Blueprint-Core/). For more details see [Getting Started](https://wittlewolfie.github.io/WW-Blueprint-Core/articles/intro.html).

# Acknowledgements

* Thank you to the Owlcat modders who came before me, documenting their process and sharing their code.
* Thank you to the modders on Discord who helped me learn modding so I could create this library.

# Interested in modding?

* Check out the [OwlcatModdingWiki](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki).
* Join us on [Discord](https://discord.gg/zHbMuYT6).

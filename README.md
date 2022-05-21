# WW-Blueprint-Core

[![NuGet](https://img.shields.io/nuget/v/WW-Blueprint-Core?style=flat-square)](https://www.nuget.org/packages/WW-Blueprint-Core)

*Disclaimer*: While the documentation is still mostly correct, function and parameter names may have changed in the 2.0 release. Documentation updates are in progress.

*What is BlueprintCore*: A library to simplify modifying Pathfinder: Wrath of the Righteous. At a glance it provides:

* A method chaining API for creating and modifying Blueprints, Actions, and Conditions
```C#
BuffConfigurator.New(MyBuffName, MyBuffGuid).AddContextStatBonus(StatType.Strength, ContextValues.Constant(2)).Configure();
```
* Methods for constructing  Blueprint, Action, Condition, and BlueprintComponent types
    * Each method has comments listing up to three example blueprints
    * Method comments include usage details sourced from the modding community and game assembly
    * Constructors provide default, non-null values for types which should not be null
    * Manual tuning of methods enforces required fields and other implicit requirements
        * Implemented with help from modders like you, see [How to Contribute](https://wittlewolfie.github.io/WW-Blueprint-Core/articles/contributing.html).
* Blueprint modification API limiting BlueprintComponents to usable types
* Runtime validation of blueprint configurations
    * Uses the game's own validation code in combination with custom logic to validate implicit constraints
* Utility classes
    * Tools for creating common types
    * Tools for localization, blueprint management, logging, and more

If you're interested in contributing, see [How to Contribute](https://wittlewolfie.github.io/WW-Blueprint-Core/articles/contributing.html).

For usage see [Getting Started](https://wittlewolfie.github.io/WW-Blueprint-Core/articles/intro.html).

## Features

### Blueprint Configurators

Each Blueprint class has a corresponding configurator, e.g. `BuffConfigurator`, which exposes an API for modifying its fields and components. Once you call `Configure()` all of the changes are committed and validation errors are logged as a warning.

The API uses method chaining, meaning each method call returns the configurator resulting in reduced boilerplate:

```C#
FeatureConfigurator.New(FeatName, FeatGuid)
  .AddBuffSkillBonus(StatType.SkillKnowledgeArcana, 2)
  .AddBuffSkillBonus(StatType.SkillUseMagicDevice, 2)
  .Configure();
```

The API includes methods to set or modify Blueprint fields and add all supported BlueprintComponent types. With auto-complete this provides a quick and easy way to search for BlueprintComponent types.

Supported BlueprintComponent types means types that *should* work with a given blueprint. This is determined using the game's type attributes which declare supported Blueprint types for each component: `AllowedOn`. The attribute is not always correct, so please report any problems with the API: [GitHub Issues](https://github.com/WittleWolfie/WW-Blueprint-Core/issues).

Every effort is made to minimize boilerplate in the API and enforce proper usage of Blueprint field and components. Blueprint fields that should not be modified are hidden when reported by a contributor or on [GitHub Issues](https://github.com/WittleWolfie/WW-Blueprint-Core/issues). Component methods are regularly updated to ignore unused fields and require fields necessary for the component to function. Field types that should not be null are automatically populated with a default to prevent exceptions.

For example, the `FeatureConfigurator` exposes a method `AddPrerequisiteCharacterLevel`:
![AddPreRequisiteCharacterLevel VS Documentation](https://github.com/WittleWolfie/WW-Blueprint-Core/blob/main/docs/images/configurator_method_example.png)

### ActionList and ConditionsChecker Builders

`ActionsBuilder` is a builder API for `ActionList` and `ConditionsBuilder` is a builder API for `ConditionsChecker`. When `Build()` is called the corresponding game type is returned and validation errors are logged as a warning.

They provide methods for creating Action and Condition types, split across extension classes to limit the scope of auto-complete. The extensions are logically grouped so most uses require only one set.

For example, `ActionsBuilderKingdomEx` contains builder methods for actions related to the Kingdom and Crusade system and can be referenced by including the namespace `BlueprintCore.Actions.Builder.KingdomEx`:

```C#
using BlueprintCore.Actions.Builder.KingdomEx;

ActionsBuilder.New()
  .ChangeTacticalMorale(ContextValues.Constant(5))
  .Build();
```

Library methods, such as configurator methods, accept builders directly and call `Build()` internally to minimize boilerplate:

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

`LogWrapper` exposes the game's logger for mod usage. This results in logging output to the game logs which can be viewed using [Remote Console](https://github.com/OwlcatOpenSource/RemoteConsole/releases).

It exposes verbose logging with more control for debugging and prefixes logs to quickly identify logs output by your mod or BlueprintCore.

For example, this code
```C#
LogWrapper logger = LogWrapper.Get("MyMod");
logger.Info("Logger initialized.");
```
would log:
```
BlueprintCore.MyMod: Logger initialized.
```

#### Type Builders

Classes for constructing simple types like `ContexValues` for creating `ContextValue` types or `ContextRankConfigs` for creating `ContextRankConfig` components.

```C#
FeatureConfigurator.New(FeatureName, FeatureGuid)
  .AddContextRankConfig(ContextRankConfigs.BaseAttack().WithBonusValueProgression(2))
  .Build();
```

Utility classes provide additional functionality to simplify modifying the game as well as helping ensure correct use of game types.

## Usage

BlueprintCore is available as a [NuGet package](https://www.nuget.org/packages/WW-Blueprint-Core/). For more details see the [Getting Started](https://wittlewolfie.github.io/WW-Blueprint-Core/articles/intro.html).

# Acknowledgements

* Thank you to the Owlcat modders who came before me, documenting their process and sharing their code.
* Thank you to the modders on Discord who helped me learn modding so I could create this library.

# Interested in modding?

* Check out the [OwlcatModdingWiki](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki).
* Join us on [Discord](https://discord.gg/zHbMuYT6).

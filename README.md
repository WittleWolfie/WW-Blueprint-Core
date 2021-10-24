# WW-Blueprint-Core

Fluent API library for modifying Pathfinder: Wrath of the Righteous and validating Blueprint configurations.

[![NuGet](https://img.shields.io/nuget/v/WW-Blueprint-Core?style=flat-square)](https://www.nuget.org/packages/WW-Blueprint-Core)

If you're interested in contributing, see [How to Contribute](articles/contributing.md).

## Features

### Blueprint Configurators

Each concrete blueprint class has a corresponding configurator, e.g. `BuffConfigurator`, which exposes a fluent API for modifying its fields and components. Once you call `Configure()` all of the changes are committed and validated. All validation errors are logged as a warning.

The API attempts to limit use of `BlueprintComponent` types to supported blueprints but it is not always possible. If a blueprint does contain an unsupported component it results in a validation error.

### ActionList and ConditionsChecker Builders

`ActionsBuilder` is a builder API for `ActionList` and `ConditionsBuilder` is a builder API for `ConditionsChecker`. When a configurator or builder requires an `ActionList` or `ConditionsChecker` it takes the corresponding builder as an input.

Since there are a very large number of actions and conditions, each builder class is implemented across several extensions. This limits auto-complete to a subset of related actions. e.g. If you are adding a new ability you can include `ActionsBuilderContextEx` while ignoring extensions such as `ActionsBuilderKingdomEx` which only affects kingdom and crusade mechanics.

Like configurators, builders log validation errors when `Build()` is called. This happens automatically when a builder is given as an argument to a configurator function.

### Validation

All objects builder or configured in the library are validated, along with some input objects. Validation uses the game's `ValidationContext` API as well as custom logic to validate implicit contracts not covered by the game's own validation.

## Usage

BlueprintCore is available as [NuGet package](https://www.nuget.org/packages/WW-Blueprint-Core/) that provides the source code for compilation into your modification. It requires a [public assembly](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki/Publicise-Assemblies).

For more details check the [documentation](https://wittlewolfie.github.io/WW-Blueprint-Core/articles/intro.html).

### Example

**Skald's Vigor**
```C#
BuffConfigurator.For(SkladsVigorBuff)
    .ContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { SkaldClass }).DivideByThenDoubleThenAdd1(8))
    .FastHealing(1, bonusValue: ContextValues.Rank(AbilityRankType.Default))
    .Configure();

var applyBuff = ActionsBuilder.New().ApplyBuff(SkaldsVigorBuff, permanent: true, dispellable: false);
BuffConfigurator.For(RAGING_SONG_BUFF)
    .FactContextActions(
        onActivated:
            ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New().TargetIsYourself().HasFact(SkaldsVigor),
                    ifTrue: applyBuff)
                .Conditional(
                    ConditionsBuilder.New().CasterHasFact(GreaterSkaldsVigor),
                    ifTrue: applyBuff),
        onDeactivated: ActionsBuilder.New().RemoveBuff(SkaldsVigorBuff))
    .Configure();
```

# Acknowledgements

* Thank you to the Owlcat modders who came before me, documenting their process and sharing their code.
* Thank you to the modders on Discord who helped me learn modding so I could create this library.

# Interested in modding?

* Check out the [OwlcatModdingWiki](https://github.com/WittleWolfie/OwlcatModdingWiki/wiki).
* Join us on [Discord](https://discord.gg/zHbMuYT6).
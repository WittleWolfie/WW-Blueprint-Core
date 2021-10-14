# WW-Blueprint-Core

Fluent API library for modifying Pathfinder: Wrath of the Righteous and validating Blueprint configurations.

# Status: WIP

Not ready for use as a library yet. There are a few key things that need to be finalized before I
publish:

1. Finalize ActionListBuilder extension class distinctions **DONE**
2. Finalize ConditionsCheckerBuilder extension class distinctions **DONE**
3. Add Create() to BlueprintConfigurator **DONE**
4. Cleanup Utils APIs **IN PROGRESS**

Once these are done it will be usable but incomplete. Completion is dependent on implementing all
Actions, Conditions, and Components in the appropriate Builder or Configurator API.

## Features

### Blueprint Configurators

Each concrete blueprint class has a corresponding configurator, e.g. `BuffConfigurator`, which exposes a fluent API for modifying its field values and blueprint components. Once you call `Configure()` on a blueprint configurator, all of the changes are committed and validated. If validation fails, all errors are bundled into a warning log message.

### ActionList and ConditionsChecker Builders

`ActionList` and `ConditionsChecker` are supported with a builder API. Blueprint configurators take builders are arguments for blueprint components to minimize boilerplate. To simplify their usage, the actual methods for each action or condition are grouped into extension classes by use case. This allows you to ignore actions unrelated to your modification. e.g. If you are only adding new feats you can skip including extension classes like `ActionListBuilderKingdomEx` which only affect the kingdom building and crusade portion of the game.

### Validation

All actions, conditions, blueprints, and blueprint components are validated when built or configured. Validation is done through a combination of Wrath's `ValidationContext` API with additional checks to validate implicit contracts in the code that native validation does not check.

## Usage

Right now it's not ready for use--the API may change in breaking ways while I finish the initial release. However, feel free to start using it or even submitting PRs or Issues. I'm particularly interested in feedback on how to logically group Actions and Conditions.

You can use `copy_assemblies.bat` to set up your assembly directory for project references: you must set the `WRATH_DIR` environment variable to the root install directory for Pathfinder: Wrath of the Righteous. You must use a publicized assembly. See [Publicize Assemblies](https://github.com/TylerGoeringer/OwlcatModdingWiki/wiki/Publicise-Assemblies) for more details.

### Example
**Skald's Vigor**
```C#
BuffConfigurator.For(SkladsVigorBuff)
    .ContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { SkaldClass }).DivideByThenDoubleThenAdd1(8))
    .FastHealing(1, bonusValue: ContextValues.Rank(AbilityRankType.Default))
    .Configure();

var applyBuff = ActionListBuilder.New().ApplyBuff(SkaldsVigorBuff, permanent: true, dispellable: false);
BuffConfigurator.For(RAGING_SONG_BUFF)
    .FactContextActions(
        onActivated:
            ActionListBuilder.New()
                .Conditional(
                    ConditionsCheckerBuilder.New().TargetIsYourself().HasFact(SkaldsVigor),
                    ifTrue: applyBuff)
                .Conditional(
                    ConditionsCheckerBuilder.New().CasterHasFact(GreaterSkaldsVigor),
                    ifTrue: applyBuff),
        onDeactivated: ActionListBuilder.New().RemoveBuff(SkaldsVigorBuff))
    .Configure();
```

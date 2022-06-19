# Actions and Conditions

Actions and conditions in the game are used to define triggered behavior. When a spell is cast the effect could be applied by an action and a condition could determine which effect is used based on the type of target.

Almost all uses of actions and conditions are in the form of `ActionList` and `ConditionsChecker`.

In BPCore [ActionsBuilder](xref:BlueprintCore.Actions.Builder.ActionsBuilder) and [ConditionsBuilder](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder) provide APIs for constructing them.

## ActionsBuilder and ConditionsBuilder

### Basic Usage

```C#
using BlueprintCore.Actions.Builder.ContextEx;

// Creates an ActionsBuilder which grants a buff and triggers a melee attack
var meleeAttack =
  ActionsBuilder.New()
    .ApplyBuff(MyAttackBuff, duration: ContextDuration.Fixed(1))
    .MeleeAttack();
```

You can call `Build()` directly but usually this is not necessary. Actions and conditions are used in the context of blueprints, blueprint components, or other actions and conditions. BlueprintCore APIs all accept builders in place of `ActionList` and `ConditionsChecker`:
```C#
using BlueprintCore.Actions.Builder.ContextEx;

AbilityConfigurator.New(AbilityName, AbilityGuid)
  // Adds an AbilityEffectRunAction component which grants a buff and triggers a melee attack when the ability is used.
  // Build() is called internally by the library.
  .AddAbilityEffectRunAction(
    ActionsBuilder.New()
      .ApplyBuff(MyAttackBuff, duration: ContextDuration.Fixed(1))
      .MeleeAttack())
  .Configure();
```

Notice that both examples included the namespace `BlueprintCore.Actions.Builder.ContextEx`. This is because actions and conditions are implemented using extension classes. Each extension namespace includes a different set of actions and conditions, grouped loosely by usage.

The full breakdown of extension classes is provided in [ActionsBuilder](xref:BlueprintCore.Actions.Builder.ActionsBuilder) and [ConditionsBuilder](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder). At a glance:

* AreaEx - Involves the game map, dungeons, or locations
* AVEx - Involves audiovisual effects such as dialogs, camera, cutscenes, and sounds 
* BasicEx - Most non-context actions and conditions related to game mechanics
* ContextEx - Most context actions and conditions related to game mechanics
* KingdomEx - Involves the Kingdom and Crusade system
* MiscEx - Catch-all for uncategorized
* NewEx - New actions and conditions implemented in BlueprintCore
* UpgraderEx - UpgraderOnlyActions (does not exist for conditions)

Only actions or conditions in the extension classes imported will be available in auto-complete or compilation. Usually you only need a single extension class for a given blueprint.

### Customizing Builders

Builders are implemented almost entirely through extension classes and methods. To add your own methods just create a class and use the extension method syntax:

```C#
public static ActionsBuilder AddMyCustomAction(this ActionsBuilder builder, int someValue)
{
  return builder.Add(ElementTool.Create<MyCustomAction>() { Value = someValue });
}
```

Note the usage of [ElementTool.Create<>()](xref:BlueprintCore.Utils.ElementTool.Create``1). Use this when instantiating types inheriting from `Element` to ensure they are configured properly or it can cause your mod to fail.

### Advanced Usage

Builders have an `Add()` method which can be used to add any relevant type:

```C#
var actions = ActionsBuilder.New().Add(ElementTool.Create<MyCustomAction>());
```

There is also a version of `Add()` which takes a type argument and init action:

```C#
var actions = ActionsBuilder.New().Add<MyCustomAction>(a => a.Value = someValue);
```

ConditionsBuilder has a special method, [UseOr()](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder.UseOr), which results in the conditions being evaluated using or instead of and logic. i.e. By default all conditions in the builder must pass but calling `UseOr()` means only a single condition needs to pass.

1. Instantiate a builder using `New()`
2. Add actions/conditions using builder methods
    * `ConditionsBuilder` has a special method, [UseOr()](xref:BlueprintCore.Conditions.Builder.ConditionsBuilder.UseOr) which results in a `ConditionsChecker` that will pass if any one condition passes. By default all conditions must pass.
3. Build the list with `Build()`
    * When an `ActionList` or `ConditionsChecker` is needed in a library method you do not need to call `Build()`. Instead the builder is passed into the method directly and `Build()` is called by the library.
    * Calling build logs validation errors as a warning.
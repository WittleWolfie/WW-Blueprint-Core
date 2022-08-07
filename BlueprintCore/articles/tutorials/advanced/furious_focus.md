# Advanced Feat: Furious Focus

This tutorial assumes you've gone through [Adding a Feat](~/tutorials/feat.md) and [Skald's Vigor](skalds_vigor.md), or are familiar with the basics of adding a feat and using BPCore.

We'll be adding [Furious Focus](https://www.d20pfsrd.com/feats/combat-feats/furious-focus-combat/).

Go through the basic setup steps:

1. Create the `FuriousFocus` class
2. Create the `Configure` method
3. Create the feat, setting the name and description

```C#
public class FuriousFocus
{
  public static void Configure()
  {
    FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
      .SetDisplayName(FeatDisplayName)
      .SetDescription(FeatDescription)
      .Configure();
  }
}
```

Make sure to add `FeatDisplayName` and `FeatDescription` to your `LocalizedStrings.json` file.

## Add the Prerequisites

Furious Focus requires Strength 13, Power Attack, and BAB +1. You might be tempted to just make Power Attack a prerequisite since it requires Strength 13 and BAB +1, but this doesn't guarantee a character meets the requirements since Power Attack may be granted as a bonus that bypasses prerequisites:

```C#
FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
  .SetDisplayName(FeatDisplayName)
  .SetDescription(FeatDescription)
  .AddPrerequisiteStatValue(StatType.Strength, 13)
  .AddPrerequisiteStatValue(StatType.BaseAttackBonus, 1)
  .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
  .Configure();
```

## Add the Attack Bonus

Furious Focus only modifies the character's attack bonus when Power Attack is active. If you look at Power Attack's blueprint it adds the `PowerAttackToggleAbility` which applies `PowerAttackBuff`, which applies a penalty using `WeaponParametersAttackBonus`.

Unfortunately `WeaponParametersAttackBonus` cannot implement Furious Focus. In fact, there are no components that support the necessary configuration to apply the bonus:

* Power Attack is active
* First attack of the turn
* Two-handed weapons only

This means we need a custom component:

```C#
[TypeId("5767d0d5-d84c-4949-94aa-e654febc3b0f")]
private class FuriousFocusBonus :
  UnitFactComponentDelegate,
  IInitiatorRulebookHandler<RuleCalculateAttackBonusWithoutTarget>
{
  public void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt) { }

  public void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt)
  {

  }
}
```

The `TypeId` attribute is not strictly necessary but is good practice. It ensures a unique type ID for your component, used when serialized to JSON. The component inherits from `UnitFactComponentDelegate` and `IInitiatorRulebookHandler<RuleCalculateAttackBonusWithoutTarget>` to mimic `WeaponParametersAttackBonus`.

The implementation goes in `OnEventDidTrigger` because the penalty from power attack is applied in `OnEventAboutToTrigger`. This enables applying a bonus only if power attack applies a penalty:

```C#
var powerAttackModifier =
  evt.m_ModifiableBonus?.Modifiers?
    .Where(m => m.Fact?.Blueprint == PowerAttackBuff)
    .Select(m => (Modifier?)m) // Cast to avoid getting a default struct
    .FirstOrDefault();
if (powerAttackModifier is null)
{
  Logger.Verbose("Skipped: power attack not applied");
  return;
}

Logger.Info($"Adding attack bonus to {Owner.CharacterName}'s attack");
evt.AddModifier(new Modifier(-powerAttackModifier.Value.Value, Fact, ModifierDescriptor.UntypedStackable));
```

To understand where this code comes from just look at how `WeaponParametersAttackBonus` applies its penalty. Each modifier is added to `m_ModifiableBonus` and includes a value and a `Fact` which points to the fact providing the bonus. When adding the Furious Focus bonus the `Fact` from `UnitFactComponentDelegate` is provided to ensure it shows up in the tooltips.

Add the component to the feature:

```C#
FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
  .SetDisplayName(FeatDisplayName)
  .SetDescription(FeatDescription)
  .AddPrerequisiteStatValue(StatType.Strength, 13)
  .AddPrerequisiteStatValue(StatType.BaseAttackBonus, 1)
  .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
  .AddComponent<FuriousFocusBonus>()
  .Configure();
```

Test it out and you should see something like this:

![Furious Focus attack bonus tooltip](~/images/advanced_feat/furious_focus_tooltip.png)

## Completing the Feat

Right now the attack bonus eliminates the penalty from Power Attack at all times. Finishing the feat requires adding some restrictions to the bonus:

1. Two-handed weapons only
2. First attack only

These are left as an exercise. One solution is available in the "Solutions" folder if you're stuck or want to compare.

Tips:

* Look at how `WeaponParametersAttackBonus` supports `OnlyTwoHanded`
* Look at `RuleAttackWithWeapon`
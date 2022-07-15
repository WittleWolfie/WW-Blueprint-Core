# Adding More Feats

This tutorial assumes you've gone through [Adding a Feat](feat.md) or are otherwise familiar with the basics of adding a feat.

We'll be adding three new feats, each of which poses a different challenge: [Skald's Vigor](https://www.d20pfsrd.com/feats/general-feats/skald-s-vigor/), [Furious Focus](https://www.d20pfsrd.com/feats/combat-feats/furious-focus-combat/), and [Hurtful](https://www.d20pfsrd.com/feats/combat-feats/hurtful-combat/).

## Skald's Vigor

Go through the basic setup steps:

1. Create the `SkaldsVigor` class
2. Create the `Configure` method
3. Create the feat, setting the name and description

```C#
public class SkaldsVigor
{
  public static void Configure()
  {
    FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
      .SetDisplayName("SkaldsVigor.Name")
      .SetDescription("SkaldsVigor.Description")
      .Configure();
  }
}
```

### Adding a Prerequisite

First let's make sure the feat is only available to character with the Raging Song feature. There's a category of components to implement feature preqrequisites. You can find them by searching `Prerequisite` in the `FeatureConfigurator` API or the decompiler.

For this use `AddPrerequisiteFeature` and pass in the Raging Song feature. You can find the Raging Song feature using [BubblePrints](https://github.com/factubsio/BubblePrints) or by searching `FeatureRefs`:

```C#
FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
  .SetDisplayName("SkaldsVigor.Name")
  .SetDescription("SkaldsVigor.Description")
  .AddPrerequisiteFeature(FeatureRefs.RagingSong.ToString())
  .Configure();
```

Unfortunately `FeatureRefs.RagingSong` provides `Blueprint<BlueprintReference<BlueprintFeature>>` but `AddPrerequisiteFeature` expects `Blueprint<BlueprintFeatureReference>`. There's no way to automatically convert but you can call `ToString()` to get the GUID directly. You can also use the cast method: `FeatureRefs.RagingSong.Cast<BlueprintFeatureReference>()`.

> ![TIP]
> In this example there is only a single version of Raging Song. Some features have multiple versions such as a Magus's Spell Combat. You can require one of a set of features using PrerequisiteFeaturesFromList.

Go ahead and test it out. It should be available to characters with Raging Song:

![Skald's Vigor showing prerequisite is present](~/images/advanced_feat/present_prereq.png)

and unavailable to characters without it:

![Skald's Vigor showing prerequisite is missing](~/images/advanced_feat/missing_prereq.png)

### 
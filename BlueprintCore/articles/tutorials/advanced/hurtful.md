# Advanced Feat: Hurtful

This tutorial assumes you've gone through [Adding a Feat](~/tutorials/feat.md) and [Skald's Vigor](skalds_vigor.md), or are familiar with the basics of adding a feat and using BPCore.

We'll be adding [Hurtful](https://www.d20pfsrd.com/feats/combat-feats/hurtful-combat/).

Go through the basic setup steps:

1. Create the `Hurtful` class
2. Create the `Configure` method
3. Create the feat, setting the name and description

```C#
public class Hurtful
{
  public static void Configure()
  {
    FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
      .SetDisplayName("Hurtful.Name")
      .SetDescription("Hurtful.Description")
      .Configure();
  }
}
```
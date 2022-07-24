# Advanced Feat: Furious Focus

This tutorial assumes you've gone through [Adding a Feat](feat.md) or are otherwise familiar with the basics of adding a feat.

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
      .SetDisplayName("FuriousFocus.Name")
      .SetDescription("FuriousFocus.Description")
      .Configure();
  }
}
```
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Artisans;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Artisans
{
  /// <summary>Configurator for <see cref="ArtisanItemDeck"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ArtisanItemDeck))]
  public class ArtisanItemDeckConfigurator : BaseBlueprintConfigurator<ArtisanItemDeck, ArtisanItemDeckConfigurator>
  {
     private ArtisanItemDeckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArtisanItemDeckConfigurator For(string name)
    {
      return new ArtisanItemDeckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArtisanItemDeckConfigurator New(string name)
    {
      BlueprintTool.Create<ArtisanItemDeck>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArtisanItemDeckConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ArtisanItemDeck>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ArtisanItemDeck.TypeName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArtisanItemDeckConfigurator SetTypeName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TypeName = value);
    }

    /// <summary>
    /// Modifies <see cref="ArtisanItemDeck.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArtisanItemDeckConfigurator AddToTiers(params ArtisanItemDeck.TierData[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Tiers = CommonTool.Append(bp.Tiers, values));
    }

    /// <summary>
    /// Modifies <see cref="ArtisanItemDeck.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArtisanItemDeckConfigurator RemoveFromTiers(params ArtisanItemDeck.TierData[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Tiers = bp.Tiers.Where(item => !values.Contains(item)).ToArray());
    }
  }
}

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Artisans;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Artisans
{
  /// <summary>Configurator for <see cref="BlueprintKingdomArtisan"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomArtisan))]
  public class KingdomArtisanConfigurator : BaseBlueprintConfigurator<BlueprintKingdomArtisan, KingdomArtisanConfigurator>
  {
     private KingdomArtisanConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomArtisanConfigurator For(string name)
    {
      return new KingdomArtisanConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomArtisanConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomArtisan>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomArtisanConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomArtisan>(name, assetId);
      return For(name);
    }
  }
}

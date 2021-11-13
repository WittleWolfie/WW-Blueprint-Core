using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintKingdomDeck"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomDeck))]
  public class KingdomDeckConfigurator : BaseBlueprintConfigurator<BlueprintKingdomDeck, KingdomDeckConfigurator>
  {
     private KingdomDeckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomDeckConfigurator For(string name)
    {
      return new KingdomDeckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomDeckConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomDeck>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomDeckConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomDeck>(name, assetId);
      return For(name);
    }

  }
}

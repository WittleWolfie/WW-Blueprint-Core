using BlueprintCore.Blueprints.Configurators.Kingdom;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintKingdomClaim"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomClaim))]
  public class KingdomClaimConfigurator : BaseKingdomProjectConfigurator<BlueprintKingdomClaim, KingdomClaimConfigurator>
  {
     private KingdomClaimConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomClaimConfigurator For(string name)
    {
      return new KingdomClaimConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomClaimConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomClaim>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomClaimConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomClaim>(name, assetId);
      return For(name);
    }
  }
}

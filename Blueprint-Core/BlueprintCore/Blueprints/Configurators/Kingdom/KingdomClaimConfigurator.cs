using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;

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

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.KnownCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetKnownCondition(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.KnownCondition = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.FailCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetFailCondition(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.FailCondition = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.UnknownDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetUnknownDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.UnknownDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.KnownDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetKnownDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.KnownDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.FailedDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetFailedDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FailedDescription = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomClaim.FulfilledDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomClaimConfigurator SetFulfilledDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FulfilledDescription = value);
    }
  }
}

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Localization;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Flags
{
  /// <summary>Configurator for <see cref="BlueprintKingdomMoraleFlag"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomMoraleFlag))]
  public class KingdomMoraleFlagConfigurator : BaseFactConfigurator<BlueprintKingdomMoraleFlag, KingdomMoraleFlagConfigurator>
  {
     private KingdomMoraleFlagConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomMoraleFlagConfigurator For(string name)
    {
      return new KingdomMoraleFlagConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomMoraleFlagConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomMoraleFlag>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomMoraleFlagConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomMoraleFlag>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_DisplayName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetDisplayName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DisplayName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_NeutralDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetNeutralDuration(int value)
    {
      return OnConfigureInternal(bp => bp.m_NeutralDuration = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_NegativeWarningDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetNegativeWarningDuration(int value)
    {
      return OnConfigureInternal(bp => bp.m_NegativeWarningDuration = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_PerDayBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetPerDayBonus(int value)
    {
      return OnConfigureInternal(bp => bp.m_PerDayBonus = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_PerDayPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetPerDayPenalty(int value)
    {
      return OnConfigureInternal(bp => bp.m_PerDayPenalty = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_FlagType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetFlagType(BlueprintKingdomMoraleFlag.FlagType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_FlagType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomMoraleFlag.m_CounterDecrementPerDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomMoraleFlagConfigurator SetCounterDecrementPerDay(int value)
    {
      return OnConfigureInternal(bp => bp.m_CounterDecrementPerDay = value);
    }
  }
}

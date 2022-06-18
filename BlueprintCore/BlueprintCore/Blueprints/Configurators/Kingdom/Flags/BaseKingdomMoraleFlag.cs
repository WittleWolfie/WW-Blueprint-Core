//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Localization;
using System;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Flags
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomMoraleFlag"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomMoraleFlagConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintKingdomMoraleFlag
    where TBuilder : BaseKingdomMoraleFlagConfigurator<T, TBuilder>
  {
    protected BaseKingdomMoraleFlagConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomMoraleFlag.m_DisplayName"/>
    /// </summary>
    public TBuilder SetDisplayName(LocalizedString displayName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DisplayName = displayName;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomMoraleFlag.m_DisplayName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisplayName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DisplayName is null) { return; }
          action.Invoke(bp.m_DisplayName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomMoraleFlag.m_Description"/>
    /// </summary>
    public TBuilder SetDescription(LocalizedString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Description = description;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomMoraleFlag.m_Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Description is null) { return; }
          action.Invoke(bp.m_Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomMoraleFlag.m_NeutralDuration"/>
    /// </summary>
    public TBuilder SetNeutralDuration(int neutralDuration)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NeutralDuration = neutralDuration;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomMoraleFlag.m_NeutralDuration"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNeutralDuration(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_NeutralDuration);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomMoraleFlag.m_NegativeWarningDuration"/>
    /// </summary>
    public TBuilder SetNegativeWarningDuration(int negativeWarningDuration)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NegativeWarningDuration = negativeWarningDuration;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomMoraleFlag.m_NegativeWarningDuration"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNegativeWarningDuration(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_NegativeWarningDuration);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomMoraleFlag.m_PerDayBonus"/>
    /// </summary>
    public TBuilder SetPerDayBonus(int perDayBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PerDayBonus = perDayBonus;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomMoraleFlag.m_PerDayBonus"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPerDayBonus(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_PerDayBonus);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomMoraleFlag.m_PerDayPenalty"/>
    /// </summary>
    public TBuilder SetPerDayPenalty(int perDayPenalty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PerDayPenalty = perDayPenalty;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomMoraleFlag.m_PerDayPenalty"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPerDayPenalty(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_PerDayPenalty);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomMoraleFlag.m_FlagType"/>
    /// </summary>
    public TBuilder SetFlagType(BlueprintKingdomMoraleFlag.FlagType flagType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FlagType = flagType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomMoraleFlag.m_FlagType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFlagType(Action<BlueprintKingdomMoraleFlag.FlagType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_FlagType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomMoraleFlag.m_CounterDecrementPerDay"/>
    /// </summary>
    public TBuilder SetCounterDecrementPerDay(int counterDecrementPerDay)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CounterDecrementPerDay = counterDecrementPerDay;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomMoraleFlag.m_CounterDecrementPerDay"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCounterDecrementPerDay(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_CounterDecrementPerDay);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_DisplayName is null)
      {
        Blueprint.m_DisplayName = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Description is null)
      {
        Blueprint.m_Description = Utils.Constants.Empty.String;
      }
    }
  }
}

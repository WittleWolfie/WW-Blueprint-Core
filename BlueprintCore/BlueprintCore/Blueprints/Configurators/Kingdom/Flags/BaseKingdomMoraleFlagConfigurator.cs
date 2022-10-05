//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintKingdomMoraleFlag>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_DisplayName = copyFrom.m_DisplayName;
          bp.m_Description = copyFrom.m_Description;
          bp.m_NeutralDuration = copyFrom.m_NeutralDuration;
          bp.m_NegativeWarningDuration = copyFrom.m_NegativeWarningDuration;
          bp.m_PerDayBonus = copyFrom.m_PerDayBonus;
          bp.m_PerDayPenalty = copyFrom.m_PerDayPenalty;
          bp.m_FlagType = copyFrom.m_FlagType;
          bp.m_CounterDecrementPerDay = copyFrom.m_CounterDecrementPerDay;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomMoraleFlag.m_DisplayName"/>
    /// </summary>
    ///
    /// <param name="displayName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDisplayName(LocalString displayName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DisplayName = displayName?.LocalizedString;
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
    ///
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDescription(LocalString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Description = description?.LocalizedString;
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
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

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAbilityResource"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAbilityResourceConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAbilityResource
    where TBuilder : BaseAbilityResourceConfigurator<T, TBuilder>
  {
    protected BaseAbilityResourceConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityResource.LocalizedName"/>
    /// </summary>
    ///
    /// <param name="localizedName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedName(LocalString localizedName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedName = localizedName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbilityResource.LocalizedName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedName is null) { return; }
          action.Invoke(bp.LocalizedName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityResource.LocalizedDescription"/>
    /// </summary>
    ///
    /// <param name="localizedDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedDescription(LocalString localizedDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedDescription = localizedDescription?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbilityResource.LocalizedDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedDescription is null) { return; }
          action.Invoke(bp.LocalizedDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityResource.m_Icon"/>
    /// </summary>
    public TBuilder SetIcon(Sprite icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(icon);
          bp.m_Icon = icon;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbilityResource.m_Icon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Icon is null) { return; }
          action.Invoke(bp.m_Icon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityResource.m_MaxAmount"/>
    /// </summary>
    public TBuilder SetMaxAmount(BlueprintAbilityResource.Amount maxAmount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxAmount = maxAmount;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbilityResource.m_MaxAmount"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxAmount(Action<BlueprintAbilityResource.Amount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MaxAmount);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityResource.m_UseMax"/>
    /// </summary>
    public TBuilder SetUseMax(bool useMax = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UseMax = useMax;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityResource.m_Max"/>
    /// </summary>
    public TBuilder SetMax(int max)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Max = max;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityResource.m_Min"/>
    /// </summary>
    ///
    /// <param name="min">
    /// <para>
    /// InfoBox: Resource would be restored to at least this amount (Useful for MaxAmount dependent on stat modifier, that can be negative)
    /// </para>
    /// </param>
    public TBuilder SetMin(int min)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Min = min;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.LocalizedName is null)
      {
        Blueprint.LocalizedName = Utils.Constants.Empty.String;
      }
      if (Blueprint.LocalizedDescription is null)
      {
        Blueprint.LocalizedDescription = Utils.Constants.Empty.String;
      }
    }
  }
}

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
    protected BaseAbilityResourceConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityResource.LocalizedName"/>
    /// </summary>
    public TBuilder SetLocalizedName(LocalizedString localizedName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedName = localizedName;
          if (bp.LocalizedName is null)
          {
            bp.LocalizedName = Utils.Constants.Empty.String;
          }
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
    public TBuilder SetLocalizedDescription(LocalizedString localizedDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedDescription = localizedDescription;
          if (bp.LocalizedDescription is null)
          {
            bp.LocalizedDescription = Utils.Constants.Empty.String;
          }
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
    /// Modifies <see cref="BlueprintAbilityResource.m_UseMax"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUseMax(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_UseMax);
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
    /// Modifies <see cref="BlueprintAbilityResource.m_Max"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMax(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Max);
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

    /// <summary>
    /// Modifies <see cref="BlueprintAbilityResource.m_Min"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="min">
    /// <para>
    /// InfoBox: Resource would be restored to at least this amount (Useful for MaxAmount dependent on stat modifier, that can be negative)
    /// </para>
    /// </param>
    public TBuilder ModifyMin(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Min);
        });
    }
  }
}
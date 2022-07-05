//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Visual.LightSelector;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Visual
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTimeOfDaySettings"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTimeOfDaySettingsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintTimeOfDaySettings
    where TBuilder : BaseTimeOfDaySettingsConfigurator<T, TBuilder>
  {
    protected BaseTimeOfDaySettingsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTimeOfDaySettings.Morning"/>
    /// </summary>
    public TBuilder SetMorning(GameObject morning)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(morning);
          bp.Morning = morning;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTimeOfDaySettings.Morning"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMorning(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Morning is null) { return; }
          action.Invoke(bp.Morning);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTimeOfDaySettings.Day"/>
    /// </summary>
    public TBuilder SetDay(GameObject day)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(day);
          bp.Day = day;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTimeOfDaySettings.Day"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDay(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Day is null) { return; }
          action.Invoke(bp.Day);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTimeOfDaySettings.Evening"/>
    /// </summary>
    public TBuilder SetEvening(GameObject evening)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(evening);
          bp.Evening = evening;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTimeOfDaySettings.Evening"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEvening(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Evening is null) { return; }
          action.Invoke(bp.Evening);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTimeOfDaySettings.Night"/>
    /// </summary>
    public TBuilder SetNight(GameObject night)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(night);
          bp.Night = night;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTimeOfDaySettings.Night"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNight(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Night is null) { return; }
          action.Invoke(bp.Night);
        });
    }
  }
}

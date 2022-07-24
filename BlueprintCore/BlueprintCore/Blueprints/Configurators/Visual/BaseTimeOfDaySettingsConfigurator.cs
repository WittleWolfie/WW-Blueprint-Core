//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
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
    ///
    /// <param name="morning">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    public TBuilder SetMorning(Asset<GameObject> morning)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Morning = morning?.Get();
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
    ///
    /// <param name="day">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    public TBuilder SetDay(Asset<GameObject> day)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Day = day?.Get();
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
    ///
    /// <param name="evening">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    public TBuilder SetEvening(Asset<GameObject> evening)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Evening = evening?.Get();
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
    ///
    /// <param name="night">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    public TBuilder SetNight(Asset<GameObject> night)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Night = night?.Get();
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

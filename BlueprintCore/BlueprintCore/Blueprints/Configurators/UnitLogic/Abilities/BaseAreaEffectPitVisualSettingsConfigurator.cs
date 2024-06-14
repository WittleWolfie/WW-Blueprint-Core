//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaEffectPitVisualSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaEffectPitVisualSettingsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAreaEffectPitVisualSettings
    where TBuilder : BaseAreaEffectPitVisualSettingsConfigurator<T, TBuilder>
  {
    protected BaseAreaEffectPitVisualSettingsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaEffectPitVisualSettings>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DepthMeters = copyFrom.DepthMeters;
          bp.HoleEdgeMeters = copyFrom.HoleEdgeMeters;
          bp.UnitDisappearFx = copyFrom.UnitDisappearFx;
          bp.UnitAppearFx = copyFrom.UnitAppearFx;
          bp.FallXZCurve = copyFrom.FallXZCurve;
          bp.FallYCurve = copyFrom.FallYCurve;
          bp.ClimbXZCurve = copyFrom.ClimbXZCurve;
          bp.ClimbYCurve = copyFrom.ClimbYCurve;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAreaEffectPitVisualSettings>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.DepthMeters = copyFrom.DepthMeters;
          bp.HoleEdgeMeters = copyFrom.HoleEdgeMeters;
          bp.UnitDisappearFx = copyFrom.UnitDisappearFx;
          bp.UnitAppearFx = copyFrom.UnitAppearFx;
          bp.FallXZCurve = copyFrom.FallXZCurve;
          bp.FallYCurve = copyFrom.FallYCurve;
          bp.ClimbXZCurve = copyFrom.ClimbXZCurve;
          bp.ClimbYCurve = copyFrom.ClimbYCurve;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEffectPitVisualSettings.DepthMeters"/>
    /// </summary>
    public TBuilder SetDepthMeters(float depthMeters)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DepthMeters = depthMeters;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEffectPitVisualSettings.HoleEdgeMeters"/>
    /// </summary>
    public TBuilder SetHoleEdgeMeters(float holeEdgeMeters)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HoleEdgeMeters = holeEdgeMeters;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEffectPitVisualSettings.UnitDisappearFx"/>
    /// </summary>
    ///
    /// <param name="unitDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetUnitDisappearFx(AssetLink<PrefabLink> unitDisappearFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnitDisappearFx = unitDisappearFx?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEffectPitVisualSettings.UnitDisappearFx"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnitDisappearFx(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitDisappearFx is null) { return; }
          action.Invoke(bp.UnitDisappearFx);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEffectPitVisualSettings.UnitAppearFx"/>
    /// </summary>
    ///
    /// <param name="unitAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetUnitAppearFx(AssetLink<PrefabLink> unitAppearFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnitAppearFx = unitAppearFx?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEffectPitVisualSettings.UnitAppearFx"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnitAppearFx(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitAppearFx is null) { return; }
          action.Invoke(bp.UnitAppearFx);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEffectPitVisualSettings.FallXZCurve"/>
    /// </summary>
    public TBuilder SetFallXZCurve(AnimationCurve fallXZCurve)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(fallXZCurve);
          bp.FallXZCurve = fallXZCurve;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEffectPitVisualSettings.FallXZCurve"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFallXZCurve(Action<AnimationCurve> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FallXZCurve is null) { return; }
          action.Invoke(bp.FallXZCurve);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEffectPitVisualSettings.FallYCurve"/>
    /// </summary>
    public TBuilder SetFallYCurve(AnimationCurve fallYCurve)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(fallYCurve);
          bp.FallYCurve = fallYCurve;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEffectPitVisualSettings.FallYCurve"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFallYCurve(Action<AnimationCurve> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FallYCurve is null) { return; }
          action.Invoke(bp.FallYCurve);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEffectPitVisualSettings.ClimbXZCurve"/>
    /// </summary>
    public TBuilder SetClimbXZCurve(AnimationCurve climbXZCurve)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(climbXZCurve);
          bp.ClimbXZCurve = climbXZCurve;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEffectPitVisualSettings.ClimbXZCurve"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyClimbXZCurve(Action<AnimationCurve> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClimbXZCurve is null) { return; }
          action.Invoke(bp.ClimbXZCurve);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAreaEffectPitVisualSettings.ClimbYCurve"/>
    /// </summary>
    public TBuilder SetClimbYCurve(AnimationCurve climbYCurve)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(climbYCurve);
          bp.ClimbYCurve = climbYCurve;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAreaEffectPitVisualSettings.ClimbYCurve"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyClimbYCurve(Action<AnimationCurve> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClimbYCurve is null) { return; }
          action.Invoke(bp.ClimbYCurve);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.UnitDisappearFx is null)
      {
        Blueprint.UnitDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.UnitAppearFx is null)
      {
        Blueprint.UnitAppearFx = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}

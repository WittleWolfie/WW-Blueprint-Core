//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintProjectileTrajectory"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseProjectileTrajectoryConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintProjectileTrajectory
    where TBuilder : BaseProjectileTrajectoryConfigurator<T, TBuilder>
  {
    protected BaseProjectileTrajectoryConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintProjectileTrajectory>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.UpDirection = copyFrom.UpDirection;
          bp.PlaneOffset = copyFrom.PlaneOffset;
          bp.UpOffset = copyFrom.UpOffset;
          bp.AmplitudeScaleByLifetime = copyFrom.AmplitudeScaleByLifetime;
          bp.AmplitudeScaleByFullDistance = copyFrom.AmplitudeScaleByFullDistance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectileTrajectory.UpDirection"/>
    /// </summary>
    public TBuilder SetUpDirection(Vector3 upDirection)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UpDirection = upDirection;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectileTrajectory.UpDirection"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUpDirection(Action<Vector3> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.UpDirection);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectileTrajectory.PlaneOffset"/>
    /// </summary>
    public TBuilder SetPlaneOffset(params TrajectoryOffset[] planeOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(planeOffset);
          bp.PlaneOffset = planeOffset;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintProjectileTrajectory.PlaneOffset"/>
    /// </summary>
    public TBuilder AddToPlaneOffset(params TrajectoryOffset[] planeOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PlaneOffset = bp.PlaneOffset ?? new TrajectoryOffset[0];
          bp.PlaneOffset = CommonTool.Append(bp.PlaneOffset, planeOffset);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProjectileTrajectory.PlaneOffset"/>
    /// </summary>
    public TBuilder RemoveFromPlaneOffset(params TrajectoryOffset[] planeOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PlaneOffset is null) { return; }
          bp.PlaneOffset = bp.PlaneOffset.Where(val => !planeOffset.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProjectileTrajectory.PlaneOffset"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPlaneOffset(Func<TrajectoryOffset, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PlaneOffset is null) { return; }
          bp.PlaneOffset = bp.PlaneOffset.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintProjectileTrajectory.PlaneOffset"/>
    /// </summary>
    public TBuilder ClearPlaneOffset()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PlaneOffset = new TrajectoryOffset[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectileTrajectory.PlaneOffset"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPlaneOffset(Action<TrajectoryOffset> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PlaneOffset is null) { return; }
          bp.PlaneOffset.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectileTrajectory.UpOffset"/>
    /// </summary>
    public TBuilder SetUpOffset(params TrajectoryOffset[] upOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(upOffset);
          bp.UpOffset = upOffset;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintProjectileTrajectory.UpOffset"/>
    /// </summary>
    public TBuilder AddToUpOffset(params TrajectoryOffset[] upOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UpOffset = bp.UpOffset ?? new TrajectoryOffset[0];
          bp.UpOffset = CommonTool.Append(bp.UpOffset, upOffset);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProjectileTrajectory.UpOffset"/>
    /// </summary>
    public TBuilder RemoveFromUpOffset(params TrajectoryOffset[] upOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UpOffset is null) { return; }
          bp.UpOffset = bp.UpOffset.Where(val => !upOffset.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProjectileTrajectory.UpOffset"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUpOffset(Func<TrajectoryOffset, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UpOffset is null) { return; }
          bp.UpOffset = bp.UpOffset.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintProjectileTrajectory.UpOffset"/>
    /// </summary>
    public TBuilder ClearUpOffset()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UpOffset = new TrajectoryOffset[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectileTrajectory.UpOffset"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUpOffset(Action<TrajectoryOffset> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UpOffset is null) { return; }
          bp.UpOffset.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectileTrajectory.AmplitudeScaleByLifetime"/>
    /// </summary>
    public TBuilder SetAmplitudeScaleByLifetime(AnimationCurve amplitudeScaleByLifetime)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(amplitudeScaleByLifetime);
          bp.AmplitudeScaleByLifetime = amplitudeScaleByLifetime;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectileTrajectory.AmplitudeScaleByLifetime"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAmplitudeScaleByLifetime(Action<AnimationCurve> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AmplitudeScaleByLifetime is null) { return; }
          action.Invoke(bp.AmplitudeScaleByLifetime);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectileTrajectory.AmplitudeScaleByFullDistance"/>
    /// </summary>
    public TBuilder SetAmplitudeScaleByFullDistance(AnimationCurve amplitudeScaleByFullDistance)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(amplitudeScaleByFullDistance);
          bp.AmplitudeScaleByFullDistance = amplitudeScaleByFullDistance;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectileTrajectory.AmplitudeScaleByFullDistance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAmplitudeScaleByFullDistance(Action<AnimationCurve> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AmplitudeScaleByFullDistance is null) { return; }
          action.Invoke(bp.AmplitudeScaleByFullDistance);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.PlaneOffset is null)
      {
        Blueprint.PlaneOffset = new TrajectoryOffset[0];
      }
      if (Blueprint.UpOffset is null)
      {
        Blueprint.UpOffset = new TrajectoryOffset[0];
      }
    }
  }
}

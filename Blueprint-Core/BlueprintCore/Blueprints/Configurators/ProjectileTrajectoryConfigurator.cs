using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintProjectileTrajectory"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintProjectileTrajectory))]
  public class ProjectileTrajectoryConfigurator : BaseBlueprintConfigurator<BlueprintProjectileTrajectory, ProjectileTrajectoryConfigurator>
  {
     private ProjectileTrajectoryConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ProjectileTrajectoryConfigurator For(string name)
    {
      return new ProjectileTrajectoryConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ProjectileTrajectoryConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintProjectileTrajectory>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ProjectileTrajectoryConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintProjectileTrajectory>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectileTrajectory.UpDirection"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator SetUpDirection(Vector3 value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.UpDirection = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectileTrajectory.PlaneOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator AddToPlaneOffset(params TrajectoryOffset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PlaneOffset = CommonTool.Append(bp.PlaneOffset, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectileTrajectory.PlaneOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator RemoveFromPlaneOffset(params TrajectoryOffset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PlaneOffset = bp.PlaneOffset.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectileTrajectory.UpOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator AddToUpOffset(params TrajectoryOffset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UpOffset = CommonTool.Append(bp.UpOffset, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectileTrajectory.UpOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator RemoveFromUpOffset(params TrajectoryOffset[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UpOffset = bp.UpOffset.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectileTrajectory.AmplitudeScaleByLifetime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator SetAmplitudeScaleByLifetime(AnimationCurve value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AmplitudeScaleByLifetime = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectileTrajectory.AmplitudeScaleByFullDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileTrajectoryConfigurator SetAmplitudeScaleByFullDistance(AnimationCurve value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AmplitudeScaleByFullDistance = value);
    }
  }
}

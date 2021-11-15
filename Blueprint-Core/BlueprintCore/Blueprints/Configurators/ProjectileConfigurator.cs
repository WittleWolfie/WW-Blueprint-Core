using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ResourceLinks;
using Kingmaker.Visual.HitSystem;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintProjectile"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintProjectile))]
  public class ProjectileConfigurator : BaseBlueprintConfigurator<BlueprintProjectile, ProjectileConfigurator>
  {
     private ProjectileConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ProjectileConfigurator For(string name)
    {
      return new ProjectileConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ProjectileConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintProjectile>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ProjectileConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintProjectile>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.Speed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetSpeed(float value)
    {
      return OnConfigureInternal(bp => bp.Speed = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.MinTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetMinTime(float value)
    {
      return OnConfigureInternal(bp => bp.MinTime = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.View"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetView(ProjectileLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.View = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.CastFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetCastFx(PrefabLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CastFx = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.CastEffectDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetCastEffectDuration(float value)
    {
      return OnConfigureInternal(bp => bp.CastEffectDuration = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.LifetimeParticlesAfterHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetLifetimeParticlesAfterHit(float value)
    {
      return OnConfigureInternal(bp => bp.LifetimeParticlesAfterHit = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.ProjectileHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetProjectileHit(ProjectileHitSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ProjectileHit = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.DamageHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetDamageHit(DamageHitSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DamageHit = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.SourceBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetSourceBone(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SourceBone = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.SourceBoneOffsetAtTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetSourceBoneOffsetAtTarget(bool value)
    {
      return OnConfigureInternal(bp => bp.SourceBoneOffsetAtTarget = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.UseSourceBoneScale"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetUseSourceBoneScale(bool value)
    {
      return OnConfigureInternal(bp => bp.UseSourceBoneScale = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.SourceBoneCorpulenceOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetSourceBoneCorpulenceOffset(float value)
    {
      return OnConfigureInternal(bp => bp.SourceBoneCorpulenceOffset = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.TargetBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetTargetBone(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TargetBone = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.TargetBoneOnCrit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetTargetBoneOnCrit(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TargetBoneOnCrit = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.TargetBoneOffsetMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetTargetBoneOffsetMultiplier(float value)
    {
      return OnConfigureInternal(bp => bp.TargetBoneOffsetMultiplier = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.FallsOnMiss"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetFallsOnMiss(bool value)
    {
      return OnConfigureInternal(bp => bp.FallsOnMiss = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.MissMinRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetMissMinRadius(float value)
    {
      return OnConfigureInternal(bp => bp.MissMinRadius = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.MissMaxRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetMissMaxRadius(float value)
    {
      return OnConfigureInternal(bp => bp.MissMaxRadius = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.MissRaycastDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetMissRaycastDistance(float value)
    {
      return OnConfigureInternal(bp => bp.MissRaycastDistance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.AddRagdollImpulse"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetAddRagdollImpulse(float value)
    {
      return OnConfigureInternal(bp => bp.AddRagdollImpulse = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.m_Trajectory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintProjectileTrajectory"/></param>
    [Generated]
    public ProjectileConfigurator SetTrajectory(string value)
    {
      return OnConfigureInternal(bp => bp.m_Trajectory = BlueprintTool.GetRef<BlueprintProjectileTrajectoryReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.FollowTerrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetFollowTerrain(bool value)
    {
      return OnConfigureInternal(bp => bp.FollowTerrain = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.StuckArrowPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetStuckArrowPrefab(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.StuckArrowPrefab = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProjectile.DeflectedArrowPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProjectileConfigurator SetDeflectedArrowPrefab(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DeflectedArrowPrefab = value);
    }

    /// <summary>
    /// Adds <see cref="CannotSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CannotSneakAttack))]
    public ProjectileConfigurator AddCannotSneakAttack()
    {
      return AddComponent(new CannotSneakAttack());
    }
  }
}

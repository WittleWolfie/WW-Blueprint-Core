//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ResourceLinks;
using Kingmaker.Visual.HitSystem;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintProjectile"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseProjectileConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintProjectile
    where TBuilder : BaseProjectileConfigurator<T, TBuilder>
  {
    protected BaseProjectileConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.Speed"/>
    /// </summary>
    public TBuilder SetSpeed(float speed)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Speed = speed;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.Speed"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpeed(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Speed);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.MinTime"/>
    /// </summary>
    public TBuilder SetMinTime(float minTime)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinTime = minTime;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.MinTime"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinTime(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinTime);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.View"/>
    /// </summary>
    public TBuilder SetView(ProjectileLink view)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(view);
          bp.View = view;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.View"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyView(Action<ProjectileLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.View is null) { return; }
          action.Invoke(bp.View);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.CastFx"/>
    /// </summary>
    public TBuilder SetCastFx(PrefabLink castFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CastFx = castFx;
          if (bp.CastFx is null)
          {
            bp.CastFx = Utils.Constants.Empty.PrefabLink;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.CastFx"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCastFx(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CastFx is null) { return; }
          action.Invoke(bp.CastFx);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.CastEffectDuration"/>
    /// </summary>
    public TBuilder SetCastEffectDuration(float castEffectDuration)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CastEffectDuration = castEffectDuration;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.CastEffectDuration"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCastEffectDuration(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CastEffectDuration);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.LifetimeParticlesAfterHit"/>
    /// </summary>
    public TBuilder SetLifetimeParticlesAfterHit(float lifetimeParticlesAfterHit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LifetimeParticlesAfterHit = lifetimeParticlesAfterHit;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.LifetimeParticlesAfterHit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLifetimeParticlesAfterHit(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.LifetimeParticlesAfterHit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.ProjectileHit"/>
    /// </summary>
    public TBuilder SetProjectileHit(ProjectileHitSettings projectileHit)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(projectileHit);
          bp.ProjectileHit = projectileHit;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.ProjectileHit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProjectileHit(Action<ProjectileHitSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ProjectileHit is null) { return; }
          action.Invoke(bp.ProjectileHit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.DamageHit"/>
    /// </summary>
    public TBuilder SetDamageHit(DamageHitSettings damageHit)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(damageHit);
          bp.DamageHit = damageHit;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.DamageHit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDamageHit(Action<DamageHitSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DamageHit is null) { return; }
          action.Invoke(bp.DamageHit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.SourceBone"/>
    /// </summary>
    public TBuilder SetSourceBone(string sourceBone)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SourceBone = sourceBone;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.SourceBone"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySourceBone(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SourceBone is null) { return; }
          action.Invoke(bp.SourceBone);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.SourceBoneOffsetAtTarget"/>
    /// </summary>
    public TBuilder SetSourceBoneOffsetAtTarget(bool sourceBoneOffsetAtTarget = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SourceBoneOffsetAtTarget = sourceBoneOffsetAtTarget;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.SourceBoneOffsetAtTarget"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySourceBoneOffsetAtTarget(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SourceBoneOffsetAtTarget);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.UseSourceBoneScale"/>
    /// </summary>
    public TBuilder SetUseSourceBoneScale(bool useSourceBoneScale = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UseSourceBoneScale = useSourceBoneScale;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.UseSourceBoneScale"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUseSourceBoneScale(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.UseSourceBoneScale);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.SourceBoneCorpulenceOffset"/>
    /// </summary>
    public TBuilder SetSourceBoneCorpulenceOffset(float sourceBoneCorpulenceOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SourceBoneCorpulenceOffset = sourceBoneCorpulenceOffset;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.SourceBoneCorpulenceOffset"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySourceBoneCorpulenceOffset(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SourceBoneCorpulenceOffset);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.TargetBone"/>
    /// </summary>
    public TBuilder SetTargetBone(string targetBone)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TargetBone = targetBone;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.TargetBone"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTargetBone(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TargetBone is null) { return; }
          action.Invoke(bp.TargetBone);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.TargetBoneOnCrit"/>
    /// </summary>
    public TBuilder SetTargetBoneOnCrit(string targetBoneOnCrit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TargetBoneOnCrit = targetBoneOnCrit;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.TargetBoneOnCrit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTargetBoneOnCrit(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TargetBoneOnCrit is null) { return; }
          action.Invoke(bp.TargetBoneOnCrit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.TargetBoneOffsetMultiplier"/>
    /// </summary>
    public TBuilder SetTargetBoneOffsetMultiplier(float targetBoneOffsetMultiplier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TargetBoneOffsetMultiplier = targetBoneOffsetMultiplier;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.TargetBoneOffsetMultiplier"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTargetBoneOffsetMultiplier(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.TargetBoneOffsetMultiplier);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.FallsOnMiss"/>
    /// </summary>
    public TBuilder SetFallsOnMiss(bool fallsOnMiss = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FallsOnMiss = fallsOnMiss;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.FallsOnMiss"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFallsOnMiss(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FallsOnMiss);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.MissMinRadius"/>
    /// </summary>
    public TBuilder SetMissMinRadius(float missMinRadius)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MissMinRadius = missMinRadius;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.MissMinRadius"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMissMinRadius(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MissMinRadius);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.MissMaxRadius"/>
    /// </summary>
    public TBuilder SetMissMaxRadius(float missMaxRadius)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MissMaxRadius = missMaxRadius;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.MissMaxRadius"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMissMaxRadius(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MissMaxRadius);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.MissRaycastDistance"/>
    /// </summary>
    public TBuilder SetMissRaycastDistance(float missRaycastDistance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MissRaycastDistance = missRaycastDistance;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.MissRaycastDistance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMissRaycastDistance(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MissRaycastDistance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.AddRagdollImpulse"/>
    /// </summary>
    public TBuilder SetAddRagdollImpulse(float addRagdollImpulse)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AddRagdollImpulse = addRagdollImpulse;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.AddRagdollImpulse"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAddRagdollImpulse(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AddRagdollImpulse);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.m_Trajectory"/>
    /// </summary>
    ///
    /// <param name="trajectory">
    /// <para>
    /// Blueprint of type BlueprintProjectileTrajectory. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTrajectory(Blueprint<BlueprintProjectileTrajectory, BlueprintProjectileTrajectoryReference> trajectory)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Trajectory = trajectory?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.m_Trajectory"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="trajectory">
    /// <para>
    /// Blueprint of type BlueprintProjectileTrajectory. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyTrajectory(Action<BlueprintProjectileTrajectoryReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Trajectory is null) { return; }
          action.Invoke(bp.m_Trajectory);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.FollowTerrain"/>
    /// </summary>
    public TBuilder SetFollowTerrain(bool followTerrain = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FollowTerrain = followTerrain;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.FollowTerrain"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFollowTerrain(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FollowTerrain);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.StuckArrowPrefab"/>
    /// </summary>
    public TBuilder SetStuckArrowPrefab(GameObject stuckArrowPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(stuckArrowPrefab);
          bp.StuckArrowPrefab = stuckArrowPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.StuckArrowPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStuckArrowPrefab(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StuckArrowPrefab is null) { return; }
          action.Invoke(bp.StuckArrowPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProjectile.DeflectedArrowPrefab"/>
    /// </summary>
    public TBuilder SetDeflectedArrowPrefab(GameObject deflectedArrowPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(deflectedArrowPrefab);
          bp.DeflectedArrowPrefab = deflectedArrowPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProjectile.DeflectedArrowPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDeflectedArrowPrefab(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DeflectedArrowPrefab is null) { return; }
          action.Invoke(bp.DeflectedArrowPrefab);
        });
    }

    /// <summary>
    /// Adds <see cref="CannotSneakAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MagicMissile01</term><description>741743ccd287a854fbb68ce70f75fa05</description></item>
    /// <item><term>MagicMissile03</term><description>caadaf27d789793459a3e32cb0615d14</description></item>
    /// <item><term>MagicMissile04</term><description>43295b5988021f741a28b8bf0424a412</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddCannotSneakAttack()
    {
      return AddComponent(new CannotSneakAttack());
    }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
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
    protected BaseProjectileConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintProjectile>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Speed = copyFrom.Speed;
          bp.MinTime = copyFrom.MinTime;
          bp.View = copyFrom.View;
          bp.CastFx = copyFrom.CastFx;
          bp.CastEffectDuration = copyFrom.CastEffectDuration;
          bp.LifetimeParticlesAfterHit = copyFrom.LifetimeParticlesAfterHit;
          bp.ProjectileHit = copyFrom.ProjectileHit;
          bp.DamageHit = copyFrom.DamageHit;
          bp.SourceBone = copyFrom.SourceBone;
          bp.SourceBoneOffsetAtTarget = copyFrom.SourceBoneOffsetAtTarget;
          bp.UseSourceBoneScale = copyFrom.UseSourceBoneScale;
          bp.SourceBoneCorpulenceOffset = copyFrom.SourceBoneCorpulenceOffset;
          bp.TargetBone = copyFrom.TargetBone;
          bp.TargetBoneOnCrit = copyFrom.TargetBoneOnCrit;
          bp.TargetBoneOffsetMultiplier = copyFrom.TargetBoneOffsetMultiplier;
          bp.FallsOnMiss = copyFrom.FallsOnMiss;
          bp.MissMinRadius = copyFrom.MissMinRadius;
          bp.MissMaxRadius = copyFrom.MissMaxRadius;
          bp.MissRaycastDistance = copyFrom.MissRaycastDistance;
          bp.AddRagdollImpulse = copyFrom.AddRagdollImpulse;
          bp.m_Trajectory = copyFrom.m_Trajectory;
          bp.FollowTerrain = copyFrom.FollowTerrain;
          bp.StuckArrowPrefab = copyFrom.StuckArrowPrefab;
          bp.DeflectedArrowPrefab = copyFrom.DeflectedArrowPrefab;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintProjectile>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Speed = copyFrom.Speed;
          bp.MinTime = copyFrom.MinTime;
          bp.View = copyFrom.View;
          bp.CastFx = copyFrom.CastFx;
          bp.CastEffectDuration = copyFrom.CastEffectDuration;
          bp.LifetimeParticlesAfterHit = copyFrom.LifetimeParticlesAfterHit;
          bp.ProjectileHit = copyFrom.ProjectileHit;
          bp.DamageHit = copyFrom.DamageHit;
          bp.SourceBone = copyFrom.SourceBone;
          bp.SourceBoneOffsetAtTarget = copyFrom.SourceBoneOffsetAtTarget;
          bp.UseSourceBoneScale = copyFrom.UseSourceBoneScale;
          bp.SourceBoneCorpulenceOffset = copyFrom.SourceBoneCorpulenceOffset;
          bp.TargetBone = copyFrom.TargetBone;
          bp.TargetBoneOnCrit = copyFrom.TargetBoneOnCrit;
          bp.TargetBoneOffsetMultiplier = copyFrom.TargetBoneOffsetMultiplier;
          bp.FallsOnMiss = copyFrom.FallsOnMiss;
          bp.MissMinRadius = copyFrom.MissMinRadius;
          bp.MissMaxRadius = copyFrom.MissMaxRadius;
          bp.MissRaycastDistance = copyFrom.MissRaycastDistance;
          bp.AddRagdollImpulse = copyFrom.AddRagdollImpulse;
          bp.m_Trajectory = copyFrom.m_Trajectory;
          bp.FollowTerrain = copyFrom.FollowTerrain;
          bp.StuckArrowPrefab = copyFrom.StuckArrowPrefab;
          bp.DeflectedArrowPrefab = copyFrom.DeflectedArrowPrefab;
        });
    }

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
    /// Sets the value of <see cref="BlueprintProjectile.View"/>
    /// </summary>
    ///
    /// <param name="view">
    /// You can pass in the animation using a ProjectileLink or it's AssetId.
    /// </param>
    public TBuilder SetView(AssetLink<ProjectileLink> view)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.View = view?.Get();
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
    ///
    /// <param name="castFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetCastFx(AssetLink<PrefabLink> castFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CastFx = castFx?.Get();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTrajectory(Blueprint<BlueprintProjectileTrajectoryReference> trajectory)
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
    /// Sets the value of <see cref="BlueprintProjectile.StuckArrowPrefab"/>
    /// </summary>
    ///
    /// <param name="stuckArrowPrefab">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    public TBuilder SetStuckArrowPrefab(Asset<GameObject> stuckArrowPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StuckArrowPrefab = stuckArrowPrefab?.Get();
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
    ///
    /// <param name="deflectedArrowPrefab">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    public TBuilder SetDeflectedArrowPrefab(Asset<GameObject> deflectedArrowPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeflectedArrowPrefab = deflectedArrowPrefab?.Get();
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCannotSneakAttack(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new CannotSneakAttack();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.CastFx is null)
      {
        Blueprint.CastFx = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.m_Trajectory is null)
      {
        Blueprint.m_Trajectory = BlueprintTool.GetRef<BlueprintProjectileTrajectoryReference>(null);
      }
    }
  }
}

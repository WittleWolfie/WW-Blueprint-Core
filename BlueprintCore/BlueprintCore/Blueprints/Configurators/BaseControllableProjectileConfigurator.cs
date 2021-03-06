//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintControllableProjectile"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseControllableProjectileConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintControllableProjectile
    where TBuilder : BaseControllableProjectileConfigurator<T, TBuilder>
  {
    protected BaseControllableProjectileConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintControllableProjectile.m_OnCreatureCastPrefab"/>
    /// </summary>
    public TBuilder SetOnCreatureCastPrefab(PrefabLink onCreatureCastPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OnCreatureCastPrefab = onCreatureCastPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintControllableProjectile.m_OnCreatureCastPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnCreatureCastPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OnCreatureCastPrefab is null) { return; }
          action.Invoke(bp.m_OnCreatureCastPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintControllableProjectile.m_OnCreaturePrefab"/>
    /// </summary>
    public TBuilder SetOnCreaturePrefab(PrefabLink onCreaturePrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OnCreaturePrefab = onCreaturePrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintControllableProjectile.m_OnCreaturePrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnCreaturePrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OnCreaturePrefab is null) { return; }
          action.Invoke(bp.m_OnCreaturePrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintControllableProjectile.m_HeightOffset"/>
    /// </summary>
    public TBuilder SetHeightOffset(float heightOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HeightOffset = heightOffset;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintControllableProjectile.m_RotationLifetime"/>
    /// </summary>
    public TBuilder SetRotationLifetime(float rotationLifetime)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RotationLifetime = rotationLifetime;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintControllableProjectile.m_RotationCurve"/>
    /// </summary>
    public TBuilder SetRotationCurve(AnimationCurve rotationCurve)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(rotationCurve);
          bp.m_RotationCurve = rotationCurve;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintControllableProjectile.m_RotationCurve"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRotationCurve(Action<AnimationCurve> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RotationCurve is null) { return; }
          action.Invoke(bp.m_RotationCurve);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintControllableProjectile.m_PreparationStartSound"/>
    /// </summary>
    public TBuilder SetPreparationStartSound(string preparationStartSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PreparationStartSound = preparationStartSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintControllableProjectile.m_PreparationStartSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPreparationStartSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PreparationStartSound is null) { return; }
          action.Invoke(bp.m_PreparationStartSound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintControllableProjectile.m_PreparationEndSound"/>
    /// </summary>
    public TBuilder SetPreparationEndSound(string preparationEndSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PreparationEndSound = preparationEndSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintControllableProjectile.m_PreparationEndSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPreparationEndSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PreparationEndSound is null) { return; }
          action.Invoke(bp.m_PreparationEndSound);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_OnCreatureCastPrefab is null)
      {
        Blueprint.m_OnCreatureCastPrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.m_OnCreaturePrefab is null)
      {
        Blueprint.m_OnCreaturePrefab = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}

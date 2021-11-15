using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintControllableProjectile"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintControllableProjectile))]
  public class ControllableProjectileConfigurator : BaseBlueprintConfigurator<BlueprintControllableProjectile, ControllableProjectileConfigurator>
  {
     private ControllableProjectileConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ControllableProjectileConfigurator For(string name)
    {
      return new ControllableProjectileConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ControllableProjectileConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintControllableProjectile>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ControllableProjectileConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintControllableProjectile>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_OnCreatureCastPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetOnCreatureCastPrefab(PrefabLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_OnCreatureCastPrefab = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_OnCreaturePrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetOnCreaturePrefab(PrefabLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_OnCreaturePrefab = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_HeightOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetHeightOffset(float value)
    {
      return OnConfigureInternal(bp => bp.m_HeightOffset = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_RotationLifetime"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetRotationLifetime(float value)
    {
      return OnConfigureInternal(bp => bp.m_RotationLifetime = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_RotationCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetRotationCurve(AnimationCurve value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_RotationCurve = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_PreparationStartSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetPreparationStartSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_PreparationStartSound = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintControllableProjectile.m_PreparationEndSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ControllableProjectileConfigurator SetPreparationEndSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_PreparationEndSound = value);
    }
  }
}

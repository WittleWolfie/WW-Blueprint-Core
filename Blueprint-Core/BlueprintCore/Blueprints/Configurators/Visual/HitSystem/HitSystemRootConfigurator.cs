using BlueprintCore.Utils;
using Kingmaker.Visual.HitSystem;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Visual.HitSystem
{
  /// <summary>Configurator for <see cref="HitSystemRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(HitSystemRoot))]
  public class HitSystemRootConfigurator : BaseBlueprintConfigurator<HitSystemRoot, HitSystemRootConfigurator>
  {
     private HitSystemRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HitSystemRootConfigurator For(string name)
    {
      return new HitSystemRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static HitSystemRootConfigurator New(string name)
    {
      BlueprintTool.Create<HitSystemRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HitSystemRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<HitSystemRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.DamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToDamageTypes(params DamageEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DamageTypes = CommonTool.Append(bp.DamageTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.DamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromDamageTypes(params DamageEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.DamageTypes = bp.DamageTypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.EnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToEnergyTypes(params EnergyEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.EnergyTypes = CommonTool.Append(bp.EnergyTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.EnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromEnergyTypes(params EnergyEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.EnergyTypes = bp.EnergyTypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.BloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToBloodTypes(params BloodEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.BloodTypes = CommonTool.Append(bp.BloodTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.BloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromBloodTypes(params BloodEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.BloodTypes = bp.BloodTypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.DefaultDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetDefaultDamage(DamageHitSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultDamage = value);
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.DefaultAoeDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetDefaultAoeDamage(DamageHitSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DefaultAoeDamage = value);
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToOverrideHitDirectionPrefabFromAnimationStyle(params BloodPrefabsFromWeaponAnimationStyleEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.OverrideHitDirectionPrefabFromAnimationStyle = CommonTool.Append(bp.OverrideHitDirectionPrefabFromAnimationStyle, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromOverrideHitDirectionPrefabFromAnimationStyle(params BloodPrefabsFromWeaponAnimationStyleEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.OverrideHitDirectionPrefabFromAnimationStyle = bp.OverrideHitDirectionPrefabFromAnimationStyle.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.MaxHeightIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetMaxHeightIncrease(float value)
    {
      return OnConfigureInternal(bp => bp.MaxHeightIncrease = value);
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.EnergyResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetEnergyResistance(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.EnergyResistance = value);
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.RagdollDistanceForLootBag"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetRagdollDistanceForLootBag(float value)
    {
      return OnConfigureInternal(bp => bp.RagdollDistanceForLootBag = value);
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.BlowUpDismembermentChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetBlowUpDismembermentChance(float value)
    {
      return OnConfigureInternal(bp => bp.BlowUpDismembermentChance = value);
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.LimbsApartDismembermentChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetLimbsApartDismembermentChance(float value)
    {
      return OnConfigureInternal(bp => bp.LimbsApartDismembermentChance = value);
    }

    /// <summary>
    /// Sets <see cref="HitSystemRoot.m_Initialized"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator SetInitialized(bool value)
    {
      return OnConfigureInternal(bp => bp.m_Initialized = value);
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedDamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedDamageTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedDamageTypes = CommonTool.Append(bp.m_CachedDamageTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedDamageTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedDamageTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedDamageTypes = bp.m_CachedDamageTypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedEnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedEnergyTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedEnergyTypes = CommonTool.Append(bp.m_CachedEnergyTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedEnergyTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedEnergyTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedEnergyTypes = bp.m_CachedEnergyTypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedBillboardBloodTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedBillboardBloodTypes = CommonTool.Append(bp.m_CachedBillboardBloodTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedBillboardBloodTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedBillboardBloodTypes = bp.m_CachedBillboardBloodTypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedDirectionalBloodTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedDirectionalBloodTypes = CommonTool.Append(bp.m_CachedDirectionalBloodTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedDirectionalBloodTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedDirectionalBloodTypes = bp.m_CachedDirectionalBloodTypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedBillboardAdditiveBloodTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedBillboardAdditiveBloodTypes = CommonTool.Append(bp.m_CachedBillboardAdditiveBloodTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedBillboardAdditiveBloodTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedBillboardAdditiveBloodTypes = bp.m_CachedBillboardAdditiveBloodTypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedDirectionalAdditiveBloodTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedDirectionalAdditiveBloodTypes = CommonTool.Append(bp.m_CachedDirectionalAdditiveBloodTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedDirectionalAdditiveBloodTypes(params HitCollection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedDirectionalAdditiveBloodTypes = bp.m_CachedDirectionalAdditiveBloodTypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator AddToCachedBloodPrefabsFromWeaponAnimationStyleEntries(params BloodPrefabsFromWeaponAnimationStyleEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = CommonTool.Append(bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries, values));
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HitSystemRootConfigurator RemoveFromCachedBloodPrefabsFromWeaponAnimationStyleEntries(params BloodPrefabsFromWeaponAnimationStyleEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries.Where(item => !values.Contains(item)).ToArray());
    }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using Kingmaker.Visual.HitSystem;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Visual
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="HitSystemRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHitSystemRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : HitSystemRoot
    where TBuilder : BaseHitSystemRootConfigurator<T, TBuilder>
  {
    protected BaseHitSystemRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.DamageTypes"/>
    /// </summary>
    public TBuilder SetDamageTypes(params DamageEntry[] damageTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(damageTypes);
          bp.DamageTypes = damageTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.DamageTypes"/>
    /// </summary>
    public TBuilder AddToDamageTypes(params DamageEntry[] damageTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DamageTypes = bp.DamageTypes ?? new DamageEntry[0];
          bp.DamageTypes = CommonTool.Append(bp.DamageTypes, damageTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.DamageTypes"/>
    /// </summary>
    public TBuilder RemoveFromDamageTypes(params DamageEntry[] damageTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DamageTypes is null) { return; }
          bp.DamageTypes = bp.DamageTypes.Where(val => !damageTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.DamageTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDamageTypes(Func<DamageEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DamageTypes is null) { return; }
          bp.DamageTypes = bp.DamageTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.DamageTypes"/>
    /// </summary>
    public TBuilder ClearDamageTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DamageTypes = new DamageEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.DamageTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDamageTypes(Action<DamageEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DamageTypes is null) { return; }
          bp.DamageTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.EnergyTypes"/>
    /// </summary>
    public TBuilder SetEnergyTypes(params EnergyEntry[] energyTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(energyTypes);
          bp.EnergyTypes = energyTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.EnergyTypes"/>
    /// </summary>
    public TBuilder AddToEnergyTypes(params EnergyEntry[] energyTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EnergyTypes = bp.EnergyTypes ?? new EnergyEntry[0];
          bp.EnergyTypes = CommonTool.Append(bp.EnergyTypes, energyTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.EnergyTypes"/>
    /// </summary>
    public TBuilder RemoveFromEnergyTypes(params EnergyEntry[] energyTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EnergyTypes is null) { return; }
          bp.EnergyTypes = bp.EnergyTypes.Where(val => !energyTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.EnergyTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEnergyTypes(Func<EnergyEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EnergyTypes is null) { return; }
          bp.EnergyTypes = bp.EnergyTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.EnergyTypes"/>
    /// </summary>
    public TBuilder ClearEnergyTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EnergyTypes = new EnergyEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.EnergyTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEnergyTypes(Action<EnergyEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EnergyTypes is null) { return; }
          bp.EnergyTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.BloodTypes"/>
    /// </summary>
    public TBuilder SetBloodTypes(params BloodEntry[] bloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(bloodTypes);
          bp.BloodTypes = bloodTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.BloodTypes"/>
    /// </summary>
    public TBuilder AddToBloodTypes(params BloodEntry[] bloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BloodTypes = bp.BloodTypes ?? new BloodEntry[0];
          bp.BloodTypes = CommonTool.Append(bp.BloodTypes, bloodTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.BloodTypes"/>
    /// </summary>
    public TBuilder RemoveFromBloodTypes(params BloodEntry[] bloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BloodTypes is null) { return; }
          bp.BloodTypes = bp.BloodTypes.Where(val => !bloodTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.BloodTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBloodTypes(Func<BloodEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BloodTypes is null) { return; }
          bp.BloodTypes = bp.BloodTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.BloodTypes"/>
    /// </summary>
    public TBuilder ClearBloodTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BloodTypes = new BloodEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.BloodTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBloodTypes(Action<BloodEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BloodTypes is null) { return; }
          bp.BloodTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.DefaultDamage"/>
    /// </summary>
    public TBuilder SetDefaultDamage(DamageHitSettings defaultDamage)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(defaultDamage);
          bp.DefaultDamage = defaultDamage;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.DefaultDamage"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultDamage(Action<DamageHitSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DefaultDamage is null) { return; }
          action.Invoke(bp.DefaultDamage);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.DefaultAoeDamage"/>
    /// </summary>
    public TBuilder SetDefaultAoeDamage(DamageHitSettings defaultAoeDamage)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(defaultAoeDamage);
          bp.DefaultAoeDamage = defaultAoeDamage;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.DefaultAoeDamage"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultAoeDamage(Action<DamageHitSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DefaultAoeDamage is null) { return; }
          action.Invoke(bp.DefaultAoeDamage);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/>
    /// </summary>
    public TBuilder SetOverrideHitDirectionPrefabFromAnimationStyle(params BloodPrefabsFromWeaponAnimationStyleEntry[] overrideHitDirectionPrefabFromAnimationStyle)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(overrideHitDirectionPrefabFromAnimationStyle);
          bp.OverrideHitDirectionPrefabFromAnimationStyle = overrideHitDirectionPrefabFromAnimationStyle;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/>
    /// </summary>
    public TBuilder AddToOverrideHitDirectionPrefabFromAnimationStyle(params BloodPrefabsFromWeaponAnimationStyleEntry[] overrideHitDirectionPrefabFromAnimationStyle)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideHitDirectionPrefabFromAnimationStyle = bp.OverrideHitDirectionPrefabFromAnimationStyle ?? new BloodPrefabsFromWeaponAnimationStyleEntry[0];
          bp.OverrideHitDirectionPrefabFromAnimationStyle = CommonTool.Append(bp.OverrideHitDirectionPrefabFromAnimationStyle, overrideHitDirectionPrefabFromAnimationStyle);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/>
    /// </summary>
    public TBuilder RemoveFromOverrideHitDirectionPrefabFromAnimationStyle(params BloodPrefabsFromWeaponAnimationStyleEntry[] overrideHitDirectionPrefabFromAnimationStyle)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverrideHitDirectionPrefabFromAnimationStyle is null) { return; }
          bp.OverrideHitDirectionPrefabFromAnimationStyle = bp.OverrideHitDirectionPrefabFromAnimationStyle.Where(val => !overrideHitDirectionPrefabFromAnimationStyle.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromOverrideHitDirectionPrefabFromAnimationStyle(Func<BloodPrefabsFromWeaponAnimationStyleEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverrideHitDirectionPrefabFromAnimationStyle is null) { return; }
          bp.OverrideHitDirectionPrefabFromAnimationStyle = bp.OverrideHitDirectionPrefabFromAnimationStyle.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/>
    /// </summary>
    public TBuilder ClearOverrideHitDirectionPrefabFromAnimationStyle()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideHitDirectionPrefabFromAnimationStyle = new BloodPrefabsFromWeaponAnimationStyleEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.OverrideHitDirectionPrefabFromAnimationStyle"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyOverrideHitDirectionPrefabFromAnimationStyle(Action<BloodPrefabsFromWeaponAnimationStyleEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverrideHitDirectionPrefabFromAnimationStyle is null) { return; }
          bp.OverrideHitDirectionPrefabFromAnimationStyle.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.MaxHeightIncrease"/>
    /// </summary>
    public TBuilder SetMaxHeightIncrease(float maxHeightIncrease)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxHeightIncrease = maxHeightIncrease;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.MaxHeightIncrease"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxHeightIncrease(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxHeightIncrease);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.EnergyResistance"/>
    /// </summary>
    public TBuilder SetEnergyResistance(GameObject energyResistance)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(energyResistance);
          bp.EnergyResistance = energyResistance;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.EnergyResistance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEnergyResistance(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EnergyResistance is null) { return; }
          action.Invoke(bp.EnergyResistance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.RagdollDistanceForLootBag"/>
    /// </summary>
    public TBuilder SetRagdollDistanceForLootBag(float ragdollDistanceForLootBag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RagdollDistanceForLootBag = ragdollDistanceForLootBag;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.RagdollDistanceForLootBag"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRagdollDistanceForLootBag(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.RagdollDistanceForLootBag);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.BlowUpDismembermentChance"/>
    /// </summary>
    public TBuilder SetBlowUpDismembermentChance(float blowUpDismembermentChance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BlowUpDismembermentChance = blowUpDismembermentChance;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.BlowUpDismembermentChance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBlowUpDismembermentChance(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BlowUpDismembermentChance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.LimbsApartDismembermentChance"/>
    /// </summary>
    public TBuilder SetLimbsApartDismembermentChance(float limbsApartDismembermentChance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LimbsApartDismembermentChance = limbsApartDismembermentChance;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.LimbsApartDismembermentChance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLimbsApartDismembermentChance(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.LimbsApartDismembermentChance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.m_Initialized"/>
    /// </summary>
    public TBuilder SetInitialized(bool initialized = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Initialized = initialized;
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_Initialized"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInitialized(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Initialized);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.m_CachedDamageTypes"/>
    /// </summary>
    public TBuilder SetCachedDamageTypes(params HitCollection[] cachedDamageTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cachedDamageTypes);
          bp.m_CachedDamageTypes = cachedDamageTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.m_CachedDamageTypes"/>
    /// </summary>
    public TBuilder AddToCachedDamageTypes(params HitCollection[] cachedDamageTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedDamageTypes = bp.m_CachedDamageTypes ?? new HitCollection[0];
          bp.m_CachedDamageTypes = CommonTool.Append(bp.m_CachedDamageTypes, cachedDamageTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedDamageTypes"/>
    /// </summary>
    public TBuilder RemoveFromCachedDamageTypes(params HitCollection[] cachedDamageTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedDamageTypes is null) { return; }
          bp.m_CachedDamageTypes = bp.m_CachedDamageTypes.Where(val => !cachedDamageTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedDamageTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCachedDamageTypes(Func<HitCollection, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedDamageTypes is null) { return; }
          bp.m_CachedDamageTypes = bp.m_CachedDamageTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.m_CachedDamageTypes"/>
    /// </summary>
    public TBuilder ClearCachedDamageTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedDamageTypes = new HitCollection[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedDamageTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCachedDamageTypes(Action<HitCollection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedDamageTypes is null) { return; }
          bp.m_CachedDamageTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.m_CachedEnergyTypes"/>
    /// </summary>
    public TBuilder SetCachedEnergyTypes(params HitCollection[] cachedEnergyTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cachedEnergyTypes);
          bp.m_CachedEnergyTypes = cachedEnergyTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.m_CachedEnergyTypes"/>
    /// </summary>
    public TBuilder AddToCachedEnergyTypes(params HitCollection[] cachedEnergyTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedEnergyTypes = bp.m_CachedEnergyTypes ?? new HitCollection[0];
          bp.m_CachedEnergyTypes = CommonTool.Append(bp.m_CachedEnergyTypes, cachedEnergyTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedEnergyTypes"/>
    /// </summary>
    public TBuilder RemoveFromCachedEnergyTypes(params HitCollection[] cachedEnergyTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedEnergyTypes is null) { return; }
          bp.m_CachedEnergyTypes = bp.m_CachedEnergyTypes.Where(val => !cachedEnergyTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedEnergyTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCachedEnergyTypes(Func<HitCollection, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedEnergyTypes is null) { return; }
          bp.m_CachedEnergyTypes = bp.m_CachedEnergyTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.m_CachedEnergyTypes"/>
    /// </summary>
    public TBuilder ClearCachedEnergyTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedEnergyTypes = new HitCollection[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedEnergyTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCachedEnergyTypes(Action<HitCollection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedEnergyTypes is null) { return; }
          bp.m_CachedEnergyTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/>
    /// </summary>
    public TBuilder SetCachedBillboardBloodTypes(params HitCollection[] cachedBillboardBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cachedBillboardBloodTypes);
          bp.m_CachedBillboardBloodTypes = cachedBillboardBloodTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/>
    /// </summary>
    public TBuilder AddToCachedBillboardBloodTypes(params HitCollection[] cachedBillboardBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedBillboardBloodTypes = bp.m_CachedBillboardBloodTypes ?? new HitCollection[0];
          bp.m_CachedBillboardBloodTypes = CommonTool.Append(bp.m_CachedBillboardBloodTypes, cachedBillboardBloodTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/>
    /// </summary>
    public TBuilder RemoveFromCachedBillboardBloodTypes(params HitCollection[] cachedBillboardBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedBillboardBloodTypes is null) { return; }
          bp.m_CachedBillboardBloodTypes = bp.m_CachedBillboardBloodTypes.Where(val => !cachedBillboardBloodTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCachedBillboardBloodTypes(Func<HitCollection, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedBillboardBloodTypes is null) { return; }
          bp.m_CachedBillboardBloodTypes = bp.m_CachedBillboardBloodTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/>
    /// </summary>
    public TBuilder ClearCachedBillboardBloodTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedBillboardBloodTypes = new HitCollection[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedBillboardBloodTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCachedBillboardBloodTypes(Action<HitCollection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedBillboardBloodTypes is null) { return; }
          bp.m_CachedBillboardBloodTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/>
    /// </summary>
    public TBuilder SetCachedDirectionalBloodTypes(params HitCollection[] cachedDirectionalBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cachedDirectionalBloodTypes);
          bp.m_CachedDirectionalBloodTypes = cachedDirectionalBloodTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/>
    /// </summary>
    public TBuilder AddToCachedDirectionalBloodTypes(params HitCollection[] cachedDirectionalBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedDirectionalBloodTypes = bp.m_CachedDirectionalBloodTypes ?? new HitCollection[0];
          bp.m_CachedDirectionalBloodTypes = CommonTool.Append(bp.m_CachedDirectionalBloodTypes, cachedDirectionalBloodTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/>
    /// </summary>
    public TBuilder RemoveFromCachedDirectionalBloodTypes(params HitCollection[] cachedDirectionalBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedDirectionalBloodTypes is null) { return; }
          bp.m_CachedDirectionalBloodTypes = bp.m_CachedDirectionalBloodTypes.Where(val => !cachedDirectionalBloodTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCachedDirectionalBloodTypes(Func<HitCollection, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedDirectionalBloodTypes is null) { return; }
          bp.m_CachedDirectionalBloodTypes = bp.m_CachedDirectionalBloodTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/>
    /// </summary>
    public TBuilder ClearCachedDirectionalBloodTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedDirectionalBloodTypes = new HitCollection[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedDirectionalBloodTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCachedDirectionalBloodTypes(Action<HitCollection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedDirectionalBloodTypes is null) { return; }
          bp.m_CachedDirectionalBloodTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/>
    /// </summary>
    public TBuilder SetCachedBillboardAdditiveBloodTypes(params HitCollection[] cachedBillboardAdditiveBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cachedBillboardAdditiveBloodTypes);
          bp.m_CachedBillboardAdditiveBloodTypes = cachedBillboardAdditiveBloodTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/>
    /// </summary>
    public TBuilder AddToCachedBillboardAdditiveBloodTypes(params HitCollection[] cachedBillboardAdditiveBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedBillboardAdditiveBloodTypes = bp.m_CachedBillboardAdditiveBloodTypes ?? new HitCollection[0];
          bp.m_CachedBillboardAdditiveBloodTypes = CommonTool.Append(bp.m_CachedBillboardAdditiveBloodTypes, cachedBillboardAdditiveBloodTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/>
    /// </summary>
    public TBuilder RemoveFromCachedBillboardAdditiveBloodTypes(params HitCollection[] cachedBillboardAdditiveBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedBillboardAdditiveBloodTypes is null) { return; }
          bp.m_CachedBillboardAdditiveBloodTypes = bp.m_CachedBillboardAdditiveBloodTypes.Where(val => !cachedBillboardAdditiveBloodTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCachedBillboardAdditiveBloodTypes(Func<HitCollection, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedBillboardAdditiveBloodTypes is null) { return; }
          bp.m_CachedBillboardAdditiveBloodTypes = bp.m_CachedBillboardAdditiveBloodTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/>
    /// </summary>
    public TBuilder ClearCachedBillboardAdditiveBloodTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedBillboardAdditiveBloodTypes = new HitCollection[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedBillboardAdditiveBloodTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCachedBillboardAdditiveBloodTypes(Action<HitCollection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedBillboardAdditiveBloodTypes is null) { return; }
          bp.m_CachedBillboardAdditiveBloodTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/>
    /// </summary>
    public TBuilder SetCachedDirectionalAdditiveBloodTypes(params HitCollection[] cachedDirectionalAdditiveBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cachedDirectionalAdditiveBloodTypes);
          bp.m_CachedDirectionalAdditiveBloodTypes = cachedDirectionalAdditiveBloodTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/>
    /// </summary>
    public TBuilder AddToCachedDirectionalAdditiveBloodTypes(params HitCollection[] cachedDirectionalAdditiveBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedDirectionalAdditiveBloodTypes = bp.m_CachedDirectionalAdditiveBloodTypes ?? new HitCollection[0];
          bp.m_CachedDirectionalAdditiveBloodTypes = CommonTool.Append(bp.m_CachedDirectionalAdditiveBloodTypes, cachedDirectionalAdditiveBloodTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/>
    /// </summary>
    public TBuilder RemoveFromCachedDirectionalAdditiveBloodTypes(params HitCollection[] cachedDirectionalAdditiveBloodTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedDirectionalAdditiveBloodTypes is null) { return; }
          bp.m_CachedDirectionalAdditiveBloodTypes = bp.m_CachedDirectionalAdditiveBloodTypes.Where(val => !cachedDirectionalAdditiveBloodTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCachedDirectionalAdditiveBloodTypes(Func<HitCollection, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedDirectionalAdditiveBloodTypes is null) { return; }
          bp.m_CachedDirectionalAdditiveBloodTypes = bp.m_CachedDirectionalAdditiveBloodTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/>
    /// </summary>
    public TBuilder ClearCachedDirectionalAdditiveBloodTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedDirectionalAdditiveBloodTypes = new HitCollection[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedDirectionalAdditiveBloodTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCachedDirectionalAdditiveBloodTypes(Action<HitCollection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedDirectionalAdditiveBloodTypes is null) { return; }
          bp.m_CachedDirectionalAdditiveBloodTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/>
    /// </summary>
    public TBuilder SetCachedBloodPrefabsFromWeaponAnimationStyleEntries(params BloodPrefabsFromWeaponAnimationStyleEntry[] cachedBloodPrefabsFromWeaponAnimationStyleEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(cachedBloodPrefabsFromWeaponAnimationStyleEntries);
          bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = cachedBloodPrefabsFromWeaponAnimationStyleEntries;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/>
    /// </summary>
    public TBuilder AddToCachedBloodPrefabsFromWeaponAnimationStyleEntries(params BloodPrefabsFromWeaponAnimationStyleEntry[] cachedBloodPrefabsFromWeaponAnimationStyleEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries ?? new BloodPrefabsFromWeaponAnimationStyleEntry[0];
          bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = CommonTool.Append(bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries, cachedBloodPrefabsFromWeaponAnimationStyleEntries);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/>
    /// </summary>
    public TBuilder RemoveFromCachedBloodPrefabsFromWeaponAnimationStyleEntries(params BloodPrefabsFromWeaponAnimationStyleEntry[] cachedBloodPrefabsFromWeaponAnimationStyleEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries is null) { return; }
          bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries.Where(val => !cachedBloodPrefabsFromWeaponAnimationStyleEntries.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCachedBloodPrefabsFromWeaponAnimationStyleEntries(Func<BloodPrefabsFromWeaponAnimationStyleEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries is null) { return; }
          bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/>
    /// </summary>
    public TBuilder ClearCachedBloodPrefabsFromWeaponAnimationStyleEntries()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = new BloodPrefabsFromWeaponAnimationStyleEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="HitSystemRoot.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCachedBloodPrefabsFromWeaponAnimationStyleEntries(Action<BloodPrefabsFromWeaponAnimationStyleEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries is null) { return; }
          bp.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries.ForEach(action);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.DamageTypes is null)
      {
        Blueprint.DamageTypes = new DamageEntry[0];
      }
      if (Blueprint.EnergyTypes is null)
      {
        Blueprint.EnergyTypes = new EnergyEntry[0];
      }
      if (Blueprint.BloodTypes is null)
      {
        Blueprint.BloodTypes = new BloodEntry[0];
      }
      if (Blueprint.OverrideHitDirectionPrefabFromAnimationStyle is null)
      {
        Blueprint.OverrideHitDirectionPrefabFromAnimationStyle = new BloodPrefabsFromWeaponAnimationStyleEntry[0];
      }
      if (Blueprint.m_CachedDamageTypes is null)
      {
        Blueprint.m_CachedDamageTypes = new HitCollection[0];
      }
      if (Blueprint.m_CachedEnergyTypes is null)
      {
        Blueprint.m_CachedEnergyTypes = new HitCollection[0];
      }
      if (Blueprint.m_CachedBillboardBloodTypes is null)
      {
        Blueprint.m_CachedBillboardBloodTypes = new HitCollection[0];
      }
      if (Blueprint.m_CachedDirectionalBloodTypes is null)
      {
        Blueprint.m_CachedDirectionalBloodTypes = new HitCollection[0];
      }
      if (Blueprint.m_CachedBillboardAdditiveBloodTypes is null)
      {
        Blueprint.m_CachedBillboardAdditiveBloodTypes = new HitCollection[0];
      }
      if (Blueprint.m_CachedDirectionalAdditiveBloodTypes is null)
      {
        Blueprint.m_CachedDirectionalAdditiveBloodTypes = new HitCollection[0];
      }
      if (Blueprint.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries is null)
      {
        Blueprint.m_CachedBloodPrefabsFromWeaponAnimationStyleEntries = new BloodPrefabsFromWeaponAnimationStyleEntry[0];
      }
    }
  }
}

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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
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
    }
  }
}

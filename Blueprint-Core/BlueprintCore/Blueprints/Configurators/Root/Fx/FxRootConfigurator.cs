using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Blueprints.Root.Fx;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Root.Fx
{
  /// <summary>Configurator for <see cref="FxRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(FxRoot))]
  public class FxRootConfigurator : BaseBlueprintConfigurator<FxRoot, FxRootConfigurator>
  {
     private FxRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FxRootConfigurator For(string name)
    {
      return new FxRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FxRootConfigurator New(string name)
    {
      BlueprintTool.Create<FxRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FxRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<FxRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_SingleHandCasts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="CastsGroup"/></param>
    [Generated]
    public FxRootConfigurator SetSingleHandCasts(string value)
    {
      return OnConfigureInternal(bp => bp.m_SingleHandCasts = BlueprintTool.GetRef<CastsGroup.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_DoubleHandCasts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="CastsGroup"/></param>
    [Generated]
    public FxRootConfigurator SetDoubleHandCasts(string value)
    {
      return OnConfigureInternal(bp => bp.m_DoubleHandCasts = BlueprintTool.GetRef<CastsGroup.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_HeadCasts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="CastsGroup"/></param>
    [Generated]
    public FxRootConfigurator SetHeadCasts(string value)
    {
      return OnConfigureInternal(bp => bp.m_HeadCasts = BlueprintTool.GetRef<CastsGroup.Reference>(value));
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_TorsoCasts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="CastsGroup"/></param>
    [Generated]
    public FxRootConfigurator SetTorsoCasts(string value)
    {
      return OnConfigureInternal(bp => bp.m_TorsoCasts = BlueprintTool.GetRef<CastsGroup.Reference>(value));
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.FallEventStrings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToFallEventStrings(params string[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.FallEventStrings = CommonTool.Append(bp.FallEventStrings, values));
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.FallEventStrings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromFallEventStrings(params string[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.FallEventStrings = bp.FallEventStrings.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="FxRoot.DustOnFallPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetDustOnFallPrefab(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DustOnFallPrefab = value);
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.PoolEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToPoolEntries(params PoolEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PoolEntries = CommonTool.Append(bp.PoolEntries, values));
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.PoolEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromPoolEntries(params PoolEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PoolEntries = bp.PoolEntries.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.OverrideDeathPrefabsFromEnergy = CommonTool.Append(bp.OverrideDeathPrefabsFromEnergy, values));
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.OverrideDeathPrefabsFromEnergy = bp.OverrideDeathPrefabsFromEnergy.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="FxRoot.IntensityMultiplierMorning"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetIntensityMultiplierMorning(float value)
    {
      return OnConfigureInternal(bp => bp.IntensityMultiplierMorning = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.IntensityMultiplierDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetIntensityMultiplierDay(float value)
    {
      return OnConfigureInternal(bp => bp.IntensityMultiplierDay = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.IntensityMultiplierEvening"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetIntensityMultiplierEvening(float value)
    {
      return OnConfigureInternal(bp => bp.IntensityMultiplierEvening = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.IntensityMultiplierNight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetIntensityMultiplierNight(float value)
    {
      return OnConfigureInternal(bp => bp.IntensityMultiplierNight = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RangeMultiplierMorning"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRangeMultiplierMorning(float value)
    {
      return OnConfigureInternal(bp => bp.RangeMultiplierMorning = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RangeMultiplierDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRangeMultiplierDay(float value)
    {
      return OnConfigureInternal(bp => bp.RangeMultiplierDay = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RangeMultiplierEvening"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRangeMultiplierEvening(float value)
    {
      return OnConfigureInternal(bp => bp.RangeMultiplierEvening = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RangeMultiplierNight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRangeMultiplierNight(float value)
    {
      return OnConfigureInternal(bp => bp.RangeMultiplierNight = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RaceFxSnapMapScaleSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRaceFxSnapMapScaleSettings(RaceFxScaleSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RaceFxSnapMapScaleSettings = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RaceFxSnapToLocatorScaleSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRaceFxSnapToLocatorScaleSettings(RaceFxScaleSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RaceFxSnapToLocatorScaleSettings = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.RaceFxFluidFogInteractionScaleSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetRaceFxFluidFogInteractionScaleSettings(RaceFxScaleSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RaceFxFluidFogInteractionScaleSettings = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.DefaultLifetimeSeconds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetDefaultLifetimeSeconds(float value)
    {
      return OnConfigureInternal(bp => bp.DefaultLifetimeSeconds = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.FadeOutTimeSeconds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetFadeOutTimeSeconds(float value)
    {
      return OnConfigureInternal(bp => bp.FadeOutTimeSeconds = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.MaxFootprintsCountPerUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetMaxFootprintsCountPerUnit(int value)
    {
      return OnConfigureInternal(bp => bp.MaxFootprintsCountPerUnit = value);
    }

    /// <summary>
    /// Sets <see cref="FxRoot.MinDistanceBetweenFootprints"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetMinDistanceBetweenFootprints(float value)
    {
      return OnConfigureInternal(bp => bp.MinDistanceBetweenFootprints = value);
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.FootprintsReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFootprintType"/></param>
    [Generated]
    public FxRootConfigurator AddToFootprintsReferences(params string[] values)
    {
      return OnConfigureInternal(bp => bp.FootprintsReferences = CommonTool.Append(bp.FootprintsReferences, values.Select(name => BlueprintTool.GetRef<BlueprintFootprintTypeReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.FootprintsReferences"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFootprintType"/></param>
    [Generated]
    public FxRootConfigurator RemoveFromFootprintsReferences(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintFootprintTypeReference>(name));
            bp.FootprintsReferences =
                bp.FootprintsReferences
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.FootprintsLocators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToFootprintsLocators(params FxRoot.FootprintLocators[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.FootprintsLocators = CommonTool.Append(bp.FootprintsLocators, values));
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.FootprintsLocators"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromFootprintsLocators(params FxRoot.FootprintLocators[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.FootprintsLocators = bp.FootprintsLocators.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="FxRoot.m_DeathFxsInitialized"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator SetDeathFxsInitialized(bool value)
    {
      return OnConfigureInternal(bp => bp.m_DeathFxsInitialized = value);
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.m_CachedOverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator AddToCachedOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedOverrideDeathPrefabsFromEnergy = CommonTool.Append(bp.m_CachedOverrideDeathPrefabsFromEnergy, values));
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.m_CachedOverrideDeathPrefabsFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FxRootConfigurator RemoveFromCachedOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_CachedOverrideDeathPrefabsFromEnergy = bp.m_CachedOverrideDeathPrefabsFromEnergy.Where(item => !values.Contains(item)).ToArray());
    }
  }
}

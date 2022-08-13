//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Blueprints.Root.Fx;
using Kingmaker.Utility;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Root.Fx
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="FxRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFxRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : FxRoot
    where TBuilder : BaseFxRootConfigurator<T, TBuilder>
  {
    protected BaseFxRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.m_SingleHandCasts"/>
    /// </summary>
    ///
    /// <param name="singleHandCasts">
    /// <para>
    /// Blueprint of type CastsGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSingleHandCasts(Blueprint<CastsGroup.Reference> singleHandCasts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SingleHandCasts = singleHandCasts?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.m_SingleHandCasts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySingleHandCasts(Action<CastsGroup.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SingleHandCasts is null) { return; }
          action.Invoke(bp.m_SingleHandCasts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.m_DoubleHandCasts"/>
    /// </summary>
    ///
    /// <param name="doubleHandCasts">
    /// <para>
    /// Blueprint of type CastsGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDoubleHandCasts(Blueprint<CastsGroup.Reference> doubleHandCasts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DoubleHandCasts = doubleHandCasts?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.m_DoubleHandCasts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDoubleHandCasts(Action<CastsGroup.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DoubleHandCasts is null) { return; }
          action.Invoke(bp.m_DoubleHandCasts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.m_HeadCasts"/>
    /// </summary>
    ///
    /// <param name="headCasts">
    /// <para>
    /// Blueprint of type CastsGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetHeadCasts(Blueprint<CastsGroup.Reference> headCasts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HeadCasts = headCasts?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.m_HeadCasts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHeadCasts(Action<CastsGroup.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_HeadCasts is null) { return; }
          action.Invoke(bp.m_HeadCasts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.m_TorsoCasts"/>
    /// </summary>
    ///
    /// <param name="torsoCasts">
    /// <para>
    /// Blueprint of type CastsGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTorsoCasts(Blueprint<CastsGroup.Reference> torsoCasts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TorsoCasts = torsoCasts?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.m_TorsoCasts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTorsoCasts(Action<CastsGroup.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TorsoCasts is null) { return; }
          action.Invoke(bp.m_TorsoCasts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.FallEventStrings"/>
    /// </summary>
    public TBuilder SetFallEventStrings(params string[] fallEventStrings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FallEventStrings = fallEventStrings;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="FxRoot.FallEventStrings"/>
    /// </summary>
    public TBuilder AddToFallEventStrings(params string[] fallEventStrings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FallEventStrings = bp.FallEventStrings ?? new string[0];
          bp.FallEventStrings = CommonTool.Append(bp.FallEventStrings, fallEventStrings);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.FallEventStrings"/>
    /// </summary>
    public TBuilder RemoveFromFallEventStrings(params string[] fallEventStrings)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FallEventStrings is null) { return; }
          bp.FallEventStrings = bp.FallEventStrings.Where(val => !fallEventStrings.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.FallEventStrings"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFallEventStrings(Func<string, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FallEventStrings is null) { return; }
          bp.FallEventStrings = bp.FallEventStrings.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="FxRoot.FallEventStrings"/>
    /// </summary>
    public TBuilder ClearFallEventStrings()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FallEventStrings = new string[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.FallEventStrings"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFallEventStrings(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FallEventStrings is null) { return; }
          bp.FallEventStrings.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.DustOnFallPrefab"/>
    /// </summary>
    ///
    /// <param name="dustOnFallPrefab">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    public TBuilder SetDustOnFallPrefab(Asset<GameObject> dustOnFallPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DustOnFallPrefab = dustOnFallPrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.DustOnFallPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDustOnFallPrefab(Action<GameObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DustOnFallPrefab is null) { return; }
          action.Invoke(bp.DustOnFallPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.PoolEntries"/>
    /// </summary>
    public TBuilder SetPoolEntries(params PoolEntry[] poolEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(poolEntries);
          bp.PoolEntries = poolEntries;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="FxRoot.PoolEntries"/>
    /// </summary>
    public TBuilder AddToPoolEntries(params PoolEntry[] poolEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PoolEntries = bp.PoolEntries ?? new PoolEntry[0];
          bp.PoolEntries = CommonTool.Append(bp.PoolEntries, poolEntries);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.PoolEntries"/>
    /// </summary>
    public TBuilder RemoveFromPoolEntries(params PoolEntry[] poolEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PoolEntries is null) { return; }
          bp.PoolEntries = bp.PoolEntries.Where(val => !poolEntries.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.PoolEntries"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPoolEntries(Func<PoolEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PoolEntries is null) { return; }
          bp.PoolEntries = bp.PoolEntries.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="FxRoot.PoolEntries"/>
    /// </summary>
    public TBuilder ClearPoolEntries()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PoolEntries = new PoolEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.PoolEntries"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPoolEntries(Action<PoolEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PoolEntries is null) { return; }
          bp.PoolEntries.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/>
    /// </summary>
    public TBuilder SetOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] overrideDeathPrefabsFromEnergy)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(overrideDeathPrefabsFromEnergy);
          bp.OverrideDeathPrefabsFromEnergy = overrideDeathPrefabsFromEnergy;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/>
    /// </summary>
    public TBuilder AddToOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] overrideDeathPrefabsFromEnergy)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideDeathPrefabsFromEnergy = bp.OverrideDeathPrefabsFromEnergy ?? new DeathFxFromEnergyEntry[0];
          bp.OverrideDeathPrefabsFromEnergy = CommonTool.Append(bp.OverrideDeathPrefabsFromEnergy, overrideDeathPrefabsFromEnergy);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/>
    /// </summary>
    public TBuilder RemoveFromOverrideDeathPrefabsFromEnergy(params DeathFxFromEnergyEntry[] overrideDeathPrefabsFromEnergy)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverrideDeathPrefabsFromEnergy is null) { return; }
          bp.OverrideDeathPrefabsFromEnergy = bp.OverrideDeathPrefabsFromEnergy.Where(val => !overrideDeathPrefabsFromEnergy.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromOverrideDeathPrefabsFromEnergy(Func<DeathFxFromEnergyEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverrideDeathPrefabsFromEnergy is null) { return; }
          bp.OverrideDeathPrefabsFromEnergy = bp.OverrideDeathPrefabsFromEnergy.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/>
    /// </summary>
    public TBuilder ClearOverrideDeathPrefabsFromEnergy()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideDeathPrefabsFromEnergy = new DeathFxFromEnergyEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.OverrideDeathPrefabsFromEnergy"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyOverrideDeathPrefabsFromEnergy(Action<DeathFxFromEnergyEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverrideDeathPrefabsFromEnergy is null) { return; }
          bp.OverrideDeathPrefabsFromEnergy.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.IntensityMultiplierMorning"/>
    /// </summary>
    public TBuilder SetIntensityMultiplierMorning(float intensityMultiplierMorning)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IntensityMultiplierMorning = intensityMultiplierMorning;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.IntensityMultiplierDay"/>
    /// </summary>
    public TBuilder SetIntensityMultiplierDay(float intensityMultiplierDay)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IntensityMultiplierDay = intensityMultiplierDay;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.IntensityMultiplierEvening"/>
    /// </summary>
    public TBuilder SetIntensityMultiplierEvening(float intensityMultiplierEvening)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IntensityMultiplierEvening = intensityMultiplierEvening;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.IntensityMultiplierNight"/>
    /// </summary>
    public TBuilder SetIntensityMultiplierNight(float intensityMultiplierNight)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IntensityMultiplierNight = intensityMultiplierNight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.RangeMultiplierMorning"/>
    /// </summary>
    public TBuilder SetRangeMultiplierMorning(float rangeMultiplierMorning)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RangeMultiplierMorning = rangeMultiplierMorning;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.RangeMultiplierDay"/>
    /// </summary>
    public TBuilder SetRangeMultiplierDay(float rangeMultiplierDay)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RangeMultiplierDay = rangeMultiplierDay;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.RangeMultiplierEvening"/>
    /// </summary>
    public TBuilder SetRangeMultiplierEvening(float rangeMultiplierEvening)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RangeMultiplierEvening = rangeMultiplierEvening;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.RangeMultiplierNight"/>
    /// </summary>
    public TBuilder SetRangeMultiplierNight(float rangeMultiplierNight)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RangeMultiplierNight = rangeMultiplierNight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.RaceFxSnapMapScaleSettings"/>
    /// </summary>
    public TBuilder SetRaceFxSnapMapScaleSettings(RaceFxScaleSettings raceFxSnapMapScaleSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(raceFxSnapMapScaleSettings);
          bp.RaceFxSnapMapScaleSettings = raceFxSnapMapScaleSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.RaceFxSnapMapScaleSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRaceFxSnapMapScaleSettings(Action<RaceFxScaleSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RaceFxSnapMapScaleSettings is null) { return; }
          action.Invoke(bp.RaceFxSnapMapScaleSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.RaceFxSnapToLocatorScaleSettings"/>
    /// </summary>
    public TBuilder SetRaceFxSnapToLocatorScaleSettings(RaceFxScaleSettings raceFxSnapToLocatorScaleSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(raceFxSnapToLocatorScaleSettings);
          bp.RaceFxSnapToLocatorScaleSettings = raceFxSnapToLocatorScaleSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.RaceFxSnapToLocatorScaleSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRaceFxSnapToLocatorScaleSettings(Action<RaceFxScaleSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RaceFxSnapToLocatorScaleSettings is null) { return; }
          action.Invoke(bp.RaceFxSnapToLocatorScaleSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.RaceFxFluidFogInteractionScaleSettings"/>
    /// </summary>
    public TBuilder SetRaceFxFluidFogInteractionScaleSettings(RaceFxScaleSettings raceFxFluidFogInteractionScaleSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(raceFxFluidFogInteractionScaleSettings);
          bp.RaceFxFluidFogInteractionScaleSettings = raceFxFluidFogInteractionScaleSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.RaceFxFluidFogInteractionScaleSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRaceFxFluidFogInteractionScaleSettings(Action<RaceFxScaleSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RaceFxFluidFogInteractionScaleSettings is null) { return; }
          action.Invoke(bp.RaceFxFluidFogInteractionScaleSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.DefaultLifetimeSeconds"/>
    /// </summary>
    public TBuilder SetDefaultLifetimeSeconds(float defaultLifetimeSeconds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DefaultLifetimeSeconds = defaultLifetimeSeconds;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.FadeOutTimeSeconds"/>
    /// </summary>
    public TBuilder SetFadeOutTimeSeconds(float fadeOutTimeSeconds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FadeOutTimeSeconds = fadeOutTimeSeconds;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.MaxFootprintsCountPerUnit"/>
    /// </summary>
    public TBuilder SetMaxFootprintsCountPerUnit(int maxFootprintsCountPerUnit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxFootprintsCountPerUnit = maxFootprintsCountPerUnit;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.MinDistanceBetweenFootprints"/>
    /// </summary>
    public TBuilder SetMinDistanceBetweenFootprints(float minDistanceBetweenFootprints)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinDistanceBetweenFootprints = minDistanceBetweenFootprints;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.FootprintsReferences"/>
    /// </summary>
    ///
    /// <param name="footprintsReferences">
    /// <para>
    /// Blueprint of type BlueprintFootprintType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFootprintsReferences(params Blueprint<BlueprintFootprintTypeReference>[] footprintsReferences)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FootprintsReferences = footprintsReferences.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="FxRoot.FootprintsReferences"/>
    /// </summary>
    ///
    /// <param name="footprintsReferences">
    /// <para>
    /// Blueprint of type BlueprintFootprintType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToFootprintsReferences(params Blueprint<BlueprintFootprintTypeReference>[] footprintsReferences)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FootprintsReferences = bp.FootprintsReferences ?? new BlueprintFootprintTypeReference[0];
          bp.FootprintsReferences = CommonTool.Append(bp.FootprintsReferences, footprintsReferences.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.FootprintsReferences"/>
    /// </summary>
    ///
    /// <param name="footprintsReferences">
    /// <para>
    /// Blueprint of type BlueprintFootprintType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFootprintsReferences(params Blueprint<BlueprintFootprintTypeReference>[] footprintsReferences)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FootprintsReferences is null) { return; }
          bp.FootprintsReferences = bp.FootprintsReferences.Where(val => !footprintsReferences.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.FootprintsReferences"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFootprintsReferences(Func<BlueprintFootprintTypeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FootprintsReferences is null) { return; }
          bp.FootprintsReferences = bp.FootprintsReferences.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="FxRoot.FootprintsReferences"/>
    /// </summary>
    public TBuilder ClearFootprintsReferences()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FootprintsReferences = new BlueprintFootprintTypeReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.FootprintsReferences"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFootprintsReferences(Action<BlueprintFootprintTypeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FootprintsReferences is null) { return; }
          bp.FootprintsReferences.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.FootprintsLocators"/>
    /// </summary>
    public TBuilder SetFootprintsLocators(params FxRoot.FootprintLocators[] footprintsLocators)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(footprintsLocators);
          bp.FootprintsLocators = footprintsLocators;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="FxRoot.FootprintsLocators"/>
    /// </summary>
    public TBuilder AddToFootprintsLocators(params FxRoot.FootprintLocators[] footprintsLocators)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FootprintsLocators = bp.FootprintsLocators ?? new FxRoot.FootprintLocators[0];
          bp.FootprintsLocators = CommonTool.Append(bp.FootprintsLocators, footprintsLocators);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.FootprintsLocators"/>
    /// </summary>
    public TBuilder RemoveFromFootprintsLocators(params FxRoot.FootprintLocators[] footprintsLocators)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FootprintsLocators is null) { return; }
          bp.FootprintsLocators = bp.FootprintsLocators.Where(val => !footprintsLocators.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FxRoot.FootprintsLocators"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFootprintsLocators(Func<FxRoot.FootprintLocators, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FootprintsLocators is null) { return; }
          bp.FootprintsLocators = bp.FootprintsLocators.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="FxRoot.FootprintsLocators"/>
    /// </summary>
    public TBuilder ClearFootprintsLocators()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FootprintsLocators = new FxRoot.FootprintLocators[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="FxRoot.FootprintsLocators"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFootprintsLocators(Action<FxRoot.FootprintLocators> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FootprintsLocators is null) { return; }
          bp.FootprintsLocators.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FxRoot.m_DeathFxsInitialized"/>
    /// </summary>
    public TBuilder SetDeathFxsInitialized(bool deathFxsInitialized = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DeathFxsInitialized = deathFxsInitialized;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_SingleHandCasts is null)
      {
        Blueprint.m_SingleHandCasts = BlueprintTool.GetRef<CastsGroup.Reference>(null);
      }
      if (Blueprint.m_DoubleHandCasts is null)
      {
        Blueprint.m_DoubleHandCasts = BlueprintTool.GetRef<CastsGroup.Reference>(null);
      }
      if (Blueprint.m_HeadCasts is null)
      {
        Blueprint.m_HeadCasts = BlueprintTool.GetRef<CastsGroup.Reference>(null);
      }
      if (Blueprint.m_TorsoCasts is null)
      {
        Blueprint.m_TorsoCasts = BlueprintTool.GetRef<CastsGroup.Reference>(null);
      }
      if (Blueprint.FallEventStrings is null)
      {
        Blueprint.FallEventStrings = new string[0];
      }
      if (Blueprint.PoolEntries is null)
      {
        Blueprint.PoolEntries = new PoolEntry[0];
      }
      if (Blueprint.OverrideDeathPrefabsFromEnergy is null)
      {
        Blueprint.OverrideDeathPrefabsFromEnergy = new DeathFxFromEnergyEntry[0];
      }
      if (Blueprint.FootprintsReferences is null)
      {
        Blueprint.FootprintsReferences = new BlueprintFootprintTypeReference[0];
      }
      if (Blueprint.FootprintsLocators is null)
      {
        Blueprint.FootprintsLocators = new FxRoot.FootprintLocators[0];
      }
    }
  }
}

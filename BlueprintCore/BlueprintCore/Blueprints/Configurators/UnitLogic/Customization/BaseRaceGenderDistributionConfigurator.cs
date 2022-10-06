//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Customization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Customization
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="RaceGenderDistribution"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRaceGenderDistributionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : RaceGenderDistribution
    where TBuilder : BaseRaceGenderDistributionConfigurator<T, TBuilder>
  {
    protected BaseRaceGenderDistributionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<RaceGenderDistribution>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Races = copyFrom.Races;
          bp.LeftHandedChance = copyFrom.LeftHandedChance;
          bp.MaleBaseWeight = copyFrom.MaleBaseWeight;
          bp.FemaleBaseWeight = copyFrom.FemaleBaseWeight;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<RaceGenderDistribution>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Races = copyFrom.Races;
          bp.LeftHandedChance = copyFrom.LeftHandedChance;
          bp.MaleBaseWeight = copyFrom.MaleBaseWeight;
          bp.FemaleBaseWeight = copyFrom.FemaleBaseWeight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RaceGenderDistribution.Races"/>
    /// </summary>
    public TBuilder SetRaces(params RaceEntry[] races)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(races);
          bp.Races = races;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="RaceGenderDistribution.Races"/>
    /// </summary>
    public TBuilder AddToRaces(params RaceEntry[] races)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Races = bp.Races ?? new RaceEntry[0];
          bp.Races = CommonTool.Append(bp.Races, races);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RaceGenderDistribution.Races"/>
    /// </summary>
    public TBuilder RemoveFromRaces(params RaceEntry[] races)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Races is null) { return; }
          bp.Races = bp.Races.Where(val => !races.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RaceGenderDistribution.Races"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRaces(Func<RaceEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Races is null) { return; }
          bp.Races = bp.Races.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="RaceGenderDistribution.Races"/>
    /// </summary>
    public TBuilder ClearRaces()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Races = new RaceEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="RaceGenderDistribution.Races"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRaces(Action<RaceEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Races is null) { return; }
          bp.Races.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RaceGenderDistribution.LeftHandedChance"/>
    /// </summary>
    public TBuilder SetLeftHandedChance(float leftHandedChance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeftHandedChance = leftHandedChance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RaceGenderDistribution.MaleBaseWeight"/>
    /// </summary>
    public TBuilder SetMaleBaseWeight(float maleBaseWeight)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaleBaseWeight = maleBaseWeight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RaceGenderDistribution.FemaleBaseWeight"/>
    /// </summary>
    public TBuilder SetFemaleBaseWeight(float femaleBaseWeight)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FemaleBaseWeight = femaleBaseWeight;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Races is null)
      {
        Blueprint.Races = new RaceEntry[0];
      }
    }
  }
}

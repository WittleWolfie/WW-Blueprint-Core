//***** AUTO-GENERATED - DO NOT EDIT *****//

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
          bp.Races = bp.Races.Where(predicate).ToArray();
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
    /// Modifies <see cref="RaceGenderDistribution.LeftHandedChance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeftHandedChance(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.LeftHandedChance);
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
    /// Modifies <see cref="RaceGenderDistribution.MaleBaseWeight"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaleBaseWeight(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaleBaseWeight);
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

    /// <summary>
    /// Modifies <see cref="RaceGenderDistribution.FemaleBaseWeight"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFemaleBaseWeight(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FemaleBaseWeight);
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

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitsAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : UnitsAroundConsideration
    where TBuilder : BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
  {
    protected BaseUnitsAroundConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<UnitsAroundConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_SqrCustomRadius = copyFrom.m_SqrCustomRadius;
          bp.Filter = copyFrom.Filter;
          bp.FilterDead = copyFrom.FilterDead;
          bp.MinCount = copyFrom.MinCount;
          bp.MaxCount = copyFrom.MaxCount;
          bp.IncludeUnconscious = copyFrom.IncludeUnconscious;
          bp.BelowMinScore = copyFrom.BelowMinScore;
          bp.MinScore = copyFrom.MinScore;
          bp.MaxScore = copyFrom.MaxScore;
          bp.ExtraTargetScore = copyFrom.ExtraTargetScore;
          bp.UseAbilityShape = copyFrom.UseAbilityShape;
          bp.UseCustomRadius = copyFrom.UseCustomRadius;
          bp.CustomRadiusInMeters = copyFrom.CustomRadiusInMeters;
          bp.CheckRadiusFromCaster = copyFrom.CheckRadiusFromCaster;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.m_SqrCustomRadius"/>
    /// </summary>
    public TBuilder SetSqrCustomRadius(float sqrCustomRadius)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SqrCustomRadius = sqrCustomRadius;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.Filter"/>
    /// </summary>
    public TBuilder SetFilter(Kingmaker.AI.Blueprints.TargetType filter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Filter = filter;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.FilterDead"/>
    /// </summary>
    public TBuilder SetFilterDead(DeadTargetType filterDead)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FilterDead = filterDead;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.MinCount"/>
    /// </summary>
    public TBuilder SetMinCount(int minCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinCount = minCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.MaxCount"/>
    /// </summary>
    public TBuilder SetMaxCount(int maxCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxCount = maxCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.IncludeUnconscious"/>
    /// </summary>
    public TBuilder SetIncludeUnconscious(bool includeUnconscious = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IncludeUnconscious = includeUnconscious;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.BelowMinScore"/>
    /// </summary>
    public TBuilder SetBelowMinScore(float belowMinScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BelowMinScore = belowMinScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.MinScore"/>
    /// </summary>
    public TBuilder SetMinScore(float minScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinScore = minScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.MaxScore"/>
    /// </summary>
    public TBuilder SetMaxScore(float maxScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxScore = maxScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.ExtraTargetScore"/>
    /// </summary>
    public TBuilder SetExtraTargetScore(float extraTargetScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExtraTargetScore = extraTargetScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.UseAbilityShape"/>
    /// </summary>
    ///
    /// <param name="useAbilityShape">
    /// <para>
    /// InfoBox: Check units in action&amp;apos;s ability AoE from target. (In Tactical combat is considered as always true)
    /// </para>
    /// </param>
    public TBuilder SetUseAbilityShape(bool useAbilityShape = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UseAbilityShape = useAbilityShape;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.UseCustomRadius"/>
    /// </summary>
    ///
    /// <param name="useCustomRadius">
    /// <para>
    /// InfoBox: Check units in given radius (CustomRadiusInMeters) from target or caster (CheckRadiusFromCaster)
    /// </para>
    /// </param>
    public TBuilder SetUseCustomRadius(bool useCustomRadius = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UseCustomRadius = useCustomRadius;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.CustomRadiusInMeters"/>
    /// </summary>
    public TBuilder SetCustomRadiusInMeters(float customRadiusInMeters)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomRadiusInMeters = customRadiusInMeters;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitsAroundConsideration.CheckRadiusFromCaster"/>
    /// </summary>
    public TBuilder SetCheckRadiusFromCaster(bool checkRadiusFromCaster = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CheckRadiusFromCaster = checkRadiusFromCaster;
        });
    }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
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
    /// Modifies <see cref="UnitsAroundConsideration.m_SqrCustomRadius"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySqrCustomRadius(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_SqrCustomRadius);
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
    /// Modifies <see cref="UnitsAroundConsideration.Filter"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFilter(Action<Kingmaker.AI.Blueprints.TargetType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Filter);
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
    /// Modifies <see cref="UnitsAroundConsideration.MinCount"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinCount(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinCount);
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
    /// Modifies <see cref="UnitsAroundConsideration.MaxCount"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxCount(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxCount);
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
    /// Modifies <see cref="UnitsAroundConsideration.IncludeUnconscious"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIncludeUnconscious(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IncludeUnconscious);
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
    /// Modifies <see cref="UnitsAroundConsideration.BelowMinScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBelowMinScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BelowMinScore);
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
    /// Modifies <see cref="UnitsAroundConsideration.MinScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinScore);
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
    /// Modifies <see cref="UnitsAroundConsideration.MaxScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxScore);
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
    /// Modifies <see cref="UnitsAroundConsideration.ExtraTargetScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExtraTargetScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ExtraTargetScore);
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
    /// Modifies <see cref="UnitsAroundConsideration.UseAbilityShape"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUseAbilityShape(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.UseAbilityShape);
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
    /// Modifies <see cref="UnitsAroundConsideration.UseCustomRadius"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUseCustomRadius(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.UseCustomRadius);
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
    /// Modifies <see cref="UnitsAroundConsideration.CustomRadiusInMeters"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCustomRadiusInMeters(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CustomRadiusInMeters);
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

    /// <summary>
    /// Modifies <see cref="UnitsAroundConsideration.CheckRadiusFromCaster"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCheckRadiusFromCaster(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CheckRadiusFromCaster);
        });
    }
  }
}

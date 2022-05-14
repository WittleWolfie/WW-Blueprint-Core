//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="TacticalCombatTagConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatTagConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : TacticalCombatTagConsideration
    where TBuilder : BaseTacticalCombatTagConsiderationConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatTagConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="TacticalCombatTagConsideration.HasTagScore"/>
    /// </summary>
    public TBuilder SetHasTagScore(float hasTagScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasTagScore = hasTagScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="TacticalCombatTagConsideration.HasTagScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasTagScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasTagScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TacticalCombatTagConsideration.DoesNotHaveTagScore"/>
    /// </summary>
    public TBuilder SetDoesNotHaveTagScore(float doesNotHaveTagScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoesNotHaveTagScore = doesNotHaveTagScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="TacticalCombatTagConsideration.DoesNotHaveTagScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDoesNotHaveTagScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DoesNotHaveTagScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TacticalCombatTagConsideration.Tag"/>
    /// </summary>
    public TBuilder SetTag(params ArmyProperties[] tag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Tag = tag.Aggregate((ArmyProperties) 0, (f1, f2) => f1 | f2);;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="TacticalCombatTagConsideration.Tag"/>
    /// </summary>
    public TBuilder AddToTag(params ArmyProperties[] tag)
    {
      return OnConfigureInternal(
        bp =>
        {
          tag.ForEach(f => bp.Tag |= f);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TacticalCombatTagConsideration.Tag"/>
    /// </summary>
    public TBuilder RemoveFromTag(params ArmyProperties[] tag)
    {
      return OnConfigureInternal(
        bp =>
        {
          tag.ForEach(f => bp.Tag &= ~f);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TacticalCombatTagConsideration.ShouldHaveAllTags"/>
    /// </summary>
    public TBuilder SetShouldHaveAllTags(bool shouldHaveAllTags = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShouldHaveAllTags = shouldHaveAllTags;
        });
    }

    /// <summary>
    /// Modifies <see cref="TacticalCombatTagConsideration.ShouldHaveAllTags"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShouldHaveAllTags(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ShouldHaveAllTags);
        });
    }
  }
}

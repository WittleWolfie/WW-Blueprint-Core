//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;
using Kingmaker.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ArmyHealthConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmyHealthConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ArmyHealthConsideration
    where TBuilder : BaseArmyHealthConsiderationConfigurator<T, TBuilder>
  {
    protected BaseArmyHealthConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="ArmyHealthConsideration.FullBorder"/>
    /// </summary>
    ///
    /// <param name="fullBorder">
    /// <para>
    /// InfoBox: If unit current HP is above this percent of max HP -> return FullScore
    /// </para>
    /// </param>
    public TBuilder SetFullBorder(float fullBorder)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FullBorder = fullBorder;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyHealthConsideration.FullBorder"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="fullBorder">
    /// <para>
    /// InfoBox: If unit current HP is above this percent of max HP -> return FullScore
    /// </para>
    /// </param>
    public TBuilder ModifyFullBorder(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FullBorder);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyHealthConsideration.DeadBorder"/>
    /// </summary>
    ///
    /// <param name="deadBorder">
    /// <para>
    /// InfoBox: If unit current HP is below this percent of max HP -> return DeadScore
    /// </para>
    /// </param>
    public TBuilder SetDeadBorder(float deadBorder)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeadBorder = deadBorder;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyHealthConsideration.DeadBorder"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="deadBorder">
    /// <para>
    /// InfoBox: If unit current HP is below this percent of max HP -> return DeadScore
    /// </para>
    /// </param>
    public TBuilder ModifyDeadBorder(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DeadBorder);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyHealthConsideration.FullScore"/>
    /// </summary>
    ///
    /// <param name="fullScore">
    /// <para>
    /// InfoBox: According to current HP percentage returns score between FullScore and DeadScore Current HP here is sum of all alive squad units HP
    /// </para>
    /// </param>
    public TBuilder SetFullScore(float fullScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FullScore = fullScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyHealthConsideration.FullScore"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="fullScore">
    /// <para>
    /// InfoBox: According to current HP percentage returns score between FullScore and DeadScore Current HP here is sum of all alive squad units HP
    /// </para>
    /// </param>
    public TBuilder ModifyFullScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FullScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyHealthConsideration.DeadScore"/>
    /// </summary>
    public TBuilder SetDeadScore(float deadScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeadScore = deadScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyHealthConsideration.DeadScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDeadScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DeadScore);
        });
    }
  }
}
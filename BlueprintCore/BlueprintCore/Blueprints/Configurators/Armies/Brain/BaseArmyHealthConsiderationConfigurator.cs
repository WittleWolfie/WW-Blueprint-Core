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
    protected BaseArmyHealthConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ArmyHealthConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.FullBorder = copyFrom.FullBorder;
          bp.DeadBorder = copyFrom.DeadBorder;
          bp.FullScore = copyFrom.FullScore;
          bp.DeadScore = copyFrom.DeadScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyHealthConsideration.FullBorder"/>
    /// </summary>
    ///
    /// <param name="fullBorder">
    /// <para>
    /// InfoBox: If unit current HP is above this percent of max HP -&amp;gt; return FullScore
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
    /// Sets the value of <see cref="ArmyHealthConsideration.DeadBorder"/>
    /// </summary>
    ///
    /// <param name="deadBorder">
    /// <para>
    /// InfoBox: If unit current HP is below this percent of max HP -&amp;gt; return DeadScore
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
  }
}

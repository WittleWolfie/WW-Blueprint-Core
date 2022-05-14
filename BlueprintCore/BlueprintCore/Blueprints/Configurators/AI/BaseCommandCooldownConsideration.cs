//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using System;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="CommandCooldownConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCommandCooldownConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : CommandCooldownConsideration
    where TBuilder : BaseCommandCooldownConsiderationConfigurator<T, TBuilder>
  {
    protected BaseCommandCooldownConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="CommandCooldownConsideration.CommandType"/>
    /// </summary>
    public TBuilder SetCommandType(UnitCommand.CommandType commandType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CommandType = commandType;
        });
    }

    /// <summary>
    /// Modifies <see cref="CommandCooldownConsideration.CommandType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCommandType(Action<UnitCommand.CommandType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CommandType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CommandCooldownConsideration.OnCooldownScore"/>
    /// </summary>
    public TBuilder SetOnCooldownScore(float onCooldownScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnCooldownScore = onCooldownScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="CommandCooldownConsideration.OnCooldownScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnCooldownScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OnCooldownScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CommandCooldownConsideration.OffCooldownScore"/>
    /// </summary>
    public TBuilder SetOffCooldownScore(float offCooldownScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OffCooldownScore = offCooldownScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="CommandCooldownConsideration.OffCooldownScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOffCooldownScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OffCooldownScore);
        });
    }
  }
}

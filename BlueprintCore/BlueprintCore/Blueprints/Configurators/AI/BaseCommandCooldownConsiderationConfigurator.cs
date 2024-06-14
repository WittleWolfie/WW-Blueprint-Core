//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

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
    protected BaseCommandCooldownConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<CommandCooldownConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.CommandType = copyFrom.CommandType;
          bp.OnCooldownScore = copyFrom.OnCooldownScore;
          bp.OffCooldownScore = copyFrom.OffCooldownScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<CommandCooldownConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.CommandType = copyFrom.CommandType;
          bp.OnCooldownScore = copyFrom.OnCooldownScore;
          bp.OffCooldownScore = copyFrom.OffCooldownScore;
        });
    }

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
  }
}

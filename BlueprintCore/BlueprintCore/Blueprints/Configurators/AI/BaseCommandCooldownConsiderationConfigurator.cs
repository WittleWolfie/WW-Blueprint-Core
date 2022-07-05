//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;

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

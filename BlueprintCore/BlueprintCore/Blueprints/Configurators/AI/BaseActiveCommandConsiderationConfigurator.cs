//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ActiveCommandConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseActiveCommandConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ActiveCommandConsideration
    where TBuilder : BaseActiveCommandConsiderationConfigurator<T, TBuilder>
  {
    protected BaseActiveCommandConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="ActiveCommandConsideration.CommandType"/>
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
    /// Sets the value of <see cref="ActiveCommandConsideration.HasCommandScore"/>
    /// </summary>
    public TBuilder SetHasCommandScore(float hasCommandScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasCommandScore = hasCommandScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ActiveCommandConsideration.NoCommandScore"/>
    /// </summary>
    public TBuilder SetNoCommandScore(float noCommandScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoCommandScore = noCommandScore;
        });
    }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Crusade;

namespace BlueprintCore.Blueprints.Configurators.Crusade
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="SettlementBlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSettlementAreaConfigurator<T, TBuilder>
    : BaseAreaConfigurator<T, TBuilder>
    where T : SettlementBlueprintArea
    where TBuilder : BaseSettlementAreaConfigurator<T, TBuilder>
  {
    protected BaseSettlementAreaConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSettlementAreaPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSettlementAreaPresetConfigurator<T, TBuilder>
    : BaseAreaPresetConfigurator<T, TBuilder>
    where T : BlueprintSettlementAreaPreset
    where TBuilder : BaseSettlementAreaPresetConfigurator<T, TBuilder>
  {
    protected BaseSettlementAreaPresetConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

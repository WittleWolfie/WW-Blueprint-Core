//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintMultiEntranceEntry"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseMultiEntranceEntryConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintMultiEntranceEntry
    where TBuilder : BaseMultiEntranceEntryConfigurator<T, TBuilder>
  {
    protected BaseMultiEntranceEntryConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

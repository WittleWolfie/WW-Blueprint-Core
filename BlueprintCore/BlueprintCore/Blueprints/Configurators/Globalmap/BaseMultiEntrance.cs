//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintMultiEntrance"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseMultiEntranceConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintMultiEntrance
    where TBuilder : BaseMultiEntranceConfigurator<T, TBuilder>
  {
    protected BaseMultiEntranceConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

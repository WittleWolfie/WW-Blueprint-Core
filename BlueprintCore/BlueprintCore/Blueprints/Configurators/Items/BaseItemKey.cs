//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemKey"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemKeyConfigurator<T, TBuilder>
    : BaseItemConfigurator<T, TBuilder>
    where T : BlueprintItemKey
    where TBuilder : BaseItemKeyConfigurator<T, TBuilder>
  {
    protected BaseItemKeyConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintHiddenItem"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseHiddenItemConfigurator<T, TBuilder>
    : BaseItemConfigurator<T, TBuilder>
    where T : BlueprintHiddenItem
    where TBuilder : BaseHiddenItemConfigurator<T, TBuilder>
  {
    protected BaseHiddenItemConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

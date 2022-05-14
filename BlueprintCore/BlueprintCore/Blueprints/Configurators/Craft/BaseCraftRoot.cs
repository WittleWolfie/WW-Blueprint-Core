//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Craft;

namespace BlueprintCore.Blueprints.Configurators.Craft
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="CraftRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCraftRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : CraftRoot
    where TBuilder : BaseCraftRootConfigurator<T, TBuilder>
  {
    protected BaseCraftRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

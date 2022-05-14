//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;

namespace BlueprintCore.Blueprints.Configurators.Facts
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFact"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFactConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintFact
    where TBuilder : BaseFactConfigurator<T, TBuilder>
  {
    protected BaseFactConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

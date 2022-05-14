//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaPart"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaPartConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintAreaPart
    where TBuilder : BaseAreaPartConfigurator<T, TBuilder>
  {
    protected BaseAreaPartConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

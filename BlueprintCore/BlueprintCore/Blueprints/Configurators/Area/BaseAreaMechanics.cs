//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaMechanics"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaMechanicsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAreaMechanics
    where TBuilder : BaseAreaMechanicsConfigurator<T, TBuilder>
  {
    protected BaseAreaMechanicsConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

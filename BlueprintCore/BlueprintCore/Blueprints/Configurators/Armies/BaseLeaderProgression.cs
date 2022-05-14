//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLeaderProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLeaderProgressionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintLeaderProgression
    where TBuilder : BaseLeaderProgressionConfigurator<T, TBuilder>
  {
    protected BaseLeaderProgressionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseProgressionConfigurator<T, TBuilder>
    : BaseFeatureConfigurator<T, TBuilder>
    where T : BlueprintProgression
    where TBuilder : BaseProgressionConfigurator<T, TBuilder>
  {
    protected BaseProgressionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

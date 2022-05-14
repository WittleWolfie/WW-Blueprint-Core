//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCue"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCueConfigurator<T, TBuilder>
    : BaseCueBaseConfigurator<T, TBuilder>
    where T : BlueprintCue
    where TBuilder : BaseCueConfigurator<T, TBuilder>
  {
    protected BaseCueConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

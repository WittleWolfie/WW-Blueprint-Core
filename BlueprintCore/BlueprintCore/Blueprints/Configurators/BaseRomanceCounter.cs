//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintRomanceCounter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRomanceCounterConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintRomanceCounter
    where TBuilder : BaseRomanceCounterConfigurator<T, TBuilder>
  {
    protected BaseRomanceCounterConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

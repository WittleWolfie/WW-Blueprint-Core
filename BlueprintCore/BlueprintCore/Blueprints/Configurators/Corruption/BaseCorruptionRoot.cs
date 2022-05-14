//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Corruption;

namespace BlueprintCore.Blueprints.Configurators.Corruption
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCorruptionRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCorruptionRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCorruptionRoot
    where TBuilder : BaseCorruptionRootConfigurator<T, TBuilder>
  {
    protected BaseCorruptionRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

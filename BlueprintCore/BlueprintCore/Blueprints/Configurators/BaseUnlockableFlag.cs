//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnlockableFlag"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnlockableFlagConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUnlockableFlag
    where TBuilder : BaseUnlockableFlagConfigurator<T, TBuilder>
  {
    protected BaseUnlockableFlagConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

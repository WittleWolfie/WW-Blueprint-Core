//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintControllableProjectile"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseControllableProjectileConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintControllableProjectile
    where TBuilder : BaseControllableProjectileConfigurator<T, TBuilder>
  {
    protected BaseControllableProjectileConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAbilityResource"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAbilityResourceConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAbilityResource
    where TBuilder : BaseAbilityResourceConfigurator<T, TBuilder>
  {
    protected BaseAbilityResourceConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

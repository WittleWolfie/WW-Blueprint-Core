//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomEvent"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomEventConfigurator<T, TBuilder>
    : BaseKingdomEventBaseConfigurator<T, TBuilder>
    where T : BlueprintKingdomEvent
    where TBuilder : BaseKingdomEventConfigurator<T, TBuilder>
  {
    protected BaseKingdomEventConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

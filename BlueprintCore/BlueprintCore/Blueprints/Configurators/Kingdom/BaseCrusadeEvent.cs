//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCrusadeEvent"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCrusadeEventConfigurator<T, TBuilder>
    : BaseKingdomEventBaseConfigurator<T, TBuilder>
    where T : BlueprintCrusadeEvent
    where TBuilder : BaseCrusadeEventConfigurator<T, TBuilder>
  {
    protected BaseCrusadeEventConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

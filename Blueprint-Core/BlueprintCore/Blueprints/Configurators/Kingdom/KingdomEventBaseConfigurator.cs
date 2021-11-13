using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomEventBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomEventBase))]
  public abstract class BaseKingdomEventBaseConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintKingdomEventBase
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseKingdomEventBaseConfigurator(string name) : base(name) { }

  }
}

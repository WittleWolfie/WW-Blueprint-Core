//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.BarkBanters;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.BarkBanters
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintBarkBanter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBarkBanterConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintBarkBanter
    where TBuilder : BaseBarkBanterConfigurator<T, TBuilder>
  {
    protected BaseBarkBanterConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

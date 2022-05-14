//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Credits;

namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCreditsGroup"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCreditsGroupConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCreditsGroup
    where TBuilder : BaseCreditsGroupConfigurator<T, TBuilder>
  {
    protected BaseCreditsGroupConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

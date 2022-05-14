//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Formations;

namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintPartyFormation"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BasePartyFormationConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintPartyFormation
    where TBuilder : BasePartyFormationConfigurator<T, TBuilder>
  {
    protected BasePartyFormationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

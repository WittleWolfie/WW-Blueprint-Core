//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.RandomEncounters.Settings;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCampingEncounter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCampingEncounterConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCampingEncounter
    where TBuilder : BaseCampingEncounterConfigurator<T, TBuilder>
  {
    protected BaseCampingEncounterConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

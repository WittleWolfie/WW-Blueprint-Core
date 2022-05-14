//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintScriptZone"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseScriptZoneConfigurator<T, TBuilder>
    : BaseMapObjectConfigurator<T, TBuilder>
    where T : BlueprintScriptZone
    where TBuilder : BaseScriptZoneConfigurator<T, TBuilder>
  {
    protected BaseScriptZoneConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

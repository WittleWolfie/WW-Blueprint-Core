//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Persistence.Versioning;

namespace BlueprintCore.Blueprints.Configurators.EntitySystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitUpgrader"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitUpgraderConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUnitUpgrader
    where TBuilder : BaseUnitUpgraderConfigurator<T, TBuilder>
  {
    protected BaseUnitUpgraderConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

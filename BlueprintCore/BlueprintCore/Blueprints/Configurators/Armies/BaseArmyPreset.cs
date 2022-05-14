//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmyPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmyPresetConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArmyPreset
    where TBuilder : BaseArmyPresetConfigurator<T, TBuilder>
  {
    protected BaseArmyPresetConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmyPresetList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmyPresetListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArmyPresetList
    where TBuilder : BaseArmyPresetListConfigurator<T, TBuilder>
  {
    protected BaseArmyPresetListConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Customization;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Customization
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitCustomizationPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitCustomizationPresetConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : UnitCustomizationPreset
    where TBuilder : BaseUnitCustomizationPresetConfigurator<T, TBuilder>
  {
    protected BaseUnitCustomizationPresetConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

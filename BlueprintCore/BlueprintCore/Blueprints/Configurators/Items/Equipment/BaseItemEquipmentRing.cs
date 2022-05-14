//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentRing"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentRingConfigurator<T, TBuilder>
    : BaseItemEquipmentSimpleConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentRing
    where TBuilder : BaseItemEquipmentRingConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentRingConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

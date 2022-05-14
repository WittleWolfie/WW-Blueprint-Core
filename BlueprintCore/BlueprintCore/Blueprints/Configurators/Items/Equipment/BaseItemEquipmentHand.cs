//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentHand"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentHandConfigurator<T, TBuilder>
    : BaseItemEquipmentConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentHand
    where TBuilder : BaseItemEquipmentHandConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentHandConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

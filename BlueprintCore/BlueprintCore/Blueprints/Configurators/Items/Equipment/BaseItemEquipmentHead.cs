//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentHead"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentHeadConfigurator<T, TBuilder>
    : BaseItemEquipmentSimpleConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentHead
    where TBuilder : BaseItemEquipmentHeadConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentHeadConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

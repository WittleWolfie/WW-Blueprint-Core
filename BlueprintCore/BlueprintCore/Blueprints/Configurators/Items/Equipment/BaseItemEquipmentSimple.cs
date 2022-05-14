//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentSimple"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentSimpleConfigurator<T, TBuilder>
    : BaseItemEquipmentConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentSimple
    where TBuilder : BaseItemEquipmentSimpleConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentSimpleConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

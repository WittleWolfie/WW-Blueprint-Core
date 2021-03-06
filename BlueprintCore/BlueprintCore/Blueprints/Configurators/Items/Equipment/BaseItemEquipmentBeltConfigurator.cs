//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentBelt"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentBeltConfigurator<T, TBuilder>
    : BaseItemEquipmentSimpleConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentBelt
    where TBuilder : BaseItemEquipmentBeltConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentBeltConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

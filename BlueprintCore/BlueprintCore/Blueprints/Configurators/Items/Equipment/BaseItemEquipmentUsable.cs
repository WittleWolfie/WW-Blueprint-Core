//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentUsable"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentUsableConfigurator<T, TBuilder>
    : BaseItemEquipmentConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentUsable
    where TBuilder : BaseItemEquipmentUsableConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentUsableConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}

using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentHand"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentHand))]
  public abstract class BaseItemEquipmentHandConfigurator<T, TBuilder>
      : BaseItemEquipmentConfigurator<T, TBuilder>
      where T : BlueprintItemEquipmentHand
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseItemEquipmentHandConfigurator(string name) : base(name) { }
  }
}

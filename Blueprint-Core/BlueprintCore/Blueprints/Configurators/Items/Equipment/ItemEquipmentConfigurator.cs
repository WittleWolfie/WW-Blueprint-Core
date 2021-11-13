using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipment"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipment))]
  public abstract class BaseItemEquipmentConfigurator<T, TBuilder>
      : BaseItemConfigurator<T, TBuilder>
      where T : BlueprintItemEquipment
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseItemEquipmentConfigurator(string name) : base(name) { }

  }
}

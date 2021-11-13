using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;
namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentSimple"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentSimple))]
  public abstract class BaseItemEquipmentSimpleConfigurator<T, TBuilder>
      : BaseItemEquipmentConfigurator<T, TBuilder>
      where T : BlueprintItemEquipmentSimple
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseItemEquipmentSimpleConfigurator(string name) : base(name) { }

  }
}

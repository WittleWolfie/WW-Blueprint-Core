using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentShirt"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentShirt))]
  public class ItemEquipmentShirtConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentShirt, ItemEquipmentShirtConfigurator>
  {
    private ItemEquipmentShirtConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentShirtConfigurator For(string name)
    {
      return new ItemEquipmentShirtConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemEquipmentShirtConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemEquipmentShirt>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentShirtConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemEquipmentShirt>(name, assetId);
      return For(name);
    }
  }
}

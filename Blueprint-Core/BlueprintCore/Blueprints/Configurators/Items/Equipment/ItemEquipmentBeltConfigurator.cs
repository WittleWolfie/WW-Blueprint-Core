using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentBelt"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentBelt))]
  public class ItemEquipmentBeltConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentBelt, ItemEquipmentBeltConfigurator>
  {
    private ItemEquipmentBeltConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentBeltConfigurator For(string name)
    {
      return new ItemEquipmentBeltConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemEquipmentBeltConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemEquipmentBelt>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentBeltConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemEquipmentBelt>(name, assetId);
      return For(name);
    }
  }
}

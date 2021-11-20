using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentHandSimple"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentHandSimple))]
  public class ItemEquipmentHandSimpleConfigurator : BaseItemEquipmentHandConfigurator<BlueprintItemEquipmentHandSimple, ItemEquipmentHandSimpleConfigurator>
  {
    private ItemEquipmentHandSimpleConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentHandSimpleConfigurator For(string name)
    {
      return new ItemEquipmentHandSimpleConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemEquipmentHandSimpleConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemEquipmentHandSimple>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentHandSimpleConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemEquipmentHandSimple>(name, assetId);
      return For(name);
    }
  }
}

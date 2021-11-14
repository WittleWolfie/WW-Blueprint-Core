using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>Configurator for <see cref="BlueprintItemEquipmentUsable"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentUsable))]
  public class ItemEquipmentUsableConfigurator : BaseItemEquipmentConfigurator<BlueprintItemEquipmentUsable, ItemEquipmentUsableConfigurator>
  {
     private ItemEquipmentUsableConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentUsableConfigurator For(string name)
    {
      return new ItemEquipmentUsableConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemEquipmentUsableConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemEquipmentUsable>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentUsableConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemEquipmentUsable>(name, assetId);
      return For(name);
    }
  }
}

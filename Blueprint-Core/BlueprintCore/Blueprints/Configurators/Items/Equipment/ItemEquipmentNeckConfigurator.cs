using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentNeck"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentNeck))]
  public class ItemEquipmentNeckConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentNeck, ItemEquipmentNeckConfigurator>
  {
    private ItemEquipmentNeckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentNeckConfigurator For(string name)
    {
      return new ItemEquipmentNeckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemEquipmentNeckConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemEquipmentNeck>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentNeckConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemEquipmentNeck>(name, assetId);
      return For(name);
    }
  }
}

using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentGloves"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentGloves))]
  public class ItemEquipmentGlovesConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentGloves, ItemEquipmentGlovesConfigurator>
  {
    private ItemEquipmentGlovesConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentGlovesConfigurator For(string name)
    {
      return new ItemEquipmentGlovesConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemEquipmentGlovesConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemEquipmentGloves>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentGlovesConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemEquipmentGloves>(name, assetId);
      return For(name);
    }
  }
}

using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Equipment;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Configurator for <see cref="BlueprintItemEquipmentGlasses"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentGlasses))]
  public class ItemEquipmentGlassesConfigurator : BaseItemEquipmentSimpleConfigurator<BlueprintItemEquipmentGlasses, ItemEquipmentGlassesConfigurator>
  {
    private ItemEquipmentGlassesConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemEquipmentGlassesConfigurator For(string name)
    {
      return new ItemEquipmentGlassesConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemEquipmentGlassesConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemEquipmentGlasses>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemEquipmentGlassesConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemEquipmentGlasses>(name, assetId);
      return For(name);
    }
  }
}

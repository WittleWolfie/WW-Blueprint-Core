using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Armors;

namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>Configurator for <see cref="BlueprintItemArmor"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemArmor))]
  public class ItemArmorConfigurator : BaseItemEquipmentConfigurator<BlueprintItemArmor, ItemArmorConfigurator>
  {
     private ItemArmorConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemArmorConfigurator For(string name)
    {
      return new ItemArmorConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemArmorConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemArmor>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemArmorConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemArmor>(name, assetId);
      return For(name);
    }
  }
}

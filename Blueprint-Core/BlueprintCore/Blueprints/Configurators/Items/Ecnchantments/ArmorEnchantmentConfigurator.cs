using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Ecnchantments;

namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>Configurator for <see cref="BlueprintArmorEnchantment"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmorEnchantment))]
  public class ArmorEnchantmentConfigurator : BaseEquipmentEnchantmentConfigurator<BlueprintArmorEnchantment, ArmorEnchantmentConfigurator>
  {
     private ArmorEnchantmentConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmorEnchantmentConfigurator For(string name)
    {
      return new ArmorEnchantmentConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmorEnchantmentConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArmorEnchantment>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmorEnchantmentConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArmorEnchantment>(name, assetId);
      return For(name);
    }
  }
}

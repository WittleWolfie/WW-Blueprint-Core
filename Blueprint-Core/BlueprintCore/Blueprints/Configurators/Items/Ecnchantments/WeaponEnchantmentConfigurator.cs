using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Ecnchantments;

namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>Configurator for <see cref="BlueprintWeaponEnchantment"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintWeaponEnchantment))]
  public class WeaponEnchantmentConfigurator : BaseItemEnchantmentConfigurator<BlueprintWeaponEnchantment, WeaponEnchantmentConfigurator>
  {
     private WeaponEnchantmentConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static WeaponEnchantmentConfigurator For(string name)
    {
      return new WeaponEnchantmentConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static WeaponEnchantmentConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintWeaponEnchantment>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static WeaponEnchantmentConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintWeaponEnchantment>(name, assetId);
      return For(name);
    }
  }
}

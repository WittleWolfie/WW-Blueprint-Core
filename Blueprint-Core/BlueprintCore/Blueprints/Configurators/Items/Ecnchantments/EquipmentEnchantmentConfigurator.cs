using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Ecnchantments;

namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEquipmentEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEquipmentEnchantment))]
  public abstract class BaseEquipmentEnchantmentConfigurator<T, TBuilder>
      : BaseItemEnchantmentConfigurator<T, TBuilder>
      where T : BlueprintEquipmentEnchantment
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseEquipmentEnchantmentConfigurator(string name) : base(name) { }
  }

  /// <summary>Configurator for <see cref="BlueprintEquipmentEnchantment"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintEquipmentEnchantment))]
  public class EquipmentEnchantmentConfigurator : BaseItemEnchantmentConfigurator<BlueprintEquipmentEnchantment, EquipmentEnchantmentConfigurator>
  {
     private EquipmentEnchantmentConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static EquipmentEnchantmentConfigurator For(string name)
    {
      return new EquipmentEnchantmentConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static EquipmentEnchantmentConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintEquipmentEnchantment>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static EquipmentEnchantmentConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintEquipmentEnchantment>(name, assetId);
      return For(name);
    }
  }
}

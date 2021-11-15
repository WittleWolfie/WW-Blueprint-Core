using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Enums;
using System.Linq;

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

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_Type"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArmorType"/></param>
    [Generated]
    public ItemArmorConfigurator SetType(string value)
    {
      return OnConfigureInternal(bp => bp.m_Type = BlueprintTool.GetRef<BlueprintArmorTypeReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_Size"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemArmorConfigurator SetSize(Size value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Size = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_VisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemArmorConfigurator SetVisualParameters(ArmorVisualParameters value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_VisualParameters = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemArmor.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemArmorConfigurator AddToEnchantments(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, values.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemArmor.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemArmorConfigurator RemoveFromEnchantments(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name));
            bp.m_Enchantments =
                bp.m_Enchantments
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_OverrideShardItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemArmorConfigurator SetOverrideShardItem(bool value)
    {
      return OnConfigureInternal(bp => bp.m_OverrideShardItem = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemArmor.m_OverrideDestructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemArmorConfigurator SetOverrideDestructible(bool value)
    {
      return OnConfigureInternal(bp => bp.m_OverrideDestructible = value);
    }
  }
}

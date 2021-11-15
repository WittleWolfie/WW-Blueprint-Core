using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.ResourceLinks;
using System.Linq;

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

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentUsable.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemEquipmentUsableConfigurator SetType(UsableItemType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Type = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentUsable.m_IdentifyDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemEquipmentUsableConfigurator SetIdentifyDC(int value)
    {
      return OnConfigureInternal(bp => bp.m_IdentifyDC = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentUsable.m_InventoryEquipSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemEquipmentUsableConfigurator SetInventoryEquipSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_InventoryEquipSound = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipmentUsable.m_BeltItemPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemEquipmentUsableConfigurator SetBeltItemPrefab(PrefabLink value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_BeltItemPrefab = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemEquipmentUsableConfigurator AddToEnchantments(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, values.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public ItemEquipmentUsableConfigurator RemoveFromEnchantments(params string[] values)
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
  }
}

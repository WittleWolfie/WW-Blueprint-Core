using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentSimple"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipmentSimple))]
  public abstract class BaseItemEquipmentSimpleConfigurator<T, TBuilder>
      : BaseItemEquipmentConfigurator<T, TBuilder>
      where T : BlueprintItemEquipmentSimple
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseItemEquipmentSimpleConfigurator(string name) : base(name) { }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipmentSimple.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public TBuilder AddToEnchantments(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, values.Select(name => BlueprintTool.GetRef<BlueprintEquipmentEnchantmentReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipmentSimple.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintEquipmentEnchantment"/></param>
    [Generated]
    public TBuilder RemoveFromEnchantments(params string[] values)
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
    /// Sets <see cref="BlueprintItemEquipmentSimple.m_InventoryEquipSound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInventoryEquipSound(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_InventoryEquipSound = value);
    }
  }
}

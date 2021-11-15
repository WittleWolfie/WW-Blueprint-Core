using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Class.Kineticist;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>Configurator for <see cref="BlueprintItemWeapon"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemWeapon))]
  public class ItemWeaponConfigurator : BaseItemEquipmentHandConfigurator<BlueprintItemWeapon, ItemWeaponConfigurator>
  {
     private ItemWeaponConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemWeaponConfigurator For(string name)
    {
      return new ItemWeaponConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemWeaponConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemWeapon>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemWeaponConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemWeapon>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_Type"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    public ItemWeaponConfigurator SetType(string value)
    {
      return OnConfigureInternal(bp => bp.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_Size"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetSize(Size value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Size = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemWeapon.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintWeaponEnchantment"/></param>
    [Generated]
    public ItemWeaponConfigurator AddToEnchantments(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, values.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemWeapon.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintWeaponEnchantment"/></param>
    [Generated]
    public ItemWeaponConfigurator RemoveFromEnchantments(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name));
            bp.m_Enchantments =
                bp.m_Enchantments
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_OverrideDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetOverrideDamageDice(bool value)
    {
      return OnConfigureInternal(bp => bp.m_OverrideDamageDice = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_DamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetDamageDice(DiceFormula value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DamageDice = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_OverrideDamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetOverrideDamageType(bool value)
    {
      return OnConfigureInternal(bp => bp.m_OverrideDamageType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_DamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetDamageType(DamageTypeDescription value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DamageType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.Double"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetDouble(bool value)
    {
      return OnConfigureInternal(bp => bp.Double = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_SecondWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    public ItemWeaponConfigurator SetSecondWeapon(string value)
    {
      return OnConfigureInternal(bp => bp.m_SecondWeapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.KeepInPolymorph"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetKeepInPolymorph(bool value)
    {
      return OnConfigureInternal(bp => bp.KeepInPolymorph = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_OverrideShardItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetOverrideShardItem(bool value)
    {
      return OnConfigureInternal(bp => bp.m_OverrideShardItem = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_OverrideDestructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetOverrideDestructible(bool value)
    {
      return OnConfigureInternal(bp => bp.m_OverrideDestructible = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemWeapon.m_AlwaysPrimary"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ItemWeaponConfigurator SetAlwaysPrimary(bool value)
    {
      return OnConfigureInternal(bp => bp.m_AlwaysPrimary = value);
    }

    /// <summary>
    /// Adds <see cref="WeaponKineticBlade"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ActivationAbility"><see cref="BlueprintAbility"/></param>
    /// <param name="m_Blast"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(WeaponKineticBlade))]
    public ItemWeaponConfigurator AddWeaponKineticBlade(
        string m_ActivationAbility,
        string m_Blast)
    {
      
      var component =  new WeaponKineticBlade();
      component.m_ActivationAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(m_ActivationAbility);
      component.m_Blast = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Blast);
      return AddComponent(component);
    }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using System;

namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEquipmentEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseEquipmentEnchantmentConfigurator<T, TBuilder>
    : BaseItemEnchantmentConfigurator<T, TBuilder>
    where T : BlueprintEquipmentEnchantment
    where TBuilder : BaseEquipmentEnchantmentConfigurator<T, TBuilder>
  {
    protected BaseEquipmentEnchantmentConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="AllSavesBonusEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Item Enchantments/Bonus to all saves
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlackKnightCloakEnchantment</term><description>1ad2e26850bfef7409199c2fa23e1fa3</description></item>
    /// <item><term>Resistance5</term><description>86748e27c9e3b414a97330ea74858994</description></item>
    /// <item><term>WhiteKnightCloakEnchantment</term><description>6a37e931c20406e488be6250b5d79a44</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddAllSavesBonusEquipment(
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? value = null)
    {
      var component = new AllSavesBonusEquipment();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Value = value ?? component.Value;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeDamageStatReplacement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Damage Stat Replacement Increase
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>UnarmedAgileEnchantment</term><description>90316f5801dbe4748a66816a7c00380c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEquipmentWeaponTypeDamageStatReplacement(
        bool? allNaturalAndUnarmed = null,
        WeaponCategory? category = null,
        bool? requiresFinesse = null,
        StatType? stat = null)
    {
      var component = new EquipmentWeaponTypeDamageStatReplacement();
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed ?? component.AllNaturalAndUnarmed;
      component.Category = category ?? component.Category;
      component.RequiresFinesse = requiresFinesse ?? component.RequiresFinesse;
      component.Stat = stat ?? component.Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeEnhancement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Damage Stat Replacement Increase
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ClawEnhancement2</term><description>54f152bc1abbffa42a030ff300f03d5a</description></item>
    /// <item><term>UnarmedEnhancement1</term><description>da7d830b3f75749458c2e51524805560</description></item>
    /// <item><term>UnarmedEnhancement6</term><description>c21b5879e8a7497408980ca0427c7f52</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEquipmentWeaponTypeEnhancement(
        bool? allNaturalAndUnarmed = null,
        WeaponCategory? category = null,
        int? enhancement = null)
    {
      var component = new EquipmentWeaponTypeEnhancement();
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed ?? component.AllNaturalAndUnarmed;
      component.Category = category ?? component.Category;
      component.Enhancement = enhancement ?? component.Enhancement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponRangeTypeAttackBonusEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlovesOfPreciseShotEnchant</term><description>a56baa402b5b3e14bb4da75c533f223a</description></item>
    /// <item><term>RingOfEternalSkyEnchant</term><description>73a1f8d196f761047be5fb69d318001d</description></item>
    /// <item><term>RingOfFirmTouchEnchantment</term><description>78e1932653b0d5e4db01cbe87a55eb91</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddWeaponRangeTypeAttackBonusEquipment(
        int? attackBonus = null,
        ModifierDescriptor? descriptor = null,
        WeaponRangeType? rangeType = null)
    {
      var component = new WeaponRangeTypeAttackBonusEquipment();
      component.AttackBonus = attackBonus ?? component.AttackBonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.RangeType = rangeType ?? component.RangeType;
      return AddComponent(component);
    }
  }
}

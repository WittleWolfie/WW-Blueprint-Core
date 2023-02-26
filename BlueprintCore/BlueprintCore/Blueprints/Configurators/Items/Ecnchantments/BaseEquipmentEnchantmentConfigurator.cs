//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
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
    protected BaseEquipmentEnchantmentConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintEquipmentEnchantment>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintEquipmentEnchantment>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    return Self;
    }

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
    public TBuilder AddAllSavesBonusEquipment(
        ModifierDescriptor? descriptor = null,
        int? value = null)
    {
      var component = new AllSavesBonusEquipment();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Value = value ?? component.Value;
      return AddComponent(component);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEquipmentWeaponTypeDamageStatReplacement(
        bool? allNaturalAndUnarmed = null,
        WeaponCategory? category = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? requiresFinesse = null,
        StatType? stat = null)
    {
      var component = new EquipmentWeaponTypeDamageStatReplacement();
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed ?? component.AllNaturalAndUnarmed;
      component.Category = category ?? component.Category;
      component.RequiresFinesse = requiresFinesse ?? component.RequiresFinesse;
      component.Stat = stat ?? component.Stat;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>MagicFangGreaterBuff4</term><description>63dc4ce7bd5f4451b244e148be45106c</description></item>
    /// <item><term>UnarmedEnhancement6</term><description>c21b5879e8a7497408980ca0427c7f52</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEquipmentWeaponTypeEnhancement(
        bool? allNaturalAndUnarmed = null,
        WeaponCategory? category = null,
        int? enhancement = null,
        bool? isStackable = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new EquipmentWeaponTypeEnhancement();
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed ?? component.AllNaturalAndUnarmed;
      component.Category = category ?? component.Category;
      component.Enhancement = enhancement ?? component.Enhancement;
      component.IsStackable = isStackable ?? component.IsStackable;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonusEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon group attack bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GamekeepersArmorEnchantLongbow</term><description>e3017d807ffd5c3449dba82735b0ef56</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponGroupAttackBonusEquipment(
        int? attackBonus = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        WeaponFighterGroup? weaponGroup = null)
    {
      var component = new WeaponGroupAttackBonusEquipment();
      component.AttackBonus = attackBonus ?? component.AttackBonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.WeaponGroup = weaponGroup ?? component.WeaponGroup;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonusEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon group attack bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GamekeepersArmorEnchantLongbow</term><description>e3017d807ffd5c3449dba82735b0ef56</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponGroupDamageBonusEquipment(
        int? attackBonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        WeaponFighterGroup? weaponGroup = null)
    {
      var component = new WeaponGroupDamageBonusEquipment();
      component.AttackBonus = attackBonus ?? component.AttackBonus;
      component.WeaponGroup = weaponGroup ?? component.WeaponGroup;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponRangeTypeAttackBonusEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DeadlyRaysEnchantment</term><description>dcfc21064c91497aa58801d5b3f45733</description></item>
    /// <item><term>LethalConductorEnchantment</term><description>77b4aea38f4bb874396d6c6c2cc9c4cf</description></item>
    /// <item><term>RingOfFirmTouchEnchantment</term><description>78e1932653b0d5e4db01cbe87a55eb91</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponRangeTypeAttackBonusEquipment(
        int? attackBonus = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        WeaponRangeType? rangeType = null)
    {
      var component = new WeaponRangeTypeAttackBonusEquipment();
      component.AttackBonus = attackBonus ?? component.AttackBonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.RangeType = rangeType ?? component.RangeType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}

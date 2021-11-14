using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

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

    /// <summary>
    /// Adds <see cref="AllSavesBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSavesBonusEquipment))]
    public TBuilder AddAllSavesBonusEquipment(
        ModifierDescriptor Descriptor,
        int Value)
    {
      ValidateParam(Descriptor);
      
      var component =  new AllSavesBonusEquipment();
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeDamageStatReplacement))]
    public TBuilder AddEquipmentWeaponTypeDamageStatReplacement(
        StatType Stat,
        bool AllNaturalAndUnarmed,
        WeaponCategory Category,
        bool RequiresFinesse)
    {
      ValidateParam(Stat);
      ValidateParam(Category);
      
      var component =  new EquipmentWeaponTypeDamageStatReplacement();
      component.Stat = Stat;
      component.AllNaturalAndUnarmed = AllNaturalAndUnarmed;
      component.Category = Category;
      component.RequiresFinesse = RequiresFinesse;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeEnhancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeEnhancement))]
    public TBuilder AddEquipmentWeaponTypeEnhancement(
        int Enhancement,
        bool AllNaturalAndUnarmed,
        WeaponCategory Category)
    {
      ValidateParam(Category);
      
      var component =  new EquipmentWeaponTypeEnhancement();
      component.Enhancement = Enhancement;
      component.AllNaturalAndUnarmed = AllNaturalAndUnarmed;
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NaturalDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NaturalDamageStatReplacement))]
    public TBuilder AddNaturalDamageStatReplacement(
        StatType Stat)
    {
      ValidateParam(Stat);
      
      var component =  new NaturalDamageStatReplacement();
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonusEquipment))]
    public TBuilder AddWeaponGroupAttackBonusEquipment(
        WeaponFighterGroup WeaponGroup,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(WeaponGroup);
      ValidateParam(Descriptor);
      
      var component =  new WeaponGroupAttackBonusEquipment();
      component.WeaponGroup = WeaponGroup;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonusEquipment))]
    public TBuilder AddWeaponGroupDamageBonusEquipment(
        WeaponFighterGroup WeaponGroup,
        int AttackBonus)
    {
      ValidateParam(WeaponGroup);
      
      var component =  new WeaponGroupDamageBonusEquipment();
      component.WeaponGroup = WeaponGroup;
      component.AttackBonus = AttackBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponRangeTypeAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponRangeTypeAttackBonusEquipment))]
    public TBuilder AddWeaponRangeTypeAttackBonusEquipment(
        WeaponRangeType RangeType,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(RangeType);
      ValidateParam(Descriptor);
      
      var component =  new WeaponRangeTypeAttackBonusEquipment();
      component.RangeType = RangeType;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }
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

    /// <summary>
    /// Adds <see cref="AllSavesBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSavesBonusEquipment))]
    public EquipmentEnchantmentConfigurator AddAllSavesBonusEquipment(
        ModifierDescriptor Descriptor,
        int Value)
    {
      ValidateParam(Descriptor);
      
      var component =  new AllSavesBonusEquipment();
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeDamageStatReplacement))]
    public EquipmentEnchantmentConfigurator AddEquipmentWeaponTypeDamageStatReplacement(
        StatType Stat,
        bool AllNaturalAndUnarmed,
        WeaponCategory Category,
        bool RequiresFinesse)
    {
      ValidateParam(Stat);
      ValidateParam(Category);
      
      var component =  new EquipmentWeaponTypeDamageStatReplacement();
      component.Stat = Stat;
      component.AllNaturalAndUnarmed = AllNaturalAndUnarmed;
      component.Category = Category;
      component.RequiresFinesse = RequiresFinesse;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentWeaponTypeEnhancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentWeaponTypeEnhancement))]
    public EquipmentEnchantmentConfigurator AddEquipmentWeaponTypeEnhancement(
        int Enhancement,
        bool AllNaturalAndUnarmed,
        WeaponCategory Category)
    {
      ValidateParam(Category);
      
      var component =  new EquipmentWeaponTypeEnhancement();
      component.Enhancement = Enhancement;
      component.AllNaturalAndUnarmed = AllNaturalAndUnarmed;
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NaturalDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NaturalDamageStatReplacement))]
    public EquipmentEnchantmentConfigurator AddNaturalDamageStatReplacement(
        StatType Stat)
    {
      ValidateParam(Stat);
      
      var component =  new NaturalDamageStatReplacement();
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonusEquipment))]
    public EquipmentEnchantmentConfigurator AddWeaponGroupAttackBonusEquipment(
        WeaponFighterGroup WeaponGroup,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(WeaponGroup);
      ValidateParam(Descriptor);
      
      var component =  new WeaponGroupAttackBonusEquipment();
      component.WeaponGroup = WeaponGroup;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonusEquipment))]
    public EquipmentEnchantmentConfigurator AddWeaponGroupDamageBonusEquipment(
        WeaponFighterGroup WeaponGroup,
        int AttackBonus)
    {
      ValidateParam(WeaponGroup);
      
      var component =  new WeaponGroupDamageBonusEquipment();
      component.WeaponGroup = WeaponGroup;
      component.AttackBonus = AttackBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponRangeTypeAttackBonusEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponRangeTypeAttackBonusEquipment))]
    public EquipmentEnchantmentConfigurator AddWeaponRangeTypeAttackBonusEquipment(
        WeaponRangeType RangeType,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(RangeType);
      ValidateParam(Descriptor);
      
      var component =  new WeaponRangeTypeAttackBonusEquipment();
      component.RangeType = RangeType;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }
  }
}

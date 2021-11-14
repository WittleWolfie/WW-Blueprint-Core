using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.WeaponEnchants;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Linq;

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

    /// <summary>
    /// Adds <see cref="WeaponDamageReroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageReroll))]
    public WeaponEnchantmentConfigurator AddWeaponDamageReroll()
    {
      return AddComponent(new WeaponDamageReroll());
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponCriticalAdditionalAttackEnchant"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponCriticalAdditionalAttackEnchant))]
    public WeaponEnchantmentConfigurator AddTwoWeaponCriticalAdditionalAttackEnchant()
    {
      return AddComponent(new TwoWeaponCriticalAdditionalAttackEnchant());
    }

    /// <summary>
    /// Adds <see cref="SuppressBane"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressBane))]
    public WeaponEnchantmentConfigurator AddSuppressBane()
    {
      return AddComponent(new SuppressBane());
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalConfirmationBonus))]
    public WeaponEnchantmentConfigurator AddWeaponCriticalConfirmationBonus(
        ContextValue Value,
        int AdditionalBonus)
    {
      ValidateParam(Value);
      
      var component =  new WeaponCriticalConfirmationBonus();
      component.Value = Value;
      component.AdditionalBonus = AdditionalBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalEdgeIncrease))]
    public WeaponEnchantmentConfigurator AddWeaponCriticalEdgeIncrease()
    {
      return AddComponent(new WeaponCriticalEdgeIncrease());
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalEdgeStackable))]
    public WeaponEnchantmentConfigurator AddWeaponCriticalEdgeStackable(
        int Bonus)
    {
      
      var component =  new WeaponCriticalEdgeStackable();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCriticalMultiplierIncrease))]
    public WeaponEnchantmentConfigurator AddWeaponCriticalMultiplierIncrease(
        int AdditionalMultiplier)
    {
      
      var component =  new WeaponCriticalMultiplierIncrease();
      component.AdditionalMultiplier = AdditionalMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageMultiplierStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageMultiplierStatReplacement))]
    public WeaponEnchantmentConfigurator AddWeaponDamageMultiplierStatReplacement(
        StatType Stat,
        float Multiplier)
    {
      ValidateParam(Stat);
      
      var component =  new WeaponDamageMultiplierStatReplacement();
      component.Stat = Stat;
      component.Multiplier = Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageStatReplacement))]
    public WeaponEnchantmentConfigurator AddWeaponDamageStatReplacement(
        StatType Stat,
        bool RequiresFinesse)
    {
      ValidateParam(Stat);
      
      var component =  new WeaponDamageStatReplacement();
      component.Stat = Stat;
      component.RequiresFinesse = RequiresFinesse;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponOversized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponOversized))]
    public WeaponEnchantmentConfigurator AddWeaponOversized()
    {
      return AddComponent(new WeaponOversized());
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealmentAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(IgnoreConcealmentAgainstFactOwner))]
    public WeaponEnchantmentConfigurator AddIgnoreConcealmentAgainstFactOwner(
        string[] m_Facts,
        bool Not)
    {
      
      var component =  new IgnoreConcealmentAgainstFactOwner();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDREnchantment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreTargetDREnchantment))]
    public WeaponEnchantmentConfigurator AddIgnoreTargetDREnchantment()
    {
      return AddComponent(new IgnoreTargetDREnchantment());
    }

    /// <summary>
    /// Adds <see cref="ImproveEnhancmentIfHasEnchantment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Enchantments"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(ImproveEnhancmentIfHasEnchantment))]
    public WeaponEnchantmentConfigurator AddImproveEnhancmentIfHasEnchantment(
        string[] m_Enchantments)
    {
      
      var component =  new ImproveEnhancmentIfHasEnchantment();
      component.m_Enchantments = m_Enchantments.Select(bp => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ModifyWeaponStatsConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ModifyWeaponStatsConditional))]
    public WeaponEnchantmentConfigurator AddModifyWeaponStatsConditional(
        ModifyWeaponStatsConditional.ModificationType m_Type,
        DamageAlignment Alignment,
        ContextValue BonusDamage,
        AlignmentComponent WielderAlignmentRestriction,
        AlignmentComponent TargetAlignmentRestriction)
    {
      ValidateParam(m_Type);
      ValidateParam(Alignment);
      ValidateParam(BonusDamage);
      ValidateParam(WielderAlignmentRestriction);
      ValidateParam(TargetAlignmentRestriction);
      
      var component =  new ModifyWeaponStatsConditional();
      component.m_Type = m_Type;
      component.Alignment = Alignment;
      component.BonusDamage = BonusDamage;
      component.WielderAlignmentRestriction = WielderAlignmentRestriction;
      component.TargetAlignmentRestriction = TargetAlignmentRestriction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BrilliantEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BrilliantEnergy))]
    public WeaponEnchantmentConfigurator AddBrilliantEnergy()
    {
      return AddComponent(new BrilliantEnergy());
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponDamageByBuffStack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(IncreaseWeaponDamageByBuffStack))]
    public WeaponEnchantmentConfigurator AddIncreaseWeaponDamageByBuffStack(
        int BonusPerStack,
        string m_CheckedBuff)
    {
      
      var component =  new IncreaseWeaponDamageByBuffStack();
      component.BonusPerStack = BonusPerStack;
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckedBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponEnhancementBonusOnTargetFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseWeaponEnhancementBonusOnTargetFocus))]
    public WeaponEnchantmentConfigurator AddIncreaseWeaponEnhancementBonusOnTargetFocus(
        ContextValue BonusIncrementValue,
        ContextValue MaximumTotalEnhancementBonus,
        int m_CurrentEnhancementBonus,
        UnitReference m_FocusingTarget)
    {
      ValidateParam(BonusIncrementValue);
      ValidateParam(MaximumTotalEnhancementBonus);
      ValidateParam(m_FocusingTarget);
      
      var component =  new IncreaseWeaponEnhancementBonusOnTargetFocus();
      component.BonusIncrementValue = BonusIncrementValue;
      component.MaximumTotalEnhancementBonus = MaximumTotalEnhancementBonus;
      component.m_CurrentEnhancementBonus = m_CurrentEnhancementBonus;
      component.m_FocusingTarget = m_FocusingTarget;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MissAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(MissAgainstFactOwner))]
    public WeaponEnchantmentConfigurator AddMissAgainstFactOwner(
        string[] m_Facts)
    {
      
      var component =  new MissAgainstFactOwner();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponAlignment))]
    public WeaponEnchantmentConfigurator AddWeaponAlignment(
        DamageAlignment Alignment)
    {
      ValidateParam(Alignment);
      
      var component =  new WeaponAlignment();
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAngelDamageDice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MaximizeFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponAngelDamageDice))]
    public WeaponEnchantmentConfigurator AddWeaponAngelDamageDice(
        DiceFormula EnergyDamageDice,
        DamageEnergyType Element,
        string m_MaximizeFeature)
    {
      ValidateParam(EnergyDamageDice);
      ValidateParam(Element);
      
      var component =  new WeaponAngelDamageDice();
      component.EnergyDamageDice = EnergyDamageDice;
      component.Element = Element;
      component.m_MaximizeFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_MaximizeFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponBuffOnAttack))]
    public WeaponEnchantmentConfigurator AddWeaponBuffOnAttack(
        string m_Buff,
        Rounds Duration,
        PrefabLink Fx)
    {
      ValidateParam(Duration);
      ValidateParam(Fx);
      
      var component =  new WeaponBuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Duration = Duration;
      component.Fx = Fx;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnConfirmedCrit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponBuffOnConfirmedCrit))]
    public WeaponEnchantmentConfigurator AddWeaponBuffOnConfirmedCrit(
        string m_Buff,
        Rounds Duration,
        PrefabLink Fx,
        bool OnlyNatural20)
    {
      ValidateParam(Duration);
      ValidateParam(Fx);
      
      var component =  new WeaponBuffOnConfirmedCrit();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Duration = Duration;
      component.Fx = Fx;
      component.OnlyNatural20 = OnlyNatural20;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponConditionalDamageDice))]
    public WeaponEnchantmentConfigurator AddWeaponConditionalDamageDice(
        DamageDescription Damage,
        bool CheckWielder,
        bool IsBane,
        ConditionsBuilder Conditions)
    {
      ValidateParam(Damage);
      
      var component =  new WeaponConditionalDamageDice();
      component.Damage = Damage;
      component.CheckWielder = CheckWielder;
      component.IsBane = IsBane;
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponConditionalEnhancementBonus))]
    public WeaponEnchantmentConfigurator AddWeaponConditionalEnhancementBonus(
        int EnhancementBonus,
        bool CheckWielder,
        bool IsBane,
        ConditionsBuilder Conditions)
    {
      
      var component =  new WeaponConditionalEnhancementBonus();
      component.EnhancementBonus = EnhancementBonus;
      component.CheckWielder = CheckWielder;
      component.IsBane = IsBane;
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCritAutoconfirmAgainstAlignment))]
    public WeaponEnchantmentConfigurator AddWeaponCritAutoconfirmAgainstAlignment(
        AlignmentComponent EnemyAlignment)
    {
      ValidateParam(EnemyAlignment);
      
      var component =  new WeaponCritAutoconfirmAgainstAlignment();
      component.EnemyAlignment = EnemyAlignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCritAutoconfirmAgainstSize))]
    public WeaponEnchantmentConfigurator AddWeaponCritAutoconfirmAgainstSize(
        Size Size)
    {
      ValidateParam(Size);
      
      var component =  new WeaponCritAutoconfirmAgainstSize();
      component.Size = Size;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponDamageAgainstAlignment))]
    public WeaponEnchantmentConfigurator AddWeaponDamageAgainstAlignment(
        AlignmentComponent EnemyAlignment,
        DamageAlignment WeaponAlignment,
        ContextDiceValue Value,
        DamageEnergyType DamageType)
    {
      ValidateParam(EnemyAlignment);
      ValidateParam(WeaponAlignment);
      ValidateParam(Value);
      ValidateParam(DamageType);
      
      var component =  new WeaponDamageAgainstAlignment();
      component.EnemyAlignment = EnemyAlignment;
      component.WeaponAlignment = WeaponAlignment;
      component.Value = Value;
      component.DamageType = DamageType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDebuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(WeaponDebuffOnAttack))]
    public WeaponEnchantmentConfigurator AddWeaponDebuffOnAttack(
        string m_Buff,
        Rounds Duration,
        SavingThrowType SaveType,
        int DC,
        PrefabLink Fx)
    {
      ValidateParam(Duration);
      ValidateParam(SaveType);
      ValidateParam(Fx);
      
      var component =  new WeaponDebuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Duration = Duration;
      component.SaveType = SaveType;
      component.DC = DC;
      component.Fx = Fx;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyBurst"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnergyBurst))]
    public WeaponEnchantmentConfigurator AddWeaponEnergyBurst(
        DamageEnergyType Element,
        DiceType Dice)
    {
      ValidateParam(Element);
      ValidateParam(Dice);
      
      var component =  new WeaponEnergyBurst();
      component.Element = Element;
      component.Dice = Dice;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyDamageDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnergyDamageDice))]
    public WeaponEnchantmentConfigurator AddWeaponEnergyDamageDice(
        DiceFormula EnergyDamageDice,
        DamageEnergyType Element)
    {
      ValidateParam(EnergyDamageDice);
      ValidateParam(Element);
      
      var component =  new WeaponEnergyDamageDice();
      component.EnergyDamageDice = EnergyDamageDice;
      component.Element = Element;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnhancementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponEnhancementBonus))]
    public WeaponEnchantmentConfigurator AddWeaponEnhancementBonus(
        int EnhancementBonus,
        bool Stack)
    {
      
      var component =  new WeaponEnhancementBonus();
      component.EnhancementBonus = EnhancementBonus;
      component.Stack = Stack;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponExtraAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponExtraAttack))]
    public WeaponEnchantmentConfigurator AddWeaponExtraAttack(
        int Number,
        bool Haste)
    {
      
      var component =  new WeaponExtraAttack();
      component.Number = Number;
      component.Haste = Haste;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponImprovised"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponImprovised))]
    public WeaponEnchantmentConfigurator AddWeaponImprovised()
    {
      return AddComponent(new WeaponImprovised());
    }

    /// <summary>
    /// Adds <see cref="WeaponMagic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMagic))]
    public WeaponEnchantmentConfigurator AddWeaponMagic()
    {
      return AddComponent(new WeaponMagic());
    }

    /// <summary>
    /// Adds <see cref="WeaponMasterwork"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMasterwork))]
    public WeaponEnchantmentConfigurator AddWeaponMasterwork()
    {
      return AddComponent(new WeaponMasterwork());
    }

    /// <summary>
    /// Adds <see cref="WeaponMaterial"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMaterial))]
    public WeaponEnchantmentConfigurator AddWeaponMaterial(
        PhysicalDamageMaterial Material)
    {
      ValidateParam(Material);
      
      var component =  new WeaponMaterial();
      component.Material = Material;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponReality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponReality))]
    public WeaponEnchantmentConfigurator AddWeaponReality(
        DamageRealityType Reality)
    {
      ValidateParam(Reality);
      
      var component =  new WeaponReality();
      component.Reality = Reality;
      return AddComponent(component);
    }
  }
}

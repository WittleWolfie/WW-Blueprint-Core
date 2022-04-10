using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.WeaponEnchants;
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

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Configurator for <see cref="BlueprintWeaponEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class WeaponEnchantmentConfigurator : BaseItemEnchantmentConfigurator<BlueprintWeaponEnchantment, WeaponEnchantmentConfigurator>
  {
    private WeaponEnchantmentConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static WeaponEnchantmentConfigurator For(string name)
    {
      return new WeaponEnchantmentConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static WeaponEnchantmentConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintWeaponEnchantment>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponEnchantment.WeaponFxPrefab"/> (Auto Generated)
    /// </summary>
    
    public WeaponEnchantmentConfigurator SetWeaponFxPrefab(PrefabLink? weaponFxPrefab)
    {
      ValidateParam(weaponFxPrefab);

      return OnConfigureInternal(
          bp =>
          {
            bp.WeaponFxPrefab = weaponFxPrefab ?? Constants.Empty.PrefabLink;
          });
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageReroll"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponDamageReroll(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponDamageReroll();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponCriticalAdditionalAttackEnchant"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddTwoWeaponCriticalAdditionalAttackEnchant()
    {
      return AddComponent(new TwoWeaponCriticalAdditionalAttackEnchant());
    }

    /// <summary>
    /// Adds <see cref="SuppressBane"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddSuppressBane(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SuppressBane();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponCriticalConfirmationBonus(
        ContextValue? value = null,
        int additionalBonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new WeaponCriticalConfirmationBonus();
      component.Value = value ?? ContextValues.Constant(0);
      component.AdditionalBonus = additionalBonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponCriticalEdgeIncrease(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponCriticalEdgeIncrease();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeStackable"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponCriticalEdgeStackable(
        int bonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponCriticalEdgeStackable();
      component.Bonus = bonus;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponCriticalMultiplierIncrease(
        int additionalMultiplier = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponCriticalMultiplierIncrease();
      component.AdditionalMultiplier = additionalMultiplier;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageMultiplierStatReplacement"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponDamageMultiplierStatReplacement(
        StatType stat = default,
        float multiplier = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponDamageMultiplierStatReplacement();
      component.Stat = stat;
      component.Multiplier = multiplier;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponDamageStatReplacement(
        StatType stat = default,
        bool requiresFinesse = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponDamageStatReplacement();
      component.Stat = stat;
      component.RequiresFinesse = requiresFinesse;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponOversized"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponOversized(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponOversized();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealmentAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public WeaponEnchantmentConfigurator AddIgnoreConcealmentAgainstFactOwner(
        string[]? facts = null,
        bool not = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreConcealmentAgainstFactOwner();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Not = not;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDREnchantment"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddIgnoreTargetDREnchantment(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IgnoreTargetDREnchantment();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ImproveEnhancmentIfHasEnchantment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/></param>
    
    
    public WeaponEnchantmentConfigurator AddImproveEnhancmentIfHasEnchantment(
        string[]? enchantments = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ImproveEnhancmentIfHasEnchantment();
      component.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ModifyWeaponStatsConditional"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddModifyWeaponStatsConditional(
        ModifyWeaponStatsConditional.ModificationType type = default,
        DamageAlignment alignment = default,
        ContextValue? bonusDamage = null,
        AlignmentComponent wielderAlignmentRestriction = default,
        AlignmentComponent targetAlignmentRestriction = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonusDamage);

      var component = new ModifyWeaponStatsConditional();
      component.m_Type = type;
      component.Alignment = alignment;
      component.BonusDamage = bonusDamage ?? ContextValues.Constant(0);
      component.WielderAlignmentRestriction = wielderAlignmentRestriction;
      component.TargetAlignmentRestriction = targetAlignmentRestriction;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BrilliantEnergy"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddBrilliantEnergy(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BrilliantEnergy();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponDamageByBuffStack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public WeaponEnchantmentConfigurator AddIncreaseWeaponDamageByBuffStack(
        int bonusPerStack = default,
        string? checkedBuff = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new IncreaseWeaponDamageByBuffStack();
      component.BonusPerStack = bonusPerStack;
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponEnhancementBonusOnTargetFocus"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddIncreaseWeaponEnhancementBonusOnTargetFocus(
        UnitReference focusingTarget,
        ContextValue? bonusIncrementValue = null,
        ContextValue? maximumTotalEnhancementBonus = null,
        int currentEnhancementBonus = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(bonusIncrementValue);
      ValidateParam(maximumTotalEnhancementBonus);

      var component = new IncreaseWeaponEnhancementBonusOnTargetFocus();
      component.BonusIncrementValue = bonusIncrementValue ?? ContextValues.Constant(0);
      component.MaximumTotalEnhancementBonus = maximumTotalEnhancementBonus ?? ContextValues.Constant(0);
      component.m_CurrentEnhancementBonus = currentEnhancementBonus;
      component.m_FocusingTarget = focusingTarget;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MissAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public WeaponEnchantmentConfigurator AddMissAgainstFactOwner(
        string[]? facts = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MissAgainstFactOwner();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponAlignment(
        DamageAlignment alignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponAlignment();
      component.Alignment = alignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponAngelDamageDice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="maximizeFeature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public WeaponEnchantmentConfigurator AddWeaponAngelDamageDice(
        DiceFormula energyDamageDice,
        DamageEnergyType element = default,
        string? maximizeFeature = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponAngelDamageDice();
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.m_MaximizeFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(maximizeFeature);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public WeaponEnchantmentConfigurator AddWeaponBuffOnAttack(
        Rounds duration,
        string? buff = null,
        PrefabLink? fx = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(fx);

      var component = new WeaponBuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Duration = duration;
      component.Fx = fx ?? Constants.Empty.PrefabLink;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnConfirmedCrit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public WeaponEnchantmentConfigurator AddWeaponBuffOnConfirmedCrit(
        Rounds duration,
        string? buff = null,
        PrefabLink? fx = null,
        bool onlyNatural20 = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(fx);

      var component = new WeaponBuffOnConfirmedCrit();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Duration = duration;
      component.Fx = fx ?? Constants.Empty.PrefabLink;
      component.OnlyNatural20 = onlyNatural20;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalDamageDice"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponConditionalDamageDice(
        DamageDescription damage,
        bool checkWielder = default,
        bool isBane = default,
        ConditionsBuilder? conditions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(damage);

      var component = new WeaponConditionalDamageDice();
      component.Damage = damage;
      component.CheckWielder = checkWielder;
      component.IsBane = isBane;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalEnhancementBonus"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponConditionalEnhancementBonus(
        int enhancementBonus = default,
        bool checkWielder = default,
        bool isBane = default,
        ConditionsBuilder? conditions = null)
    {
      var component = new WeaponConditionalEnhancementBonus();
      component.EnhancementBonus = enhancementBonus;
      component.CheckWielder = checkWielder;
      component.IsBane = isBane;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponCritAutoconfirmAgainstAlignment(
        AlignmentComponent enemyAlignment = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponCritAutoconfirmAgainstAlignment();
      component.EnemyAlignment = enemyAlignment;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstSize"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponCritAutoconfirmAgainstSize(
        Size size = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponCritAutoconfirmAgainstSize();
      component.Size = size;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageAgainstAlignment"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponDamageAgainstAlignment(
        AlignmentComponent enemyAlignment = default,
        DamageAlignment weaponAlignment = default,
        ContextDiceValue? value = null,
        DamageEnergyType damageType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(value);

      var component = new WeaponDamageAgainstAlignment();
      component.EnemyAlignment = enemyAlignment;
      component.WeaponAlignment = weaponAlignment;
      component.Value = value ?? Constants.Empty.DiceValue;
      component.DamageType = damageType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponDebuffOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    
    public WeaponEnchantmentConfigurator AddWeaponDebuffOnAttack(
        Rounds duration,
        string? buff = null,
        SavingThrowType saveType = default,
        int dC = default,
        PrefabLink? fx = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(fx);

      var component = new WeaponDebuffOnAttack();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Duration = duration;
      component.SaveType = saveType;
      component.DC = dC;
      component.Fx = fx ?? Constants.Empty.PrefabLink;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyBurst"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponEnergyBurst(
        DamageEnergyType element = default,
        DiceType dice = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponEnergyBurst();
      component.Element = element;
      component.Dice = dice;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyDamageDice"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponEnergyDamageDice(
        DiceFormula energyDamageDice,
        DamageEnergyType element = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponEnergyDamageDice();
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnhancementBonus"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponEnhancementBonus(
        int enhancementBonus = default,
        bool stack = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponEnhancementBonus();
      component.EnhancementBonus = enhancementBonus;
      component.Stack = stack;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponExtraAttack"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponExtraAttack(
        int number = default,
        bool haste = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponExtraAttack();
      component.Number = number;
      component.Haste = haste;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponImprovised"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponImprovised(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponImprovised();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponMasterwork"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponMasterwork(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponMasterwork();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponMaterial"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponMaterial(
        PhysicalDamageMaterial material = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponMaterial();
      component.Material = material;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="WeaponReality"/> (Auto Generated)
    /// </summary>
    
    
    public WeaponEnchantmentConfigurator AddWeaponReality(
        DamageRealityType reality = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new WeaponReality();
      component.Reality = reality;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}

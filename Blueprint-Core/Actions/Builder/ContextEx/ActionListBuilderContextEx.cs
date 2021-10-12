using System;
using System.Linq;
using BlueprintCore.Blueprints;
using BlueprintCore.Conditions;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Quests;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation;
using Kingmaker.Visual.Animation.Actions;

namespace BlueprintCore.Actions.Builder.ContextEx
{
  /** Extension to ActionListBuilder which supports all ContextAction types. */
  public static class ActionListBuilderContextEx
  {
    /** 
     * ContextActionAddFeature
     *
     * @param feature BlueprintFeature
     */
    public static ActionListBuilder AddFeature(this ActionListBuilder builder, string feature)
    {
      var addFeature = ElementTool.Create<ContextActionAddFeature>();
      addFeature.m_PermanentFeature =
          BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(feature);
      return builder.Add(addFeature);
    }

    /**
     * ContextActionAddLocustClone
     *
     * @param feature BlueprintFeature
     */
    public static ActionListBuilder AddLocustClone(this ActionListBuilder builder, string feature)
    {
      var addClone = ElementTool.Create<ContextActionAddLocustClone>();
      addClone.m_CloneFeature =
          BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(feature);
      return builder.Add(addClone);
    }

    /** ContextActionAeonRollbackToSavedState */
    public static ActionListBuilder AeonRollbackState(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionAeonRollbackToSavedState>());
    }

    /**
     * ContextActionApplyBuff
     *
     * @param buff BlueprintBuff
     */
    public static ActionListBuilder ApplyBuff(
        this ActionListBuilder builder,
        string buff,
        bool useDurationSeconds = false,
        float durationSeconds = 0f,
        ContextDurationValue duration = null,
        bool permanent = false,
        bool isFromSpell = false,
        bool dispellable = true,
        bool toCaster = false,
        bool asChild = true,
        bool sameDuration = false)
    {
      if (!useDurationSeconds && duration == null && !permanent)
      {
        throw new InvalidOperationException("Missing duration.");
      }
      var applyBuff = ElementTool.Create<ContextActionApplyBuff>();
      applyBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff);
      applyBuff.UseDurationSeconds = useDurationSeconds;
      applyBuff.DurationSeconds = durationSeconds;
      applyBuff.DurationValue = duration;
      applyBuff.Permanent = permanent;
      applyBuff.IsFromSpell = isFromSpell;
      applyBuff.IsNotDispelable = !dispellable;
      applyBuff.ToCaster = toCaster;
      applyBuff.AsChild = asChild;
      applyBuff.SameDuration = sameDuration;
      return builder.Add(applyBuff);
    }

    // Default GUIDs for ArmorEnchantPool and ShieldArmorEnchantPool
    private const string PlusOneArmor = "1d9b60d57afb45c4f9bb0a3c21bb3b98";
    private const string PlusTwoArmor = "d45bfd838c541bb40bde7b0bf0e1b684";
    private const string PlusThreeArmor = "51c51d841e9f16046a169729c13c4d4f";
    private const string PlusFourArmor = "a23bcee56c9fcf64d863dafedb369387";
    private const string PlusFiveArmor = "15d7d6cbbf56bd744b37bbf9225ea83b";

    private static BlueprintItemEnchantmentReference GetItemEnchant(string enchant)
    {
      return BlueprintTool
          .GetRef<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>(enchant);
    }

    /**
     * ContextActionArmorEnchantPool
     *
     * The caster's armor is enchanted based on its available enhancement bonus.
     * e.g. If the armor can be enchanted to +4 but already has a +1 enchantment,
     * plusThreeEnchantment is applied.
     *
     * See ArcaneArmor and SacredArmor for example usages.
     *
     * @param plus*Enchantment BlueprintItemEnchantment Defaults to TemporaryArmorEnhancementBonus*
     */
    public static ActionListBuilder ArmorEnchantPool(
        this ActionListBuilder builder,
        EnchantPoolType poolType,
        ContextDurationValue duration,
        ActivatableAbilityGroup group = ActivatableAbilityGroup.None,
        string plusOneEnchantment = PlusOneArmor,
        string plusTwoEnchantment = PlusTwoArmor,
        string plusThreeEnchantment = PlusThreeArmor,
        string plusFourEnchantment = PlusFourArmor,
        string plusFiveEnchantment = PlusFiveArmor)
    {
      var enchantArmor = ElementTool.Create<ContextActionArmorEnchantPool>();
      enchantArmor.EnchantPool = poolType;
      enchantArmor.Group = group;
      enchantArmor.DurationValue = duration;
      enchantArmor.m_DefaultEnchantments[0] = GetItemEnchant(plusOneEnchantment);
      enchantArmor.m_DefaultEnchantments[1] = GetItemEnchant(plusTwoEnchantment);
      enchantArmor.m_DefaultEnchantments[2] = GetItemEnchant(plusThreeEnchantment);
      enchantArmor.m_DefaultEnchantments[3] = GetItemEnchant(plusFourEnchantment);
      enchantArmor.m_DefaultEnchantments[4] = GetItemEnchant(plusFiveEnchantment);
      return builder.Add(enchantArmor);
    }

    /** 
     * ContextActionShieldArmorEnchantPool
     *
     * The caster's shield is enchanted based on its available enhancement bonus.
     * e.g. If the shield can be enchanted to +4 but already has a +1 enchantment,
     * plusThreeEnchantment is applied.
     *
     * See SacredArmor for example usage.
     *
     * @param plus*Enchantment BlueprintItemEnchantment Defaults to TemporaryArmorEnhancementBonus*
     */
    public static ActionListBuilder ShieldArmorEnchantPool(
        this ActionListBuilder builder,
        EnchantPoolType poolType,
        ContextDurationValue duration,
        ActivatableAbilityGroup group = ActivatableAbilityGroup.None,
        string plusOneEnchantment = PlusOneArmor,
        string plusTwoEnchantment = PlusTwoArmor,
        string plusThreeEnchantment = PlusThreeArmor,
        string plusFourEnchantment = PlusFourArmor,
        string plusFiveEnchantment = PlusFiveArmor)
    {
      var enchant = ElementTool.Create<ContextActionShieldArmorEnchantPool>();
      enchant.EnchantPool = poolType;
      enchant.Group = group;
      enchant.DurationValue = duration;
      enchant.m_DefaultEnchantments[0] = GetItemEnchant(plusOneEnchantment);
      enchant.m_DefaultEnchantments[1] = GetItemEnchant(plusTwoEnchantment);
      enchant.m_DefaultEnchantments[2] = GetItemEnchant(plusThreeEnchantment);
      enchant.m_DefaultEnchantments[3] = GetItemEnchant(plusFourEnchantment);
      enchant.m_DefaultEnchantments[4] = GetItemEnchant(plusFiveEnchantment);
      return builder.Add(enchant);
    }

    // Default GUIDs for WeaponEnchantPool and ShieldWeaponEnchantPool
    private const string PlusOneWeapon = "d704f90f54f813043a525f304f6c0050";
    private const string PlusTwoWeapon = "9e9bab3020ec5f64499e007880b37e52";
    private const string PlusThreeWeapon = "d072b841ba0668846adeb007f623bd6c";
    private const string PlusFourWeapon = "6a6a0901d799ceb49b33d4851ff72132";
    private const string PlusFiveWeapon = "746ee366e50611146821d61e391edf16";

    /** 
     * ContextActionWeaponEnchantPool
     *
     * The caster's weapon is enchanted based on its available enhancement bonus.
     * e.g. If the weapon can be enchanted to +4 but already has a +1 enchantment,
     * plusThreeEnchantment is applied.
     *
     * See ArcaneWeapon or SacredWeapon for example usage.
     *
     * @param plus*Enchantment BlueprintItemEnchantment Defaults to TemporaryEnhancement*
     */
    public static ActionListBuilder WeaponEnchantPool(
        this ActionListBuilder builder,
        EnchantPoolType poolType,
        ContextDurationValue duration,
        ActivatableAbilityGroup group = ActivatableAbilityGroup.None,
        string plusOneEnchantment = PlusOneWeapon,
        string plusTwoEnchantment = PlusTwoWeapon,
        string plusThreeEnchantment = PlusThreeWeapon,
        string plusFourEnchantment = PlusFourWeapon,
        string plusFiveEnchantment = PlusFiveWeapon)
    {
      var enchant = ElementTool.Create<ContextActionWeaponEnchantPool>();
      enchant.EnchantPool = poolType;
      enchant.Group = group;
      enchant.DurationValue = duration;
      enchant.m_DefaultEnchantments[0] = GetItemEnchant(plusOneEnchantment);
      enchant.m_DefaultEnchantments[1] = GetItemEnchant(plusTwoEnchantment);
      enchant.m_DefaultEnchantments[2] = GetItemEnchant(plusThreeEnchantment);
      enchant.m_DefaultEnchantments[3] = GetItemEnchant(plusFourEnchantment);
      enchant.m_DefaultEnchantments[4] = GetItemEnchant(plusFiveEnchantment);
      return builder.Add(enchant);
    }

    /** 
     * ContextActionShieldWeaponEnchantPool
     *
     * The caster's shield is enchanted based on its available enhancement bonus.
     * e.g. If the shield can be enchanted to +4 but already has a +1 enchantment,
     * plusThreeEnchantment is applied.
     *
     * See SacredWeapon for example usage.
     *
     * @param plus*Enchantment BlueprintItemEnchantment Defaults to TemporaryEnhancement*
     */
    public static ActionListBuilder ShieldWeaponEnchantPool(
        this ActionListBuilder builder,
        EnchantPoolType poolType,
        ContextDurationValue duration,
        ActivatableAbilityGroup group = ActivatableAbilityGroup.None,
        string plusOneEnchantment = PlusOneWeapon,
        string plusTwoEnchantment = PlusTwoWeapon,
        string plusThreeEnchantment = PlusThreeWeapon,
        string plusFourEnchantment = PlusFourWeapon,
        string plusFiveEnchantment = PlusFiveWeapon)
    {
      var enchant = ElementTool.Create<ContextActionShieldWeaponEnchantPool>();
      enchant.EnchantPool = poolType;
      enchant.Group = group;
      enchant.DurationValue = duration;
      enchant.m_DefaultEnchantments[0] = GetItemEnchant(plusOneEnchantment);
      enchant.m_DefaultEnchantments[1] = GetItemEnchant(plusTwoEnchantment);
      enchant.m_DefaultEnchantments[2] = GetItemEnchant(plusThreeEnchantment);
      enchant.m_DefaultEnchantments[3] = GetItemEnchant(plusFourEnchantment);
      enchant.m_DefaultEnchantments[4] = GetItemEnchant(plusFiveEnchantment);
      return builder.Add(enchant);
    }

    /**
     * ContextActionAttackWithWeapon
     *
     * @param weapon BlueprintItemWeapon
     */
    public static ActionListBuilder AttackWithWeapon(
        this ActionListBuilder builder, StatType damageStat, string weapon)
    {
      var attack = ElementTool.Create<ContextActionAttackWithWeapon>();
      attack.m_Stat = damageStat;
      attack.m_WeaponRef =
          BlueprintTool.GetRef<BlueprintItemWeapon, BlueprintItemWeaponReference>(weapon);
      return builder.Add(attack);
    }

    /** ContextActionBatteringBlast */
    public static ActionListBuilder BatteringBlast(
        this ActionListBuilder builder, bool remove = false)
    {
      var blast = ElementTool.Create<ContextActionBatteringBlast>();
      blast.Remove = remove;
      return builder.Add(blast);
    }

    /** ContextActionBreakFree */
    public static ActionListBuilder BreakFree(
        this ActionListBuilder builder,
        bool useCMB = false,
        bool useCMD = false,
        ActionListBuilder onSuccess = null,
        ActionListBuilder onFail = null)
    {
      var breakFree = ElementTool.Create<ContextActionBreakFree>();
      breakFree.UseCMB = useCMB;
      breakFree.UseCMD = useCMD;
      breakFree.Success = onSuccess?.Build() ?? Constants.Empty.Actions;
      breakFree.Failure = onFail?.Build() ?? Constants.Empty.Actions;
      return builder.Add(breakFree);
    }

    /** ContextActionBreathOfLife */
    public static ActionListBuilder BreathOfLife(
        this ActionListBuilder builder, ContextDiceValue value)
    {
      var breathOfLife = ElementTool.Create<ContextActionBreathOfLife>();
      breathOfLife.Value = value;
      return builder.Add(breathOfLife);
    }

    /** ContextActionBreathOfMoney */
    public static ActionListBuilder BreathOfMoney(
        this ActionListBuilder builder, ContextValue minCoins, ContextValue maxCoins)
    {
      var breathOfMoney = ElementTool.Create<ContextActionBreathOfMoney>();
      breathOfMoney.MinCoins = minCoins;
      breathOfMoney.MaxCoins = maxCoins;
      return builder.Add(breathOfMoney);
    }

    /**
     * ContextActionCastSpell
     *
     * @param spell BlueprintAbility
     */
    public static ActionListBuilder CastSpell(
        this ActionListBuilder builder,
        string spell,
        bool castByTarget = false,
        ContextValue overrideDC = null,
        ContextValue overrideLevel = null)
    {
      var castSpell = ElementTool.Create<ContextActionCastSpell>();
      castSpell.m_Spell = BlueprintTool.GetRef<BlueprintAbility, BlueprintAbilityReference>(spell);
      castSpell.CastByTarget = castByTarget;
      if (overrideDC != null)
      {
        castSpell.OverrideDC = true;
        castSpell.DC = overrideDC;
      }
      if (overrideLevel != null)
      {
        castSpell.OverrideSpellLevel = true;
        castSpell.SpellLevel = overrideLevel;
      }
      return builder.Add(castSpell);
    }

    /** ContextActionChangeSharedValue */
    public static ActionListBuilder SetSharedValue(
        this ActionListBuilder builder, AbilitySharedValue sharedValue, ContextValue setValue)
    {
      return ChangeSharedValue(builder, sharedValue, SharedValueChangeType.Set, set: setValue);
    }

    /** ContextActionChangeSharedValue */
    public static ActionListBuilder SetSharedValueToHD(
        this ActionListBuilder builder, AbilitySharedValue sharedValue)
    {
      return ChangeSharedValue(builder, sharedValue, SharedValueChangeType.SubHD);
    }

    /** ContextActionChangeSharedValue */
    public static ActionListBuilder AddToSharedValue(
        this ActionListBuilder builder, AbilitySharedValue sharedValue, ContextValue addValue)
    {
      return ChangeSharedValue(builder, sharedValue, SharedValueChangeType.Add, add: addValue);
    }

    /** ContextActionChangeSharedValue */
    public static ActionListBuilder MultiplySharedValue(
        this ActionListBuilder builder, AbilitySharedValue sharedValue, ContextValue multiplyValue)
    {
      return ChangeSharedValue(
          builder, sharedValue, SharedValueChangeType.Multiply, multiply: multiplyValue);
    }

    /** ContextActionChangeSharedValue */
    public static ActionListBuilder DivideSharedValueBy2(
        this ActionListBuilder builder, AbilitySharedValue sharedValue)
    {
      return ChangeSharedValue(builder, sharedValue, SharedValueChangeType.Div2);
    }

    /** ContextActionChangeSharedValue */
    public static ActionListBuilder DivideSharedValueBy4(
        this ActionListBuilder builder, AbilitySharedValue sharedValue)
    {
      return ChangeSharedValue(builder, sharedValue, SharedValueChangeType.Div4);
    }

    private static ActionListBuilder ChangeSharedValue(
        ActionListBuilder builder,
        AbilitySharedValue sharedValue,
        SharedValueChangeType type,
        ContextValue add = null,
        ContextValue set = null,
        ContextValue multiply = null)
    {
      var changeValue = ElementTool.Create<ContextActionChangeSharedValue>();
      changeValue.SharedValue = sharedValue;
      changeValue.Type = type;
      changeValue.AddValue = add;
      changeValue.SetValue = set;
      changeValue.MultiplyValue = multiply;
      return builder.Add(changeValue);
    }

    /**
     * ContextActionClearSummonPool
     *
     * @param pool BlueprintSummonPool
     */
    public static ActionListBuilder ClearSummonPool(this ActionListBuilder builder, string pool)
    {
      var clearSummons = ElementTool.Create<ContextActionClearSummonPool>();
      clearSummons.m_SummonPool =
          BlueprintTool.GetRef<BlueprintSummonPool, BlueprintSummonPoolReference>(pool);
      return builder.Add(clearSummons);
    }

    /** ContextActionCombatManeuver */
    public static ActionListBuilder CombatManeuver(
        this ActionListBuilder builder,
        CombatManeuver type,
        ActionListBuilder onSuccess,
        bool ignoreConcealment = false,
        bool batteringBlast = false,
        StatType useStat = StatType.Unknown,
        bool useKineticistMainStat = false,
        bool useCastingStat = false,
        bool useCasterLevelForBAB = false,
        bool useBestMentalStat = false)
    {
      var maneuver = ElementTool.Create<ContextActionCombatManeuver>();
      maneuver.Type = type;
      maneuver.OnSuccess = onSuccess.Build();
      maneuver.IgnoreConcealment = ignoreConcealment;
      maneuver.BatteringBlast = batteringBlast;
      maneuver.ReplaceStat =
          useStat != StatType.Unknown
              || useKineticistMainStat
              || useCastingStat
              || useCasterLevelForBAB
              || useBestMentalStat;
      maneuver.NewStat = useStat;
      maneuver.UseKineticistMainStat = useKineticistMainStat;
      maneuver.UseCastingStat = useCastingStat;
      maneuver.UseCasterLevelAsBaseAttack = useCasterLevelForBAB;
      maneuver.UseBestMentalStat = useBestMentalStat;
      return builder.Add(maneuver);
    }

    /** ContextActionCombatManeuverCustom */
    public static ActionListBuilder CustomCombatManeuver(
        this ActionListBuilder builder,
        CombatManeuver type,
        ActionListBuilder onSuccess = null,
        ActionListBuilder onFail = null)
    {
      var maneuver = ElementTool.Create<ContextActionCombatManeuverCustom>();
      maneuver.Type = type;
      maneuver.Success = onSuccess?.Build() ?? Constants.Empty.Actions;
      maneuver.Failure = onFail?.Build() ?? Constants.Empty.Actions;
      return builder.Add(maneuver);
    }

    /** ContextActionConditionalSaved */
    public static ActionListBuilder AfterSavingThrow(
        this ActionListBuilder builder,
        ActionListBuilder ifPassed = null,
        ActionListBuilder ifFailed = null)
    {
      var onSave = ElementTool.Create<ContextActionConditionalSaved>();
      onSave.Succeed = ifPassed?.Build() ?? Constants.Empty.Actions;
      onSave.Failed = ifFailed?.Build() ?? Constants.Empty.Actions;
      return builder.Add(onSave);
    }

    /**
     * ContextActionDealDamage
     *
     * @param sharedResult If specified, the resulting damage is stored in this shared value.
     * @param criticalSharedResult If specified and the associated attack roll is a critical, this
     *   shared value is set to 1.
     */
    public static ActionListBuilder DealDamage(
        this ActionListBuilder builder,
        DamageTypeDescription type,
        ContextDiceValue value,
        bool dealHalfIfSaved = false,
        bool dealHalf = false,
        bool ignoreCrit = false,
        bool isAOE = false,
        int? minHPAfterDmg = null,
        AbilitySharedValue? sharedResult = null,
        AbilitySharedValue? criticalSharedResult = null)
    {
      return DealDamage(
          builder,
          ContextActionDealDamage.Type.Damage,
          dealHalfIfSaved,
          ignoreCrit,
          dmgType: type,
          value: value,
          dealHalf: dealHalf,
          isAOE: isAOE,
          minHPAfterDmg: minHPAfterDmg,
          sharedResult: sharedResult,
          criticalSharedResult: criticalSharedResult);
    }

    /**
     * ContextActionDealDamage
     *
     * @param preRolledValue Deals damage equal to this shared value.
     * @param sharedResult If specified, the resulting damage is stored in this shared value.
     * @param criticalSharedResult If specified and the associated attack roll is a critical, this
     *   shared value is set to 1.
     */
    public static ActionListBuilder DealDamagePreRolled(
        this ActionListBuilder builder,
        DamageTypeDescription type,
        AbilitySharedValue preRolledValue,
        bool dealHalfIfSaved = false,
        bool dealHalf = false,
        bool alreadyHalved = false,
        bool ignoreCrit = false,
        int? minHPAfterDmg = null,
        AbilitySharedValue? sharedResult = null,
        AbilitySharedValue? criticalSharedResult = null)
    {
      return DealDamage(
          builder,
          ContextActionDealDamage.Type.Damage,
          dealHalfIfSaved,
          ignoreCrit,
          dmgType: type,
          preRolledValue: preRolledValue,
          dealHalf: dealHalf,
          alreadyHalved: alreadyHalved,
          minHPAfterDmg: minHPAfterDmg,
          sharedResult: sharedResult,
          criticalSharedResult: criticalSharedResult);
    }

    /**
     * ContextActionDealDamage
     *
     * @param sharedResult If specified, the resulting damage is stored in this shared value.
     * @param criticalSharedResult If specified and the associated attack roll is a critical, this
     *   shared value is set to 1.
     */
    public static ActionListBuilder DealAbilityDamage(
        this ActionListBuilder builder,
        StatType type,
        ContextDiceValue value,
        bool isDrain = false,
        bool dealHalfIfSaved = false,
        bool ignoreCrit = false,
        int? minStatAfterDmg = null,
        AbilitySharedValue? sharedResult = null,
        AbilitySharedValue? criticalSharedResult = null)
    {
      return DealDamage(
          builder,
          ContextActionDealDamage.Type.AbilityDamage,
          dealHalfIfSaved,
          ignoreCrit,
          statType: type,
          value: value,
          isDrain: isDrain,
          minHPAfterDmg: minStatAfterDmg,
          sharedResult: sharedResult,
          criticalSharedResult: criticalSharedResult);
    }

    /**
     * ContextActionDealDamage
     *
     * @param sharedResult If specified, the resulting damage is stored in this shared value.
     * @param criticalSharedResult If specified and the associated attack roll is a critical, this
     *   shared value is set to 1.
     */
    public static ActionListBuilder DealPermanentNegativeLevels(
        this ActionListBuilder builder,
        ContextDiceValue damageValue,
        bool dealHalfIfSaved = false,
        bool ignoreCrit = false,
        AbilitySharedValue? sharedResult = null,
        AbilitySharedValue? criticalSharedResult = null)
    {
      return DealDamage(
        builder,
        ContextActionDealDamage.Type.EnergyDrain,
        dealHalfIfSaved,
        ignoreCrit,
        drainType: EnergyDrainType.Permanent,
        value: damageValue,
        sharedResult: sharedResult,
        criticalSharedResult: criticalSharedResult);
    }

    /**
     * ContextActionDealDamage
     *
     * @param sharedResult If specified, the resulting damage is stored in this shared value.
     * @param criticalSharedResult If specified and the associated attack roll is a critical, this
     *   shared value is set to 1.
     */
    public static ActionListBuilder DealTempNegativeLevels(
        this ActionListBuilder builder,
        ContextDiceValue damageValue,
        ContextDurationValue duration,
        bool permanentOnFailedSave = false,
        bool dealHalfIfSaved = false,
        bool ignoreCrit = false,
        AbilitySharedValue? sharedResult = null,
        AbilitySharedValue? criticalSharedResult = null)
    {
      return DealDamage(
        builder,
        ContextActionDealDamage.Type.EnergyDrain,
        dealHalfIfSaved,
        ignoreCrit,
        drainType:
            permanentOnFailedSave
                ? EnergyDrainType.SaveOrBecamePermanent
                : EnergyDrainType.Temporary,
        duration: duration,
        value: damageValue,
        sharedResult: sharedResult,
        criticalSharedResult: criticalSharedResult);
    }

    private static ActionListBuilder DealDamage(
      ActionListBuilder builder,
      ContextActionDealDamage.Type type,
      bool halfIfSaved,
      bool ignoreCrit,
      bool dealHalf = false,
      bool alreadyHalved = false,
      bool isAOE = false,
      bool isDrain = false,
      ContextDiceValue value = null,
      DamageTypeDescription dmgType = null,
      ContextDurationValue duration = null,
      StatType? statType = null,
      EnergyDrainType? drainType = null,
      int? minHPAfterDmg = null,
      AbilitySharedValue? preRolledValue = null,
      AbilitySharedValue? sharedResult = null,
      AbilitySharedValue? criticalSharedResult = null)
    {
      var dmg = ElementTool.Create<ContextActionDealDamage>();
      dmg.m_Type = type;
      dmg.HalfIfSaved = halfIfSaved;
      dmg.IgnoreCritical = ignoreCrit;
      dmg.Half = dealHalf;
      dmg.AlreadyHalved = alreadyHalved;
      dmg.IsAoE = isAOE;
      dmg.Drain = isDrain;
      dmg.Value = value ?? Constants.Empty.DiceValue;

      if (dmgType is not null)
      {
        Validator.Check(dmgType);
        dmg.DamageType = dmgType;
      }
      if (duration is not null) { dmg.Duration = duration; }
      if (statType is not null) { dmg.AbilityType = statType.Value; }
      if (drainType is not null) { dmg.EnergyDrainType = drainType.Value; }
      if (minHPAfterDmg is not null)
      {
        dmg.UseMinHPAfterDamage = true;
        dmg.MinHPAfterDamage = minHPAfterDmg.Value;
      }
      if (preRolledValue is not null)
      {
        dmg.ReadPreRolledFromSharedValue = true;
        dmg.PreRolledSharedValue = preRolledValue.Value;
      }
      if (sharedResult is not null)
      {
        dmg.WriteResultToSharedValue = true;
        dmg.ResultSharedValue = sharedResult.Value;
      }
      if (criticalSharedResult is not null)
      {
        dmg.WriteCriticalToSharedValue = true;
        dmg.CriticalSharedValue = criticalSharedResult.Value;
      }
      return builder.Add(dmg);
    }

    /** ContextActionDealWeaponDamage */
    public static ActionListBuilder DealWeaponDamage(
        this ActionListBuilder builder, bool allowRanged = false)
    {
      var dmg = ElementTool.Create<ContextActionDealWeaponDamage>();
      dmg.CanBeRanged = allowRanged;
      return builder.Add(dmg);
    }

    /** ContextActionDetectSecretDoors */
    public static ActionListBuilder DetectSecretDoors(this ActionListBuilder builder)
    {
      var detectDoors = ElementTool.Create<ContextActionDetectSecretDoors>();
      return builder.Add(detectDoors);
    }

    /** ContextActionDevourBySwarm */
    public static ActionListBuilder DevourWithSwarm(this ActionListBuilder builder)
    {
      var devour = ElementTool.Create<ContextActionDevourBySwarm>();
      return builder.Add(devour);
    }

    /** ContextActionDisarm */
    public static ActionListBuilder Disarm(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDisarm>());
    }

    /** ContextActionDismissAreaEffect */
    public static ActionListBuilder DismissAOE(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismissAreaEffect>());
    }

    /** ContextActionDismount */
    public static ActionListBuilder Dismount(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismount>());
    }

    /**
     * ContextActionDispelMagic
     *
     * @param checkEitherSchoolOrDescriptor By default dispel only effects things matching both the
     *   required SpellSchool and SpellDescriptor. If this is true, effects only need to satisfy one
     *   or the other.
     */
    public static ActionListBuilder Dispel(
        this ActionListBuilder builder,
        ContextActionDispelMagic.BuffType type,
        RuleDispelMagic.CheckType checkType,
        ContextValue maxSpellLevel,
        bool onlyDispelEnemyBuffs = false,
        bool removeOnlyOne = false,
        int bonus = 0,
        ContextValue contextBonus = null,
        ActionListBuilder onSuccess = null,
        ActionListBuilder onFail = null,
        SpellSchool[] limitToSchools = null,
        SpellDescriptor? limitToDescriptor = null,
        bool checkEitherSchoolOrDescriptor = false,
        StatType skill = StatType.Unknown,
        ContextValue maxCasterLevel = null)
    {
      var dispel = ElementTool.Create<ContextActionDispelMagic>();
      dispel.m_BuffType = type;
      dispel.m_CheckType = checkType;
      dispel.m_MaxSpellLevel = maxSpellLevel;
      dispel.OnlyTargetEnemyBuffs = onlyDispelEnemyBuffs;
      dispel.m_StopAfterFirstRemoved = removeOnlyOne;
      dispel.CheckBonus = bonus;
      dispel.ContextBonus = contextBonus ?? 0;
      dispel.OnSuccess = onSuccess?.Build() ?? Constants.Empty.Actions;
      dispel.OnFail = onFail?.Build() ?? Constants.Empty.Actions;
      dispel.Schools = limitToSchools ?? Array.Empty<SpellSchool>();
      dispel.Descriptor = limitToDescriptor ?? SpellDescriptor.None;
      dispel.CheckSchoolOrDescriptor = checkEitherSchoolOrDescriptor;
      dispel.m_Skill = skill;

      if (maxCasterLevel is not null)
      {
        dispel.m_UseMaxCasterLevel = true;
        dispel.m_MaxCasterLevel = maxCasterLevel;
      }
      if ((dispel.IsSkillCheck && dispel.m_Skill == StatType.Unknown)
          || !dispel.IsSkillCheck && dispel.m_Skill != StatType.Unknown)
      {
        throw new InvalidCastException($"Mismatched CheckType and StatType: {checkType}, {skill}");
      }
      return builder.Add(dispel);
    }

    /** ContextActionDropItems */
    public static ActionListBuilder DropItems(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDropItems>());
    }

    /**
     * ContextActionEnchantWornItem
     *
     * @param enchantment BlueprintItemEnchantment
     */
    public static ActionListBuilder EnchantWornItem(
        this ActionListBuilder builder,
        string enchantment,
        EquipSlotBase.SlotType slot,
        ContextDurationValue duration,
        bool onCaster = false,
        bool removeOnUnequip = false)
    {
      var enchant = ElementTool.Create<ContextActionEnchantWornItem>();
      enchant.m_Enchantment =
          BlueprintTool
              .GetRef<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>(enchantment);
      enchant.Slot = slot;
      enchant.DurationValue = duration;
      enchant.ToCaster = onCaster;
      enchant.RemoveOnUnequip = removeOnUnequip;
      return builder.Add(enchant);
    }

    /**
     * ContextActionFinishObjective
     *
     * @param objective BlueprintQuestObjective
     */
    public static ActionListBuilder FinishObjective(
        this ActionListBuilder builder, string objective)
    {
      var finish = ElementTool.Create<ContextActionFinishObjective>();
      finish.m_Objective =
          BlueprintTool
              .GetRef<BlueprintQuestObjective, BlueprintQuestObjectiveReference>(objective);
      return builder.Add(finish);
    }

    /** ContextActionForEachSwallowedUnit */
    public static ActionListBuilder OnEachSwallowedUnit(
        this ActionListBuilder builder, ActionListBuilder onEachUnit)
    {
      var onUnits = ElementTool.Create<ContextActionForEachSwallowedUnit>();
      onUnits.Action = onEachUnit.Build();
      return builder.Add(onUnits);
    }

    /** ContextActionGiveExperience */
    public static ActionListBuilder GiveExperience(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionGiveExperience>());
    }

    /**
     * ContextActionGrapple
     *
     * @param *Buff BlueprintBuff Applied for the duration of the grapple check.
     */
    public static ActionListBuilder Grapple(
        this ActionListBuilder builder, string casterBuff = null, string targetBuff = null)
    {
      var grapple = ElementTool.Create<ContextActionGrapple>();
      if (casterBuff != null)
      {
        grapple.m_CasterBuff =
            BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(casterBuff);
      }
      if (targetBuff != null)
      {
        grapple.m_TargetBuff =
            BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(targetBuff);
      }
      return builder.Add(grapple);
    }

    /** ContextActionHealEnergyDrain */
    public static ActionListBuilder HealNegativeLevels(
        this ActionListBuilder builder,
        EnergyDrainHealType tempLevels = EnergyDrainHealType.None,
        EnergyDrainHealType permanentLevels = EnergyDrainHealType.None)
    {
      var heal = ElementTool.Create<ContextActionHealEnergyDrain>();
      heal.TemporaryNegativeLevelsHeal = tempLevels;
      heal.PermanentNegativeLevelsHeal = permanentLevels;
      return builder.Add(heal);
    }

    /**
     * ContextActionHealStatDamage
     *
     * @param sharedResult If specified, the amount of healing done will be stored in this shared
     *   value.
     */
    public static ActionListBuilder HealStatDamage(
        this ActionListBuilder builder,
        ContextActionHealStatDamage.StatDamageHealType type,
        ContextActionHealStatDamage.StatClass statClass,
        ContextDiceValue value = null,
        bool healDrain = false,
        AbilitySharedValue? sharedResult = null)
    {
      if (type == ContextActionHealStatDamage.StatDamageHealType.Dice && value == null)
      {
        throw new InvalidOperationException("Cannot use StatDamageHealType.Dice without a value.");
      }

      var heal = ElementTool.Create<ContextActionHealStatDamage>();
      heal.m_HealType = type;
      heal.m_StatClass = statClass;
      heal.Value = value;
      heal.HealDrain = healDrain;
      if (sharedResult != null)
      {
        heal.WriteResultToSharedValue = true;
        heal.ResultSharedValue = sharedResult.Value;
      }
      return builder.Add(heal);
    }

    /** ContextActionHealTarget */
    public static ActionListBuilder HealTarget(
        this ActionListBuilder builder, ContextDiceValue value)
    {
      var heal = ElementTool.Create<ContextActionHealTarget>();
      heal.Value = value;
      return builder.Add(heal);
    }

    /** ContextActionHideInPlainSight */
    public static ActionListBuilder HideInPlainSight(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionHideInPlainSight>());
    }

    /** ContextActionKill */
    public static ActionListBuilder Kill(
        this ActionListBuilder builder,
        UnitState.DismemberType dismember = UnitState.DismemberType.None)
    {
      var kill = ElementTool.Create<ContextActionKill>();
      kill.Dismember = dismember;
      return builder.Add(kill);
    }

    /** ContextActionKnockdownTarget */
    public static ActionListBuilder Knockdown(
        this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionKnockdownTarget>());
    }

    /** ContextActionMakeKnowledgeCheck */
    public static ActionListBuilder KnowledgeCheck(
        this ActionListBuilder builder,
        ActionListBuilder onSuccess = null,
        ActionListBuilder onFail = null)
    {
      var knowledgeCheck = ElementTool.Create<ContextActionMakeKnowledgeCheck>();
      knowledgeCheck.SuccessActions = onSuccess?.Build() ?? Constants.Empty.Actions;
      knowledgeCheck.FailActions = onFail?.Build() ?? Constants.Empty.Actions;
      return builder.Add(knowledgeCheck);
    }

    /** ContextActionMarkForceDismemberOwner */
    public static ActionListBuilder MarkOwnerForDismemberment(
        this ActionListBuilder builder,
        UnitState.DismemberType type = UnitState.DismemberType.Normal)
    {
      var markForDismemberment = ElementTool.Create<ContextActionMarkForceDismemberOwner>();
      markForDismemberment.ForceDismemberType = type;
      return builder.Add(markForDismemberment);
    }

    /** ContextActionMeleeAttack */
    public static ActionListBuilder MeleeAttack(
        this ActionListBuilder builder,
        bool autoCritThreat = false,
        bool autoCritConfirm = false,
        bool autoHit = false,
        bool ignoreStatBonus = false,
        bool selectNewTarget = false)
    {
      var attack = ElementTool.Create<ContextActionMeleeAttack>();
      attack.AutoCritThreat = autoCritThreat;
      attack.AutoCritConfirmation = autoCritConfirm;
      attack.AutoHit = autoHit;
      attack.IgnoreStatBonus = ignoreStatBonus;
      attack.SelectNewTarget = selectNewTarget;
      return builder.Add(attack);
    }

    /** ContextActionMount */
    public static ActionListBuilder Mount(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionMount>());
    }

    /** ContextActionOnContextCaster */
    public static ActionListBuilder OnCaster(
        this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onCaster = ElementTool.Create<ContextActionOnContextCaster>();
      onCaster.Actions = actions.Build();
      return builder.Add(onCaster);
    }

    /** ContextActionOnOwner */
    public static ActionListBuilder OnOwner(
        this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onOwner = ElementTool.Create<ContextActionOnOwner>();
      onOwner.Actions = actions.Build();
      return builder.Add(onOwner);
    }

    /**
     * ContextActionOnRandomAreaTarget
     *
     * -The component's field `OnEnemies` is unused. It only targets enemies.
     * -Only works inside of AbilityAreaEffectRunAction.
     */
    public static ActionListBuilder OnRandomEnemyInAOE(
        this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onEnemy = ElementTool.Create<ContextActionOnRandomAreaTarget>();
      onEnemy.Actions = actions.Build();
      return builder.Add(onEnemy);
    }

    /**
     * ContextActionOnRandomTargetsAround
     *
     * @param ignoreFact BlueprintUnitFact Units with this fact are ignored.
     */
    public static ActionListBuilder OnRandomUnitNearTarget(
        this ActionListBuilder builder,
        ActionListBuilder actions,
        int radiusInFeet,
        int numTargets = 1,
        bool targetEnemies = true,
        string ignoreFact = null)
    {
      var onUnit = ElementTool.Create<ContextActionOnRandomTargetsAround>();
      onUnit.Actions = actions.Build();
      onUnit.Radius = new Feet(radiusInFeet);
      onUnit.NumberOfTargets = numTargets;
      onUnit.OnEnemies = targetEnemies;
      onUnit.m_FilterNoFact =
          ignoreFact is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintUnitFactReference>(null)
              : BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(ignoreFact);
      return builder.Add(onUnit);
    }

    /** ContextActionOnSwarmTargets */
    public static ActionListBuilder OnSwarmTargets(
        this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onTarget = ElementTool.Create<ContextActionOnSwarmTargets>();
      onTarget.Actions = actions.Build();
      return builder.Add(onTarget);
    }

    /** ContextActionPartyMembers */
    public static ActionListBuilder OnPartyMembers(
        this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onParty = ElementTool.Create<ContextActionPartyMembers>();
      onParty.Action = actions.Build();
      return builder.Add(onParty);
    }

    /** ContextActionProjectileFx */
    public static ActionListBuilder ProjectileFx(this ActionListBuilder builder, string projectile)
    {
      var projectileFx = ElementTool.Create<ContextActionProjectileFx>();
      projectileFx.m_Projectile =
          BlueprintTool.GetRef<BlueprintProjectile, BlueprintProjectileReference>(projectile);
      return builder.Add(projectileFx);
    }

    /** ContextActionProvokeAttackFromCaster */
    public static ActionListBuilder ProvokeOpportunityAttackFromCaster(
        this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionProvokeAttackFromCaster>());
    }

    /** ContextActionProvokeAttackOfOpportunity */
    public static ActionListBuilder ProvokeOpportunityAttack(
        this ActionListBuilder builder, bool casterProvokes = false)
    {
      var attack = ElementTool.Create<ContextActionProvokeAttackOfOpportunity>();
      attack.ApplyToCaster = casterProvokes;
      return builder.Add(attack);
    }

    /** ContextActionPush */
    public static ActionListBuilder Push(
        this ActionListBuilder builder,
        ContextValue distance,
        bool provokeOpportunityAttack = false)
    {
      var push = ElementTool.Create<ContextActionPush>();
      push.Distance = distance;
      push.ProvokeAttackOfOpportunity = provokeOpportunityAttack;
      return builder.Add(push);
    }

    /**
     * ContextActionRandomize
     *
     * @param weightedActions Pair of ActionListBuilder and an int representing the relative
     *   probability of that action compared to the rest of the entries. These map to
     *   ContextActionRandomize.ActionWrapper.
     */
    public static ActionListBuilder RandomActions(
        this ActionListBuilder builder,
        params (ActionListBuilder actions, int weight)[] weightedActions)
    {
      var actions = ElementTool.Create<ContextActionRandomize>();
      actions.m_Actions =
          weightedActions
              .Select(
                  weightedAction => new ContextActionRandomize.ActionWrapper
                  {
                    Action = weightedAction.actions.Build(),
                    Weight = weightedAction.weight
                  })
              .ToArray();
      return builder.Add(actions);
    }

    /** ContextActionRangedAttack */
    public static ActionListBuilder RangedAttack(
        this ActionListBuilder builder,
        bool autoCritThreat = false,
        bool autoCritConfirm = false,
        bool autoHit = false,
        bool ignoreStatBonus = false,
        bool selectNewTarget = false)
    {
      var attack = ElementTool.Create<ContextActionRangedAttack>();
      attack.AutoCritThreat = autoCritThreat;
      attack.AutoCritConfirmation = autoCritConfirm;
      attack.AutoHit = autoHit;
      attack.IgnoreStatBonus = ignoreStatBonus;
      attack.SelectNewTarget = selectNewTarget;
      return builder.Add(attack);
    }

    /** ContextActionRecoverItemCharges */
    public static ActionListBuilder RecoverItemCharges(
        this ActionListBuilder builder, string item, int charges = 1)
    {
      var recoverCharges = ElementTool.Create<ContextActionRecoverItemCharges>();
      recoverCharges.m_Item =
          BlueprintTool.GetRef<BlueprintItemEquipment, BlueprintItemEquipmentReference>(item);
      recoverCharges.ChargesRecoverCount = charges;
      return builder.Add(recoverCharges);
    }

    /** ContextActionReduceBuffDuration */
    public static ActionListBuilder ChangeBuffDuration(
        this ActionListBuilder builder,
        string buff,
        ContextDurationValue duration,
        bool increase,
        bool onTarget = false)
    {
      var changeDuration = ElementTool.Create<ContextActionReduceBuffDuration>();
      changeDuration.m_TargetBuff =
          BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff);
      changeDuration.DurationValue = duration;
      changeDuration.Increase = increase;
      changeDuration.ToTarget = onTarget;
      return builder.Add(changeDuration);
    }

    /**
     * ContextActionRemoveBuff
     *
     * @param buff BlueprintBuff
     */
    public static ActionListBuilder RemoveBuff(
        this ActionListBuilder builder, string buff, bool removeRank = false, bool toCaster = false)
    {
      var removeBuff = ElementTool.Create<ContextActionRemoveBuff>();
      removeBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff);
      removeBuff.RemoveRank = removeRank;
      removeBuff.ToCaster = toCaster;
      return builder.Add(removeBuff);
    }

    /** ContextActionRemoveBuffsByDescriptor */
    public static ActionListBuilder RemoveBuffsWithDescriptor(
        this ActionListBuilder builder, SpellDescriptor descriptor, bool includeThisBuff = false)
    {
      var removeBuffs = ElementTool.Create<ContextActionRemoveBuffsByDescriptor>();
      removeBuffs.SpellDescriptor = descriptor;
      removeBuffs.NotSelf = !includeThisBuff;
      return builder.Add(removeBuffs);
    }

    /**
     * ContextActionRemoveBuffSingleStack
     *
     * @param buff BlueprintBuff
     */
    public static ActionListBuilder RemoveBuffStack(this ActionListBuilder builder, string buff)
    {
      var removeStack = ElementTool.Create<ContextActionRemoveBuffSingleStack>();
      removeStack.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff);
      return builder.Add(removeStack);
    }

    /** ContextActionRemoveDeathDoor */
    public static ActionListBuilder RemoveDeathDoor(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveDeathDoor>());
    }

    /**
     * ContextActionRemoveSelf
     *
     * Only works on buffs and area effects.
     */
    public static ActionListBuilder RemoveSelf(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveSelf>());
    }

    /** ContextActionRepeatedActions */
    public static ActionListBuilder RepeatActions(
        this ActionListBuilder builder, ActionListBuilder actions, ContextDiceValue times)
    {
      var repeat = ElementTool.Create<ContextActionRepeatedActions>();
      repeat.Actions = actions.Build();
      repeat.Value = times;
      return builder.Add(repeat);
    }

    /**
     * ContextActionRestoreSpells
     *
     * @param spellbooks BlueprintSpellbook
     */
    public static ActionListBuilder RestoreSpells(
        this ActionListBuilder builder, params string[] spellbooks)
    {
      var restoreSpells = ElementTool.Create<ContextActionRestoreSpells>();
      restoreSpells.m_Spellbooks =
          spellbooks
              .Select(
                  spellbook =>
                      BlueprintTool
                          .GetRef<BlueprintSpellbook, BlueprintSpellbookReference>(spellbook))
              .ToArray();
      return builder.Add(restoreSpells);
    }

    /**
     * ContextActionResurrect
     *
     * @param healPercent Percentage of health after resurrection as a float between 0.0 and 1.0.
     * @param resurrectBuff BlueprintBuff Replaces the default resurrection buff. Must have a
     *   ResurrectionLogic component.
     */
    public static ActionListBuilder Resurrect(
        this ActionListBuilder builder, float healPercent, string resurrectBuff = null)
    {
      return Resurrect(builder, resurrectBuff, healPercent, false);
    }

    /** ContextActionResurrect */
    public static ActionListBuilder ResurrectAndFullRestore(
        this ActionListBuilder builder, string resurrectBuff = null)
    {
      return Resurrect(builder, resurrectBuff, 0.0f, true);
    }

    private static ActionListBuilder Resurrect(
        ActionListBuilder builder, string resurrectBuff, float healPercent, bool fullRestore)
    {
      var resurrect = ElementTool.Create<ContextActionResurrect>();
      resurrect.m_CustomResurrectionBuff =
          resurrectBuff == null
              ? BlueprintReferenceBase.CreateTyped<BlueprintBuffReference>(null)
              : BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(resurrectBuff);
      resurrect.ResultHealth = healPercent;
      resurrect.FullRestore = fullRestore;
      return builder.Add(resurrect);
    }

    /** ContextActionRunAnimationClip */
    public static ActionListBuilder RunAnimationClip(
        this ActionListBuilder builder,
        AnimationClipWrapper clip,
        ExecutionMode mode = ExecutionMode.Interrupted,
        float transitionIn = 0.25f,
        float transitionOut = 0.25f)
    {
      var animation = ElementTool.Create<ContextActionRunAnimationClip>();
      animation.ClipWrapper = clip;
      animation.Mode = mode;
      animation.TransitionIn = transitionIn;
      animation.TransitionOut = transitionOut;
      return builder.Add(animation);
    }

    /**
     * ContextActionSavingThrow
     *
     * @param fromBuff If this is true, onResult should have a ContextActionConditionalSaved with
     *   ContextActionApplyBuff in it's Succeed ActionList. The buff associated with that component
     *   will be attached to the RuleSavingThrow.
     */
    public static ActionListBuilder SavingThrow(
        this ActionListBuilder builder,
        SavingThrowType type,
        ActionListBuilder onResult,
        ContextValue customDC = null,
        bool fromBuff = false,
        params (ConditionsCheckerBuilder conditions, ContextValue value)[] conditionalDCModifiers)
    {
      var savingThrow = ElementTool.Create<ContextActionSavingThrow>();
      savingThrow.Type = type;
      savingThrow.Actions = onResult.Build();
      savingThrow.FromBuff = fromBuff;
      savingThrow.m_ConditionalDCIncrease =
          conditionalDCModifiers
              .Select(modifier =>
                  new ContextActionSavingThrow.ConditionalDCIncrease
                  {
                    Condition = modifier.conditions.Build(),
                    Value = modifier.value
                  })
              .ToArray();

      if (customDC is not null)
      {
        savingThrow.HasCustomDC = true;
        savingThrow.CustomDC = customDC;
      }
      return builder.Add(savingThrow);
    }

    /** ContextActionSelectByValue */
    public static ActionListBuilder RunActionWithGreatestValue(
        this ActionListBuilder builder,
        params (ContextValue value, ActionListBuilder action)[] actionVariants)
    {
      var select = ElementTool.Create<ContextActionSelectByValue>();
      select.m_Type = ContextActionSelectByValue.SelectionType.Greatest;
      select.m_Variants =
          actionVariants
              .Select(variant =>
                  new ContextActionSelectByValue.ValueAndAction
                  {
                    Value = variant.value,
                    Action = variant.action.Build()
                  })
              .ToArray();
      return builder.Add(select);
    }

    /** ContextActionShowBark */
    public static ActionListBuilder Bark(
        this ActionListBuilder builder,
        LocalizedString bark,
        bool showIfUnconcious = false,
        bool durationBasedOnTextLength = false)
    {
      var showBark = ElementTool.Create<ContextActionShowBark>();
      showBark.WhatToBark = bark;
      showBark.ShowWhileUnconscious = showIfUnconcious;
      showBark.BarkDurationByText = durationBasedOnTextLength;
      return builder.Add(showBark);
    }

    /** ContextActionSkillCheck */
    public static ActionListBuilder SkillCheck(
        this ActionListBuilder builder,
        StatType skill,
        ContextValue customDC = null,
        ActionListBuilder onSuccess = null,
        ActionListBuilder onFail = null,
        params (ConditionsCheckerBuilder condition, ContextValue value)[] dcModifiers)
    {
      return SkillCheck(
          builder, skill, customDC, false, onSuccess, onFail: onFail, dcModifiers: dcModifiers);
    }

    /** ContextActionSkillCheck */
    public static ActionListBuilder SkillCheckWithFailureDegrees(
        this ActionListBuilder builder,
        StatType skill,
        ContextValue customDC = null,
        ActionListBuilder onSuccess = null,
        ActionListBuilder onFailBy5to10 = null,
        ActionListBuilder onFailBy10orMore = null,
        params (ConditionsCheckerBuilder condition, ContextValue value)[] dcModifiers)
    {
      return SkillCheck(
          builder,
          skill,
          customDC,
          true,
          onSuccess,
          onFailBy5to10: onFailBy5to10,
          onFailBy10orMore: onFailBy10orMore,
          dcModifiers: dcModifiers);
    }

    private static ActionListBuilder SkillCheck(
        ActionListBuilder builder,
        StatType skill,
        ContextValue customDC,
        bool calculateDCDiff,
        ActionListBuilder onSuccess,
        (ConditionsCheckerBuilder condition, ContextValue value)[] dcModifiers,
        ActionListBuilder onFail = null,
        ActionListBuilder onFailBy5to10 = null,
        ActionListBuilder onFailBy10orMore = null)
    {
      var skillCheck = ElementTool.Create<ContextActionSkillCheck>();
      skillCheck.Stat = skill;
      if (customDC is not null)
      {
        skillCheck.UseCustomDC = true;
        skillCheck.CustomDC = customDC;
      }
      skillCheck.Success = onSuccess?.Build() ?? Constants.Empty.Actions;
      skillCheck.Failure = onFail?.Build() ?? Constants.Empty.Actions;
      skillCheck.FailureDiffMoreOrEqual5Less10 = onFailBy5to10?.Build() ?? Constants.Empty.Actions;
      skillCheck.FailureDiffMoreOrEqual10 = onFailBy10orMore?.Build() ?? Constants.Empty.Actions;
      skillCheck.CalculateDCDifference = calculateDCDiff;
      skillCheck.m_ConditionalDCIncrease =
          dcModifiers
              .Select(modifier =>
                  new ContextActionSkillCheck.ConditionalDCIncrease
                  {
                    Condition = modifier.condition.Build(),
                    Value = modifier.value
                  })
              .ToArray();
      return builder.Add(skillCheck);
    }

    /** ContextActionsOnPet */
    public static ActionListBuilder OnPets(
        this ActionListBuilder builder,
        ActionListBuilder actions,
        bool anyPetType = false,
        PetType type = PetType.AnimalCompanion)
    {
      var onPets = ElementTool.Create<ContextActionsOnPet>();
      onPets.Actions = actions.Build();
      onPets.AllPets = anyPetType;
      onPets.PetType = type;
      return builder.Add(onPets);
    }

    /**
     * ContextActionSpawnAreaEffect
     *
     * @param aoe BlueprintAbilityAreaEffect
     */
    public static ActionListBuilder SpawnAOE(
        this ActionListBuilder builder, string aoe, ContextDurationValue duration)
    {
      var spawnAOE = ElementTool.Create<ContextActionSpawnAreaEffect>();
      spawnAOE.m_AreaEffect =
          BlueprintTool
              .GetRef<BlueprintAbilityAreaEffect, BlueprintAbilityAreaEffectReference>(aoe);
      spawnAOE.DurationValue = duration;
      return builder.Add(spawnAOE);
    }

    /**
     * ContextActionSpawnControllableProjectile
     *
     * @param projectile BlueprintControllableProjectile
     * @param buff BlueprintBuff
     */
    public static ActionListBuilder SpawnControllableProjectile(
        this ActionListBuilder builder, string projectile, string buff)
    {
      var spawnProjectile = ElementTool.Create<ContextActionSpawnControllableProjectile>();
      spawnProjectile.ControllableProjectile =
          BlueprintTool
              .GetRef<BlueprintControllableProjectile, BlueprintControllableProjectileReference>(
                  projectile);
      spawnProjectile.AssociatedCasterBuff =
          BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff);
      return builder.Add(spawnProjectile);
    }

    /** ContextActionSpawnFx */
    public static ActionListBuilder SpawnFx(this ActionListBuilder builder, PrefabLink prefab)
    {
      var spawnFx = ElementTool.Create<ContextActionSpawnFx>();
      spawnFx.PrefabLink = prefab;
      return builder.Add(spawnFx);
    }

    /**
     * ContextActionSpawnMonster
     *
     * @param monster BlueprintUnit
     */
    public static ActionListBuilder SpawnMonster(
        this ActionListBuilder builder,
        string monster,
        ContextDiceValue count,
        ContextDurationValue duration,
        ActionListBuilder onSpawn = null,
        ContextValue level = null,
        bool controllable = false,
        bool linkToCaster = true)
    {
      return SpawnMonsterInternal(
        builder,
        monster,
        count,
        duration,
        onSpawn,
        level,
        controllable,
        linkToCaster);
    }

    /**
     * ContextActionSpawnMonster
     *
     * @param monster BlueprintUnit
     * @param summonPool BlueprintSummonPool
     */
    public static ActionListBuilder SpawnMonsterUsingSummonPool(
        this ActionListBuilder builder,
        string monster,
        string summonPool,
        ContextDiceValue count,
        ContextDurationValue duration,
        bool useSummonPoolLimit = false,
        ActionListBuilder onSpawn = null,
        ContextValue level = null,
        bool controllable = false,
        bool linkToCaster = true)
    {
      return SpawnMonsterInternal(
        builder,
        monster,
        count,
        duration,
        onSpawn,
        level,
        controllable,
        linkToCaster,
        summonPool: summonPool,
        useSummonPoolLimit: useSummonPoolLimit);
    }

    private static ActionListBuilder SpawnMonsterInternal(
        this ActionListBuilder builder,
        string monster,
        ContextDiceValue count,
        ContextDurationValue duration,
        ActionListBuilder onSpawn,
        ContextValue level,
        bool controllable,
        bool linkToCaster,
        string summonPool = null,
        bool useSummonPoolLimit = false)
    {
      var spawn = ElementTool.Create<ContextActionSpawnMonster>();
      spawn.m_Blueprint = BlueprintTool.GetRef<BlueprintUnit, BlueprintUnitReference>(monster);
      spawn.CountValue = count;
      spawn.DurationValue = duration;
      spawn.AfterSpawn = onSpawn?.Build() ?? Constants.Empty.Actions;
      spawn.LevelValue = level ?? 0;
      spawn.IsDirectlyControllable = controllable;
      spawn.DoNotLinkToCaster = !linkToCaster;

      spawn.m_SummonPool =
          summonPool is null
              ? null
              : BlueprintTool.GetRef<BlueprintSummonPool, BlueprintSummonPoolReference>(summonPool);
      spawn.UseLimitFromSummonPool = useSummonPoolLimit;
      return builder.Add(spawn);
    }

    /**
     * ContextActionSpawnUnlinkedMonster
     *
     * @param monster BlueprintUnit
     */
    public static ActionListBuilder SpawnMonsterUnlinked(
        this ActionListBuilder builder, string monster)
    {
      var spawn = ElementTool.Create<ContextActionSpawnUnlinkedMonster>();
      spawn.m_Blueprint = BlueprintTool.GetRef<BlueprintUnit, BlueprintUnitReference>(monster);
      return builder.Add(spawn);
    }

    /** ContextActionSpendAttackOfOpportunity */
    public static ActionListBuilder SpendOpportunityAttack(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSpendAttackOfOpportunity>());
    }

    /** ContextActionStealBuffs */
    public static ActionListBuilder StealBuffs(
        this ActionListBuilder builder, SpellDescriptor descriptor)
    {
      var steal = ElementTool.Create<ContextActionStealBuffs>();
      steal.m_Descriptor = descriptor;
      return builder.Add(steal);
    }

    /**
     * ContextActionSwallowWhole
     *
     * @param buff BlueprintBuff
     */
    public static ActionListBuilder SwallowWhole(this ActionListBuilder builder, string buff = null)
    {
      var swallow = ElementTool.Create<ContextActionSwallowWhole>();
      swallow.m_TargetBuff =
          buff is null
              ? null
              : BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff);
      return builder.Add(swallow);
    }

    /** ContextActionSwarmTarget */
    public static ActionListBuilder AddToSwarmTargets(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSwarmTarget>());
    }

    /** ContextActionSwarmTarget */
    public static ActionListBuilder RemoveFromSwarmTargets(this ActionListBuilder builder)
    {
      var removeTarget = ElementTool.Create<ContextActionSwarmTarget>();
      removeTarget.Remove = true;
      return builder.Add(removeTarget);
    }

    /** ContextActionTranslocate */
    public static ActionListBuilder Teleport(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionTranslocate>());
    }

    /** ContextActionUnsummon */
    public static ActionListBuilder Unsummon(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionUnsummon>());
    }

    /**
     * ContextRestoreResource
     *
     * @param resource BlueprintAbilityResource
     */
    public static ActionListBuilder RestoreResource(
        this ActionListBuilder builder, string resource, ContextValue amount = null)
    {
      var restore = ElementTool.Create<ContextRestoreResource>();
      restore.m_Resource =
          BlueprintTool
              .GetRef<BlueprintAbilityResource, BlueprintAbilityResourceReference>(resource);

      if (amount != null)
      {
        restore.ContextValueRestoration = true;
        restore.Value = amount;
      }
      return builder.Add(restore);
    }

    /** ContextRestoreResource */
    public static ActionListBuilder RestoreAllResourcesToFull(this ActionListBuilder builder)
    {
      var restore = ElementTool.Create<ContextRestoreResource>();
      restore.m_IsFullRestoreAllResources = true;
      return builder.Add(restore);
    }

    /**
     * ContextSpendResource
     *
     * @param resource BlueprintAbilityResource
     */
    public static ActionListBuilder SpendResource(
        this ActionListBuilder builder, string resource, ContextValue amount = null)
    {
      var spend = ElementTool.Create<ContextSpendResource>();
      spend.m_Resource =
          BlueprintTool
              .GetRef<BlueprintAbilityResource, BlueprintAbilityResourceReference>(resource);

      if (amount != null)
      {
        spend.ContextValueSpendure = true;
        spend.Value = amount;
      }
      return builder.Add(spend);
    }

    // Default GUIDs for Demoralize buffs
    private const string Shaken = "25ec6cb6ab1845c48a95f9c20b034220";
    private const string Frightened = "f08a7239aa961f34c8301518e71d4cdf";
    private const string DisplayWeaponProwess = "ac8d4d2e375a8c841a19ed46696e5af2";
    private const string ShatterConfidenceFeature = "14225a2e4561bfd46874c9a4a97e7133";
    private const string ShatterConfidenceBuff = "51f5a63f1a0cb9047acdad77fc437312";

    /** Demoralize */
    public static ActionListBuilder Demoralize(
        this ActionListBuilder builder,
        int bonus = 0,
        bool dazzlingDisplay = false,
        string effect = Shaken,
        string greaterEffect = Frightened,
        string swordlordProwess = DisplayWeaponProwess,
        string shatterConfidenceFeature = ShatterConfidenceFeature,
        string shatterConfidenceBuff = ShatterConfidenceBuff,
        ActionListBuilder tricksterRank3Actions = null)
    {
      var demoralize = ElementTool.Create<Demoralize>();
      demoralize.Bonus = bonus;
      demoralize.DazzlingDisplay = dazzlingDisplay;
      demoralize.m_Buff = BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(effect);
      demoralize.m_GreaterBuff =
          BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(greaterEffect);
      demoralize.m_SwordlordProwessFeature =
          BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(swordlordProwess);
      demoralize.m_ShatterConfidenceFeature =
          BlueprintTool
              .GetRef<BlueprintFeature, BlueprintFeatureReference>(shatterConfidenceFeature);
      demoralize.m_ShatterConfidenceBuff =
          BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(shatterConfidenceBuff);
      demoralize.TricksterRank3Actions = tricksterRank3Actions?.Build() ?? Constants.Empty.Actions;
      return builder.Add(demoralize);
    }

    /**
     * EnhanceWeapon
     *
     * @param enhancements BlueprintItemEnchantment
     */
    public static ActionListBuilder MagicWeapon(
        this ActionListBuilder builder,
        string[] enhancements,
        ContextDurationValue duration,
        ContextValue level,
        bool greater = false,
        bool useSecondaryHand = false)
    {
      return EnhanceWeaponInternal(
          builder,
          EnhanceWeapon.EnchantmentApplyType.MagicWeapon,
          enhancements,
          duration,
          level,
          greater,
          useSecondaryHand: useSecondaryHand);
    }

    /**
     * EnhanceWeapon
     *
     * @param enhancements BlueprintItemEnchantment
     */
    public static ActionListBuilder MagicFang(
        this ActionListBuilder builder,
        string[] enhancements,
        ContextDurationValue duration,
        ContextValue level,
        bool greater = false)
    {
      return EnhanceWeaponInternal(
          builder,
          EnhanceWeapon.EnchantmentApplyType.MagicFang,
          enhancements,
          duration,
          level,
          greater);
    }

    private static ActionListBuilder EnhanceWeaponInternal(
        ActionListBuilder builder,
        EnhanceWeapon.EnchantmentApplyType type,
        string[] enhancements,
        ContextDurationValue duration,
        ContextValue level,
        bool greater,
        bool useSecondaryHand = false)
    {
      var enhance = ElementTool.Create<EnhanceWeapon>();
      enhance.EnchantmentType = type;
      enhance.m_Enchantment =
          enhancements
              .Select(
                  enhancement =>
                      BlueprintTool
                          .GetRef<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>(
                              enhancement))
              .ToArray();
      enhance.DurationValue = duration;
      enhance.EnchantLevel = level;
      enhance.Greater = greater;
      enhance.UseSecondaryHand = useSecondaryHand;
      return builder.Add(enhance);
    }

    /**
     * SwordlordAdaptiveTacticsAdd
     *
     * @param source BlueprintUnitFact
     */
    public static ActionListBuilder SwordlordAdaptiveTacticsAdd(
        this ActionListBuilder builder, string source)
    {
      var add = ElementTool.Create<SwordlordAdaptiveTacticsAdd>();
      add.m_Source = BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(source);
      return builder.Add(add);
    }

    /** SwordlordAdaptiveTacticsClear */
    public static ActionListBuilder SwordlordAdaptiveTacticsClear(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SwordlordAdaptiveTacticsClear>());
    }

    //----- Kingmaker.Assets.UnitLogic.Mechanics.Actions -----//

    /** ContextActionPlaySound */
    public static ActionListBuilder PlaySound(this ActionListBuilder builder, string soundName)
    {
      var playSound = ElementTool.Create<ContextActionPlaySound>();
      playSound.SoundName = soundName;
      return builder.Add(playSound);
    }

    /** ContextActionResetAlignment */
    public static ActionListBuilder ResetAlignment(
        this ActionListBuilder builder, bool removeMythicLock = false)
    {
      var resetAlignment = ElementTool.Create<ContextActionResetAlignment>();
      resetAlignment.m_ResetAlignmentLock = removeMythicLock;
      return builder.Add(resetAlignment);
    }

    /** ContextActionSwarmAttack */
    public static ActionListBuilder SwarmAttack(
        this ActionListBuilder builder, ActionListBuilder attackActions)
    {
      var attack = ElementTool.Create<ContextActionSwarmAttack>();
      attack.AttackActions = attackActions.Build();
      return builder.Add(attack);
    }

    /** ContextActionSwitchDualCompanion */
    public static ActionListBuilder SwitchDualCompanion(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSwitchDualCompanion>());
    }
  }
}
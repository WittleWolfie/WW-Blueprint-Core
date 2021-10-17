using BlueprintCore.Blueprints;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Actions.Builder.ContextEx
{
  /// <summary>
  /// Extension to <see cref="ActionListBuilder">ActionListBuilder</see> for most
  /// <see cref="ContextAction">ContextAction</see> types. Some <see cref="ContextAction"/> types are in more specific
  /// extensions such as <see cref="AVEx.ActionListBuilderAVEx">AVEx</see> or
  /// <see cref="KingdomEx.ActionListBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionListBuilder"/>
  public static class ActionListBuilderContextEx
  {
    /// <summary>
    /// Adds <see cref="ContextActionAddFeature">ContextActionAddFeature</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    public static ActionListBuilder AddFeature(this ActionListBuilder builder, string feature)
    {
      var addFeature = ElementTool.Create<ContextActionAddFeature>();
      addFeature.m_PermanentFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return builder.Add(addFeature);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddLocustClone">ContextActionAddLocustClone</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    public static ActionListBuilder AddLocustClone(this ActionListBuilder builder, string feature)
    {
      var addClone = ElementTool.Create<ContextActionAddLocustClone>();
      addClone.m_CloneFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return builder.Add(addClone);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAeonRollbackToSavedState">ContextActionAeonRollbackToSavedState</see>
    /// </summary>
    public static ActionListBuilder AeonRollbackState(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionAeonRollbackToSavedState>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionApplyBuff">ContextActionApplyBuff</see>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
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
      applyBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
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
      return BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchant);
    }

    /// <summary>
    /// Adds <see cref="ContextActionArmorEnchantPool">ContextActionArmorEnchantPool</see>
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// The caster's armor is enchanted based on its available enhancement bonus. <br />
    /// e.g.If the armor can be enchanted to +4 but already has a +1 enchantment, plusThreeEnchantment is applied.
    /// </para>
    /// 
    /// <para>
    /// See ArcaneArmor and SacredArmor blueprints for example usages.
    /// </para>
    /// </remarks>
    /// 
    /// <para>
    /// All enchantments default to the corresponding TemporaryArmorEnhancementBonus* blueprint.
    /// </para>
    /// 
    /// <param name="plusOneEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusTwoEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusThreeEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusFourEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusFiveEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
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

    /// <summary>
    /// Adds <see cref="ContextActionShieldArmorEnchantPool">ContextActionShieldArmorEnchantPool</see>
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// The caster's shield is enchanted based on its available enhancement bonus. <br />
    /// e.g.If the shield can be enchanted to +4 but already has a +1 enchantment, plusThreeEnchantment is applied.
    /// </para>
    /// 
    /// <para>
    /// See the SacredArmor blueprint for example usage.
    /// </para>
    /// 
    /// <para>
    /// All enchantments default to the corresponding TemporaryArmorEnhancementBonus* blueprint.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="plusOneEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusTwoEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusThreeEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusFourEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusFiveEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
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

    /// <summary>
    /// Adds <see cref="ContextActionWeaponEnchantPool">ContextActionWeaponEnchantPool</see>
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// The caster's weapon is enchanted based on its available enhancement bonus. <br />
    /// e.g.If the weapon can be enchanted to +4 but already has a +1 enchantment, plusThreeEnchantment is applied.
    /// </para>
    /// 
    /// <para>
    /// See ArcaneWeapon and SacredWeapon blueprints for example usages.
    /// </para>
    /// 
    /// <para>
    /// All enchantments default to the corresponding TemporaryEnhancement* blueprint.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="plusOneEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusTwoEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusThreeEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusFourEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusFiveEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
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
    /// <summary>
    /// Adds <see cref="ContextActionShieldWeaponEnchantPool">ContextActionShieldWeaponEnchantPool</see>
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// The caster's shield is enchanted based on its available enhancement bonus. <br />
    /// e.g.If the shield can be enchanted to +4 but already has a +1 enchantment, plusThreeEnchantment is applied.
    /// </para>
    /// 
    /// <para>
    /// See the SacredWeapon blueprint for example usage.
    /// </para>
    /// 
    /// <para>
    /// All enchantments default to the corresponding TemporaryEnhancement* blueprint.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="plusOneEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusTwoEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusThreeEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusFourEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
    /// <param name="plusFiveEnchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment"/>BlueprintItemEnchantment</param>
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

    /// <summary>
    /// Adds <see cref="ContextActionAttackWithWeapon">ContextActionAttackWithWeapon</see>
    /// </summary>
    /// 
    /// <param name="weapon"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintItemWeapon">BlueprintItemWeapon</see></param>
    public static ActionListBuilder AttackWithWeapon(this ActionListBuilder builder, StatType damageStat, string weapon)
    {
      var attack = ElementTool.Create<ContextActionAttackWithWeapon>();
      attack.m_Stat = damageStat;
      attack.m_WeaponRef = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      return builder.Add(attack);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBatteringBlast">ContextActionBatteringBlast</see>
    /// </summary>
    public static ActionListBuilder BatteringBlast(this ActionListBuilder builder, bool remove = false)
    {
      var blast = ElementTool.Create<ContextActionBatteringBlast>();
      blast.Remove = remove;
      return builder.Add(blast);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreakFree">ContextActionBreakFree</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionBreathOfLife">ContextActionBreathOfLife</see>
    /// </summary>
    public static ActionListBuilder BreathOfLife(
        this ActionListBuilder builder, ContextDiceValue value)
    {
      var breathOfLife = ElementTool.Create<ContextActionBreathOfLife>();
      breathOfLife.Value = value;
      return builder.Add(breathOfLife);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreathOfMoney">ContextActionBreathOfMoney</see>
    /// </summary>
    public static ActionListBuilder BreathOfMoney(
        this ActionListBuilder builder, ContextValue minCoins, ContextValue maxCoins)
    {
      var breathOfMoney = ElementTool.Create<ContextActionBreathOfMoney>();
      breathOfMoney.MinCoins = minCoins;
      breathOfMoney.MaxCoins = maxCoins;
      return builder.Add(breathOfMoney);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCastSpell">ContextActionCastSpell</see>
    /// </summary>
    /// 
    /// <param name="spell"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility">BlueprintAbility</see></param>
    public static ActionListBuilder CastSpell(
        this ActionListBuilder builder,
        string spell,
        bool castByTarget = false,
        ContextValue overrideDC = null,
        ContextValue overrideLevel = null)
    {
      var castSpell = ElementTool.Create<ContextActionCastSpell>();
      castSpell.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
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

    /// <summary>
    /// Adds <see cref="ContextActionChangeSharedValue">ContextActionChangeSharedValue</see>
    /// </summary>
    public static ActionListBuilder SetSharedValue(
        this ActionListBuilder builder, AbilitySharedValue sharedValue, ContextValue setValue)
    {
      return ChangeSharedValue(builder, sharedValue, SharedValueChangeType.Set, set: setValue);
    }

    /// <inheritdoc cref="SetSharedValue"/>
    public static ActionListBuilder SetSharedValueToHD(
        this ActionListBuilder builder, AbilitySharedValue sharedValue)
    {
      return ChangeSharedValue(builder, sharedValue, SharedValueChangeType.SubHD);
    }

    /// <inheritdoc cref="SetSharedValue"/>
    public static ActionListBuilder AddToSharedValue(
        this ActionListBuilder builder, AbilitySharedValue sharedValue, ContextValue addValue)
    {
      return ChangeSharedValue(builder, sharedValue, SharedValueChangeType.Add, add: addValue);
    }

    /// <inheritdoc cref="SetSharedValue"/>
    public static ActionListBuilder MultiplySharedValue(
        this ActionListBuilder builder, AbilitySharedValue sharedValue, ContextValue multiplyValue)
    {
      return ChangeSharedValue(
          builder, sharedValue, SharedValueChangeType.Multiply, multiply: multiplyValue);
    }

    /// <inheritdoc cref="SetSharedValue"/>
    public static ActionListBuilder DivideSharedValueBy2(
        this ActionListBuilder builder, AbilitySharedValue sharedValue)
    {
      return ChangeSharedValue(builder, sharedValue, SharedValueChangeType.Div2);
    }

    /// <inheritdoc cref="SetSharedValue"/>
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

    /// <summary>
    /// Adds <see cref="ContextActionClearSummonPool">ContextActionClearSummonPool</see>
    /// </summary>
    /// 
    /// <param name="pool"><see cref="BlueprintSummonPool">BlueprintSummonPool</see></param>
    public static ActionListBuilder ClearSummonPool(this ActionListBuilder builder, string pool)
    {
      var clearSummons = ElementTool.Create<ContextActionClearSummonPool>();
      clearSummons.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
      return builder.Add(clearSummons);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCombatManeuver">ContextActionCombatManeuver</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionCombatManeuverCustom">ContextActionCombatManeuverCustom</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionConditionalSaved">ContextActionConditionalSaved</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionDealDamage">ContextActionDealDamage</see>
    /// </summary>
    /// 
    /// <param name="sharedResult">If specified, the resulting damage is stored in this shared value.</param>
    /// <param name="criticalSharedResult">
    /// If specified and the associated attack roll is a critical, this shared value is set to 1.
    /// </param>
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

    /// <inheritdoc cref="DealDamage"/>
    /// <param name="preRolledValue">Deals damage equal to this shared value.</param>
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

    /// <inheritdoc cref="DealDamage"/>
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

    /// <inheritdoc cref="DealDamage"/>
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

    /// <inheritdoc cref="DealDamage"/>
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
        builder.Validate(dmgType);
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

    /// <summary>
    /// Adds <see cref="ContextActionDealWeaponDamage">ContextActionDealWeaponDamage</see>
    /// </summary>
    public static ActionListBuilder DealWeaponDamage(this ActionListBuilder builder, bool allowRanged = false)
    {
      var dmg = ElementTool.Create<ContextActionDealWeaponDamage>();
      dmg.CanBeRanged = allowRanged;
      return builder.Add(dmg);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDetectSecretDoors">ContextActionDetectSecretDoors</see>
    /// </summary>
    public static ActionListBuilder DetectSecretDoors(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDetectSecretDoors>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDevourBySwarm">ContextActionDevourBySwarm</see>
    /// </summary>
    public static ActionListBuilder DevourWithSwarm(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDevourBySwarm>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDisarm">ContextActionDisarm</see>
    /// </summary>
    public static ActionListBuilder Disarm(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDisarm>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDismissAreaEffect">ContextActionDismissAreaEffect</see>
    /// </summary>
    public static ActionListBuilder DismissAOE(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismissAreaEffect>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDismount">ContextActionDismount</see>
    /// </summary>
    public static ActionListBuilder Dismount(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismount>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDispelMagic">ContextActionDispelMagic</see>
    /// </summary>
    /// 
    /// <param name="checkEitherSchoolOrDescriptor">
    /// By default dispel only effects things matching both the required SpellSchool and SpellDescriptor. If this is
    /// true, effects only need to satisfy one or the other.
    /// </param>
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

    /// <summary>
    /// Adds <see cref="ContextActionDropItems">ContextActionDropItems</see>
    /// </summary>
    public static ActionListBuilder DropItems(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDropItems>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionEnchantWornItem">ContextActionEnchantWornItem</see>
    /// </summary>
    /// 
    /// <param name="enchantment"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment">BlueprintItemEnchantment</see></param>
    public static ActionListBuilder EnchantWornItem(
        this ActionListBuilder builder,
        string enchantment,
        EquipSlotBase.SlotType slot,
        ContextDurationValue duration,
        bool onCaster = false,
        bool removeOnUnequip = false)
    {
      var enchant = ElementTool.Create<ContextActionEnchantWornItem>();
      enchant.m_Enchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantment);
      enchant.Slot = slot;
      enchant.DurationValue = duration;
      enchant.ToCaster = onCaster;
      enchant.RemoveOnUnequip = removeOnUnequip;
      return builder.Add(enchant);
    }

    /// <summary>
    /// Adds <see cref="ContextActionFinishObjective">ContextActionFinishObjective</see>
    /// </summary>
    public static ActionListBuilder FinishObjective(this ActionListBuilder builder, string objective)
    {
      var finish = ElementTool.Create<ContextActionFinishObjective>();
      finish.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(objective);
      return builder.Add(finish);
    }

    /// <summary>
    /// Adds <see cref="ContextActionForEachSwallowedUnit">ContextActionForEachSwallowedUnit</see>
    /// </summary>
    public static ActionListBuilder OnEachSwallowedUnit(
        this ActionListBuilder builder, ActionListBuilder onEachUnit)
    {
      var onUnits = ElementTool.Create<ContextActionForEachSwallowedUnit>();
      onUnits.Action = onEachUnit.Build();
      return builder.Add(onUnits);
    }

    /// <summary>
    /// Adds <see cref="ContextActionGiveExperience">ContextActionGiveExperience</see>
    /// </summary>
    public static ActionListBuilder GiveExperience(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionGiveExperience>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionGrapple">ContextActionGrapple</see>
    /// </summary>
    /// 
    /// <param name="casterBuff">
    /// <see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see> applied for the duration of
    /// the grapple check.
    /// </param>
    /// <param name="targetBuff">
    /// <see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see> applied for the duration of
    /// the grapple check.
    /// </param>
    public static ActionListBuilder Grapple(
        this ActionListBuilder builder, string casterBuff = null, string targetBuff = null)
    {
      var grapple = ElementTool.Create<ContextActionGrapple>();
      if (casterBuff != null) { grapple.m_CasterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(casterBuff); }
      if (targetBuff != null) { grapple.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(targetBuff); }
      return builder.Add(grapple);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealEnergyDrain">ContextActionHealEnergyDrain</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionHealStatDamage">ContextActionHealStatDamage</see>
    /// </summary>
    /// 
    /// <param name="sharedResult">If specified, the amount of healing done is stored in this shared value.</param>
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

    /// <summary>
    /// Adds <see cref="ContextActionHealTarget">ContextActionHealTarget</see>
    /// </summary>
    public static ActionListBuilder HealTarget(this ActionListBuilder builder, ContextDiceValue value)
    {
      var heal = ElementTool.Create<ContextActionHealTarget>();
      heal.Value = value;
      return builder.Add(heal);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHideInPlainSight">ContextActionHideInPlainSight</see>
    /// </summary>
    public static ActionListBuilder HideInPlainSight(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionHideInPlainSight>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionKill">ContextActionKill</see>
    /// </summary>
    public static ActionListBuilder Kill(
        this ActionListBuilder builder, UnitState.DismemberType dismember = UnitState.DismemberType.None)
    {
      var kill = ElementTool.Create<ContextActionKill>();
      kill.Dismember = dismember;
      return builder.Add(kill);
    }

    /// <summary>
    /// Adds <see cref="ContextActionKnockdownTarget">ContextActionKnockdownTarget</see>
    /// </summary>
    public static ActionListBuilder Knockdown(
        this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionKnockdownTarget>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionMakeKnowledgeCheck">ContextActionMakeKnowledgeCheck</see>
    /// </summary>
    public static ActionListBuilder KnowledgeCheck(
        this ActionListBuilder builder, ActionListBuilder onSuccess = null, ActionListBuilder onFail = null)
    {
      var knowledgeCheck = ElementTool.Create<ContextActionMakeKnowledgeCheck>();
      knowledgeCheck.SuccessActions = onSuccess?.Build() ?? Constants.Empty.Actions;
      knowledgeCheck.FailActions = onFail?.Build() ?? Constants.Empty.Actions;
      return builder.Add(knowledgeCheck);
    }

    /// <summary>
    /// Adds <see cref="ContextActionMarkForceDismemberOwner">ContextActionMarkForceDismemberOwner</see>
    /// </summary>
    public static ActionListBuilder MarkOwnerForDismemberment(
        this ActionListBuilder builder, UnitState.DismemberType type = UnitState.DismemberType.Normal)
    {
      var markForDismemberment = ElementTool.Create<ContextActionMarkForceDismemberOwner>();
      markForDismemberment.ForceDismemberType = type;
      return builder.Add(markForDismemberment);
    }

    /// <summary>
    /// Adds <see cref="ContextActionMeleeAttack">ContextActionMeleeAttack</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionMount">ContextActionMount</see>
    /// </summary>
    public static ActionListBuilder Mount(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionMount>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnContextCaster">ContextActionOnContextCaster</see>
    /// </summary>
    public static ActionListBuilder OnCaster(this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onCaster = ElementTool.Create<ContextActionOnContextCaster>();
      onCaster.Actions = actions.Build();
      return builder.Add(onCaster);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnOwner">ContextActionOnOwner</see>
    /// </summary>
    public static ActionListBuilder OnOwner(this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onOwner = ElementTool.Create<ContextActionOnOwner>();
      onOwner.Actions = actions.Build();
      return builder.Add(onOwner);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnRandomAreaTarget">ContextActionOnRandomAreaTarget</see>
    /// </summary>
    /// 
    /// <remarks>
    /// <list type="bullet">
    ///   <item>
    ///     <description>The component's OnEnemies field is unused. It only targets enemies.</description>
    ///   </item>
    ///   <item>
    ///     <description>
    ///       Only works inside of
    ///       <see cref="Kingmaker.UnitLogic.Abilities.Components.AreaEffects.AbilityAreaEffectRunAction">AbilityAreaEffectRunAction</see>
    ///     </description>
    ///   </item>
    /// </list>
    /// </remarks>
    public static ActionListBuilder OnRandomEnemyInAOE(this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onEnemy = ElementTool.Create<ContextActionOnRandomAreaTarget>();
      onEnemy.Actions = actions.Build();
      return builder.Add(onEnemy);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnRandomTargetsAround">ContextActionOnRandomTargetsAround</see>
    /// </summary>
    /// 
    /// <param name="ignoreFact">
    /// <see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see> units with this fact are
    /// ignored.
    /// </param>
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
      onUnit.m_FilterNoFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFact);
      return builder.Add(onUnit);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnSwarmTargets">ContextActionOnSwarmTargets</see>
    /// </summary>
    public static ActionListBuilder OnSwarmTargets(this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onTarget = ElementTool.Create<ContextActionOnSwarmTargets>();
      onTarget.Actions = actions.Build();
      return builder.Add(onTarget);
    }

    /// <summary>
    /// Adds <see cref="ContextActionPartyMembers">ContextActionPartyMembers</see>
    /// </summary>
    public static ActionListBuilder OnPartyMembers(
        this ActionListBuilder builder, ActionListBuilder actions)
    {
      var onParty = ElementTool.Create<ContextActionPartyMembers>();
      onParty.Action = actions.Build();
      return builder.Add(onParty);
    }

    /// <summary>
    /// Adds <see cref="ContextActionProjectileFx">ContextActionProjectileFx</see>
    /// </summary>
    /// 
    /// <param name="projectile"><see cref="BlueprintProjectile">BlueprintProjectile</see></param>
    public static ActionListBuilder ProjectileFx(this ActionListBuilder builder, string projectile)
    {
      var projectileFx = ElementTool.Create<ContextActionProjectileFx>();
      projectileFx.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(projectile);
      return builder.Add(projectileFx);
    }

    /// <summary>
    /// Adds <see cref="ContextActionProvokeAttackFromCaster">ContextActionProvokeAttackFromCaster</see>
    /// </summary>
    public static ActionListBuilder ProvokeOpportunityAttackFromCaster(
        this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionProvokeAttackFromCaster>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionProvokeAttackOfOpportunity">ContextActionProvokeAttackOfOpportunity</see>
    /// </summary>
    public static ActionListBuilder ProvokeOpportunityAttack(
        this ActionListBuilder builder, bool casterProvokes = false)
    {
      var attack = ElementTool.Create<ContextActionProvokeAttackOfOpportunity>();
      attack.ApplyToCaster = casterProvokes;
      return builder.Add(attack);
    }

    /// <summary>
    /// Adds <see cref="ContextActionPush">ContextActionPush</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionRandomize">ContextActionRandomize</see>
    /// </summary>
    /// 
    /// <param name="weightedActions">
    /// Pair of <see cref="ActionListBuilder">ActionListBuilder</see> and an int representing the relative probability
    /// of that action compared to the rest of the entries. These map to
    /// <see cref="ContextActionRandomize.ActionWrapper">ContextActionRandomize.ActionWrapper</see>.
    /// </param>
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

    /// <summary>
    /// Adds <see cref="ContextActionRangedAttack">ContextActionRangedAttack</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionRecoverItemCharges">ContextActionRecoverItemCharges</see>
    /// </summary>
    /// 
    /// <param name="item"><see cref="Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipment">BlueprintItemEquipment</see></param>
    public static ActionListBuilder RecoverItemCharges(this ActionListBuilder builder, string item, int charges = 1)
    {
      var recoverCharges = ElementTool.Create<ContextActionRecoverItemCharges>();
      recoverCharges.m_Item = BlueprintTool.GetRef<BlueprintItemEquipmentReference>(item);
      recoverCharges.ChargesRecoverCount = charges;
      return builder.Add(recoverCharges);
    }

    /// <summary>
    /// Adds <see cref="ContextActionReduceBuffDuration">ContextActionReduceBuffDuration</see>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    public static ActionListBuilder ChangeBuffDuration(
        this ActionListBuilder builder,
        string buff,
        ContextDurationValue duration,
        bool increase,
        bool onTarget = false)
    {
      var changeDuration = ElementTool.Create<ContextActionReduceBuffDuration>();
      changeDuration.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      changeDuration.DurationValue = duration;
      changeDuration.Increase = increase;
      changeDuration.ToTarget = onTarget;
      return builder.Add(changeDuration);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveBuff">ContextActionRemoveBuff</see>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    public static ActionListBuilder RemoveBuff(
        this ActionListBuilder builder, string buff, bool removeRank = false, bool toCaster = false)
    {
      var removeBuff = ElementTool.Create<ContextActionRemoveBuff>();
      removeBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      removeBuff.RemoveRank = removeRank;
      removeBuff.ToCaster = toCaster;
      return builder.Add(removeBuff);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveBuffsByDescriptor">ContextActionRemoveBuffsByDescriptor</see>
    /// </summary>
    public static ActionListBuilder RemoveBuffsWithDescriptor(
        this ActionListBuilder builder, SpellDescriptor descriptor, bool includeThisBuff = false)
    {
      var removeBuffs = ElementTool.Create<ContextActionRemoveBuffsByDescriptor>();
      removeBuffs.SpellDescriptor = descriptor;
      removeBuffs.NotSelf = !includeThisBuff;
      return builder.Add(removeBuffs);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveBuffSingleStack">ContextActionRemoveBuffSingleStack</see>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    public static ActionListBuilder RemoveBuffStack(this ActionListBuilder builder, string buff)
    {
      var removeStack = ElementTool.Create<ContextActionRemoveBuffSingleStack>();
      removeStack.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return builder.Add(removeStack);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveDeathDoor">ContextActionRemoveDeathDoor</see>
    /// </summary>
    public static ActionListBuilder RemoveDeathDoor(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveDeathDoor>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveSelf">ContextActionRemoveSelf</see>
    /// </summary>
    /// 
    /// <remarks>Only works on buffs and area effects.</remarks>
    public static ActionListBuilder RemoveSelf(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveSelf>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRepeatedActions">ContextActionRepeatedActions</see>
    /// </summary>
    public static ActionListBuilder RepeatActions(
        this ActionListBuilder builder, ActionListBuilder actions, ContextDiceValue times)
    {
      var repeat = ElementTool.Create<ContextActionRepeatedActions>();
      repeat.Actions = actions.Build();
      repeat.Value = times;
      return builder.Add(repeat);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreSpells">ContextActionRestoreSpells</see>
    /// </summary>
    /// 
    /// <param name="spellbooks"><see cref="BlueprintSpellbook">BlueprintSpellbook</see></param>
    public static ActionListBuilder RestoreSpells(this ActionListBuilder builder, params string[] spellbooks)
    {
      var restoreSpells = ElementTool.Create<ContextActionRestoreSpells>();
      restoreSpells.m_Spellbooks =
          spellbooks
              .Select(spellbook => BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook))
              .ToArray();
      return builder.Add(restoreSpells);
    }

    /// <summary>
    /// Adds <see cref="ContextActionResurrect">ContextActionResurrect</see>
    /// </summary>
    /// 
    /// <param name="healPercent">Percentage of health after resurrection as a float between 0.0 and 1.0.</param>
    /// <param name="resurrectBuff">
    /// <see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see> which replces the default
    /// resurrection buff. Must contain a <see cref="Kingmaker.UnitLogic.Buffs.Components.ResurrectionLogic">ResurrectionLogic</see>
    /// </param>
    public static ActionListBuilder Resurrect(
        this ActionListBuilder builder, float healPercent, string resurrectBuff = null)
    {
      return Resurrect(builder, resurrectBuff, healPercent, false);
    }

    /// <inheritdoc cref="Resurrect"/>
    public static ActionListBuilder ResurrectAndFullRestore(this ActionListBuilder builder, string resurrectBuff = null)
    {
      return Resurrect(builder, resurrectBuff, 0.0f, true);
    }

    private static ActionListBuilder Resurrect(
        ActionListBuilder builder, string resurrectBuff, float healPercent, bool fullRestore)
    {
      var resurrect = ElementTool.Create<ContextActionResurrect>();
      resurrect.m_CustomResurrectionBuff =
          BlueprintTool.GetRef<BlueprintBuffReference>(resurrectBuff);
      resurrect.ResultHealth = healPercent;
      resurrect.FullRestore = fullRestore;
      return builder.Add(resurrect);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSavingThrow">ContextActionSavingThrow</see>
    /// </summary>
    /// 
    /// <param name="fromBuff">
    /// If this is true, onResult should have a <see cref="ContextActionConditionalSaved">ContextActionConditionalSaved</see>
    /// with <see cref="ContextActionApplyBuff">ContextActionApplyBuff</see> in it's Succeed
    /// <see cref="Kingmaker.ElementsSystem.ActionList">ActionList</see>. The buff associated with that component will
    /// be attached to the <see cref="Kingmaker.RuleSystem.Rules.RuleSavingThrow">RuleSavingThrow</see>.
    /// </param>
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

    /// <summary>
    /// Adds <see cref="ContextActionSelectByValue">ContextActionSelectByValue</see>
    /// </summary>
    public static ActionListBuilder RunActionWithGreatestValue(
        this ActionListBuilder builder, params (ContextValue value, ActionListBuilder action)[] actionVariants)
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

    /// <summary>
    /// Adds <see cref="ContextActionSkillCheck">ContextActionSkillCheck</see>
    /// </summary>
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

    /// <inheritdoc cref="SkillCheck"/>
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

    /// <summary>
    /// Adds <see cref="ContextActionsOnPet">ContextActionsOnPet</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionSpawnAreaEffect">ContextActionSpawnAreaEffect</see>
    /// </summary>
    /// 
    /// <param name="aoe"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbilityAreaEffect">BlueprintAbilityAreaEffect</see></param>
    public static ActionListBuilder SpawnAOE(
        this ActionListBuilder builder, string aoe, ContextDurationValue duration)
    {
      var spawnAOE = ElementTool.Create<ContextActionSpawnAreaEffect>();
      spawnAOE.m_AreaEffect = BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(aoe);
      spawnAOE.DurationValue = duration;
      return builder.Add(spawnAOE);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnControllableProjectile">ContextActionSpawnControllableProjectile</see>
    /// </summary>
    /// 
    /// <param name="projectile"><see cref="BlueprintControllableProjectile">BlueprintControllableProjectile</see></param>
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    public static ActionListBuilder SpawnControllableProjectile(
        this ActionListBuilder builder, string projectile, string buff)
    {
      var spawnProjectile = ElementTool.Create<ContextActionSpawnControllableProjectile>();
      spawnProjectile.ControllableProjectile =
          BlueprintTool.GetRef<BlueprintControllableProjectileReference>(projectile);
      spawnProjectile.AssociatedCasterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return builder.Add(spawnProjectile);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnMonster">ContextActionSpawnMonster</see>
    /// </summary>
    /// 
    /// <param name="monster"><see cref="BlueprintUnit">BlueprintUnit</see></param>
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

    /// <inheritdoc cref="SpawnMonster"/>
    /// <param name="summonPool"><see cref="BlueprintSummonPool">BlueprintSummonPool</see></param>
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
      spawn.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(monster);
      spawn.CountValue = count;
      spawn.DurationValue = duration;
      spawn.AfterSpawn = onSpawn?.Build() ?? Constants.Empty.Actions;
      spawn.LevelValue = level ?? 0;
      spawn.IsDirectlyControllable = controllable;
      spawn.DoNotLinkToCaster = !linkToCaster;

      spawn.m_SummonPool =
          summonPool is null
              ? null
              : BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      spawn.UseLimitFromSummonPool = useSummonPoolLimit;
      return builder.Add(spawn);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnUnlinkedMonster">ContextActionSpawnUnlinkedMonster</see>
    /// </summary>
    /// 
    /// <param name="monster"><see cref="BlueprintUnit">BlueprintUnit</see></param>
    public static ActionListBuilder SpawnMonsterUnlinked(this ActionListBuilder builder, string monster)
    {
      var spawn = ElementTool.Create<ContextActionSpawnUnlinkedMonster>();
      spawn.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(monster);
      return builder.Add(spawn);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpendAttackOfOpportunity">ContextActionSpendAttackOfOpportunity</see>
    /// </summary>
    public static ActionListBuilder SpendOpportunityAttack(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSpendAttackOfOpportunity>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionStealBuffs">ContextActionStealBuffs</see>
    /// </summary>
    public static ActionListBuilder StealBuffs(this ActionListBuilder builder, SpellDescriptor descriptor)
    {
      var steal = ElementTool.Create<ContextActionStealBuffs>();
      steal.m_Descriptor = descriptor;
      return builder.Add(steal);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwallowWhole">ContextActionSwallowWhole</see>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    public static ActionListBuilder SwallowWhole(this ActionListBuilder builder, string buff = null)
    {
      var swallow = ElementTool.Create<ContextActionSwallowWhole>();
      swallow.m_TargetBuff =
          buff is null
              ? null
              : BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return builder.Add(swallow);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwarmTarget">ContextActionSwarmTarget</see>
    /// </summary>
    public static ActionListBuilder AddToSwarmTargets(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSwarmTarget>());
    }

    /// <inheritdoc cref="AddToSwarmTargets"/>
    public static ActionListBuilder RemoveFromSwarmTargets(this ActionListBuilder builder)
    {
      var removeTarget = ElementTool.Create<ContextActionSwarmTarget>();
      removeTarget.Remove = true;
      return builder.Add(removeTarget);
    }

    /// <summary>
    /// Adds <see cref="ContextActionTranslocate">ContextActionTranslocate</see>
    /// </summary>
    public static ActionListBuilder Teleport(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionTranslocate>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionUnsummon">ContextActionUnsummon</see>
    /// </summary>
    public static ActionListBuilder Unsummon(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionUnsummon>());
    }

    /// <summary>
    /// Adds <see cref="ContextRestoreResource">ContextRestoreResource</see>
    /// </summary>
    /// 
    /// <param name="resource"><see cref="BlueprintAbilityResource">BlueprintAbilityResource</see></param>
    public static ActionListBuilder RestoreResource(
        this ActionListBuilder builder, string resource, ContextValue amount = null)
    {
      var restore = ElementTool.Create<ContextRestoreResource>();
      restore.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);

      if (amount != null)
      {
        restore.ContextValueRestoration = true;
        restore.Value = amount;
      }
      return builder.Add(restore);
    }

    /// <summary>
    /// Adds <see cref="ContextRestoreResource">ContextRestoreResource</see>
    /// </summary>
    public static ActionListBuilder RestoreAllResourcesToFull(this ActionListBuilder builder)
    {
      var restore = ElementTool.Create<ContextRestoreResource>();
      restore.m_IsFullRestoreAllResources = true;
      return builder.Add(restore);
    }

    /// <summary>
    /// Adds <see cref="ContextSpendResource">ContextSpendResource</see>
    /// </summary>
    /// 
    /// <param name="resource"><see cref="BlueprintAbilityResource">BlueprintAbilityResource</see></param>
    public static ActionListBuilder SpendResource(
        this ActionListBuilder builder, string resource, ContextValue amount = null)
    {
      var spend = ElementTool.Create<ContextSpendResource>();
      spend.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);

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

    /// <summary>
    /// Adds <see cref="Demoralize">Demoralize</see>
    /// </summary>
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
      demoralize.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(effect);
      demoralize.m_GreaterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(greaterEffect);
      demoralize.m_SwordlordProwessFeature =
          BlueprintTool.GetRef<BlueprintFeatureReference>(swordlordProwess);
      demoralize.m_ShatterConfidenceFeature =
          BlueprintTool.GetRef<BlueprintFeatureReference>(shatterConfidenceFeature);
      demoralize.m_ShatterConfidenceBuff =
          BlueprintTool.GetRef<BlueprintBuffReference>(shatterConfidenceBuff);
      demoralize.TricksterRank3Actions = tricksterRank3Actions?.Build() ?? Constants.Empty.Actions;
      return builder.Add(demoralize);
    }

    /// <summary>
    /// Adds <see cref="EnhanceWeapon">EnhanceWeapon</see>
    /// </summary>
    /// 
    /// <param name="enhancements"><see cref="Kingmaker.Blueprints.Items.Ecnchantments.BlueprintItemEnchantment">BlueprintItemEnchantment</see></param>
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

    /// <inheritdoc cref="MagicWeapon"/>
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
                      BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enhancement))
              .ToArray();
      enhance.DurationValue = duration;
      enhance.EnchantLevel = level;
      enhance.Greater = greater;
      enhance.UseSecondaryHand = useSecondaryHand;
      return builder.Add(enhance);
    }

    /// <summary>
    /// Adds <see cref="SwordlordAdaptiveTacticsAdd">SwordlordAdaptiveTacticsAdd</see>
    /// </summary>
    /// 
    /// <param name="source"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    public static ActionListBuilder SwordlordAdaptiveTacticsAdd(this ActionListBuilder builder, string source)
    {
      var add = ElementTool.Create<SwordlordAdaptiveTacticsAdd>();
      add.m_Source = BlueprintTool.GetRef<BlueprintUnitFactReference>(source);
      return builder.Add(add);
    }

    /// <summary>
    /// Adds <see cref="SwordlordAdaptiveTacticsClear">SwordlordAdaptiveTacticsClear</see>
    /// </summary>
    public static ActionListBuilder SwordlordAdaptiveTacticsClear(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SwordlordAdaptiveTacticsClear>());
    }

    //----- Kingmaker.Assets.UnitLogic.Mechanics.Actions -----//

    /// <summary>
    /// Adds <see cref="ContextActionResetAlignment">ContextActionResetAlignment</see>
    /// </summary>
    public static ActionListBuilder ResetAlignment(this ActionListBuilder builder, bool removeMythicLock = false)
    {
      var resetAlignment = ElementTool.Create<ContextActionResetAlignment>();
      resetAlignment.m_ResetAlignmentLock = removeMythicLock;
      return builder.Add(resetAlignment);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwarmAttack">ContextActionSwarmAttack</see>
    /// </summary>
    public static ActionListBuilder SwarmAttack(this ActionListBuilder builder, ActionListBuilder attackActions)
    {
      var attack = ElementTool.Create<ContextActionSwarmAttack>();
      attack.AttackActions = attackActions.Build();
      return builder.Add(attack);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwitchDualCompanion">ContextActionSwitchDualCompanion</see>
    /// </summary>
    public static ActionListBuilder SwitchDualCompanion(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSwitchDualCompanion>());
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="ContextActionAddRandomTrashItem">ContextActionAddRandomTrashItem</see>
    /// </summary>
    public static ActionListBuilder GiveRandomTrashToPlayer(
        this ActionListBuilder builder,
        TrashLootType type,
        int maxCost,
        bool identify = false,
        bool silent = false)
    {
      var addTrash = ElementTool.Create<ContextActionAddRandomTrashItem>();
      addTrash.m_LootType = type;
      addTrash.m_MaxCost = maxCost;
      addTrash.m_Identify = identify;
      addTrash.m_Silent = silent;
      return builder.Add(addTrash);
    }
  }
}
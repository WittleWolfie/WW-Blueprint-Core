//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Root.Strings.GameLog;
using Kingmaker.Controllers.Rest;
using Kingmaker.Corruption;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.Designers.Mechanics.Enums;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.DLC;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Items;
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Flags;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintScriptableObject"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBlueprintConfigurator<T, TBuilder>
    : RootConfigurator<T, TBuilder>
    where T : BlueprintScriptableObject
    where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    protected BaseBlueprintConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintScriptableObject>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintScriptableObject>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    return Self;
    }

    /// <summary>
    /// Adds <see cref="DlcCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AasimarMaleBloodrager</term><description>7ba4a4bdb55b46779ebca045d7955e82</description></item>
    /// <item><term>DruchiteTongiPlus3</term><description>bd75f3ca977a4ca1af3a176025e22aba</description></item>
    /// <item><term>WinterGrasp</term><description>406c6e4a631b43ce8f7a77844b75bf75</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dlcReward">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDlcCondition(
        Blueprint<BlueprintDlcRewardReference>? dlcReward = null,
        bool? hideInstead = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DlcCondition();
      component.m_DlcReward = dlcReward?.Reference ?? component.m_DlcReward;
      if (component.m_DlcReward is null)
      {
        component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(null);
      }
      component.m_HideInstead = hideInstead ?? component.m_HideInstead;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnCorruptionClear"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Legend_UniqueRestFeature</term><description>27327f8954cd4f91ab3deaebf1f8cfa7</description></item>
    /// <item><term>PlayerAeonCorruptionProtectionFeature</term><description>a584e29c306f4a5bb1b448037c5aed7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddBuffOnCorruptionClear(
        Blueprint<BlueprintBuffReference>? buff = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? targetBuffRank = null)
    {
      var component = new AddBuffOnCorruptionClear();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_TargetBuffRank = targetBuffRank ?? component.m_TargetBuffRank;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="IgnoreArmorGroupComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HaramakiType</term><description>9511d62bcfc57c245bf64350a5933470</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddIgnoreArmorGroupComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new IgnoreArmorGroupComponent();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteConditionForWeaponCategory"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FinesseTrainingBite</term><description>bcebc021271be1e45b012729f22dadcc</description></item>
    /// <item><term>FinesseTrainingTail</term><description>ba5616910c9b4545bf9846b7dea024f3</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisiteConditionForWeaponCategory(
        Condition? condition = null,
        List<WeaponCategory>? weaponCategories = null)
    {
      var component = new PrerequisiteConditionForWeaponCategory();
      Validate(condition);
      component.m_Condition = condition ?? component.m_Condition;
      component.m_WeaponCategories = weaponCategories ?? component.m_WeaponCategories;
      if (component.m_WeaponCategories is null)
      {
        component.m_WeaponCategories = new();
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageDecline"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_InvincibleBuff</term><description>57d5bd72d2484fd6b63aedf1b0a3e3c2</description></item>
    /// <item><term>InvincibleMeleeBuff</term><description>113a85b660744b25900e0d53d39f132f</description></item>
    /// <item><term>Kakuen_takaMeatShield</term><description>96c0689cb9bb4ac3a7a0e795fdab92c8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDamageDecline(
        DamageDeclineType? damageDeclineType = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddDamageDecline();
      component.m_DamageDeclineType = damageDeclineType ?? component.m_DamageDeclineType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddPlayerLeaveCombatTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CavalierForTheKingResource</term><description>d6f77eb811f3748428c8ad48e273e91d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPlayerLeaveCombatTrigger(
        ActionsBuilder? actions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddPlayerLeaveCombatTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TimerContextActions"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC5_RitualControllerBuff</term><description>928e019d414e47fa81e28769322628dd</description></item>
    /// <item><term>TimerReturnMephisto</term><description>9e624e985b1641608eb37c34e901268b</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddTimerContextActions(
        ActionsBuilder? actionList = null,
        float? everySeconds = null,
        TimeSpan? lastGameTime = null,
        bool? runAsContextAction = null)
    {
      var component = new TimerContextActions();
      component.ActionList = actionList?.Build() ?? component.ActionList;
      if (component.ActionList is null)
      {
        component.ActionList = Utils.Constants.Empty.Actions;
      }
      component.EverySeconds = everySeconds ?? component.EverySeconds;
      component.m_LastGameTime = lastGameTime ?? component.m_LastGameTime;
      component.RunAsContextAction = runAsContextAction ?? component.RunAsContextAction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomImmuneMessageComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NegativeLevelsBuff</term><description>b02b6b9221241394db720ca004ea9194</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCustomImmuneMessageComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        GameLogMessage? message = null)
    {
      var component = new CustomImmuneMessageComponent();
      Validate(message);
      component.Message = message ?? component.Message;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorAttackRollTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonBaneBuff</term><description>345160619fc2ddc44b8ad98c94dde448</description></item>
    /// <item><term>GuidanceBuff</term><description>ec931b882e806ce42906597e5585c13f</description></item>
    /// <item><term>WightEnergyDrainAbility</term><description>35a7f7e6ad5b4374e812fc10ec1c836c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddInitiatorAttackRollTrigger(
        ActionsBuilder? action = null,
        bool? affectFriendlyTouchSpells = null,
        bool? checkWeapon = null,
        bool? criticalHit = null,
        bool? onlyHit = null,
        bool? onlyMiss = null,
        bool? onlyNatural20 = null,
        bool? onlySpells = null,
        bool? onOwner = null,
        bool? sneakAttack = null,
        WeaponCategory? weaponCategory = null)
    {
      var component = new AddInitiatorAttackRollTrigger();
      component.Action = action?.Build() ?? component.Action;
      if (component.Action is null)
      {
        component.Action = Utils.Constants.Empty.Actions;
      }
      component.AffectFriendlyTouchSpells = affectFriendlyTouchSpells ?? component.AffectFriendlyTouchSpells;
      component.CheckWeapon = checkWeapon ?? component.CheckWeapon;
      component.CriticalHit = criticalHit ?? component.CriticalHit;
      component.OnlyHit = onlyHit ?? component.OnlyHit;
      component.OnlyMiss = onlyMiss ?? component.OnlyMiss;
      component.OnlyNatural20 = onlyNatural20 ?? component.OnlyNatural20;
      component.OnlySpells = onlySpells ?? component.OnlySpells;
      component.OnOwner = onOwner ?? component.OnOwner;
      component.SneakAttack = sneakAttack ?? component.SneakAttack;
      component.WeaponCategory = weaponCategory ?? component.WeaponCategory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorAttackWithWeaponTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>GreataxeOfFireSquallEnchantment</term><description>1abdea88a0f5b6b47903d4ffc3225185</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningFeature</term><description>0faee0a55f634902895b4e1faf828502</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="weaponBlueprint">
    /// <para>
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="weaponType">
    /// <para>
    /// Blueprint of type BlueprintWeaponType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddInitiatorAttackWithWeaponTrigger(
        ActionsBuilder? action = null,
        bool? actionsOnInitiator = null,
        bool? allNaturalAndUnarmed = null,
        WeaponCategory? category = null,
        bool? checkDistance = null,
        bool? checkPhysicalDamageForm = null,
        bool? checkWeaponBlueprint = null,
        bool? checkWeaponCategory = null,
        bool? checkWeaponGroup = null,
        bool? checkWeaponRangeType = null,
        bool? criticalHit = null,
        PhysicalDamageForm? damageForm = null,
        bool? damageMoreTargetMaxHP = null,
        Feet? distanceLessEqual = null,
        bool? duelistWeapon = null,
        WeaponFighterGroup? group = null,
        bool? ignoreAutoHit = null,
        bool? notCriticalHit = null,
        bool? notExtraAttack = null,
        bool? notSneakAttack = null,
        bool? onAttackOfOpportunity = null,
        bool? onCharge = null,
        bool? onlyHit = null,
        bool? onlyNatural20 = null,
        bool? onlyOnFirstAttack = null,
        bool? onlyOnFirstHit = null,
        bool? onlyOnFullAttack = null,
        bool? onlySneakAttack = null,
        bool? onMiss = null,
        WeaponRangeType? rangeType = null,
        bool? reduceHPToZero = null,
        bool? triggerBeforeAttack = null,
        Blueprint<BlueprintItemWeaponReference>? weaponBlueprint = null,
        Blueprint<BlueprintWeaponTypeReference>? weaponType = null)
    {
      var component = new AddInitiatorAttackWithWeaponTrigger();
      component.Action = action?.Build() ?? component.Action;
      if (component.Action is null)
      {
        component.Action = Utils.Constants.Empty.Actions;
      }
      component.ActionsOnInitiator = actionsOnInitiator ?? component.ActionsOnInitiator;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed ?? component.AllNaturalAndUnarmed;
      component.Category = category ?? component.Category;
      component.CheckDistance = checkDistance ?? component.CheckDistance;
      component.CheckPhysicalDamageForm = checkPhysicalDamageForm ?? component.CheckPhysicalDamageForm;
      component.CheckWeaponBlueprint = checkWeaponBlueprint ?? component.CheckWeaponBlueprint;
      component.CheckWeaponCategory = checkWeaponCategory ?? component.CheckWeaponCategory;
      component.CheckWeaponGroup = checkWeaponGroup ?? component.CheckWeaponGroup;
      component.CheckWeaponRangeType = checkWeaponRangeType ?? component.CheckWeaponRangeType;
      component.CriticalHit = criticalHit ?? component.CriticalHit;
      component.DamageForm = damageForm ?? component.DamageForm;
      component.DamageMoreTargetMaxHP = damageMoreTargetMaxHP ?? component.DamageMoreTargetMaxHP;
      component.DistanceLessEqual = distanceLessEqual ?? component.DistanceLessEqual;
      component.DuelistWeapon = duelistWeapon ?? component.DuelistWeapon;
      component.Group = group ?? component.Group;
      component.IgnoreAutoHit = ignoreAutoHit ?? component.IgnoreAutoHit;
      component.NotCriticalHit = notCriticalHit ?? component.NotCriticalHit;
      component.NotExtraAttack = notExtraAttack ?? component.NotExtraAttack;
      component.NotSneakAttack = notSneakAttack ?? component.NotSneakAttack;
      component.OnAttackOfOpportunity = onAttackOfOpportunity ?? component.OnAttackOfOpportunity;
      component.OnCharge = onCharge ?? component.OnCharge;
      component.OnlyHit = onlyHit ?? component.OnlyHit;
      component.OnlyNatural20 = onlyNatural20 ?? component.OnlyNatural20;
      component.OnlyOnFirstAttack = onlyOnFirstAttack ?? component.OnlyOnFirstAttack;
      component.OnlyOnFirstHit = onlyOnFirstHit ?? component.OnlyOnFirstHit;
      component.OnlyOnFullAttack = onlyOnFullAttack ?? component.OnlyOnFullAttack;
      component.OnlySneakAttack = onlySneakAttack ?? component.OnlySneakAttack;
      component.OnMiss = onMiss ?? component.OnMiss;
      component.RangeType = rangeType ?? component.RangeType;
      component.ReduceHPToZero = reduceHPToZero ?? component.ReduceHPToZero;
      component.TriggerBeforeAttack = triggerBeforeAttack ?? component.TriggerBeforeAttack;
      component.m_WeaponBlueprint = weaponBlueprint?.Reference ?? component.m_WeaponBlueprint;
      if (component.m_WeaponBlueprint is null)
      {
        component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      component.m_WeaponType = weaponType?.Reference ?? component.m_WeaponType;
      if (component.m_WeaponType is null)
      {
        component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetAttackRollTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdaptiveTactics</term><description>e01152417a8ac2248b4f69711b819441</description></item>
    /// <item><term>HolyAuraBuff</term><description>a33bf327207a5904d9e38d6a80eb09e2</description></item>
    /// <item><term>ZonKuthonBuff</term><description>83ee9bf48b4249858df8f8ea5fe6ef06</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="doNotPassAttackRoll">
    /// <para>
    /// InfoBox: Ignore attacker&amp;apos;s roll
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTargetAttackRollTrigger(
        ActionsBuilder? actionOnSelf = null,
        ActionsBuilder? actionsOnAttacker = null,
        bool? affectFriendlyTouchSpells = null,
        WeaponCategory[]? categories = null,
        bool? checkCategory = null,
        bool? criticalHit = null,
        bool? doNotPassAttackRoll = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? not = null,
        bool? notReach = null,
        bool? onlyHit = null,
        bool? onlyMelee = null)
    {
      var component = new AddTargetAttackRollTrigger();
      component.ActionOnSelf = actionOnSelf?.Build() ?? component.ActionOnSelf;
      if (component.ActionOnSelf is null)
      {
        component.ActionOnSelf = Utils.Constants.Empty.Actions;
      }
      component.ActionsOnAttacker = actionsOnAttacker?.Build() ?? component.ActionsOnAttacker;
      if (component.ActionsOnAttacker is null)
      {
        component.ActionsOnAttacker = Utils.Constants.Empty.Actions;
      }
      component.AffectFriendlyTouchSpells = affectFriendlyTouchSpells ?? component.AffectFriendlyTouchSpells;
      component.Categories = categories ?? component.Categories;
      if (component.Categories is null)
      {
        component.Categories = new WeaponCategory[0];
      }
      component.CheckCategory = checkCategory ?? component.CheckCategory;
      component.CriticalHit = criticalHit ?? component.CriticalHit;
      component.DoNotPassAttackRoll = doNotPassAttackRoll ?? component.DoNotPassAttackRoll;
      component.Not = not ?? component.Not;
      component.NotReach = notReach ?? component.NotReach;
      component.OnlyHit = onlyHit ?? component.OnlyHit;
      component.OnlyMelee = onlyMelee ?? component.OnlyMelee;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddTargetBeforeAttackRollTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AssassinMarkOfDeathBuff</term><description>9955b71ef19e44b09e2e596db4e2daef</description></item>
    /// <item><term>MasterOfArenaPolymorphBuff</term><description>e9136d4606c841eba131db95ee962ba9</description></item>
    /// <item><term>WitchHexProtectiveLuckBuff</term><description>1ba3d3a0942d080448ce6aa865bbbd65</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTargetBeforeAttackRollTrigger(
        ActionsBuilder? actionOnSelf = null,
        ActionsBuilder? actionsOnAttacker = null,
        bool? checkDescriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notReach = null,
        bool? onlyMelee = null,
        SpellDescriptorWrapper? spellDescriptors = null)
    {
      var component = new AddTargetBeforeAttackRollTrigger();
      component.ActionOnSelf = actionOnSelf?.Build() ?? component.ActionOnSelf;
      if (component.ActionOnSelf is null)
      {
        component.ActionOnSelf = Utils.Constants.Empty.Actions;
      }
      component.ActionsOnAttacker = actionsOnAttacker?.Build() ?? component.ActionsOnAttacker;
      if (component.ActionsOnAttacker is null)
      {
        component.ActionsOnAttacker = Utils.Constants.Empty.Actions;
      }
      component.CheckDescriptor = checkDescriptor ?? component.CheckDescriptor;
      component.NotReach = notReach ?? component.NotReach;
      component.OnlyMelee = onlyMelee ?? component.OnlyMelee;
      component.SpellDescriptors = spellDescriptors ?? component.SpellDescriptors;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDiceOnAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidMawBuff</term><description>f1a6799b05a40144d9acdbdca1d7c228</description></item>
    /// <item><term>GlowingScytheEnchantment</term><description>385847ab4a270a64fa00479711995e57</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningAllyBuff</term><description>02680be495534b629d543daa89b47079</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="actualTargetUnitInCondition">
    /// <para>
    /// InfoBox: Use of the unit that is damaged (if disabled, the unit that is the main attack is taken)
    /// </para>
    /// </param>
    /// <param name="applyCriticalModifier">
    /// <para>
    /// InfoBox: If enabled, the additional dice damage will inherit critical multiplier from the main damage.
    /// </para>
    /// </param>
    /// <param name="notExtraAttack">
    /// <para>
    /// InfoBox: Will be ignored for non-weapon attack
    /// </para>
    /// </param>
    /// <param name="onAttackOfOpportunity">
    /// <para>
    /// InfoBox: Will be ignored for non-weapon attack
    /// </para>
    /// </param>
    /// <param name="onCharge">
    /// <para>
    /// InfoBox: Will be ignored for non-weapon attack
    /// </para>
    /// </param>
    /// <param name="onlyOnFirstAttack">
    /// <para>
    /// InfoBox: Will be ignored for non-weapon attack
    /// </para>
    /// </param>
    /// <param name="onlyOnFirstHit">
    /// <para>
    /// InfoBox: Will be ignored for non-weapon attack
    /// </para>
    /// </param>
    /// <param name="onlyOnFullAttack">
    /// <para>
    /// InfoBox: Will be ignored for non-weapon attack
    /// </para>
    /// </param>
    /// <param name="reduceHPToZero">
    /// <para>
    /// Tooltip: For melee attacks only
    /// </para>
    /// <para>
    /// InfoBox: Will be ignored for non-weapon attack
    /// </para>
    /// </param>
    /// <param name="weaponType">
    /// <para>
    /// Blueprint of type BlueprintWeaponType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AdditionalDiceOnAttack(
        bool? actualTargetUnitInCondition = null,
        bool? allNaturalAndUnarmed = null,
        bool? applyCriticalModifier = null,
        AdditionalDiceOnAttack.WeaponOptions? attackType = null,
        WeaponCategory? category = null,
        bool? checkDistance = null,
        bool? checkWeaponCategory = null,
        bool? checkWeaponGroup = null,
        bool? checkWeaponRangeType = null,
        bool? criticalHit = null,
        List<AdditionalDiceOnAttack.DamageEntry>? damageEntries = null,
        DamageTypeDescription? damageType = null,
        Feet? distanceLessEqual = null,
        bool? duelistWeapon = null,
        WeaponFighterGroup? group = null,
        ConditionsBuilder? initiatorConditions = null,
        bool? mainDamageTypeUse = null,
        bool? notCriticalHit = null,
        bool? notExtraAttack = null,
        bool? notSneakAttack = null,
        bool? onAttackOfOpportunity = null,
        bool? onCharge = null,
        bool? onHit = null,
        bool? onlyOnFirstAttack = null,
        bool? onlyOnFirstHit = null,
        bool? onlyOnFullAttack = null,
        bool? onlySneakAttack = null,
        bool? randomizeDamage = null,
        WeaponRangeType? rangeType = null,
        bool? reduceHPToZero = null,
        ConditionsBuilder? targetConditions = null,
        bool? useWeaponDice = null,
        ContextDiceValue? value = null,
        Blueprint<BlueprintWeaponTypeReference>? weaponType = null)
    {
      var component = new AdditionalDiceOnAttack();
      component.ActualTargetUnitInCondition = actualTargetUnitInCondition ?? component.ActualTargetUnitInCondition;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed ?? component.AllNaturalAndUnarmed;
      component.ApplyCriticalModifier = applyCriticalModifier ?? component.ApplyCriticalModifier;
      component.AttackType = attackType ?? component.AttackType;
      component.Category = category ?? component.Category;
      component.CheckDistance = checkDistance ?? component.CheckDistance;
      component.CheckWeaponCategory = checkWeaponCategory ?? component.CheckWeaponCategory;
      component.CheckWeaponGroup = checkWeaponGroup ?? component.CheckWeaponGroup;
      component.CheckWeaponRangeType = checkWeaponRangeType ?? component.CheckWeaponRangeType;
      component.CriticalHit = criticalHit ?? component.CriticalHit;
      Validate(damageEntries);
      component.m_DamageEntries = damageEntries ?? component.m_DamageEntries;
      if (component.m_DamageEntries is null)
      {
        component.m_DamageEntries = new();
      }
      Validate(damageType);
      component.DamageType = damageType ?? component.DamageType;
      component.DistanceLessEqual = distanceLessEqual ?? component.DistanceLessEqual;
      component.DuelistWeapon = duelistWeapon ?? component.DuelistWeapon;
      component.Group = group ?? component.Group;
      component.InitiatorConditions = initiatorConditions?.Build() ?? component.InitiatorConditions;
      if (component.InitiatorConditions is null)
      {
        component.InitiatorConditions = Utils.Constants.Empty.Conditions;
      }
      component.MainDamageTypeUse = mainDamageTypeUse ?? component.MainDamageTypeUse;
      component.NotCriticalHit = notCriticalHit ?? component.NotCriticalHit;
      component.NotExtraAttack = notExtraAttack ?? component.NotExtraAttack;
      component.NotSneakAttack = notSneakAttack ?? component.NotSneakAttack;
      component.OnAttackOfOpportunity = onAttackOfOpportunity ?? component.OnAttackOfOpportunity;
      component.OnCharge = onCharge ?? component.OnCharge;
      component.OnHit = onHit ?? component.OnHit;
      component.OnlyOnFirstAttack = onlyOnFirstAttack ?? component.OnlyOnFirstAttack;
      component.OnlyOnFirstHit = onlyOnFirstHit ?? component.OnlyOnFirstHit;
      component.OnlyOnFullAttack = onlyOnFullAttack ?? component.OnlyOnFullAttack;
      component.OnlySneakAttack = onlySneakAttack ?? component.OnlySneakAttack;
      component.m_RandomizeDamage = randomizeDamage ?? component.m_RandomizeDamage;
      component.RangeType = rangeType ?? component.RangeType;
      component.ReduceHPToZero = reduceHPToZero ?? component.ReduceHPToZero;
      component.TargetConditions = targetConditions?.Build() ?? component.TargetConditions;
      if (component.TargetConditions is null)
      {
        component.TargetConditions = Utils.Constants.Empty.Conditions;
      }
      component.m_UseWeaponDice = useWeaponDice ?? component.m_UseWeaponDice;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = Utils.Constants.Empty.DiceValue;
      }
      component.m_WeaponType = weaponType?.Reference ?? component.m_WeaponType;
      if (component.m_WeaponType is null)
      {
        component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDiceOnDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlchemistBombsFeature</term><description>c59b2f256f5a70a4d896568658315b7d</description></item>
    /// <item><term>ElementalPunisherLongbowEnchantment</term><description>0bf0156eb3687254b9fb0f6b4067da20</description></item>
    /// <item><term>RingOfPyromaniaFeature</term><description>3789253d5e8af5c42a22cd97ef4d9e65</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilityList">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="applyCriticalModifier">
    /// <para>
    /// InfoBox: If enabled, the additional dice damage will inherit critical multiplier from the main damage.
    /// </para>
    /// </param>
    /// <param name="weaponType">
    /// <para>
    /// Blueprint of type BlueprintWeaponType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AdditionalDiceOnDamage(
        List<Blueprint<BlueprintAbilityReference>>? abilityList = null,
        AbilityType? abilityType = null,
        bool? applyCriticalModifier = null,
        bool? applyToAreaEffectDamage = null,
        bool? checkAbilityType = null,
        bool? checkDamageDealt = null,
        bool? checkEnergyDamageType = null,
        bool? checkSpellDescriptor = null,
        bool? checkSpellParent = null,
        bool? checkWeaponType = null,
        CompareOperation.Type? compareType = null,
        List<AdditionalDiceOnDamage.DamageEntry>? damageEntries = null,
        AdditionalDiceOnDamage.DamageEntriesUse? damageEntriesUse = null,
        DamageTypeDescription? damageTypeDescription = null,
        ContextDiceValue? diceValue = null,
        DamageEnergyType? energyType = null,
        bool? ignoreDamageFromThisFact = null,
        ConditionsBuilder? initiatorConditions = null,
        bool? isOneAtack = null,
        bool? mainDamageTypeUse = null,
        bool? notZeroDamage = null,
        SpellDescriptorWrapper? spellDescriptorsList = null,
        ConditionsBuilder? targetConditions = null,
        bool? targetKilledByThisDamage = null,
        ContextValue? targetValue = null,
        bool? useWeaponDice = null,
        Blueprint<BlueprintWeaponTypeReference>? weaponType = null)
    {
      var component = new AdditionalDiceOnDamage();
      component.m_AbilityList = abilityList?.Select(bp => bp.Reference)?.ToArray() ?? component.m_AbilityList;
      if (component.m_AbilityList is null)
      {
        component.m_AbilityList = new BlueprintAbilityReference[0];
      }
      component.m_AbilityType = abilityType ?? component.m_AbilityType;
      component.ApplyCriticalModifier = applyCriticalModifier ?? component.ApplyCriticalModifier;
      component.ApplyToAreaEffectDamage = applyToAreaEffectDamage ?? component.ApplyToAreaEffectDamage;
      component.CheckAbilityType = checkAbilityType ?? component.CheckAbilityType;
      component.CheckDamageDealt = checkDamageDealt ?? component.CheckDamageDealt;
      component.CheckEnergyDamageType = checkEnergyDamageType ?? component.CheckEnergyDamageType;
      component.CheckSpellDescriptor = checkSpellDescriptor ?? component.CheckSpellDescriptor;
      component.CheckSpellParent = checkSpellParent ?? component.CheckSpellParent;
      component.CheckWeaponType = checkWeaponType ?? component.CheckWeaponType;
      component.CompareType = compareType ?? component.CompareType;
      Validate(damageEntries);
      component.m_DamageEntries = damageEntries ?? component.m_DamageEntries;
      if (component.m_DamageEntries is null)
      {
        component.m_DamageEntries = new();
      }
      component.m_DamageEntriesUse = damageEntriesUse ?? component.m_DamageEntriesUse;
      Validate(damageTypeDescription);
      component.DamageTypeDescription = damageTypeDescription ?? component.DamageTypeDescription;
      component.DiceValue = diceValue ?? component.DiceValue;
      if (component.DiceValue is null)
      {
        component.DiceValue = Utils.Constants.Empty.DiceValue;
      }
      component.EnergyType = energyType ?? component.EnergyType;
      component.IgnoreDamageFromThisFact = ignoreDamageFromThisFact ?? component.IgnoreDamageFromThisFact;
      component.InitiatorConditions = initiatorConditions?.Build() ?? component.InitiatorConditions;
      if (component.InitiatorConditions is null)
      {
        component.InitiatorConditions = Utils.Constants.Empty.Conditions;
      }
      component.IsOneAtack = isOneAtack ?? component.IsOneAtack;
      component.MainDamageTypeUse = mainDamageTypeUse ?? component.MainDamageTypeUse;
      component.NotZeroDamage = notZeroDamage ?? component.NotZeroDamage;
      component.SpellDescriptorsList = spellDescriptorsList ?? component.SpellDescriptorsList;
      component.TargetConditions = targetConditions?.Build() ?? component.TargetConditions;
      if (component.TargetConditions is null)
      {
        component.TargetConditions = Utils.Constants.Empty.Conditions;
      }
      component.TargetKilledByThisDamage = targetKilledByThisDamage ?? component.TargetKilledByThisDamage;
      component.TargetValue = targetValue ?? component.TargetValue;
      if (component.TargetValue is null)
      {
        component.TargetValue = ContextValues.Constant(0);
      }
      component.m_UseWeaponDice = useWeaponDice ?? component.m_UseWeaponDice;
      component.m_WeaponType = weaponType?.Reference ?? component.m_WeaponType;
      if (component.m_WeaponType is null)
      {
        component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalStatBonusOnAttackDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DragonFerocityBuff</term><description>8709a00782de26d4a8524732879000fa</description></item>
    /// <item><term>TreantCreatureSturdy</term><description>845339bae62597d47990469030bcf32a</description></item>
    /// <item><term>UnstoppableStrikeFeature</term><description>7d60d8bb86a14e3188d208652d4a5581</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="gripStyle">
    /// <para>
    /// InfoBox: Никогда не выбирайте Auto опцию, она для внутреннего использования.
    /// </para>
    /// </param>
    public TBuilder AdditionalStatBonusOnAttackDamage(
        float? bonus = null,
        WeaponCategory? category = null,
        bool? checkCategory = null,
        bool? checkGripStyle = null,
        bool? checkTwoHanded = null,
        ConditionEnum? firstAttack = null,
        ConditionEnum? fullAttack = null,
        GripType? gripStyle = null)
    {
      var component = new AdditionalStatBonusOnAttackDamage();
      component.Bonus = bonus ?? component.Bonus;
      component.Category = category ?? component.Category;
      component.CheckCategory = checkCategory ?? component.CheckCategory;
      component.m_checkGripStyle = checkGripStyle ?? component.m_checkGripStyle;
      component.CheckTwoHanded = checkTwoHanded ?? component.CheckTwoHanded;
      component.FirstAttack = firstAttack ?? component.FirstAttack;
      component.FullAttack = fullAttack ?? component.FullAttack;
      component.m_gripStyle = gripStyle ?? component.m_gripStyle;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllAttacksEnhancement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalCompanionAttacksEnhancement</term><description>71d6955fe81a9a34b97390fef1104362</description></item>
    /// <item><term>IncubusBandLair_IncubusBossFeature</term><description>677c42f19f2b01b4c8cb8b8d7f64efc6</description></item>
    /// <item><term>RingOfEnhancedSummonsBuff</term><description>f4b35376b1021c74ea90abc40df55628</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAllAttacksEnhancement(
        int? bonus = null,
        ModifierDescriptor? descriptor = null)
    {
      var component = new AllAttacksEnhancement();
      component.Bonus = bonus ?? component.Bonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RuleCalculateDamageWithWeaponTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ExposeVulnerability</term><description>8ce3c4b3c1ad24f4dbb6cb4c72e1ec53</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="actualTargetUnit">
    /// <para>
    /// InfoBox: Use of the unit that is damaged (if disabled, the unit that is the main attack is taken)
    /// </para>
    /// </param>
    /// <param name="weaponBlueprint">
    /// <para>
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="weaponType">
    /// <para>
    /// Blueprint of type BlueprintWeaponType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddRuleCalculateDamageWithWeaponTrigger(
        ActionsBuilder? action = null,
        bool? actionsOnInitiator = null,
        bool? actualTargetUnit = null,
        bool? allNaturalAndUnarmed = null,
        WeaponCategory? category = null,
        bool? checkDistance = null,
        bool? checkPhysicalDamageForm = null,
        bool? checkWeaponBlueprint = null,
        bool? checkWeaponCategory = null,
        bool? checkWeaponGroup = null,
        bool? checkWeaponRangeType = null,
        bool? criticalHit = null,
        PhysicalDamageForm? damageForm = null,
        bool? damageMoreTargetMaxHP = null,
        Feet? distanceLessEqual = null,
        bool? duelistWeapon = null,
        WeaponFighterGroup? group = null,
        bool? ignoreAutoHit = null,
        bool? notCriticalHit = null,
        bool? notExtraAttack = null,
        bool? notSneakAttack = null,
        bool? onAttackOfOpportunity = null,
        bool? onCharge = null,
        bool? onlyHit = null,
        bool? onlyNatural20 = null,
        bool? onlyOnFirstAttack = null,
        bool? onlyOnFirstHit = null,
        bool? onlyOnFullAttack = null,
        bool? onlySneakAttack = null,
        bool? onMiss = null,
        WeaponRangeType? rangeType = null,
        bool? reduceHPToZero = null,
        bool? triggerBeforeAttack = null,
        Blueprint<BlueprintItemWeaponReference>? weaponBlueprint = null,
        Blueprint<BlueprintWeaponTypeReference>? weaponType = null)
    {
      var component = new RuleCalculateDamageWithWeaponTrigger();
      component.Action = action?.Build() ?? component.Action;
      if (component.Action is null)
      {
        component.Action = Utils.Constants.Empty.Actions;
      }
      component.ActionsOnInitiator = actionsOnInitiator ?? component.ActionsOnInitiator;
      component.ActualTargetUnit = actualTargetUnit ?? component.ActualTargetUnit;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed ?? component.AllNaturalAndUnarmed;
      component.Category = category ?? component.Category;
      component.CheckDistance = checkDistance ?? component.CheckDistance;
      component.CheckPhysicalDamageForm = checkPhysicalDamageForm ?? component.CheckPhysicalDamageForm;
      component.CheckWeaponBlueprint = checkWeaponBlueprint ?? component.CheckWeaponBlueprint;
      component.CheckWeaponCategory = checkWeaponCategory ?? component.CheckWeaponCategory;
      component.CheckWeaponGroup = checkWeaponGroup ?? component.CheckWeaponGroup;
      component.CheckWeaponRangeType = checkWeaponRangeType ?? component.CheckWeaponRangeType;
      component.CriticalHit = criticalHit ?? component.CriticalHit;
      component.DamageForm = damageForm ?? component.DamageForm;
      component.DamageMoreTargetMaxHP = damageMoreTargetMaxHP ?? component.DamageMoreTargetMaxHP;
      component.DistanceLessEqual = distanceLessEqual ?? component.DistanceLessEqual;
      component.DuelistWeapon = duelistWeapon ?? component.DuelistWeapon;
      component.Group = group ?? component.Group;
      component.IgnoreAutoHit = ignoreAutoHit ?? component.IgnoreAutoHit;
      component.NotCriticalHit = notCriticalHit ?? component.NotCriticalHit;
      component.NotExtraAttack = notExtraAttack ?? component.NotExtraAttack;
      component.NotSneakAttack = notSneakAttack ?? component.NotSneakAttack;
      component.OnAttackOfOpportunity = onAttackOfOpportunity ?? component.OnAttackOfOpportunity;
      component.OnCharge = onCharge ?? component.OnCharge;
      component.OnlyHit = onlyHit ?? component.OnlyHit;
      component.OnlyNatural20 = onlyNatural20 ?? component.OnlyNatural20;
      component.OnlyOnFirstAttack = onlyOnFirstAttack ?? component.OnlyOnFirstAttack;
      component.OnlyOnFirstHit = onlyOnFirstHit ?? component.OnlyOnFirstHit;
      component.OnlyOnFullAttack = onlyOnFullAttack ?? component.OnlyOnFullAttack;
      component.OnlySneakAttack = onlySneakAttack ?? component.OnlySneakAttack;
      component.OnMiss = onMiss ?? component.OnMiss;
      component.RangeType = rangeType ?? component.RangeType;
      component.ReduceHPToZero = reduceHPToZero ?? component.ReduceHPToZero;
      component.TriggerBeforeAttack = triggerBeforeAttack ?? component.TriggerBeforeAttack;
      component.m_WeaponBlueprint = weaponBlueprint?.Reference ?? component.m_WeaponBlueprint;
      if (component.m_WeaponBlueprint is null)
      {
        component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      component.m_WeaponType = weaponType?.Reference ?? component.m_WeaponType;
      if (component.m_WeaponType is null)
      {
        component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MarkUsableWhileCan"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PotionOfCureCriticalWounds</term><description>1f45a09f2e072ea4e8d52fadcd7e66f3</description></item>
    /// <item><term>ScrollOfCureCriticalWoundsMass</term><description>13bf4126b147cfe41b669fd2258f9ebd</description></item>
    /// <item><term>ScrollOfInflictSeriousWounds</term><description>47d41dd302a14d04faa7df70697d23ec</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddMarkUsableWhileCan(
        ConditionsBuilder? conditions = null,
        bool? not = null)
    {
      var component = new MarkUsableWhileCan();
      component.m_Conditions = conditions?.Build() ?? component.m_Conditions;
      if (component.m_Conditions is null)
      {
        component.m_Conditions = Utils.Constants.Empty.Conditions;
      }
      component.m_Not = not ?? component.m_Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyBattleResultsTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>KingdomMoraleFlagChapter2</term><description>6195e82164ff47d3a67ff5fd0d74d5e3</description></item>
    /// <item><term>Military6Errand1Tracker_buff</term><description>e0600a746cd44bb9bdefa61df0cdeebb</description></item>
    /// <item><term>TestArmy</term><description>c6e67d89056a83c4f8e9eb5b46c78f71</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="assignedRegion">
    /// <para>
    /// InfoBox: Keep None for any region
    /// </para>
    /// </param>
    /// <param name="crusadeLeader">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="demonArmies">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddArmyBattleResultsTrigger(
        RegionId? assignedRegion = null,
        Blueprint<BlueprintArmyLeaderReference>? crusadeLeader = null,
        List<Blueprint<BlueprintArmyPresetReference>>? demonArmies = null,
        ArmyType? demonsArmyType = null,
        bool? demonsFromList = null,
        ActionsBuilder? onCrusadersVictory = null,
        ActionsBuilder? onDemonsVictory = null,
        bool? specificCrusadeLeader = null)
    {
      var component = new ArmyBattleResultsTrigger();
      component.m_AssignedRegion = assignedRegion ?? component.m_AssignedRegion;
      component.m_CrusadeLeader = crusadeLeader?.Reference ?? component.m_CrusadeLeader;
      if (component.m_CrusadeLeader is null)
      {
        component.m_CrusadeLeader = BlueprintTool.GetRef<BlueprintArmyLeaderReference>(null);
      }
      component.m_DemonArmies = demonArmies?.Select(bp => bp.Reference)?.ToList() ?? component.m_DemonArmies;
      if (component.m_DemonArmies is null)
      {
        component.m_DemonArmies = new();
      }
      component.m_DemonsArmyType = demonsArmyType ?? component.m_DemonsArmyType;
      component.m_DemonsFromList = demonsFromList ?? component.m_DemonsFromList;
      component.OnCrusadersVictory = onCrusadersVictory?.Build() ?? component.OnCrusadersVictory;
      if (component.OnCrusadersVictory is null)
      {
        component.OnCrusadersVictory = Utils.Constants.Empty.Actions;
      }
      component.OnDemonsVictory = onDemonsVictory?.Build() ?? component.OnDemonsVictory;
      if (component.OnDemonsVictory is null)
      {
        component.OnDemonsVictory = Utils.Constants.Empty.Actions;
      }
      component.m_SpecificCrusadeLeader = specificCrusadeLeader ?? component.m_SpecificCrusadeLeader;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomRegionClaimedTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagDiplomacy7CrusadeResourcesForRegions</term><description>8663e81969a647fe9d6e8c3afd7d9172</description></item>
    /// <item><term>KingdomMoraleFlagChapter3Regions</term><description>d04ff8f15c034f56bcfbad952a74bdb3</description></item>
    /// <item><term>KingdomMoraleFlagChapter5Regions</term><description>b01624ee06444738964b678259f31a20</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="regions">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddKingdomRegionClaimedTrigger(
        ActionsBuilder? actions = null,
        List<Blueprint<BlueprintRegionReference>>? regions = null)
    {
      var component = new KingdomRegionClaimedTrigger();
      component.m_Actions = actions?.Build() ?? component.m_Actions;
      if (component.m_Actions is null)
      {
        component.m_Actions = Utils.Constants.Empty.Actions;
      }
      component.m_Regions = regions?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Regions;
      if (component.m_Regions is null)
      {
        component.m_Regions = new BlueprintRegionReference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementSiegeTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>KingdomMoraleFlagChapter3Siege</term><description>0b405fd736f54c05b65aaee855ad585e</description></item>
    /// <item><term>KingdomMoraleFlagChapter5Siege</term><description>97f654fb595348b4a492ef17baf2af04</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="onSettlementDestroyed">
    /// <para>
    /// InfoBox: Actions that will run right after OnSiegeEnd action, if settlement was destroyed
    /// </para>
    /// </param>
    /// <param name="onSiegeEnd">
    /// <para>
    /// InfoBox: Actions on any siege end (destroyed or conquered back)
    /// </para>
    /// </param>
    /// <param name="settlementLocation">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSettlementSiegeTrigger(
        ActionsBuilder? onSettlementDestroyed = null,
        ActionsBuilder? onSiegeEnd = null,
        ActionsBuilder? onSiegeStart = null,
        Blueprint<BlueprintGlobalMapPointReference>? settlementLocation = null,
        bool? specificLocation = null)
    {
      var component = new SettlementSiegeTrigger();
      component.m_OnSettlementDestroyed = onSettlementDestroyed?.Build() ?? component.m_OnSettlementDestroyed;
      if (component.m_OnSettlementDestroyed is null)
      {
        component.m_OnSettlementDestroyed = Utils.Constants.Empty.Actions;
      }
      component.m_OnSiegeEnd = onSiegeEnd?.Build() ?? component.m_OnSiegeEnd;
      if (component.m_OnSiegeEnd is null)
      {
        component.m_OnSiegeEnd = Utils.Constants.Empty.Actions;
      }
      component.m_OnSiegeStart = onSiegeStart?.Build() ?? component.m_OnSiegeStart;
      if (component.m_OnSiegeStart is null)
      {
        component.m_OnSiegeStart = Utils.Constants.Empty.Actions;
      }
      component.m_SettlementLocation = settlementLocation?.Reference ?? component.m_SettlementLocation;
      if (component.m_SettlementLocation is null)
      {
        component.m_SettlementLocation = BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(null);
      }
      component.m_SpecificLocation = specificLocation ?? component.m_SpecificLocation;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitRecruitedTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>KingdomMoraleFlagChapter2</term><description>6195e82164ff47d3a67ff5fd0d74d5e3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="armyUnits">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddArmyUnitRecruitedTrigger(
        ActionsBuilder? action = null,
        ArmyProperties? armyTag = null,
        List<Blueprint<BlueprintUnitReference>>? armyUnits = null,
        bool? byTag = null,
        bool? byUnits = null,
        MercenariesIncludeOption? mercenariesFilter = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? minCount = null)
    {
      var component = new ArmyUnitRecruitedTrigger();
      component.m_Action = action?.Build() ?? component.m_Action;
      if (component.m_Action is null)
      {
        component.m_Action = Utils.Constants.Empty.Actions;
      }
      component.m_ArmyTag = armyTag ?? component.m_ArmyTag;
      component.m_ArmyUnits = armyUnits?.Select(bp => bp.Reference)?.ToArray() ?? component.m_ArmyUnits;
      if (component.m_ArmyUnits is null)
      {
        component.m_ArmyUnits = new BlueprintUnitReference[0];
      }
      component.m_ByTag = byTag ?? component.m_ByTag;
      component.m_ByUnits = byUnits ?? component.m_ByUnits;
      component.m_MercenariesFilter = mercenariesFilter ?? component.m_MercenariesFilter;
      component.m_MinCount = minCount ?? component.m_MinCount;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="LeaderRecruitedTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>KingdomMoraleFlagChapter2</term><description>6195e82164ff47d3a67ff5fd0d74d5e3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddLeaderRecruitedTrigger(
        ActionsBuilder? action = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new LeaderRecruitedTrigger();
      component.m_Action = action?.Build() ?? component.m_Action;
      if (component.m_Action is null)
      {
        component.m_Action = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SummonUnitsAfterArmyBattle"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagLich0Necromancy</term><description>23f72e33717d49a78cbc6ba4df5a959b</description></item>
    /// <item><term>FlagLich5GraveKnight</term><description>6d8e19e7808b44b4af20a6f283152bfa</description></item>
    /// <item><term>FlagLocustDevour</term><description>947ba8d498a2462e8b317d252fe8478e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSummonUnitsAfterArmyBattle(
        SummonUnitsAfterArmyBattle.SummonGroup[]? groups = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SummonUnitsAfterArmyBattle();
      Validate(groups);
      component.m_Groups = groups ?? component.m_Groups;
      if (component.m_Groups is null)
      {
        component.m_Groups = new SummonUnitsAfterArmyBattle.SummonGroup[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="GarrisonDefeatedTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalmapBeforeDrezen</term><description>fde213d10dd047b4d9eca69f16b7cc70</description></item>
    /// <item><term>KingdomMoraleFlagChapter2ToDrezen</term><description>09874ec957514a6b9a8ad26a26c2d638</description></item>
    /// <item><term>KingdomMoraleFlagChapter5Regions</term><description>b01624ee06444738964b678259f31a20</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="location">
    /// <para>
    /// Tooltip: optional, trigger only when garrison defeated in specified location
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddGarrisonDefeatedTrigger(
        ActionsBuilder? actions = null,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var component = new GarrisonDefeatedTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.m_Location = location?.Reference ?? component.m_Location;
      if (component.m_Location is null)
      {
        component.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PlayerVisitGlobalMapLocationTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalmapBeforeDrezen</term><description>fde213d10dd047b4d9eca69f16b7cc70</description></item>
    /// <item><term>GlobalmapBeforeLostChapel</term><description>739f6806ac4123b4389eea950c5af95b</description></item>
    /// <item><term>GlobalmapBeforeSwarm</term><description>b83be206a84704547a8fd50bc6e02be6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddPlayerVisitGlobalMapLocationTrigger(
        ActionsBuilder? actions = null,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var component = new PlayerVisitGlobalMapLocationTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.m_Location = location?.Reference ?? component.m_Location;
      if (component.m_Location is null)
      {
        component.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OnIsleStateEnterTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MediumCity_FlyingIslesControls_Etude</term><description>fa16edfae00b94048a71bab6ef5463d4</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddOnIsleStateEnterTrigger(
        ActionsBuilder? actions = null,
        IsleEvaluator? isleEvaluator = null,
        string? targetState = null)
    {
      var component = new OnIsleStateEnterTrigger();
      component.m_Actions = actions?.Build() ?? component.m_Actions;
      if (component.m_Actions is null)
      {
        component.m_Actions = Utils.Constants.Empty.Actions;
      }
      Validate(isleEvaluator);
      component.m_IsleEvaluator = isleEvaluator ?? component.m_IsleEvaluator;
      component.m_TargetState = targetState ?? component.m_TargetState;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OnIsleStateExitTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_HasteIslandStacks</term><description>a1aecb0c003a49b9ae385035875f1b92</description></item>
    /// <item><term>MediumCity_FlyingIslesControls_Etude</term><description>fa16edfae00b94048a71bab6ef5463d4</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddOnIsleStateExitTrigger(
        ActionsBuilder? actions = null,
        IsleEvaluator? isleEvaluator = null,
        string? targetState = null)
    {
      var component = new OnIsleStateExitTrigger();
      component.m_Actions = actions?.Build() ?? component.m_Actions;
      if (component.m_Actions is null)
      {
        component.m_Actions = Utils.Constants.Empty.Actions;
      }
      Validate(isleEvaluator);
      component.m_IsleEvaluator = isleEvaluator ?? component.m_IsleEvaluator;
      component.m_TargetState = targetState ?? component.m_TargetState;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActivateTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/ActivateTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonEyeNPCVisualBuff</term><description>cf2f65c16e02826428f32be045f8523d</description></item>
    /// <item><term>MidnightFaneStory</term><description>711ca7b7c2332d94bba0e878ce799fc8</description></item>
    /// <item><term>WarCamp_DefaultPeaceful_Lann</term><description>c82f78f0f7fee3c40a7d1164d202bebd</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddActivateTrigger(
        ActionsBuilder? actions = null,
        bool? alsoOnAreaLoad = null,
        ConditionsBuilder? conditions = null,
        bool? once = null)
    {
      var component = new ActivateTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.m_AlsoOnAreaLoad = alsoOnAreaLoad ?? component.m_AlsoOnAreaLoad;
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.m_Once = once ?? component.m_Once;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaDidLoadTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonEyeNPCVisualBuff</term><description>cf2f65c16e02826428f32be045f8523d</description></item>
    /// <item><term>DLC5_TavernDefault</term><description>b354ec11d92a4d7480b021ea1a0e9fdd</description></item>
    /// <item><term>WenduagRomance_BarksAfterSexRepeat</term><description>e3049ea03e2f80a42b5b2dab02c75e78</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAreaDidLoadTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null)
    {
      var component = new AreaDidLoadTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeactivateTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/DeactivateTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abad_state_0</term><description>52edc4f040174899850aaeb0b853b1d8</description></item>
    /// <item><term>HideOath</term><description>ca9d1feaeddda7e43bd63b91078a41d4</description></item>
    /// <item><term>ZigguratZachariusInZiggurat</term><description>2844d387f27a0bb468f72603dd15eda2</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddDeactivateTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null)
    {
      var component = new DeactivateTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeviceInteractionTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/DeviceInteractionTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Area52Button</term><description>fdf004a019ae85741bcee792d46900e8</description></item>
    /// <item><term>GateDLeverLogicConnector</term><description>40ec21a61892adc429b43667f5b497bc</description></item>
    /// <item><term>GateFLeverLogicConnector</term><description>83b8311bbfcded340948d1675efa58ad</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddDeviceInteractionTrigger(
        ActionsBuilder? actions = null,
        ActionsBuilder? restrictedActions = null)
    {
      var component = new DeviceInteractionTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.RestrictedActions = restrictedActions?.Build() ?? component.RestrictedActions;
      if (component.RestrictedActions is null)
      {
        component.RestrictedActions = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvaluatedUnitCombatTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/EvaluatedUnitCombatTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2Wave</term><description>4e1dcba08c1e4a89aea4aaa07f8f89ae</description></item>
    /// <item><term>Fleshmarket_Dyunk</term><description>decab5093aaa4e78a36345545b3e094d</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEvaluatedUnitCombatTrigger(
        ActionsBuilder? actions = null,
        bool? triggerOnExit = null,
        UnitEvaluator? unit = null)
    {
      var component = new EvaluatedUnitCombatTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.TriggerOnExit = triggerOnExit ?? component.TriggerOnExit;
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvaluatedUnitDeathTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/EvaluatedUnitDeathTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>26!_SadisticGD_CH1_AlchemistLair</term><description>546bf66870894657beb8e058b2702dfb</description></item>
    /// <item><term>DLC6_CamelliaInKenabres</term><description>f25c603080364a85857f0607d45396a0</description></item>
    /// <item><term>XantirLastCombat</term><description>a885b376ef17bdf4aa1ae37ac6e911f3</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEvaluatedUnitDeathTrigger(
        ActionsBuilder? actions = null,
        bool? anyUnit = null,
        UnitEvaluator? unit = null)
    {
      var component = new EvaluatedUnitDeathTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.AnyUnit = anyUnit ?? component.AnyUnit;
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvaluatedUnitHealthTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/UnitHealthTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Alushinyrra_MutasafenAttackSE</term><description>6058edc67bafcc140a178a9ce914f21b</description></item>
    /// <item><term>FightingAsGreybor</term><description>444ff0518d69c2d47a740b2aa5d63a11</description></item>
    /// <item><term>ZachariusEnemyInZiggurat</term><description>63cc30e6086ce1842997d0924677019c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEvaluatedUnitHealthTrigger(
        ActionsBuilder? actions = null,
        bool? once = null,
        int? percentage = null,
        bool? triggerOnAlreadyLowerHeath = null,
        UnitEvaluator? unit = null)
    {
      var component = new EvaluatedUnitHealthTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Once = once ?? component.Once;
      component.Percentage = percentage ?? component.Percentage;
      component.TriggerOnAlreadyLowerHeath = triggerOnAlreadyLowerHeath ?? component.TriggerOnAlreadyLowerHeath;
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ExperienceTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_2</term><description>c1271e7f80eb45f1907c235152832c5c</description></item>
    /// <item><term>Cue_30</term><description>446465aa74e4461dabb37dd765d51310</description></item>
    /// <item><term>Cue_9</term><description>f5d717f273144804a939b339c4bc4e95</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddExperienceTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        int? experience = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ExperienceTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.Experience = experience ?? component.Experience;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="GenericInteractionTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/GenericInteractionTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_AreeluLab_RiftIsNotReady</term><description>c4e82b6002dea564eafb3c0c935c93db</description></item>
    /// <item><term>DrezenCapital_DefaultMechanic</term><description>30862a76dd4a11049be42d3de26159fb</description></item>
    /// <item><term>XO_Puzzle_2</term><description>efa8a6a57fe74752a0a8019a10eab4aa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="triggerBeforeInteraction">
    /// <para>
    /// InfoBox: Only for success interaction. If true runs this tregger&amp;apos;s Actions first and only after that default actions from map object
    /// </para>
    /// </param>
    public TBuilder AddGenericInteractionTrigger(
        ActionsBuilder? actions = null,
        EntityReference? mapObject = null,
        ActionsBuilder? restrictedActions = null,
        bool? triggerBeforeInteraction = null)
    {
      var component = new GenericInteractionTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      Validate(mapObject);
      component.MapObject = mapObject ?? component.MapObject;
      component.RestrictedActions = restrictedActions?.Build() ?? component.RestrictedActions;
      if (component.RestrictedActions is null)
      {
        component.RestrictedActions = Utils.Constants.Empty.Actions;
      }
      component.TriggerBeforeInteraction = triggerBeforeInteraction ?? component.TriggerBeforeInteraction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemInContainerTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/ItemInContainerTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLab_Return_Default</term><description>87d74b3a4bc758d408d7949c6de23fdd</description></item>
    /// <item><term>DLC1_AreeluHouse_TableItems</term><description>12bfd7ba89154c1191e28770575f1591</description></item>
    /// <item><term>ZachariusEnemyInZiggurat</term><description>63cc30e6086ce1842997d0924677019c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="itemToCheck">
    /// <para>
    /// InfoBox: Triggers for every item if null
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="onAddActions">
    /// <para>
    /// InfoBox: Evaluators: ItemFromContextEvaluator, InteractedMapObject
    /// </para>
    /// </param>
    /// <param name="onRemoveActions">
    /// <para>
    /// InfoBox: Evaluators: ItemFromContextEvaluator, InteractedMapObject
    /// </para>
    /// </param>
    public TBuilder AddItemInContainerTrigger(
        Blueprint<BlueprintItemReference>? itemToCheck = null,
        MapObjectEvaluator? mapObject = null,
        ActionsBuilder? onAddActions = null,
        ActionsBuilder? onRemoveActions = null)
    {
      var component = new ItemInContainerTrigger();
      component.m_ItemToCheck = itemToCheck?.Reference ?? component.m_ItemToCheck;
      if (component.m_ItemToCheck is null)
      {
        component.m_ItemToCheck = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      Validate(mapObject);
      component.MapObject = mapObject ?? component.MapObject;
      component.OnAddActions = onAddActions?.Build() ?? component.OnAddActions;
      if (component.OnAddActions is null)
      {
        component.OnAddActions = Utils.Constants.Empty.Actions;
      }
      component.OnRemoveActions = onRemoveActions?.Build() ?? component.OnRemoveActions;
      if (component.OnRemoveActions is null)
      {
        component.OnRemoveActions = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LevelUpTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/LevelUpTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CheckBoonFlags</term><description>87a65a30a6f5424b86fed226dbc2d101</description></item>
    /// <item><term>DLC3_DevilActivated</term><description>7181daa98be84847a11681799d3589b7</description></item>
    /// <item><term>MythicLevel</term><description>dc66b7adec0e41c2b948b4bc9c31ec99</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddLevelUpTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        UnitEvaluator? unit = null,
        LevelUpTrigger.UnitEntryType? unitEntryType = null)
    {
      var component = new LevelUpTrigger();
      component.m_Actions = actions?.Build() ?? component.m_Actions;
      if (component.m_Actions is null)
      {
        component.m_Actions = Utils.Constants.Empty.Actions;
      }
      component.m_Conditions = conditions?.Build() ?? component.m_Conditions;
      if (component.m_Conditions is null)
      {
        component.m_Conditions = Utils.Constants.Empty.Conditions;
      }
      Validate(unit);
      component.m_Unit = unit ?? component.m_Unit;
      component.m_UnitEntryType = unitEntryType ?? component.m_UnitEntryType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PartyInventoryTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/ItemTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_DuringQuest</term><description>fb99a426b8bf1f247a2272920a1fd13d</description></item>
    /// <item><term>FightWithSilkShadow</term><description>4528b09e870e2a842819270c5326126c</description></item>
    /// <item><term>ZoeyPendantTeleport</term><description>9a90929e2db1be448b495509170a4251</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="item">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddPartyInventoryTrigger(
        Blueprint<BlueprintItemReference>? item = null,
        ActionsBuilder? onAddActions = null,
        ActionsBuilder? onRemoveActions = null)
    {
      var component = new PartyInventoryTrigger();
      component.m_Item = item?.Reference ?? component.m_Item;
      if (component.m_Item is null)
      {
        component.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      component.OnAddActions = onAddActions?.Build() ?? component.OnAddActions;
      if (component.OnAddActions is null)
      {
        component.OnAddActions = Utils.Constants.Empty.Actions;
      }
      component.OnRemoveActions = onRemoveActions?.Build() ?? component.OnRemoveActions;
      if (component.OnRemoveActions is null)
      {
        component.OnRemoveActions = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PerceptionTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlushinyrraLowerCity_DefaultEtude</term><description>deecc937a263ca24c9f1a64a4874451a</description></item>
    /// <item><term>DLC6_RobberyEvent2ndStage</term><description>d28f1276a9b34a6589c8ef25e798027b</description></item>
    /// <item><term>TempleOfDelamereBefore</term><description>4af827231749d094fb76d4a1419ef06e</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPerceptionTrigger(
        MapObjectEvaluator? mapObject = null,
        ActionsBuilder? onSpotted = null,
        UnitEvaluator? unit = null)
    {
      var component = new PerceptionTrigger();
      Validate(mapObject);
      component.MapObject = mapObject ?? component.MapObject;
      component.OnSpotted = onSpotted?.Build() ?? component.OnSpotted;
      if (component.OnSpotted is null)
      {
        component.OnSpotted = Utils.Constants.Empty.Actions;
      }
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>26!_SadisticGD_Checker_restTrigger</term><description>7bc48a5ec7e240e1a059148777166ba7</description></item>
    /// <item><term>DLC2_Sv_Catcmb_RstOutOn</term><description>85754732aed2470a8ed7a296166ac66c</description></item>
    /// <item><term>WenduagRomance_BarksAfterSexRepeat</term><description>e3049ea03e2f80a42b5b2dab02c75e78</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRestTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? once = null,
        RestResult? restResults = null)
    {
      var component = new RestTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.Once = once ?? component.Once;
      component.RestResults = restResults ?? component.RestResults;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ScriptZoneTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/ScriptZoneTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BeforeFirstKTC</term><description>876af4d8747694948ab3444e2a569e26</description></item>
    /// <item><term>LowerCity_RoofColliders</term><description>7c416484d1dd47c1967fed80874ea60d</description></item>
    /// <item><term>ScriptZoneChecker</term><description>2ae8987c666b2a44ab859e6e22c0b76c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddScriptZoneTrigger(
        ActionsBuilder? onEnterActions = null,
        ConditionsBuilder? onEnterConditions = null,
        ActionsBuilder? onExitActions = null,
        ConditionsBuilder? onExitConditions = null,
        EntityReference? scriptZone = null,
        string? unitRef = null)
    {
      var component = new ScriptZoneTrigger();
      component.OnEnterActions = onEnterActions?.Build() ?? component.OnEnterActions;
      if (component.OnEnterActions is null)
      {
        component.OnEnterActions = Utils.Constants.Empty.Actions;
      }
      component.OnEnterConditions = onEnterConditions?.Build() ?? component.OnEnterConditions;
      if (component.OnEnterConditions is null)
      {
        component.OnEnterConditions = Utils.Constants.Empty.Conditions;
      }
      component.OnExitActions = onExitActions?.Build() ?? component.OnExitActions;
      if (component.OnExitActions is null)
      {
        component.OnExitActions = Utils.Constants.Empty.Actions;
      }
      component.OnExitConditions = onExitConditions?.Build() ?? component.OnExitConditions;
      if (component.OnExitConditions is null)
      {
        component.OnExitConditions = Utils.Constants.Empty.Conditions;
      }
      Validate(scriptZone);
      component.ScriptZone = scriptZone ?? component.ScriptZone;
      component.UnitRef = unitRef ?? component.UnitRef;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpawnUnitTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/SpawnUnit Trigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>IrabethEncouragedByDemon</term><description>b4f08736cf124ae4996fcef7c0a33bf1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="targetUnit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSpawnUnitTrigger(
        ActionsBuilder? actions = null,
        Blueprint<BlueprintUnitReference>? targetUnit = null)
    {
      var component = new SpawnUnitTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.m_TargetUnit = targetUnit?.Reference ?? component.m_TargetUnit;
      if (component.m_TargetUnit is null)
      {
        component.m_TargetUnit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellCastTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AltarDamage_Actions</term><description>35995aa895b843ab9c2d75d3a158487e</description></item>
    /// <item><term>DLC5_PoS_LanternBuff</term><description>05142ccf08ac496cb72f6498cccfa37d</description></item>
    /// <item><term>TreeEncounter</term><description>29794c25836b4120920ede5f68042b73</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spells">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSpellCastTrigger(
        ActionsBuilder? actions = null,
        EntityReference? scriptZone = null,
        List<Blueprint<BlueprintAbilityReference>>? spells = null)
    {
      var component = new SpellCastTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      Validate(scriptZone);
      component.ScriptZone = scriptZone ?? component.ScriptZone;
      component.m_Spells = spells?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Spells;
      if (component.m_Spells is null)
      {
        component.m_Spells = new BlueprintAbilityReference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/SummonPoolTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1ArenaCombat</term><description>8e64ed1e12bc30c498402e99c95e75e3</description></item>
    /// <item><term>DLC6_KenabresForSwarm</term><description>8028479b2d1c491e9f18ac2198f459f7</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSummonPoolTrigger(
        ActionsBuilder? actions = null,
        SummonPoolTrigger.ChangeTypes? changeType = null,
        ConditionsBuilder? conditions = null,
        int? count = null,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null)
    {
      var component = new SummonPoolTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.ChangeType = changeType ?? component.ChangeType;
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.Count = count ?? component.Count;
      component.m_SummonPool = summonPool?.Reference ?? component.m_SummonPool;
      if (component.m_SummonPool is null)
      {
        component.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TimeOfDayChangedTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ3Scene_DayTime</term><description>ffb3b99adfa368444b4a46ea36e5aec9</description></item>
    /// <item><term>DarkLurkerBladeFromShadowsFeature</term><description>d8bbc2750a7349eeb54b4cb97dc8e796</description></item>
    /// <item><term>UlbrigRomance_GardenGods_LightState02</term><description>da1d94ab114f4c78985ca7d5b7f0fd09</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTimeOfDayChangedTrigger(
        ActionsBuilder? actions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TimeOfDayChangedTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UIEventTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>OpenInventoryCheck</term><description>7a88e35c5ebea944291aca62e00d4a81</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddUIEventTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        UIEventType? eventType = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new UIEventTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.EventType = eventType ?? component.EventType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UnitHealthTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/UnitHealthTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Balor_save_health</term><description>ad452511a21544c384af7d640ceb105b</description></item>
    /// <item><term>DarkBalorFight_HideUnits</term><description>5bc605a8f4624ec08d857dcc52378eb5</description></item>
    /// <item><term>ReturnToDrezen</term><description>eb0d42923a0cf6c4281b0925337e8591</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="unit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddUnitHealthTrigger(
        ActionsBuilder? actions = null,
        int? percentage = null,
        Blueprint<BlueprintUnitReference>? unit = null)
    {
      var component = new UnitHealthTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Percentage = percentage ?? component.Percentage;
      component.m_Unit = unit?.Reference ?? component.m_Unit;
      if (component.m_Unit is null)
      {
        component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TrapTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MidnightFane_SecretChamberAvailable</term><description>e624697cc856bab4dab7ebab6ee3beca</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTrapTrigger(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ActionsBuilder? onActivation = null,
        ActionsBuilder? onDisarm = null,
        MapObjectEvaluator? trap = null)
    {
      var component = new TrapTrigger();
      component.OnActivation = onActivation?.Build() ?? component.OnActivation;
      if (component.OnActivation is null)
      {
        component.OnActivation = Utils.Constants.Empty.Actions;
      }
      component.OnDisarm = onDisarm?.Build() ?? component.OnDisarm;
      if (component.OnDisarm is null)
      {
        component.OnDisarm = Utils.Constants.Empty.Actions;
      }
      Validate(trap);
      component.Trap = trap ?? component.Trap;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="VendorDealTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_MythSell</term><description>512298ca57a94c7b90d27ccce57aa103</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="item">
    /// <para>
    /// InfoBox: If empty, triggers for any operation
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="vendor">
    /// <para>
    /// InfoBox: If empty, triggers for any vendor
    /// </para>
    /// </param>
    public TBuilder AddVendorDealTrigger(
        ActionsBuilder? actions = null,
        VendorDealTrigger.DealType? dealTriggerType = null,
        Blueprint<BlueprintItemReference>? item = null,
        UnitEvaluator? vendor = null)
    {
      var component = new VendorDealTrigger();
      component.m_Actions = actions?.Build() ?? component.m_Actions;
      if (component.m_Actions is null)
      {
        component.m_Actions = Utils.Constants.Empty.Actions;
      }
      component.m_DealTriggerType = dealTriggerType ?? component.m_DealTriggerType;
      component.m_Item = item?.Reference ?? component.m_Item;
      if (component.m_Item is null)
      {
        component.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      Validate(vendor);
      component.m_Vendor = vendor ?? component.m_Vendor;
      return AddComponent(component);
    }
  }
}

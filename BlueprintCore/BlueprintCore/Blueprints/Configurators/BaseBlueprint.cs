//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Controllers.Rest;
using Kingmaker.Corruption;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.Designers.Mechanics.Enums;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.DLC;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Flags;
using Kingmaker.PubSubSystem;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist;
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
    protected BaseBlueprintConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="AllowOnZoneSettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Trader_Desert</term><description>fbe119150585526469ae85a3aff8094d</description></item>
    /// <item><term>Trader_Karelia</term><description>70e1898c5d62e2b47bba99330f447660</description></item>
    /// <item><term>Trader_Winter</term><description>ac97038913a452d4789e11f4c3eedc66</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAllowOnZoneSettings(
        GlobalMapZone[]? allowedNaturalSettings = null)
    {
      var component = new AllowOnZoneSettings();
      component.m_AllowedNaturalSettings = allowedNaturalSettings ?? component.m_AllowedNaturalSettings;
      if (component.m_AllowedNaturalSettings is null)
      {
        component.m_AllowedNaturalSettings = new GlobalMapZone[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RE_KareliaCanyon</term><description>03fca664fc43fb040aae42bb0f41c23c</description></item>
    /// <item><term>RE_SarkorisDisaster_2</term><description>c7125176689d3814199266e2ad2c3077</description></item>
    /// <item><term>RE_WoundedForest</term><description>da702e8d79c6046439c17e7e9cbfd758</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="defaultEnterPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="goodAvoidanceEnterPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCombatRandomEncounterAreaSettings(
        GlobalMapZone[]? allowedNaturalSettings = null,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? defaultEnterPoint = null,
        CombatRandomEncounterAreaSettings.Formation[]? formations = null,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? goodAvoidanceEnterPoint = null)
    {
      var component = new CombatRandomEncounterAreaSettings();
      component.AllowedNaturalSettings = allowedNaturalSettings ?? component.AllowedNaturalSettings;
      if (component.AllowedNaturalSettings is null)
      {
        component.AllowedNaturalSettings = new GlobalMapZone[0];
      }
      component.m_DefaultEnterPoint = defaultEnterPoint?.Reference ?? component.m_DefaultEnterPoint;
      if (component.m_DefaultEnterPoint is null)
      {
        component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      foreach (var item in formations) { Validate(item); }
      component.Formations = formations ?? component.Formations;
      if (component.Formations is null)
      {
        component.Formations = new CombatRandomEncounterAreaSettings.Formation[0];
      }
      component.m_GoodAvoidanceEnterPoint = goodAvoidanceEnterPoint?.Reference ?? component.m_GoodAvoidanceEnterPoint;
      if (component.m_GoodAvoidanceEnterPoint is null)
      {
        component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      return AddComponent(component);
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
    /// <item><term>AnimalCompanionFeatureTriceratops_PreorderBonus</term><description>52c854f77105445a9457572ab5826c00</description></item>
    /// <item><term>HalflingMaleTank</term><description>ef5d1d38805e4a51b06f217135d5b7ab</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddDlcCondition(
        Blueprint<BlueprintDlcReward, BlueprintDlcRewardReference>? dlcReward = null,
        bool? hideInstead = null)
    {
      var component = new DlcCondition();
      component.m_DlcReward = dlcReward?.Reference ?? component.m_DlcReward;
      if (component.m_DlcReward is null)
      {
        component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(null);
      }
      component.m_HideInstead = hideInstead ?? component.m_HideInstead;
      return AddComponent(component);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddBuffOnCorruptionClear(
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        int? targetBuffRank = null)
    {
      var component = new AddBuffOnCorruptionClear();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_TargetBuffRank = targetBuffRank ?? component.m_TargetBuffRank;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ComponentsList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GibberingSwarmCave</term><description>d663f351f18b27846a30970a635a73fa</description></item>
    /// <item><term>LostChapel</term><description>2183cc056a7b5d647ad475c8bc6c2074</description></item>
    /// <item><term>Wintersun_Default</term><description>87839550c801db944b102f61084fd245</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="list">
    /// <para>
    /// Blueprint of type BlueprintComponentList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddComponentsList(
        Blueprint<BlueprintComponentList, BlueprintComponentListReference>? list = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new ComponentsList();
      component.m_List = list?.Reference ?? component.m_List;
      if (component.m_List is null)
      {
        component.m_List = BlueprintTool.GetRef<BlueprintComponentListReference>(null);
      }
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
    public TBuilder AddPlayerLeaveCombatTrigger(
        ActionsBuilder? actions = null)
    {
      var component = new AddPlayerLeaveCombatTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeVendorPrices"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC2_Millorn</term><description>3b91296c7ae04a1391dfe972ce1e3eaf</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddChangeVendorPrices(
        Dictionary<BlueprintItem,long>? itemsToBuyCosts = null,
        Dictionary<BlueprintItem,long>? itemsToSellCosts = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        ChangeVendorPrices.Entry[]? priceOverrides = null)
    {
      var component = new ChangeVendorPrices();
      Validate(itemsToBuyCosts);
      component.m_ItemsToBuyCosts = itemsToBuyCosts ?? component.m_ItemsToBuyCosts;
      Validate(itemsToSellCosts);
      component.m_ItemsToSellCosts = itemsToSellCosts ?? component.m_ItemsToSellCosts;
      foreach (var item in priceOverrides) { Validate(item); }
      component.m_PriceOverrides = priceOverrides ?? component.m_PriceOverrides;
      if (component.m_PriceOverrides is null)
      {
        component.m_PriceOverrides = new ChangeVendorPrices.Entry[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityAcceptBurnOnCast"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AerialEvasionAbility</term><description>41281aa38b6b27f4fa3a05c97cc01783</description></item>
    /// <item><term>SearingFleshAbility</term><description>04a61f1221b79a742912cfd847b65911</description></item>
    /// <item><term>ShroudOFWaterUpgradeAbility</term><description>84d77a1c06b800545aacd91210d3505c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityAcceptBurnOnCast(
        int? burnValue = null)
    {
      var component = new AbilityAcceptBurnOnCast();
      component.BurnValue = burnValue ?? component.BurnValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactContextActions"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>GreaterMutagenStrengthDexterityBuff</term><description>a42c49fcb081bd1469679e4f515732c8</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningFeature</term><description>0faee0a55f634902895b4e1faf828502</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddFactContextActions(
        ActionsBuilder? activated = null,
        ActionsBuilder? deactivated = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        ActionsBuilder? newRound = null)
    {
      var component = new AddFactContextActions();
      component.Activated = activated?.Build() ?? component.Activated;
      if (component.Activated is null)
      {
        component.Activated = Utils.Constants.Empty.Actions;
      }
      component.Deactivated = deactivated?.Build() ?? component.Deactivated;
      if (component.Deactivated is null)
      {
        component.Deactivated = Utils.Constants.Empty.Actions;
      }
      component.NewRound = newRound?.Build() ?? component.NewRound;
      if (component.NewRound is null)
      {
        component.NewRound = Utils.Constants.Empty.Actions;
      }
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
    /// <item><term>ArcaneEnforcerEnchantment</term><description>c61988ac4121223468471c301da4709f</description></item>
    /// <item><term>LilituTailBrandingEnchantment</term><description>f8e64fbcff0d14a4a8f3b4122bb90c08</description></item>
    /// <item><term>WightEnergyDrainAbility</term><description>35a7f7e6ad5b4374e812fc10ec1c836c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddInitiatorAttackRollTrigger(
        ActionsBuilder? action = null,
        bool? affectFriendlyTouchSpells = null,
        bool? checkWeapon = null,
        bool? criticalHit = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? onlyHit = null,
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
      component.OnOwner = onOwner ?? component.OnOwner;
      component.SneakAttack = sneakAttack ?? component.SneakAttack;
      component.WeaponCategory = weaponCategory ?? component.WeaponCategory;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>HeavyFlailOfWeaknessEnchantment</term><description>13de9078d1d11a643a8f63a3838923d0</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningFeature</term><description>0faee0a55f634902895b4e1faf828502</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="weaponType">
    /// <para>
    /// Blueprint of type BlueprintWeaponType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddInitiatorAttackWithWeaponTrigger(
        ActionsBuilder? action = null,
        bool? actionsOnInitiator = null,
        bool? allNaturalAndUnarmed = null,
        WeaponCategory? category = null,
        bool? checkDistance = null,
        bool? checkWeaponCategory = null,
        bool? checkWeaponGroup = null,
        bool? checkWeaponRangeType = null,
        bool? criticalHit = null,
        bool? damageMoreTargetMaxHP = null,
        Feet? distanceLessEqual = null,
        bool? duelistWeapon = null,
        WeaponFighterGroup? group = null,
        bool? ignoreAutoHit = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? notCriticalHit = null,
        bool? notExtraAttack = null,
        bool? notSneakAttack = null,
        bool? onAttackOfOpportunity = null,
        bool? onCharge = null,
        bool? onlyHit = null,
        bool? onlyOnFirstAttack = null,
        bool? onlyOnFirstHit = null,
        bool? onlyOnFullAttack = null,
        bool? onlySneakAttack = null,
        bool? onMiss = null,
        WeaponRangeType? rangeType = null,
        bool? reduceHPToZero = null,
        bool? waitForAttackResolve = null,
        Blueprint<BlueprintWeaponType, BlueprintWeaponTypeReference>? weaponType = null)
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
      component.CheckWeaponCategory = checkWeaponCategory ?? component.CheckWeaponCategory;
      component.CheckWeaponGroup = checkWeaponGroup ?? component.CheckWeaponGroup;
      component.CheckWeaponRangeType = checkWeaponRangeType ?? component.CheckWeaponRangeType;
      component.CriticalHit = criticalHit ?? component.CriticalHit;
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
      component.OnlyOnFirstAttack = onlyOnFirstAttack ?? component.OnlyOnFirstAttack;
      component.OnlyOnFirstHit = onlyOnFirstHit ?? component.OnlyOnFirstHit;
      component.OnlyOnFullAttack = onlyOnFullAttack ?? component.OnlyOnFullAttack;
      component.OnlySneakAttack = onlySneakAttack ?? component.OnlySneakAttack;
      component.OnMiss = onMiss ?? component.OnMiss;
      component.RangeType = rangeType ?? component.RangeType;
      component.ReduceHPToZero = reduceHPToZero ?? component.ReduceHPToZero;
      component.WaitForAttackResolve = waitForAttackResolve ?? component.WaitForAttackResolve;
      component.m_WeaponType = weaponType?.Reference ?? component.m_WeaponType;
      if (component.m_WeaponType is null)
      {
        component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>HelmOfBattleAlertnessFeature</term><description>537b6c1a95e308048a5a15a39d6ecb43</description></item>
    /// <item><term>WindsOfVengeanceBuff</term><description>796a2fe600e5ead41b29cd9963cf2de9</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddTargetAttackRollTrigger(
        ActionsBuilder? actionOnSelf = null,
        ActionsBuilder? actionsOnAttacker = null,
        bool? affectFriendlyTouchSpells = null,
        WeaponCategory[]? categories = null,
        bool? checkCategory = null,
        bool? criticalHit = null,
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
      component.Not = not ?? component.Not;
      component.NotReach = notReach ?? component.NotReach;
      component.OnlyHit = onlyHit ?? component.OnlyHit;
      component.OnlyMelee = onlyMelee ?? component.OnlyMelee;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetBeforeAttackRollTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ShamanHexProtectiveLuckBuff</term><description>9e7a13c71f6be1749af81afc57640ccf</description></item>
    /// <item><term>WitchHexProtectiveLuckBuff</term><description>1ba3d3a0942d080448ce6aa865bbbd65</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddTargetBeforeAttackRollTrigger(
        ActionsBuilder? actionOnSelf = null,
        ActionsBuilder? actionsOnAttacker = null,
        bool? checkDescriptor = null,
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
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDiceOnAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonGreaterBaneBuff</term><description>cdcc13884252b2c4d8dac57cb5f46555</description></item>
    /// <item><term>GoodBlessingMinorBuff</term><description>4b55c23d11a140949be65293ad9f75a4</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningAllyBuff</term><description>02680be495534b629d543daa89b47079</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AdditionalDiceOnAttack(
        bool? allNaturalAndUnarmed = null,
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
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
        ContextDiceValue? value = null,
        Blueprint<BlueprintWeaponType, BlueprintWeaponTypeReference>? weaponType = null)
    {
      var component = new AdditionalDiceOnAttack();
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed ?? component.AllNaturalAndUnarmed;
      component.AttackType = attackType ?? component.AttackType;
      component.Category = category ?? component.Category;
      component.CheckDistance = checkDistance ?? component.CheckDistance;
      component.CheckWeaponCategory = checkWeaponCategory ?? component.CheckWeaponCategory;
      component.CheckWeaponGroup = checkWeaponGroup ?? component.CheckWeaponGroup;
      component.CheckWeaponRangeType = checkWeaponRangeType ?? component.CheckWeaponRangeType;
      component.CriticalHit = criticalHit ?? component.CriticalHit;
      foreach (var item in damageEntries) { Validate(item); }
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>TwoHandedFighterOverhandChop</term><description>ad4d4db6bb9c75a4a9bc59174b948769</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AdditionalStatBonusOnAttackDamage(
        float? bonus = null,
        WeaponCategory? category = null,
        bool? checkCategory = null,
        bool? checkTwoHanded = null,
        ConditionEnum? firstAttack = null,
        ConditionEnum? fullAttack = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AdditionalStatBonusOnAttackDamage();
      component.Bonus = bonus ?? component.Bonus;
      component.Category = category ?? component.Category;
      component.CheckCategory = checkCategory ?? component.CheckCategory;
      component.CheckTwoHanded = checkTwoHanded ?? component.CheckTwoHanded;
      component.FirstAttack = firstAttack ?? component.FirstAttack;
      component.FullAttack = fullAttack ?? component.FullAttack;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>Marilith_Feature_InfuseWeapon</term><description>fc79f20cf9a63fb43a0239f5be732793</description></item>
    /// <item><term>RingOfEnhancedSummonsBuff</term><description>f4b35376b1021c74ea90abc40df55628</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddAllAttacksEnhancement(
        int? bonus = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AllAttacksEnhancement();
      component.Bonus = bonus ?? component.Bonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BashingFinish"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BashingFinish</term><description>0b442a7b4aa598d4e912a4ecee0500ff</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddBashingFinish(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new BashingFinish();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DestructiveShockwave"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DestructiveShockwaveMythicFeat</term><description>263a65c1e92dd964192ba7d41a76b4e3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddDestructiveShockwave(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new DestructiveShockwave();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ShieldMaster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ShieldMaster</term><description>dbec636d84482944f87435bd31522fcc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddShieldMaster(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new ShieldMaster();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityAoERadius"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidFog</term><description>dbf99b00cd35d0a4491c6cc9e771b487</description></item>
    /// <item><term>HungryPit</term><description>f63f4d1806b78604a952b3958892ce1c</description></item>
    /// <item><term>ZoneOfPredetermination</term><description>756f1d07f9ae29448888ecf016fa40a7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="diameterInCells">
    /// <para>
    /// InfoBox: For now only odd diameters can be used. 1 -> 1 cell, 3 -> 9 cells, ...
    /// </para>
    /// </param>
    public TBuilder AddAbilityAoERadius(
        bool? canBeUsedInTacticalCombat = null,
        int? diameterInCells = null,
        Feet? radius = null,
        Kingmaker.UnitLogic.Abilities.Components.TargetType? targetType = null)
    {
      var component = new AbilityAoERadius();
      component.m_CanBeUsedInTacticalCombat = canBeUsedInTacticalCombat ?? component.m_CanBeUsedInTacticalCombat;
      component.m_DiameterInCells = diameterInCells ?? component.m_DiameterInCells;
      component.m_Radius = radius ?? component.m_Radius;
      component.m_TargetType = targetType ?? component.m_TargetType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityMagusSpellRecallCostCalculator"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MagusSpellRecall</term><description>1bd76e00b6e056d42a8ecc1031dd43b4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="improvedFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityMagusSpellRecallCostCalculator(
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? improvedFeature = null)
    {
      var component = new AbilityMagusSpellRecallCostCalculator();
      component.m_ImprovedFeature = improvedFeature?.Reference ?? component.m_ImprovedFeature;
      if (component.m_ImprovedFeature is null)
      {
        component.m_ImprovedFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityUseOnRest"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelBringBackCast</term><description>eb0d3e22826725d4199a3aac0db0ad50</description></item>
    /// <item><term>InflictLightWoundsMass</term><description>9da37873d79ef0a468f969e4e5116ad2</description></item>
    /// <item><term>WitchDoctorChannelEnergy</term><description>d470eb6b3b31fde4bb44ec753de0b862</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="baseValue">
    /// <para>
    /// InfoBox: `Approximated minimum` that would be used in Rest days count calculations
    /// </para>
    /// </param>
    public TBuilder AddAbilityUseOnRest(
        bool? addCasterLevel = null,
        int? baseValue = null,
        int? maxCasterLevel = null,
        bool? multiplyByCasterLevel = null,
        AbilityUseOnRestType? type = null)
    {
      var component = new AbilityUseOnRest();
      component.AddCasterLevel = addCasterLevel ?? component.AddCasterLevel;
      component.BaseValue = baseValue ?? component.BaseValue;
      component.MaxCasterLevel = maxCasterLevel ?? component.MaxCasterLevel;
      component.MultiplyByCasterLevel = multiplyByCasterLevel ?? component.MultiplyByCasterLevel;
      component.Type = type ?? component.Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetCellsRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel3SummonHeavenlyHostAbility</term><description>f317d44314a843e7aaf3fc202cbe9577</description></item>
    /// <item><term>ArmySummonSchir</term><description>4212e78cab304071801f7cb6e9accc48</description></item>
    /// <item><term>SummonSquad</term><description>6fd4d245dd129af45a802dedff113c0d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="allowedColumns">
    /// <para>
    /// InfoBox: Keep empty to allow all cells
    /// </para>
    /// </param>
    /// <param name="factionDependent">
    /// <para>
    /// InfoBox: If True, 0 column means left for Crusaders and right for Demons
    /// </para>
    /// </param>
    public TBuilder AddAbilityTargetCellsRestriction(
        List<int>? allowedColumns = null,
        int? diameter = null,
        bool? factionDependent = null,
        bool? onlyEmptyCells = null)
    {
      var component = new AbilityTargetCellsRestriction();
      component.m_AllowedColumns = allowedColumns ?? component.m_AllowedColumns;
      if (component.m_AllowedColumns is null)
      {
        component.m_AllowedColumns = new();
      }
      component.m_Diameter = diameter ?? component.m_Diameter;
      component.m_FactionDependent = factionDependent ?? component.m_FactionDependent;
      component.m_OnlyEmptyCells = onlyEmptyCells ?? component.m_OnlyEmptyCells;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineElementalWaterElementalMovementFeature</term><description>737ef897849327b45b88b83a797918c8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddAbilityTargetHasCondition(
        UnitCondition? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? not = null)
    {
      var component = new AbilityTargetHasCondition();
      component.Condition = condition ?? component.Condition;
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasConditionOrBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CoupDeGraceAbility</term><description>32280b137ca642c45be17e2d92898758</description></item>
    /// <item><term>ExecutionerAssassinateAbility</term><description>3dad7f131aa884f4c972f2fb759d0df4</description></item>
    /// <item><term>RepurposeForcedEnd</term><description>9520c680f8584c3b8c165fae9f05278d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buffs">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityTargetHasConditionOrBuff(
        List<Blueprint<BlueprintBuff, BlueprintBuffReference>>? buffs = null,
        UnitCondition? condition = null,
        bool? not = null)
    {
      var component = new AbilityTargetHasConditionOrBuff();
      component.m_Buffs = buffs?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Buffs;
      if (component.m_Buffs is null)
      {
        component.m_Buffs = new BlueprintBuffReference[0];
      }
      component.Condition = condition ?? component.Condition;
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasOneOfConditionsOrHP"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodDrinkerAbility</term><description>be35623d2c561c649b98a1794216e9f9</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetHasOneOfConditionsOrHP(
        UnitCondition[]? condition = null,
        int? currentHPLessThan = null,
        bool? invertedHP = null,
        bool? needHPCondition = null)
    {
      var component = new AbilityTargetHasOneOfConditionsOrHP();
      component.Condition = condition ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = new UnitCondition[0];
      }
      component.CurrentHPLessThan = currentHPLessThan ?? component.CurrentHPLessThan;
      component.InvertedHP = invertedHP ?? component.InvertedHP;
      component.NeedHPCondition = needHPCondition ?? component.NeedHPCondition;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAnimalCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EmergencySwapAbility</term><description>b50ca9b5d6292fb42b8eab8e5d64842d</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetIsAnimalCompanion(
        bool? not = null)
    {
      var component = new AbilityTargetIsAnimalCompanion();
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsSuitableMount"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MountTargetAbility</term><description>9f8c0f4fcabdb3145b449826d17da18d</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetIsSuitableMount()
    {
      return AddComponent(new AbilityTargetIsSuitableMount());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsSuitableMountSize"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MountTargetAbility</term><description>9f8c0f4fcabdb3145b449826d17da18d</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetIsSuitableMountSize()
    {
      return AddComponent(new AbilityTargetIsSuitableMountSize());
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetRangeRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EmergencySwapAbility</term><description>b50ca9b5d6292fb42b8eab8e5d64842d</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetRangeRestriction(
        CompareOperation.Type? compareType = null,
        Feet? distance = null)
    {
      var component = new AbilityTargetRangeRestriction();
      component.CompareType = compareType ?? component.CompareType;
      component.Distance = distance ?? component.Distance;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="demonArmies">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddArmyBattleResultsTrigger(
        RegionId? assignedRegion = null,
        Blueprint<BlueprintArmyLeader, BlueprintArmyLeaderReference>? crusadeLeader = null,
        List<Blueprint<BlueprintArmyPreset, BlueprintArmyPresetReference>>? demonArmies = null,
        ArmyType? demonsArmyType = null,
        bool? demonsFromList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>FlagLogistics5FinancesAndMaterialsForRegions</term><description>5d797794119f4a9b8901d3c52f7ff415</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="regions">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddKingdomRegionClaimedTrigger(
        ActionsBuilder? actions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        List<Blueprint<BlueprintRegion, BlueprintRegionReference>>? regions = null)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSettlementSiegeTrigger(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        ActionsBuilder? onSettlementDestroyed = null,
        ActionsBuilder? onSiegeEnd = null,
        ActionsBuilder? onSiegeStart = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPointReference>? settlementLocation = null,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddArmyUnitRecruitedTrigger(
        ActionsBuilder? action = null,
        ArmyProperties? armyTag = null,
        List<Blueprint<BlueprintUnit, BlueprintUnitReference>>? armyUnits = null,
        bool? byTag = null,
        bool? byUnits = null,
        MercenariesIncludeOption? mercenariesFilter = null,
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
      return AddComponent(component);
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
    public TBuilder AddLeaderRecruitedTrigger(
        ActionsBuilder? action = null)
    {
      var component = new LeaderRecruitedTrigger();
      component.m_Action = action?.Build() ?? component.m_Action;
      if (component.m_Action is null)
      {
        component.m_Action = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
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
    public TBuilder AddSummonUnitsAfterArmyBattle(
        SummonUnitsAfterArmyBattle.SummonGroup[]? groups = null)
    {
      var component = new SummonUnitsAfterArmyBattle();
      foreach (var item in groups) { Validate(item); }
      component.m_Groups = groups ?? component.m_Groups;
      if (component.m_Groups is null)
      {
        component.m_Groups = new SummonUnitsAfterArmyBattle.SummonGroup[0];
      }
      return AddComponent(component);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddGarrisonDefeatedTrigger(
        ActionsBuilder? actions = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPlayerVisitGlobalMapLocationTrigger(
        ActionsBuilder? actions = null,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddOnIsleStateEnterTrigger(
        ActionsBuilder? actions = null,
        IsleEvaluator? isleEvaluator = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="OnIsleStateExitTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MediumCity_FlyingIslesControls_Etude</term><description>fa16edfae00b94048a71bab6ef5463d4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddOnIsleStateExitTrigger(
        ActionsBuilder? actions = null,
        IsleEvaluator? isleEvaluator = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>SecondaryElementEarth</term><description>956b65effbf37e5419c13100ab4385a3</description></item>
    /// <item><term>WarCamp_DefaultPeaceful_Lann</term><description>c82f78f0f7fee3c40a7d1164d202bebd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddActivateTrigger(
        ActionsBuilder? actions = null,
        bool? alsoOnAreaLoad = null,
        ConditionsBuilder? conditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AreaDidLoadTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonEyeEnemyVisualBuff</term><description>9815f77129674e8e886de2d458ecdf49</description></item>
    /// <item><term>DLC2_Sv_Bureaucrat_DeadBody</term><description>fbb763a4fb6c4df99b79b48b8c5682ef</description></item>
    /// <item><term>InvitedToWedding</term><description>d239b8b2e21331942a1a042b97d0082d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddAreaDidLoadTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>KTC_Prelate_Hulrun_Notification</term><description>5ec3719a546abce46bfbf05735a48e14</description></item>
    /// <item><term>ZigguratZachariusInZiggurat</term><description>2844d387f27a0bb468f72603dd15eda2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddDeactivateTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddDeviceInteractionTrigger(
        ActionsBuilder? actions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>ActivatingSwordOfValor</term><description>071f4953d481d5242b250b1aa7482dce</description></item>
    /// <item><term>Graveyard_NecromancerAgro</term><description>b15e78180db744dda43defca0f63f08d</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddEvaluatedUnitCombatTrigger(
        ActionsBuilder? actions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>DrezenDefaultAreaMechanic</term><description>53e461cc1c808b546a7df90e671631d8</description></item>
    /// <item><term>XantirLastCombat</term><description>a885b376ef17bdf4aa1ae37ac6e911f3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddEvaluatedUnitDeathTrigger(
        ActionsBuilder? actions = null,
        bool? anyUnit = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>GrayGarrison_FinalSiege_3rdFloor_Etude</term><description>d758d6194e2dde84b917778fd1c449af</description></item>
    /// <item><term>ZachariusEnemyInZiggurat</term><description>63cc30e6086ce1842997d0924677019c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddEvaluatedUnitHealthTrigger(
        ActionsBuilder? actions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddGenericInteractionTrigger(
        ActionsBuilder? actions = null,
        EntityReference? mapObject = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        ActionsBuilder? restrictedActions = null)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>DLC1_AreeluHouse_Vasetems</term><description>44188a0218e145e28b5a424ba97a025f</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
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
        Blueprint<BlueprintItem, BlueprintItemReference>? itemToCheck = null,
        MapObjectEvaluator? mapObject = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>DLC1_Levelup</term><description>dca1299c933b43dd8078cdf078ee6121</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddLevelUpTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        UnitEvaluator? unit = null)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>Kaylessa_Warcamp_NotesPickedUp</term><description>41ec608edfa94ebf98ef5c927af8167f</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPartyInventoryTrigger(
        Blueprint<BlueprintItem, BlueprintItemReference>? item = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>DrezenCitadel_Level2_MainEtude</term><description>bd1644e2ffad4e344a1ea59f4d309baf</description></item>
    /// <item><term>TempleOfDelamereBefore</term><description>4af827231749d094fb76d4a1419ef06e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPerceptionTrigger(
        MapObjectEvaluator? mapObject = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>DLC2_Survive_RQ_RstIn_4</term><description>56b6d7b013134f7c952b86a748822783</description></item>
    /// <item><term>WenduagRomance_BarksAfterSexRepeat</term><description>e3049ea03e2f80a42b5b2dab02c75e78</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRestTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
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
      return AddComponent(component);
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
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddScriptZoneTrigger(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="targetUnit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSpawnUnitTrigger(
        ActionsBuilder? actions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? targetUnit = null)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SpellCastTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Barrel_explosion</term><description>8fdc96985bf749dfb5f8bd9085d4aeda</description></item>
    /// <item><term>FireDamage_Actions</term><description>209d33847e7d4a33a894f9de8350a9c1</description></item>
    /// <item><term>KenabresBurning_Default</term><description>ff99c02a1f792a545bc4eda7858cbaaf</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="spells">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSpellCastTrigger(
        ActionsBuilder? actions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        EntityReference? scriptZone = null,
        List<Blueprint<BlueprintAbility, BlueprintAbilityReference>>? spells = null)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>GS_Canyon</term><description>7cb9f9854971df340baf02fb35e35eee</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSummonPoolTrigger(
        ActionsBuilder? actions = null,
        SummonPoolTrigger.ChangeTypes? changeType = null,
        ConditionsBuilder? conditions = null,
        int? count = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>BodakLair_Default</term><description>759e37bb2e588aa428202cea1e19367b</description></item>
    /// <item><term>LC_Outdoor</term><description>163aad1de63fe1043acc8fb1143c9fd0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddTimeOfDayChangedTrigger(
        ActionsBuilder? actions = null)
    {
      var component = new TimeOfDayChangedTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
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
    public TBuilder AddUIEventTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        UIEventType? eventType = null)
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
      return AddComponent(component);
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
    /// <item><term>Battle_Agains_Chaos</term><description>cec8a8ac297b47adbb67d8ecaf78592f</description></item>
    /// <item><term>EstrodTower_Default</term><description>d770f2e5f96151d4e976195494a1188f</description></item>
    /// <item><term>ReturnToDrezen</term><description>eb0d42923a0cf6c4281b0925337e8591</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="unit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddUnitHealthTrigger(
        ActionsBuilder? actions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? percentage = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    public TBuilder AddTrapTrigger(
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
      return AddComponent(component);
    }
  }
}

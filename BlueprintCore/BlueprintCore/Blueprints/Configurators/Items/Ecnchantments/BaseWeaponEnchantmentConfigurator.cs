//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintWeaponEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseWeaponEnchantmentConfigurator<T, TBuilder>
    : BaseItemEnchantmentConfigurator<T, TBuilder>
    where T : BlueprintWeaponEnchantment
    where TBuilder : BaseWeaponEnchantmentConfigurator<T, TBuilder>
  {
    protected BaseWeaponEnchantmentConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintWeaponEnchantment>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.WeaponFxPrefab = copyFrom.WeaponFxPrefab;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintWeaponEnchantment>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.WeaponFxPrefab = copyFrom.WeaponFxPrefab;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponEnchantment.WeaponFxPrefab"/>
    /// </summary>
    ///
    /// <param name="weaponFxPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetWeaponFxPrefab(AssetLink<PrefabLink> weaponFxPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.WeaponFxPrefab = weaponFxPrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponEnchantment.WeaponFxPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWeaponFxPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.WeaponFxPrefab is null) { return; }
          action.Invoke(bp.WeaponFxPrefab);
        });
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnConfirmedCritFixed"/>
    /// </summary>
    public TBuilder AddWeaponBuffOnConfirmedCritFixed(WeaponBuffOnConfirmedCritFixed component)
    {
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalConfirmationBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Critical Confirmation Bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DeadlyTollEnchantment</term><description>86d9df91e8a31b046bdab6a9fa90209e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponCriticalConfirmationBonus(
        int? additionalBonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextValue? value = null)
    {
      var component = new WeaponCriticalConfirmationBonus();
      component.AdditionalBonus = additionalBonus ?? component.AdditionalBonus;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeIncrease"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Critical Edge Increase
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_DefacerWarhammerEnchantment</term><description>c3b2c58b5e794064b09c6b59308d301f</description></item>
    /// <item><term>LightningArrowsQuiverEnchantment</term><description>d0cab2c642c912245a5c35821db45d0e</description></item>
    /// <item><term>RovagugRelicScorpionEnchantment</term><description>08dfd84c0a80dfb48924a5f3800bbd2d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponCriticalEdgeIncrease(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponCriticalEdgeIncrease();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalEdgeStackable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Critical Edge Increase
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneEnforcerEnchantment</term><description>c61988ac4121223468471c301da4709f</description></item>
    /// <item><term>ImpendingDemiseEnchantment</term><description>0b6a0abc29774cffb56170d0f3ae2f8b</description></item>
    /// <item><term>VanquisherEnchantment</term><description>0b245c8943990304da76d2058d635787</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponCriticalEdgeStackable(
        int? bonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponCriticalEdgeStackable();
      component.Bonus = bonus ?? component.Bonus;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponCriticalMultiplierIncrease"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Critical Edge Increase
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AssassinsEdgeEnchantment</term><description>3bd1ae7c49dbf58489437f13f5d16ac5</description></item>
    /// <item><term>DLC4_ShifterMythicDemonBoss_cutscene</term><description>b3d2581373294a92b330b07493e613fb</description></item>
    /// <item><term>RustedDawnEnchantment</term><description>6c73603b691801e42ba82850cc96f85e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponCriticalMultiplierIncrease(
        int? additionalMultiplier = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponCriticalMultiplierIncrease();
      component.AdditionalMultiplier = additionalMultiplier ?? component.AdditionalMultiplier;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageMultiplierStatReplacement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Damage Multiplier and Stat Replacement
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RockThrowStrength</term><description>2a0859c4984fd2e428f9edb79c97d753</description></item>
    /// <item><term>StrengthComposite</term><description>c3209eb058d471548928a200d70765e0</description></item>
    /// <item><term>StrengthThrown</term><description>c4d213911e9616949937e1520c80aaf3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponDamageMultiplierStatReplacement(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? multiplier = null,
        StatType? stat = null)
    {
      var component = new WeaponDamageMultiplierStatReplacement();
      component.Multiplier = multiplier ?? component.Multiplier;
      component.Stat = stat ?? component.Stat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageStatReplacement"/>
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
    /// <item><term>Agile</term><description>a36ad92c51789b44fa8a1c5c116a1328</description></item>
    /// <item><term>MapPlaningBardicheEnchantment</term><description>47f2aca64ba035c44bf00b23aa2882ec</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponDamageStatReplacement(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? requiresFinesse = null,
        StatType? stat = null)
    {
      var component = new WeaponDamageStatReplacement();
      component.RequiresFinesse = requiresFinesse ?? component.RequiresFinesse;
      component.Stat = stat ?? component.Stat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponOversized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Masterwork is Oversized
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Oversized</term><description>d8e1ebc1062d8cc42abff78783856b0d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponOversized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponOversized();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealmentAgainstFactOwner"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Heartseeker</term><description>e252b26686ab66241afdf33f2adaead6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="facts">
    /// <para>
    /// InfoBox: If target has at least one of the fact - ignore concealment
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
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
    /// <param name="not">
    /// <para>
    /// InfoBox: If taget has at least one the the fact - DO NOT ignore concealment
    /// </para>
    /// </param>
    public TBuilder AddIgnoreConcealmentAgainstFactOwner(
        List<Blueprint<BlueprintUnitFactReference>>? facts = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? not = null)
    {
      var component = new IgnoreConcealmentAgainstFactOwner();
      component.m_Facts = facts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Facts;
      if (component.m_Facts is null)
      {
        component.m_Facts = new BlueprintUnitFactReference[0];
      }
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDREnchantment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Heartseeker</term><description>e252b26686ab66241afdf33f2adaead6</description></item>
    /// <item><term>TheBlitzCutEnchantmentNew</term><description>2c1a6294591b48ba86540a9d813a3edd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddIgnoreTargetDREnchantment(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new IgnoreTargetDREnchantment();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ImproveEnhancmentIfHasEnchantment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ReekingHeartOfArcaneEnchantment</term><description>5cd1d37cfb12488d8b03a16c096cc5be</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
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
    public TBuilder AddImproveEnhancmentIfHasEnchantment(
        List<Blueprint<BlueprintItemEnchantmentReference>>? enchantments = null,
        bool? isStackable = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ImproveEnhancmentIfHasEnchantment();
      component.m_Enchantments = enchantments?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Enchantments;
      if (component.m_Enchantments is null)
      {
        component.m_Enchantments = new BlueprintItemEnchantmentReference[0];
      }
      component.m_IsStackable = isStackable ?? component.m_IsStackable;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="IncreaseWeaponEnhancementBonusOnTargetFocus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Furyborn</term><description>091e2f6b2fad84a45ae76b8aac3c55c3</description></item>
    /// <item><term>HopeCrusherEnchantment</term><description>58a9830abcfb7b74492126fc52a8baf7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddIncreaseWeaponEnhancementBonusOnTargetFocus(
        ContextValue? bonusIncrementValue = null,
        int? currentEnhancementBonus = null,
        UnitReference? focusingTarget = null,
        bool? isStackable = null,
        ContextValue? maximumTotalEnhancementBonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new IncreaseWeaponEnhancementBonusOnTargetFocus();
      component.BonusIncrementValue = bonusIncrementValue ?? component.BonusIncrementValue;
      if (component.BonusIncrementValue is null)
      {
        component.BonusIncrementValue = ContextValues.Constant(0);
      }
      component.m_CurrentEnhancementBonus = currentEnhancementBonus ?? component.m_CurrentEnhancementBonus;
      component.m_FocusingTarget = focusingTarget ?? component.m_FocusingTarget;
      component.IsStackable = isStackable ?? component.IsStackable;
      component.MaximumTotalEnhancementBonus = maximumTotalEnhancementBonus ?? component.MaximumTotalEnhancementBonus;
      if (component.MaximumTotalEnhancementBonus is null)
      {
        component.MaximumTotalEnhancementBonus = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MissAgainstFactOwner"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Attacks ignore fact owners
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BrilliantEnergy</term><description>66e9e299c9002ea4bb65b6f300e43770</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="facts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
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
    public TBuilder AddMissAgainstFactOwner(
        List<Blueprint<BlueprintUnitFactReference>>? facts = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new MissAgainstFactOwner();
      component.m_Facts = facts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Facts;
      if (component.m_Facts is null)
      {
        component.m_Facts = new BlueprintUnitFactReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ChaoticAligned</term><description>5781c3a3255f5be4a9f94c6faf0ac0c3</description></item>
    /// <item><term>GoodAligned</term><description>326da486cd9077242a0e25df7eb7cd78</description></item>
    /// <item><term>LawfulAligned</term><description>76c7f6e9f0618a64fa21905687e36133</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponAlignment(
        DamageAlignment? alignment = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponAlignment();
      component.Alignment = alignment ?? component.Alignment;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponBuffOnAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buff on attacks
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NaturesWrathEnchantment</term><description>afa5d47f05724ac43a4dc19e5ecbd150</description></item>
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
    /// <param name="fx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponBuffOnAttack(
        Blueprint<BlueprintBuffReference>? buff = null,
        Rounds? duration = null,
        AssetLink<PrefabLink>? fx = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponBuffOnAttack();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.Duration = duration ?? component.Duration;
      component.Fx = fx?.Get() ?? component.Fx;
      if (component.Fx is null)
      {
        component.Fx = Utils.Constants.Empty.PrefabLink;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalDamageDice"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Bonus Damage Conditional
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdditionalPiercingDamage</term><description>5a6bac93089d3ec449f316d22826c5f4</description></item>
    /// <item><term>BaneUndead</term><description>eebb4d3f20b8caa43af1fed8f2773328</description></item>
    /// <item><term>WoundBearerNegative1d6</term><description>7f727c7023be4854babc44d3ee756d31</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponConditionalDamageDice(
        bool? checkWielder = null,
        ConditionsBuilder? conditions = null,
        DamageDescription? damage = null,
        bool? isBane = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponConditionalDamageDice();
      component.CheckWielder = checkWielder ?? component.CheckWielder;
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      Validate(damage);
      component.Damage = damage ?? component.Damage;
      component.IsBane = isBane ?? component.IsBane;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponConditionalEnhancementBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Conditional Enhancement Bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AgainstHelplessPlus2</term><description>2fa378b52d997da4e814af3c48d88d35</description></item>
    /// <item><term>BaneOutsiderEvil</term><description>20ba9055c6ae1e44ca270c03feacc53b</description></item>
    /// <item><term>SingingEdgeEnchantment</term><description>a3a40379e5950cf408d4bcf375072d26</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddWeaponConditionalEnhancementBonus(
        bool? checkWielder = null,
        ConditionsBuilder? conditions = null,
        int? enhancementBonus = null,
        bool? isBane = null)
    {
      var component = new WeaponConditionalEnhancementBonus();
      component.CheckWielder = checkWielder ?? component.CheckWielder;
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.EnhancementBonus = enhancementBonus ?? component.EnhancementBonus;
      component.IsBane = isBane ?? component.IsBane;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CritAutoconfirmAgainstEvil</term><description>8c381459747746341be72f7fa0112e10</description></item>
    /// <item><term>CrossbowOfJudgementEvilEnchantment</term><description>faa140906bc385e43bf4ecf2f6267c76</description></item>
    /// <item><term>GreatswordSunSwordWeaponEnchantment</term><description>41cbbcfcde784ddb9987660f57587742</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponCritAutoconfirmAgainstAlignment(
        AlignmentComponent? enemyAlignment = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponCritAutoconfirmAgainstAlignment();
      component.EnemyAlignment = enemyAlignment ?? component.EnemyAlignment;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponCritAutoconfirmAgainstSize"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_ButcheringGreataxeEnchantment</term><description>47cd9bd112c24d4e9b0a4400bcdee6e2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponCritAutoconfirmAgainstSize(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Size? size = null)
    {
      var component = new WeaponCritAutoconfirmAgainstSize();
      component.Size = size ?? component.Size;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageAgainstAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Anarchic</term><description>57315bc1e1f62a741be0efde688087e9</description></item>
    /// <item><term>DLC3_ShadowBalorFX</term><description>9abd18bca8394dc18b17318481e06933</description></item>
    /// <item><term>Unholy</term><description>d05753b8df780fc4bb55b318f06af453</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponDamageAgainstAlignment(
        DamageEnergyType? damageType = null,
        AlignmentComponent? enemyAlignment = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextDiceValue? value = null,
        DamageAlignment? weaponAlignment = null)
    {
      var component = new WeaponDamageAgainstAlignment();
      component.DamageType = damageType ?? component.DamageType;
      component.EnemyAlignment = enemyAlignment ?? component.EnemyAlignment;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = Utils.Constants.Empty.DiceValue;
      }
      component.WeaponAlignment = weaponAlignment ?? component.WeaponAlignment;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponDebuffOnAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Debuff on attacks
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DeadlyGraceEnchant</term><description>f674d7c3fd9f70b429c321ad84e4c116</description></item>
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
    /// <param name="fx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponDebuffOnAttack(
        Blueprint<BlueprintBuffReference>? buff = null,
        int? dC = null,
        Rounds? duration = null,
        AssetLink<PrefabLink>? fx = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        SavingThrowType? saveType = null)
    {
      var component = new WeaponDebuffOnAttack();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.DC = dC ?? component.DC;
      component.Duration = duration ?? component.Duration;
      component.Fx = fx?.Get() ?? component.Fx;
      if (component.Fx is null)
      {
        component.Fx = Utils.Constants.Empty.PrefabLink;
      }
      component.SaveType = saveType ?? component.SaveType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyBurst"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Energy Dice Bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CorrosiveBurst</term><description>0cf34703e67e37b40905845ca14b1380</description></item>
    /// <item><term>FlamingBurst</term><description>3f032a3cd54e57649a0cdad0434bf221</description></item>
    /// <item><term>WeaponBondFlamingBurstEnchant</term><description>b166fefa25b04b40a840fc5461e4feb5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponEnergyBurst(
        DiceType? dice = null,
        DamageEnergyType? element = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponEnergyBurst();
      component.Dice = dice ?? component.Dice;
      component.Element = element ?? component.Element;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnergyDamageDice"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Energy Dice Bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodthirstNegative3d6</term><description>f79f6fc9e5ab7da4daf93d665e4935bf</description></item>
    /// <item><term>IcyBurst</term><description>564a6924b246d254c920a7c44bf2a58b</description></item>
    /// <item><term>WeatherBlessingElectroDamage</term><description>f3524fb5e96e44f58f6a771bb943efae</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponEnergyDamageDice(
        DamageEnergyType? element = null,
        DiceFormula? energyDamageDice = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponEnergyDamageDice();
      component.Element = element ?? component.Element;
      component.EnergyDamageDice = energyDamageDice ?? component.EnergyDamageDice;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponEnhancementBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Enhancement Bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Enhancement1</term><description>d42fc23b92c640846ac137dc26e000d4</description></item>
    /// <item><term>Enhancement8</term><description>b337af3a2c2a46d0bd0683e983f9d94e</description></item>
    /// <item><term>TemporaryEnhancement5</term><description>746ee366e50611146821d61e391edf16</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponEnhancementBonus(
        int? enhancementBonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? stack = null)
    {
      var component = new WeaponEnhancementBonus();
      component.EnhancementBonus = enhancementBonus ?? component.EnhancementBonus;
      component.Stack = stack ?? component.Stack;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponExtraAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Extra attack with this weapon
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HastyEradicatorEnchantment</term><description>d4c1935c3ee176941879db1604c2a035</description></item>
    /// <item><term>QuickbladeEnchant</term><description>1e428c24d94987c4cb20e38bfbf4e164</description></item>
    /// <item><term>UltrasoundArrowsQuiverEnchantment</term><description>a57a3d4669722794688f1ed4270b20ba</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponExtraAttack(
        bool? haste = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? number = null,
        bool? penalized = null)
    {
      var component = new WeaponExtraAttack();
      component.Haste = haste ?? component.Haste;
      component.Number = number ?? component.Number;
      component.Penalized = penalized ?? component.Penalized;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponMagic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MagicWeapon</term><description>631cb72d11015374987c161a2451a1cf</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponMagic(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponMagic();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponMasterwork"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Masterwork Weapon
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Masterwork</term><description>6b38844e2bffbac48b63036b66e735be</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponMasterwork(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponMasterwork();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponMaterial"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdamantineWeaponEnchantment</term><description>ab39e7d59dd12f4429ffef5dca88dc7b</description></item>
    /// <item><term>MithralWeaponEnchantment</term><description>0ae8fc9f2e255584faf4d14835224875</description></item>
    /// <item><term>SilverWeaponEnchantment</term><description>9012b1095c9645e0a6152f673fc07d0a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponMaterial(
        PhysicalDamageMaterial? material = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponMaterial();
      component.Material = material ?? component.Material;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponReality"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GhostTouch</term><description>47857e1a5a3ec1a46adf6491b1423b4f</description></item>
    /// <item><term>GreatswordSunSwordWeaponEnchantment</term><description>41cbbcfcde784ddb9987660f57587742</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponReality(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        DamageRealityType? reality = null)
    {
      var component = new WeaponReality();
      component.Reality = reality ?? component.Reality;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.WeaponFxPrefab is null)
      {
        Blueprint.WeaponFxPrefab = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Armies.TacticalCombat.LeaderSkills.UnitBuffComponents;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Corruption;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Buffs.HalfOfPair;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using Kingmaker.Visual;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Buffs
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintBuff"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBuffConfigurator<T, TBuilder>
    : BaseUnitFactConfigurator<T, TBuilder>
    where T : BlueprintBuff
    where TBuilder : BaseBuffConfigurator<T, TBuilder>
  {
    protected BaseBuffConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBuff.Stacking"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use <see cref="SetRanks(int)"/> for StackingType.Rank.
    /// </para>
    /// </remarks>
    ///
    /// <param name="stacking">
    /// <para>
    /// InfoBox: Replace - New buff removes existing buff and takes its place  Prolong - Existing buff duration get prolonged, new buff is otherwise ignored  Ignore - New buff is ignored  Stack - Both buffs are added and function independently  Poison - Special stacking type for poison  Summ - Duration is added to current duration  Rank - For buffs with limited stack
    /// </para>
    /// </param>
    public TBuilder SetStacking(StackingType stacking)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stacking = stacking;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBuff.IsClassFeature"/>
    /// </summary>
    public TBuilder SetIsClassFeature(bool isClassFeature = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsClassFeature = isClassFeature;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public TBuilder SetFlags(params BlueprintBuff.Flags[] flags)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Flags = flags.Aggregate((BlueprintBuff.Flags) 0, (f1, f2) => f1 | f2);
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public TBuilder AddToFlags(params BlueprintBuff.Flags[] flags)
    {
      return OnConfigureInternal(
        bp =>
        {
          flags.ForEach(f => bp.m_Flags |= f);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBuff.m_Flags"/>
    /// </summary>
    public TBuilder RemoveFromFlags(params BlueprintBuff.Flags[] flags)
    {
      return OnConfigureInternal(
        bp =>
        {
          flags.ForEach(f => bp.m_Flags &= ~f);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBuff.Ranks"/>
    /// </summary>
    public TBuilder SetRanks(int ranks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Ranks = ranks;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBuff.TickEachSecond"/>
    /// </summary>
    public TBuilder SetTickEachSecond(bool tickEachSecond = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TickEachSecond = tickEachSecond;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBuff.Frequency"/>
    /// </summary>
    public TBuilder SetFrequency(DurationRate frequency)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Frequency = frequency;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBuff.FxOnStart"/>
    /// </summary>
    ///
    /// <param name="fxOnStart">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetFxOnStart(AssetLink<PrefabLink> fxOnStart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FxOnStart = fxOnStart?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBuff.FxOnStart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFxOnStart(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FxOnStart is null) { return; }
          action.Invoke(bp.FxOnStart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBuff.FxOnRemove"/>
    /// </summary>
    ///
    /// <param name="fxOnRemove">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetFxOnRemove(AssetLink<PrefabLink> fxOnRemove)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FxOnRemove = fxOnRemove?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBuff.FxOnRemove"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFxOnRemove(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FxOnRemove is null) { return; }
          action.Invoke(bp.FxOnRemove);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBuff.ResourceAssetIds"/>
    /// </summary>
    public TBuilder SetResourceAssetIds(params string[] resourceAssetIds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceAssetIds = resourceAssetIds;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintBuff.ResourceAssetIds"/>
    /// </summary>
    public TBuilder AddToResourceAssetIds(params string[] resourceAssetIds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceAssetIds = bp.ResourceAssetIds ?? new string[0];
          bp.ResourceAssetIds = CommonTool.Append(bp.ResourceAssetIds, resourceAssetIds);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBuff.ResourceAssetIds"/>
    /// </summary>
    public TBuilder RemoveFromResourceAssetIds(params string[] resourceAssetIds)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceAssetIds is null) { return; }
          bp.ResourceAssetIds = bp.ResourceAssetIds.Where(val => !resourceAssetIds.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBuff.ResourceAssetIds"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromResourceAssetIds(Func<string, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceAssetIds is null) { return; }
          bp.ResourceAssetIds = bp.ResourceAssetIds.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintBuff.ResourceAssetIds"/>
    /// </summary>
    public TBuilder ClearResourceAssetIds()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceAssetIds = new string[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBuff.ResourceAssetIds"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyResourceAssetIds(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceAssetIds is null) { return; }
          bp.ResourceAssetIds.ForEach(action);
        });
    }

    /// <summary>
    /// Adds <see cref="AddContextStatBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add stat bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abrogail_Feature_Prebuff</term><description>f0cad5e5b57b49f8b0983392a8c72eea</description></item>
    /// <item><term>GuardedStanceEffectBuff</term><description>3858dd3e9a94f0b41abdc58387d68ccf</description></item>
    /// <item><term>XantirOnlySwarm_MidnightFaneInThePastACFeature</term><description>5c0ef576cc68f374c96a0070fd3b047c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextStatBonus(
        StatType stat,
        ContextValue value,
        ModifierDescriptor? descriptor = null,
        int? minimal = null,
        int? multiplier = null)
    {
      var component = new AddContextStatBonus();
      component.Stat = stat;
      component.Value = value;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Minimal = minimal ?? component.Minimal;
      component.HasMinimal = minimal is null;
      component.Multiplier = multiplier ?? component.Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectFastHealing"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buffs/AddEffect/FastHealing
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlackLinnormStewBuff</term><description>4fbf48fff5bff9148accad55c116b8f2</description></item>
    /// <item><term>FastHealing9</term><description>9017213d83ccddb4ab720e0a0efe36ff</description></item>
    /// <item><term>VrolikaiAspectFeature</term><description>0ed608f1a0695cd4cb80bf6d415ab295</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEffectFastHealing(
        int heal,
        ContextValue? bonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddEffectFastHealing();
      component.Heal = heal;
      component.Bonus = bonus ?? component.Bonus;
      if (component.Bonus is null)
      {
        component.Bonus = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextRankConfig"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Use <see cref="Utils.Types.ContextRankConfigs"/> to create the ContextRankConfig component.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>5_DeadStage_AcidBuff</term><description>96afbbab53c34c549a5313a1f7aed13b</description></item>
    /// <item><term>HellsSealFeature</term><description>b6798b29d36982b4786a32dfd81a914f</description></item>
    /// <item><term>ZoneOfPredeterminationArea</term><description>1ff4dfed4f7eb504fa0447e93d1bcf64</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextRankConfig(ContextRankConfig component)
    {
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellDescriptorComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abrikandilu_Frozen_Buff</term><description>b2df7031cdad480caddf962c894ca484</description></item>
    /// <item><term>HagboundWitchVileCurseDeterioration</term><description>97a64518e7fd0aa4e86a51245e9de1a7</description></item>
    /// <item><term>ZachariusFearAuraBuff</term><description>4d9144b465bbefe4786cfe86c745ea4e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSpellDescriptorComponent(
        SpellDescriptorWrapper descriptor,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SpellDescriptorComponent();
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageTriggerFixed"/>
    /// </summary>
    public TBuilder AddOutgoingDamageTriggerFixed(AddOutgoingDamageTriggerFixed component)
    {
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasFactFixed"/>
    /// </summary>
    public TBuilder AddStatBonusIfHasFactFixed(AddStatBonusIfHasFactFixed component)
    {
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddNocticulaBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add Nocticula gift
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ProfaneAscensionFeature</term><description>656e71ec777e495abc6845ff80204d96</description></item>
    /// </list>
    /// </remarks>
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddNocticulaBonus(
        ModifierDescriptor? descriptor = null,
        StatType? highestStat = null,
        ContextValue? highestStatBonus = null,
        StatType? secondHighestStat = null,
        ContextValue? secondHighestStatBonus = null)
    {
      var component = new AddNocticulaBonus();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_HighestStat = highestStat ?? component.m_HighestStat;
      component.HighestStatBonus = highestStatBonus ?? component.HighestStatBonus;
      if (component.HighestStatBonus is null)
      {
        component.HighestStatBonus = ContextValues.Constant(0);
      }
      component.m_SecondHighestStat = secondHighestStat ?? component.m_SecondHighestStat;
      component.SecondHighestStatBonus = secondHighestStatBonus ?? component.SecondHighestStatBonus;
      if (component.SecondHighestStatBonus is null)
      {
        component.SecondHighestStatBonus = ContextValues.Constant(0);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTricksterAthleticBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add stat bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TricksterAthleticsTier3Feature</term><description>e45bf795c4f84c3b8a83c011f8580491</description></item>
    /// </list>
    /// </remarks>
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddTricksterAthleticBonus(
        ModifierDescriptor? descriptor = null,
        bool? isAdded = null)
    {
      var component = new AddTricksterAthleticBonus();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_IsAdded = isAdded ?? component.m_IsAdded;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BodyguardACBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: AC bonus against Attacks
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DivineGuardianTrothBuff</term><description>16dd5c27118a51b4f986f484ee388127</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkBuff">
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
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddBodyguardACBonus(
        Blueprint<BlueprintBuffReference>? checkBuff = null,
        ModifierDescriptor? descriptor = null,
        ContextValue? value = null)
    {
      var component = new BodyguardACBonus();
      component.m_CheckBuff = checkBuff?.Reference ?? component.m_CheckBuff;
      if (component.m_CheckBuff is null)
      {
        component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = ContextValues.Constant(0);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Bugurt"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LannSparringBuff</term><description>0b87395f642f67048aafeaf65146edb0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddBugurt(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new Bugurt();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EqualForce"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EqualForceBuff</term><description>53d481a622caaf447abf6bcefb52f3c4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddEqualForce(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new EqualForce();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="IndomitableMount"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Mobility check instead of AC
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>IndomitableMountBuff</term><description>616f994a244c44039fccbc1b03e6fba9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="cooldownBuff">
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
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddIndomitableMount(
        Blueprint<BlueprintBuffReference>? cooldownBuff = null)
    {
      var component = new IndomitableMount();
      component.m_CooldownBuff = cooldownBuff?.Reference ?? component.m_CooldownBuff;
      if (component.m_CooldownBuff is null)
      {
        component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InHarmsWay"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: AC bonus against Attacks
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DivineGuardianTrothBuff</term><description>16dd5c27118a51b4f986f484ee388127</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkBuff">
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
    /// <param name="cooldownBuff">
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
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddInHarmsWay(
        Blueprint<BlueprintBuffReference>? checkBuff = null,
        Blueprint<BlueprintBuffReference>? cooldownBuff = null)
    {
      var component = new InHarmsWay();
      component.m_CheckBuff = checkBuff?.Reference ?? component.m_CheckBuff;
      if (component.m_CheckBuff is null)
      {
        component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_CooldownBuff = cooldownBuff?.Reference ?? component.m_CooldownBuff;
      if (component.m_CooldownBuff is null)
      {
        component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedCombat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Mobility check instead of AC
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MountedCombatBuff</term><description>5008df9965da43c593c98ed7e6cacfc6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="cooldownBuff">
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
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddMountedCombat(
        Blueprint<BlueprintBuffReference>? cooldownBuff = null)
    {
      var component = new MountedCombat();
      component.m_CooldownBuff = cooldownBuff?.Reference ?? component.m_CooldownBuff;
      if (component.m_CooldownBuff is null)
      {
        component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedShield"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add stat bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MountedShieldBuff</term><description>7514ebdb264362544a4fe104cd4637de</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddMountedShield(
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        StatType? stat = null)
    {
      var component = new MountedShield();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Stat = stat ?? component.Stat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ShroudOfWater"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Shroud of Water
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ShroudOfWaterArmorEffectFeature</term><description>1ff803cb49f63ea4185490fae2c43ca7</description></item>
    /// <item><term>ShroudOfWaterShieldEffectFeature</term><description>4d8feca11d6e29a499ae761b90eacdba</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="upgradeFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddShroudOfWater(
        ContextValue? baseValue = null,
        ModifierDescriptor? descriptor = null,
        StatType? stat = null,
        Blueprint<BlueprintFeatureReference>? upgradeFeature = null)
    {
      var component = new ShroudOfWater();
      component.BaseValue = baseValue ?? component.BaseValue;
      if (component.BaseValue is null)
      {
        component.BaseValue = ContextValues.Constant(0);
      }
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Stat = stat ?? component.Stat;
      component.m_UpgradeFeature = upgradeFeature?.Reference ?? component.m_UpgradeFeature;
      if (component.m_UpgradeFeature is null)
      {
        component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShield"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BindingsOfThePrinceBuffCaster</term><description>4459c5a498df0604b9cef7aa63d17584</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="masterAbility">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddUnwillingShield(
        Blueprint<BlueprintAbilityReference>? masterAbility = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new UnwillingShield();
      component.m_MasterAbility = masterAbility?.Reference ?? component.m_MasterAbility;
      if (component.m_MasterAbility is null)
      {
        component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShieldTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BindingsOfThePrinceBuffTarget</term><description>27fd890432419db4ea8d803dcd1ddde9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="masterAbility">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    [Obsolete("File an issue on GitHub if you need this.")]
    public TBuilder AddUnwillingShieldTarget(
        Blueprint<BlueprintAbilityReference>? masterAbility = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new UnwillingShieldTarget();
      component.m_MasterAbility = masterAbility?.Reference ?? component.m_MasterAbility;
      if (component.m_MasterAbility is null)
      {
        component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="GlobalMapSpeedModifier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DivineServiceSpeedModifier</term><description>23c769eaac4409742a786a157ea96273</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddGlobalMapSpeedModifier(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? speedModifier = null)
    {
      var component = new GlobalMapSpeedModifier();
      component.SpeedModifier = speedModifier ?? component.SpeedModifier;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ArmorWeightCoef"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PurifierCelestialArmorFeature</term><description>7dc8d7dede2704640956f7bc4102760a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddArmorWeightCoef(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? weightCoef = null)
    {
      var component = new ArmorWeightCoef();
      component.WeightCoef = weightCoef ?? component.WeightCoef;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddForceMove"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TsunamiBuff</term><description>1694ee72db34ecf49a63005e845e175d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddForceMove(
        ContextValue? feetPerRound = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddForceMove();
      component.FeetPerRound = feetPerRound ?? component.FeetPerRound;
      if (component.FeetPerRound is null)
      {
        component.FeetPerRound = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddRestTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcanistArcaneReservoirFeature</term><description>55db1859bd72fd04f9bd3fe1f10e4cbb</description></item>
    /// <item><term>Player_restTrigger</term><description>ac7f1eff7837432e8acdccd52308c09b</description></item>
    /// <item><term>TricksterLoreNature3Feature</term><description>b88ca3a5476ebcc4ea63d5c1e92ce222</description></item>
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
        ActionsBuilder? action = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddRestTrigger();
      component.Action = action?.Build() ?? component.Action;
      if (component.Action is null)
      {
        component.Action = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddRunwayLogic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SecretOfSubduingRunwayBuff</term><description>a4d60878d85d652489c5b0fd9b11e1ac</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRunwayLogic(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddRunwayLogic();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddTemporaryFeat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DivineHuntersBlessingBuff</term><description>493b217b69ed4ad4ca3dc71983a356c6</description></item>
    /// <item><term>PackRagerPreciseStrikeBuff</term><description>1eb018f9dcbbc2547babb490c6a362a6</description></item>
    /// <item><term>TriceratopsStatuetteBuff</term><description>b0b20d062e5419a43b5c0c829cdfcd8d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feat">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTemporaryFeat(
        Blueprint<BlueprintFeatureReference>? feat = null)
    {
      var component = new AddTemporaryFeat();
      component.m_Feat = feat?.Reference ?? component.m_Feat;
      if (component.m_Feat is null)
      {
        component.m_Feat = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWeaponEnhancementBonusToStat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PerfectStormFeature</term><description>f93deb8fb11e06743b6941626cd6f2e0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddWeaponEnhancementBonusToStat(
        ModifierDescriptor? descriptor = null,
        int? multiplier = null,
        StatType? stat = null)
    {
      var component = new AddWeaponEnhancementBonusToStat();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Multiplier = multiplier ?? component.Multiplier;
      component.Stat = stat ?? component.Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantSpecificWeaponWorn"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BooksOfDreamsIStageFeature</term><description>739765ea859647b595bc2df4012052f8</description></item>
    /// <item><term>RadianceGoodBuff</term><description>f10cba2c41612614ea28b5fc2743bc4c</description></item>
    /// <item><term>TheUndyingLoveOfTheHopebringer_LightNova_GiveBuff</term><description>8c9b07c246a3469e8c154d98ee594ee3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentBlueprint">
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
    public TBuilder AddBuffEnchantSpecificWeaponWorn(
        Blueprint<BlueprintItemEnchantmentReference>? enchantmentBlueprint = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintItemWeaponReference>? weaponBlueprint = null)
    {
      var component = new BuffEnchantSpecificWeaponWorn();
      component.m_EnchantmentBlueprint = enchantmentBlueprint?.Reference ?? component.m_EnchantmentBlueprint;
      if (component.m_EnchantmentBlueprint is null)
      {
        component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(null);
      }
      component.m_WeaponBlueprint = weaponBlueprint?.Reference ?? component.m_WeaponBlueprint;
      if (component.m_WeaponBlueprint is null)
      {
        component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantWornItem"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlignWeaponChaosBuff</term><description>2f2eb113da65b6b4fbf69e35c90afe02</description></item>
    /// <item><term>Inquisitor_Buff_Bane</term><description>4efb6790e1edf3c419bad6b52f36e32f</description></item>
    /// <item><term>WeaponOfDeathBuff</term><description>a8c1e364f631f8a46b8ef23a5528c806</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantmentBlueprint">
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
    public TBuilder AddBuffEnchantWornItem(
        bool? allWeapons = null,
        Blueprint<BlueprintItemEnchantmentReference>? enchantmentBlueprint = null,
        EquipSlotBase.SlotType? slot = null)
    {
      var component = new BuffEnchantWornItem();
      component.AllWeapons = allWeapons ?? component.AllWeapons;
      component.m_EnchantmentBlueprint = enchantmentBlueprint?.Reference ?? component.m_EnchantmentBlueprint;
      if (component.m_EnchantmentBlueprint is null)
      {
        component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(null);
      }
      component.Slot = slot ?? component.Slot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DropLootAndDestroyOnDeactivate"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DismemberedUnitBuff</term><description>c98d765d063f57a49a03f13d4f697c33</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDropLootAndDestroyOnDeactivate(
        IDisposable? coroutine = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DropLootAndDestroyOnDeactivate();
      Validate(coroutine);
      component.m_Coroutine = coroutine ?? component.m_Coroutine;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfPartyNotInCombat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BootsOfMagicalWhirlCountBuff</term><description>815fa1c6d2dc4c56859bfa84eee96107</description></item>
    /// <item><term>CallOfTheWildBeastShapeIIIBuff</term><description>db9b5a75449d82b49a6bee944ecf824a</description></item>
    /// <item><term>ShamiraBurn</term><description>3c7d6b01dace4cd5a7d9948f34239888</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRemoveBuffIfPartyNotInCombat(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RemoveBuffIfPartyNotInCombat();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SetMagusFeatureActive"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SpellCombatBuff</term><description>91e4b45ab5f29574aa1fb41da4bbdcf2</description></item>
    /// <item><term>SpellStrikeBuff</term><description>06e0c9887eb1724409977dac7168bfd7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSetMagusFeatureActive(
        SetMagusFeatureActive.FeatureType? feature = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SetMagusFeatureActive();
      component.m_Feature = feature ?? component.m_Feature;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UniqueBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelSwordEffectBuff</term><description>f5f500d6a2a39fc4181af32ad79af488</description></item>
    /// <item><term>ProfaneAscensionCharismaBuff1</term><description>503131ef5904487c86a4dbe51b84b66c</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningBuff</term><description>e248e5ef1ae04d559d5fe82ef719ee47</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddUniqueBuff(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new UniqueBuff();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBlade"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>KineticBladeAirBlastBuff</term><description>f7a55ccd8553f974a89482dd98672bbc</description></item>
    /// <item><term>KineticBladeIceBlastBuff</term><description>9e7a7d7e8334a5748a8834b0116cf6c4</description></item>
    /// <item><term>KineticBladeWaterBlastBuff</term><description>abe55a6590a056f4e8161802ae2b43c5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blade">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddKineticistBlade(
        Blueprint<BlueprintItemWeaponReference>? blade = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddKineticistBlade();
      component.m_Blade = blade?.Reference ?? component.m_Blade;
      if (component.m_Blade is null)
      {
        component.m_Blade = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Polymorph"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Anevia_DressPolymorph</term><description>6267b23ce31a4ad8b1b3557826671708</description></item>
    /// <item><term>HellknightPolymorfBuff</term><description>45a6f94d77549124ea72c5304b02f8fb</description></item>
    /// <item><term>YozzPolymorfBuff</term><description>ed4e29772921bc84098f1a9a1dcc3ddb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="additionalLimbs">
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
    /// <param name="mainHand">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="offHand">
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
    /// <param name="portrait">
    /// <para>
    /// Blueprint of type BlueprintPortrait. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="prefab">
    /// You can pass in the animation using a UnitViewLink or it's AssetId.
    /// </param>
    /// <param name="prefabFemale">
    /// You can pass in the animation using a UnitViewLink or it's AssetId.
    /// </param>
    /// <param name="race">
    /// <para>
    /// Blueprint of type BlueprintRace. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="replaceUnitForInspection">
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
    /// <param name="secondaryAdditionalLimbs">
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
    public TBuilder AddPolymorph(
        List<Blueprint<BlueprintItemWeaponReference>>? additionalLimbs = null,
        int? constitutionBonus = null,
        int? dexterityBonus = null,
        Polymorph.VisualTransitionSettings? enterTransition = null,
        Polymorph.VisualTransitionSettings? exitTransition = null,
        List<Blueprint<BlueprintUnitFactReference>>? facts = null,
        bool? keepSlots = null,
        Blueprint<BlueprintItemWeaponReference>? mainHand = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? naturalArmor = null,
        Blueprint<BlueprintItemWeaponReference>? offHand = null,
        Blueprint<BlueprintPortraitReference>? portrait = null,
        AssetLink<UnitViewLink>? prefab = null,
        AssetLink<UnitViewLink>? prefabFemale = null,
        Blueprint<BlueprintRaceReference>? race = null,
        Blueprint<BlueprintUnitReference>? replaceUnitForInspection = null,
        List<Blueprint<BlueprintItemWeaponReference>>? secondaryAdditionalLimbs = null,
        bool? silentCaster = null,
        Size? size = null,
        SpecialDollType? specialDollType = null,
        int? strengthBonus = null,
        PolymorphTransitionSettings? transitionExternal = null)
    {
      var component = new Polymorph();
      component.m_AdditionalLimbs = additionalLimbs?.Select(bp => bp.Reference)?.ToArray() ?? component.m_AdditionalLimbs;
      if (component.m_AdditionalLimbs is null)
      {
        component.m_AdditionalLimbs = new BlueprintItemWeaponReference[0];
      }
      component.ConstitutionBonus = constitutionBonus ?? component.ConstitutionBonus;
      component.DexterityBonus = dexterityBonus ?? component.DexterityBonus;
      Validate(enterTransition);
      component.m_EnterTransition = enterTransition ?? component.m_EnterTransition;
      Validate(exitTransition);
      component.m_ExitTransition = exitTransition ?? component.m_ExitTransition;
      component.m_Facts = facts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Facts;
      if (component.m_Facts is null)
      {
        component.m_Facts = new BlueprintUnitFactReference[0];
      }
      component.m_KeepSlots = keepSlots ?? component.m_KeepSlots;
      component.m_MainHand = mainHand?.Reference ?? component.m_MainHand;
      if (component.m_MainHand is null)
      {
        component.m_MainHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      component.NaturalArmor = naturalArmor ?? component.NaturalArmor;
      component.m_OffHand = offHand?.Reference ?? component.m_OffHand;
      if (component.m_OffHand is null)
      {
        component.m_OffHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      component.m_Portrait = portrait?.Reference ?? component.m_Portrait;
      if (component.m_Portrait is null)
      {
        component.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(null);
      }
      component.m_Prefab = prefab?.Get() ?? component.m_Prefab;
      component.m_PrefabFemale = prefabFemale?.Get() ?? component.m_PrefabFemale;
      component.m_Race = race?.Reference ?? component.m_Race;
      if (component.m_Race is null)
      {
        component.m_Race = BlueprintTool.GetRef<BlueprintRaceReference>(null);
      }
      component.m_ReplaceUnitForInspection = replaceUnitForInspection?.Reference ?? component.m_ReplaceUnitForInspection;
      if (component.m_ReplaceUnitForInspection is null)
      {
        component.m_ReplaceUnitForInspection = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      component.m_SecondaryAdditionalLimbs = secondaryAdditionalLimbs?.Select(bp => bp.Reference)?.ToArray() ?? component.m_SecondaryAdditionalLimbs;
      if (component.m_SecondaryAdditionalLimbs is null)
      {
        component.m_SecondaryAdditionalLimbs = new BlueprintItemWeaponReference[0];
      }
      component.m_SilentCaster = silentCaster ?? component.m_SilentCaster;
      component.Size = size ?? component.Size;
      component.m_SpecialDollType = specialDollType ?? component.m_SpecialDollType;
      component.StrengthBonus = strengthBonus ?? component.StrengthBonus;
      Validate(transitionExternal);
      component.m_TransitionExternal = transitionExternal ?? component.m_TransitionExternal;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnTurnOn"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FadeInOut</term><description>9c9da5cde5e7e5b488c7d48e86b1d99f</description></item>
    /// <item><term>Galfrey_AfterCouncilPolymorph</term><description>727d5a386464485ead4b2919b4003b1e</description></item>
    /// <item><term>NPC_Switch2Neutral</term><description>a121ed5d673eaa94880d0b38a72787ef</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRemoveBuffOnTurnOn(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? onlyFromParty = null)
    {
      var component = new RemoveBuffOnTurnOn();
      component.OnlyFromParty = onlyFromParty ?? component.OnlyFromParty;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddAreaEffect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAoOGazeBaseBuff</term><description>da22fac7ee174766a1d924749245b8e9</description></item>
    /// <item><term>HatOfHearteningSongBuff</term><description>2ac1f04db1e7da34cab38a32f9794e28</description></item>
    /// <item><term>ZeorisDaggerRing_BetrayalAreaBuff</term><description>b2b739c6e18b457d9ba30ab389b0520f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="areaEffect">
    /// <para>
    /// Blueprint of type BlueprintAbilityAreaEffect. You can pass in the blueprint using:
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
    public TBuilder AddAreaEffect(
        Blueprint<BlueprintAbilityAreaEffectReference>? areaEffect = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddAreaEffect();
      component.m_AreaEffect = areaEffect?.Reference ?? component.m_AreaEffect;
      if (component.m_AreaEffect is null)
      {
        component.m_AreaEffect = BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddAttackBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buffs/Attack bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_BesmaraPirateBaseAttackBonus</term><description>ff69961f459744018d3dbfb8e50a7973</description></item>
    /// <item><term>DLC3_BesmaraPirateBaseBuff</term><description>c2ea5f0cbdd640af9f24a1b63a2bfb6c</description></item>
    /// <item><term>KnightOfTheWallDefensiveChallengeBuff</term><description>d064c2b40f9b78240a1527bead977df3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAttackBonus(
        int? bonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddAttackBonus();
      component.Bonus = bonus ?? component.Bonus;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddCheatDamageBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buffs/Damage bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CheatEmpowerBuff</term><description>9da73e0f62054254d835013c46f3a27a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCheatDamageBonus(
        int? bonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddCheatDamageBonus();
      component.Bonus = bonus ?? component.Bonus;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddDispelMagicFailedTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SoulsCloakCurseBuff</term><description>40f948d8e5ee2534eb3d701f256f96b5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDispelMagicFailedTrigger(
        ActionsBuilder? actionOnCaster = null,
        ActionsBuilder? actionOnOwner = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddDispelMagicFailedTrigger();
      component.ActionOnCaster = actionOnCaster?.Build() ?? component.ActionOnCaster;
      if (component.ActionOnCaster is null)
      {
        component.ActionOnCaster = Utils.Constants.Empty.Actions;
      }
      component.ActionOnOwner = actionOnOwner?.Build() ?? component.ActionOnOwner;
      if (component.ActionOnOwner is null)
      {
        component.ActionOnOwner = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddEffectContextFastHealing"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buffs/AddEffect/FastHealing
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlameOfLifeEffectBuff</term><description>d79ca3a14a6d46e4987aa2127dafefe3</description></item>
    /// <item><term>MonsterMythicFeature6GoodBuff</term><description>46ec10f8db674998a0dd7a9b96cdd2f3</description></item>
    /// <item><term>SwordofValorCosmeticBuff</term><description>e68e0bedcfd3410798f7513a54e71b75</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEffectContextFastHealing(
        ContextValue? bonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddEffectContextFastHealing();
      component.Bonus = bonus ?? component.Bonus;
      if (component.Bonus is null)
      {
        component.Bonus = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddEffectRegeneration"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buffs/AddEffect/Regeneration
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BrandedTrollRegeneration</term><description>da6269afb82c5a14f86281c4e7ff9a4d</description></item>
    /// <item><term>RegenerationEvil10</term><description>8035661fe9d80964cb96c29406a079d9</description></item>
    /// <item><term>WildLink_MonarchEffectBuff</term><description>814b2b51959705945ad6c5ceb08ffbd4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEffectRegeneration(
        bool? cancelByMagicWeapon = null,
        DamageAlignment[]? cancelDamageAlignmentTypes = null,
        DamageEnergyType[]? cancelDamageEnergyTypes = null,
        PhysicalDamageMaterial[]? cancelDamageMaterials = null,
        int? heal = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? unremovable = null)
    {
      var component = new AddEffectRegeneration();
      component.CancelByMagicWeapon = cancelByMagicWeapon ?? component.CancelByMagicWeapon;
      component.CancelDamageAlignmentTypes = cancelDamageAlignmentTypes ?? component.CancelDamageAlignmentTypes;
      if (component.CancelDamageAlignmentTypes is null)
      {
        component.CancelDamageAlignmentTypes = new DamageAlignment[0];
      }
      component.CancelDamageEnergyTypes = cancelDamageEnergyTypes ?? component.CancelDamageEnergyTypes;
      if (component.CancelDamageEnergyTypes is null)
      {
        component.CancelDamageEnergyTypes = new DamageEnergyType[0];
      }
      component.CancelDamageMaterials = cancelDamageMaterials ?? component.CancelDamageMaterials;
      if (component.CancelDamageMaterials is null)
      {
        component.CancelDamageMaterials = new PhysicalDamageMaterial[0];
      }
      component.Heal = heal ?? component.Heal;
      component.Unremovable = unremovable ?? component.Unremovable;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddGenericStatBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buffs/Generic stat bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AxiomiteMeleeMiniboss_Buff_LegendaryProportions</term><description>acf2b59d0d374711b969c5ea864e9656</description></item>
    /// <item><term>LegendaryProportionsBuffMorveg</term><description>015a7e1c3af88ea4cb6189fbe52b4863</description></item>
    /// <item><term>TrueStrikeBuff</term><description>a3ce3b226c1817846b0419fa182e6ea0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddGenericStatBonus(
        ModifierDescriptor? descriptor = null,
        StatType? stat = null,
        int? value = null)
    {
      var component = new AddGenericStatBonus();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Stat = stat ?? component.Stat;
      component.Value = value ?? component.Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMirrorImage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnomalyTemplateDefensive_ImagesOfChaosEffectBuff</term><description>ae6e6c03a29d44df9bed230e940af75c</description></item>
    /// <item><term>MirrorImageBuff</term><description>98dc7e7cc6ef59f4abe20c65708ac623</description></item>
    /// <item><term>TricksterFirstAscensionBuff</term><description>b585708811497fc49836fc9112ff1732</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddMirrorImage(
        ContextDiceValue? count = null,
        int? maxCount = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddMirrorImage();
      component.Count = count ?? component.Count;
      if (component.Count is null)
      {
        component.Count = Utils.Constants.Empty.DiceValue;
      }
      component.MaxCount = maxCount ?? component.MaxCount;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="IsPositiveEffect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CarnivorousCrystal_Buff_SubsonicHum_Immunity</term><description>88e345f3233c8024e9d191a807c40223</description></item>
    /// <item><term>RavenSwarmDamageEffectImmunity</term><description>c375d8d72762cf14db97c204522b0fb0</description></item>
    /// <item><term>WildGazeImmunity</term><description>2e64086ebcd066c4b8d1e46c00c8636f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddIsPositiveEffect(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new IsPositiveEffect();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="NegativeLevelComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Colyphyr_HepzamirahDebuff</term><description>28c27ef896fc5704cb232af04f86f694</description></item>
    /// <item><term>MongrelsBlessingBuff</term><description>c5989f96b6184573988a305b4220b9b5</description></item>
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
    public TBuilder AddNegativeLevelComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new NegativeLevelComponent();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="NotDispelable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArueshalaeImmortalityBuff</term><description>7ad9d9982302e2244a7dd73fee6c381b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddNotDispelable(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new NotDispelable();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfCasterIsMissing"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnomalyDistortionImmunityAfterBuff</term><description>938dc00f7c7f4a908feb96d533263f70</description></item>
    /// <item><term>GolemAutumnGrappledBuff</term><description>077537d7c64aa4e44b559b914693d085</description></item>
    /// <item><term>WitchHexDeathCurseBuff2</term><description>5e6aeb6852a77b3449b37a4bdb9f7bb4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRemoveBuffIfCasterIsMissing(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? removeOnCasterDeath = null)
    {
      var component = new RemoveBuffIfCasterIsMissing();
      component.RemoveOnCasterDeath = removeOnCasterDeath ?? component.RemoveOnCasterDeath;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RemoveWhenCombatEnded"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnomalyDistortionBodyDesynchronizationBuff</term><description>71d9285c18274bf6a8123ccd3272e20d</description></item>
    /// <item><term>HoldMonsterBuff</term><description>2cfcce5b62d3e6d4082ec31b58468cc8</description></item>
    /// <item><term>VinetrapEntangledBuff</term><description>231a622f767e8ed4e9b3e435265a3e99</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRemoveWhenCombatEnded(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RemoveWhenCombatEnded();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ResurrectionLogic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RepurposeResurrectionBuff</term><description>57785c3bf386461ea3d623d627314afa</description></item>
    /// <item><term>ResurrectionBuff</term><description>12f2f2cf326dfd743b2cce5b14e99b3c</description></item>
    /// <item><term>SongOfTheFallenResurrectionBuff</term><description>e2cd971a6a004c53b55abd336ac8da03</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="firstFx">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="secondFx">
    /// You can pass in the animation using a GameObject or it's AssetId.
    /// </param>
    public TBuilder AddResurrectionLogic(
        Asset<GameObject>? firstFx = null,
        float? firstFxDelay = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Asset<GameObject>? secondFx = null,
        float? secondFxDelay = null)
    {
      var component = new ResurrectionLogic();
      component.FirstFx = firstFx?.Get() ?? component.FirstFx;
      component.FirstFxDelay = firstFxDelay ?? component.FirstFxDelay;
      component.SecondFx = secondFx?.Get() ?? component.SecondFx;
      component.SecondFxDelay = secondFxDelay ?? component.SecondFxDelay;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SpecialAnimationState"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buffs/Special/AnimationState
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirElementalInWhirlwind</term><description>8b1b723a20f644c469b99bd541a13a3b</description></item>
    /// <item><term>PurpleWormBurrowed</term><description>cfff89a839d188d4086492471cba5111</description></item>
    /// <item><term>WyvernInFlight</term><description>ad06fa795a9e7124a88878446c675aaa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSpecialAnimationState(
        UnitAnimationActionBuffState? animation = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SpecialAnimationState();
      Validate(animation);
      component.Animation = animation ?? component.Animation;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SummonedUnitBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buffs/Special/Summoned unit
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CR12_NabasuAdvancedSummoned</term><description>a1351a09365f46c4afb71e710eec328b</description></item>
    /// <item><term>SummonedUnitBuff</term><description>8728e884eeaa8b047be04197ecf1a0e4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSummonedUnitBuff(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SummonedUnitBuff();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponAttackTypeDamageBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Buffs/Damage bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodragerStandartRageBuff</term><description>5eac31e457999334b98f98b60fc73b2f</description></item>
    /// <item><term>EyeImplantFeature</term><description>4456e13ff90d9e6498462b92cb97ed21</description></item>
    /// <item><term>WarDomainBaseBuff</term><description>aefec65136058694ab20cd71941eec81</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="attackBonus">
    /// <para>
    /// InfoBox: It&amp;apos;s actually damage bonus
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponAttackTypeDamageBonus(
        int? attackBonus = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        WeaponRangeType? type = null,
        ContextValue? value = null)
    {
      var component = new WeaponAttackTypeDamageBonus();
      component.AttackBonus = attackBonus ?? component.AttackBonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Type = type ?? component.Type;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>DeathsnatcherEnergyDrainFeature</term><description>e4c3976c40072a747b1a9ba2d8f166f2</description></item>
    /// <item><term>Yozz_Feature_AdditionalAttacks</term><description>bcf37abbb0b1485b83059600ed440881</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customProperty">
    /// <para>
    /// Blueprint of type BlueprintUnitProperty. You can pass in the blueprint using:
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
    public TBuilder AddContextCalculateAbilityParams(
        ContextValue? casterLevel = null,
        Blueprint<BlueprintUnitPropertyReference>? customProperty = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? replaceCasterLevel = null,
        bool? replaceSpellLevel = null,
        ContextValue? spellLevel = null,
        StatType? statType = null,
        bool? statTypeFromCustomProperty = null,
        bool? useKineticistMainStat = null)
    {
      var component = new ContextCalculateAbilityParams();
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      if (component.CasterLevel is null)
      {
        component.CasterLevel = ContextValues.Constant(0);
      }
      component.m_CustomProperty = customProperty?.Reference ?? component.m_CustomProperty;
      if (component.m_CustomProperty is null)
      {
        component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(null);
      }
      component.ReplaceCasterLevel = replaceCasterLevel ?? component.ReplaceCasterLevel;
      component.ReplaceSpellLevel = replaceSpellLevel ?? component.ReplaceSpellLevel;
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      if (component.SpellLevel is null)
      {
        component.SpellLevel = ContextValues.Constant(0);
      }
      component.StatType = statType ?? component.StatType;
      component.StatTypeFromCustomProperty = statTypeFromCustomProperty ?? component.StatTypeFromCustomProperty;
      component.UseKineticistMainStat = useKineticistMainStat ?? component.UseKineticistMainStat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirBlastAbility</term><description>31f668b12011e344aa542aa07ab6c8d9</description></item>
    /// <item><term>PlasmaBlastAbility</term><description>a5631955254ae5c4d9cc2d16870448a2</description></item>
    /// <item><term>XantirOnlySwarm_MidnightFaneInThePastFeature</term><description>5131c4b93f314bd4589edf612b4eb600</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="characterClass">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
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
    public TBuilder AddContextCalculateAbilityParamsBasedOnClass(
        Blueprint<BlueprintCharacterClassReference>? characterClass = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        StatType? statType = null,
        bool? useKineticistMainStat = null)
    {
      var component = new ContextCalculateAbilityParamsBasedOnClass();
      component.m_CharacterClass = characterClass?.Reference ?? component.m_CharacterClass;
      if (component.m_CharacterClass is null)
      {
        component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.StatType = statType ?? component.StatType;
      component.UseKineticistMainStat = useKineticistMainStat ?? component.UseKineticistMainStat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbyssalCreatureAcidTemplate</term><description>6e6fda1c8a35069468e7398082cd30f5</description></item>
    /// <item><term>JagannathKhandaPoisonBuff</term><description>7cadc7cfdfb491143a62eabfdcd2d948</description></item>
    /// <item><term>WreckingBlowsEffectBuff</term><description>15dd42009de61334692b22fd7a576b79</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextCalculateSharedValue(
        double? modifier = null,
        ContextDiceValue? value = null,
        AbilitySharedValue? valueType = null)
    {
      var component = new ContextCalculateSharedValue();
      component.Modifier = modifier ?? component.Modifier;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = Utils.Constants.Empty.DiceValue;
      }
      component.ValueType = valueType ?? component.ValueType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbruptForceEnchantment</term><description>c31b3edcf2088a64e80133ebbd6374cb</description></item>
    /// <item><term>HelmetOfTheDuskFeature</term><description>ade5182f85a26fd4f85eebcaf70449ec</description></item>
    /// <item><term>WreckingDevilEnchantment</term><description>b147364a4f50438f943f8095c85916b7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="casterLevel">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is (plus bonuses)
    /// </para>
    /// </param>
    /// <param name="concentration">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is (plus bonuses)
    /// </para>
    /// </param>
    /// <param name="dC">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is (plus bonuses)
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spellLevel">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is
    /// </para>
    /// </param>
    public TBuilder AddContextSetAbilityParams(
        bool? add10ToDC = null,
        ContextValue? casterLevel = null,
        ContextValue? concentration = null,
        ContextValue? dC = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextValue? spellLevel = null)
    {
      var component = new ContextSetAbilityParams();
      component.Add10ToDC = add10ToDC ?? component.Add10ToDC;
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      if (component.CasterLevel is null)
      {
        component.CasterLevel = ContextValues.Constant(0);
      }
      component.Concentration = concentration ?? component.Concentration;
      if (component.Concentration is null)
      {
        component.Concentration = ContextValues.Constant(0);
      }
      component.DC = dC ?? component.DC;
      if (component.DC is null)
      {
        component.DC = ContextValues.Constant(0);
      }
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      if (component.SpellLevel is null)
      {
        component.SpellLevel = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>StewardOfTheSkeinGazeBuff</term><description>4f18044ca197eb945b7d1b557dd9b447</description></item>
    /// <item><term>Weird</term><description>870af83be6572594d84d276d7fc583e0</description></item>
    /// <item><term>WildHunt_ScoutCrystalAbility</term><description>c470c62b38db74e4fb6b84b331beda30</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityDifficultyLimitDC(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityDifficultyLimitDC();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyBuildingCathedralBuff</term><description>e9df77ae53da4993a882bb1d1047a4e8</description></item>
    /// <item><term>ArmyLeadership8DamageToInfantryBuff</term><description>406cc284f5714ff0ab3d6231e0aed94a</description></item>
    /// <item><term>FavoredEnemyLargeBuff</term><description>45f4acbece1c4cf4889aaceb46318ae7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDamageBonusAgainstTacticalTarget(
        Kingmaker.UnitLogic.Mechanics.ValueType? _valueType = null,
        int? bonusPercentValue = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        TargetFilter? targetFilter = null,
        ContextValue? value = null)
    {
      var component = new DamageBonusAgainstTacticalTarget();
      component._valueType = _valueType ?? component._valueType;
      component.m_BonusPercentValue = bonusPercentValue ?? component.m_BonusPercentValue;
      Validate(targetFilter);
      component.m_TargetFilter = targetFilter ?? component.m_TargetFilter;
      component.m_Value = value ?? component.m_Value;
      if (component.m_Value is null)
      {
        component.m_Value = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSquadAbilities"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyBuildingBreweryBuff</term><description>7e2a4a3c182c4f2483a90e8c6d7e0bd8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="newAbilities">
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
    public TBuilder AddReplaceSquadAbilities(
        bool? forOneTurn = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintAbilityReference>>? newAbilities = null)
    {
      var component = new ReplaceSquadAbilities();
      component.m_ForOneTurn = forOneTurn ?? component.m_ForOneTurn;
      component.m_NewAbilities = newAbilities?.Select(bp => bp.Reference)?.ToList() ?? component.m_NewAbilities;
      if (component.m_NewAbilities is null)
      {
        component.m_NewAbilities = new();
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatConfusion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyConfusedBuff</term><description>1da4d884ccac4c1a89465ea8ad48c7e4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="aiAttackNearestAction">
    /// <para>
    /// InfoBox: Set action with Can Attack allies flag
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintTacticalCombatAiAction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="harmSelfAction">
    /// <para>
    /// InfoBox: Owner is target here
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTacticalCombatConfusion(
        Blueprint<BlueprintTacticalCombatAiActionReference>? aiAttackNearestAction = null,
        ActionsBuilder? harmSelfAction = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TacticalCombatConfusion();
      component.m_AiAttackNearestAction = aiAttackNearestAction?.Reference ?? component.m_AiAttackNearestAction;
      if (component.m_AiAttackNearestAction is null)
      {
        component.m_AiAttackNearestAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(null);
      }
      component.m_HarmSelfAction = harmSelfAction?.Build() ?? component.m_HarmSelfAction;
      if (component.m_HarmSelfAction is null)
      {
        component.m_HarmSelfAction = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleChanceModifier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyBuildingBulletingBoard</term><description>d3fc356cf3ad44129a995b64fbb513ab</description></item>
    /// <item><term>ArmyBuildingTavern</term><description>5b7dae6b75e7483ba1bc10d890a690c7</description></item>
    /// <item><term>Ziforian_feature</term><description>59820030350e40fe86a83d3ca412b221</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="negativeMoraleChancePercentDelta">
    /// <para>
    /// InfoBox: Negative Morale chance formula: Chance = -Morale / NegativeMoraleModifier + NegativeMoraleChance
    /// </para>
    /// </param>
    /// <param name="positiveMoraleChancePercentDelta">
    /// <para>
    /// InfoBox: Positive Morale chance formula: Chance = UnitMorale / PositiveMoraleModifier + PositiveMoraleChance
    /// </para>
    /// </param>
    public TBuilder AddTacticalMoraleChanceModifier(
        bool? changeNegativeMorale = null,
        bool? changePositiveMorale = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextValue? negativeMoraleChancePercentDelta = null,
        ContextValue? positiveMoraleChancePercentDelta = null)
    {
      var component = new TacticalMoraleChanceModifier();
      component.m_ChangeNegativeMorale = changeNegativeMorale ?? component.m_ChangeNegativeMorale;
      component.m_ChangePositiveMorale = changePositiveMorale ?? component.m_ChangePositiveMorale;
      component.m_NegativeMoraleChancePercentDelta = negativeMoraleChancePercentDelta ?? component.m_NegativeMoraleChancePercentDelta;
      if (component.m_NegativeMoraleChancePercentDelta is null)
      {
        component.m_NegativeMoraleChancePercentDelta = ContextValues.Constant(0);
      }
      component.m_PositiveMoraleChancePercentDelta = positiveMoraleChancePercentDelta ?? component.m_PositiveMoraleChancePercentDelta;
      if (component.m_PositiveMoraleChancePercentDelta is null)
      {
        component.m_PositiveMoraleChancePercentDelta = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TargetingBlind"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlindVictimBuff</term><description>43981a02863a5d34b9e1448d32000fd7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTargetingBlind(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TargetingBlind();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraEffects"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add extra buff to buff
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonBaneFeature</term><description>0b25e8d8b0488c84c9b5714e9ca0a204</description></item>
    /// <item><term>GuardianOfLifeFeature</term><description>9dd2ce2f909e1fc4db95e118ac8171c8</description></item>
    /// <item><term>WreckingBlowsFeature</term><description>5bccc86dd1f187a4a99f092dc054c755</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkedBuff">
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
    /// <param name="exceptionFact">
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
    /// <param name="extraEffectBuff">
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
    public TBuilder AddBuffExtraEffects(
        Blueprint<BlueprintBuffReference>? checkedBuff = null,
        Blueprint<BlueprintUnitFactReference>? exceptionFact = null,
        Blueprint<BlueprintBuffReference>? extraEffectBuff = null)
    {
      var component = new BuffExtraEffects();
      component.m_CheckedBuff = checkedBuff?.Reference ?? component.m_CheckedBuff;
      if (component.m_CheckedBuff is null)
      {
        component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_ExceptionFact = exceptionFact?.Reference ?? component.m_ExceptionFact;
      if (component.m_ExceptionFact is null)
      {
        component.m_ExceptionFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.m_ExtraEffectBuff = extraEffectBuff?.Reference ?? component.m_ExtraEffectBuff;
      if (component.m_ExtraEffectBuff is null)
      {
        component.m_ExtraEffectBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicOnNextSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BattleMagesHeadbandBuff</term><description>2c06b3504c3013e4ba7ea04b1d9201a3</description></item>
    /// <item><term>QuickenedArcanaBuff</term><description>5a62abe6d8de2e24b8834493438b3e23</description></item>
    /// <item><term>UniversalistSchoolReachBuff</term><description>8bc0ae0545e59f14aaef85f064fdc263</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="sourcerousReflex">
    /// <para>
    /// InfoBox: Проверить что заклинание 1ого уровня или на 2 уровня ниже, чем макс. доступный уровень заклинаний
    /// </para>
    /// </param>
    public TBuilder AddMetamagicOnNextSpell(
        bool? doNotRemove = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Metamagic? metamagic = null,
        bool? sourcerousReflex = null)
    {
      var component = new MetamagicOnNextSpell();
      component.DoNotRemove = doNotRemove ?? component.DoNotRemove;
      component.Metamagic = metamagic ?? component.Metamagic;
      component.SourcerousReflex = sourcerousReflex ?? component.SourcerousReflex;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MetamagicRodMechanics"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmberLoveRodBuff</term><description>3123ec8935850514aab8edccf7d8e942</description></item>
    /// <item><term>MetamagicRodLesserPersistentBuff</term><description>9bbbad52b778495dbdc290700663dd90</description></item>
    /// <item><term>SkeletalFingerRodQuickenNormalBuff</term><description>2e03f85b3e759a743b2cae86b687ba4f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilitiesWhiteList">
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
    /// <param name="rodAbility">
    /// <para>
    /// Blueprint of type BlueprintActivatableAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddMetamagicRodMechanics(
        List<Blueprint<BlueprintAbilityReference>>? abilitiesWhiteList = null,
        int? maxSpellLevel = null,
        Metamagic? metamagic = null,
        Blueprint<BlueprintActivatableAbilityReference>? rodAbility = null)
    {
      var component = new MetamagicRodMechanics();
      component.m_AbilitiesWhiteList = abilitiesWhiteList?.Select(bp => bp.Reference)?.ToArray() ?? component.m_AbilitiesWhiteList;
      if (component.m_AbilitiesWhiteList is null)
      {
        component.m_AbilitiesWhiteList = new BlueprintAbilityReference[0];
      }
      component.MaxSpellLevel = maxSpellLevel ?? component.MaxSpellLevel;
      component.Metamagic = metamagic ?? component.Metamagic;
      component.m_RodAbility = rodAbility?.Reference ?? component.m_RodAbility;
      if (component.m_RodAbility is null)
      {
        component.m_RodAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NeutralToFaction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Charm</term><description>9dc29118addce3d48ae9b92be953b5b4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="faction">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
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
    public TBuilder AddNeutralToFaction(
        Blueprint<BlueprintFactionReference>? faction = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new NeutralToFaction();
      component.m_Faction = faction?.Reference ?? component.m_Faction;
      if (component.m_Faction is null)
      {
        component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SpecificSpellDamageBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SpellblastBombBuff</term><description>c783f23e678f71542995c01e36540206</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spell">
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
    public TBuilder AddSpecificSpellDamageBonus(
        int? bonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintAbilityReference>>? spell = null)
    {
      var component = new SpecificSpellDamageBonus();
      component.Bonus = bonus ?? component.Bonus;
      component.m_Spell = spell?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Spell;
      if (component.m_Spell is null)
      {
        component.m_Spell = new BlueprintAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstCaster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DebilitatingInjuryBewilderedEffectBuff</term><description>22b1d98502050cb4cbdb3679ac53115e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddACBonusAgainstCaster(
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextValue? value = null)
    {
      var component = new ACBonusAgainstCaster();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyChallengeBuff</term><description>8cd456875ab94e16a3b51d4c6e9fe7b7</description></item>
    /// <item><term>HalfFiendSmiteGoodBuff</term><description>114af78efc58e5a4c86bb12ee1d907cc</description></item>
    /// <item><term>SmiteEvilBuff_Scabbard</term><description>d0261b79ea01d73418eaf3307352792c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddACBonusAgainstTarget(
        bool? checkCaster = null,
        bool? checkCasterFriend = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextValue? value = null)
    {
      var component = new ACBonusAgainstTarget();
      component.CheckCaster = checkCaster ?? component.CheckCaster;
      component.CheckCasterFriend = checkCasterFriend ?? component.CheckCasterFriend;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimbIfHasFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DefensiveStanceBuff</term><description>3dccdf27a8209af478ac71cded18a271</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkedFact">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
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
    /// <param name="weapon">
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
    public TBuilder AddAdditionalLimbIfHasFact(
        Blueprint<BlueprintFeatureReference>? checkedFact = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintItemWeaponReference>? weapon = null)
    {
      var component = new AddAdditionalLimbIfHasFact();
      component.m_CheckedFact = checkedFact?.Reference ?? component.m_CheckedFact;
      if (component.m_CheckedFact is null)
      {
        component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.m_Weapon = weapon?.Reference ?? component.m_Weapon;
      if (component.m_Weapon is null)
      {
        component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusAbilityValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add stat bonus from ability value
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneAccuracyBuff</term><description>dd2d0de63be31854794c006dc1077294</description></item>
    /// <item><term>CombatExpertiseBuff</term><description>e81cd772a7311554090e413ea28ceea1</description></item>
    /// <item><term>ShatterConfidenceBuff</term><description>14225a2e4561bfd46874c9a4a97e7133</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddStatBonusAbilityValue(
        ModifierDescriptor? descriptor = null,
        StatType? stat = null,
        ContextValue? value = null)
    {
      var component = new AddStatBonusAbilityValue();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Stat = stat ?? component.Stat;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = ContextValues.Constant(0);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstCaster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DebilitatingInjuryDisorientedEffectBuff</term><description>1f1e42f8c06d7dc4bb70cc12c73dfb38</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAttackBonusAgainstCaster(
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextValue? value = null)
    {
      var component = new AttackBonusAgainstCaster();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmySmiteChaosBuff</term><description>61d753b863aa449e85fa34fb0374f071</description></item>
    /// <item><term>FiendishSmiteGoodBuff</term><description>a9035e49d6d79a64eaec321f2cb629a8</description></item>
    /// <item><term>VanguardAlliesStudyTargetBuff</term><description>261d47a0e2df6cf4fa6f02ec2cfb528a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAttackBonusAgainstTarget(
        bool? checkCaster = null,
        bool? checkCasterFriend = null,
        bool? checkRangeType = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        WeaponRangeType? rangeType = null,
        ContextValue? value = null)
    {
      var component = new AttackBonusAgainstTarget();
      component.CheckCaster = checkCaster ?? component.CheckCaster;
      component.CheckCasterFriend = checkCasterFriend ?? component.CheckCasterFriend;
      component.CheckRangeType = checkRangeType ?? component.CheckRangeType;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.RangeType = rangeType ?? component.RangeType;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BuffInvisibility"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DoombringingCreatureInvisibility</term><description>959857c15f0ec984884416b795cad5aa</description></item>
    /// <item><term>OracleRevelationInvisibilityGreaterBuff</term><description>f0fa43e7c8e9fe4489eede5d8d5c885c</description></item>
    /// <item><term>VanishBuff</term><description>e5b7ef8d49215314daaf0404349d42a6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddBuffInvisibility(
        ContextValue? chance = null,
        bool? dispelWithAChance = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notDispellAfterOffensiveAction = null,
        int? stealthBonus = null)
    {
      var component = new BuffInvisibility();
      component.Chance = chance ?? component.Chance;
      if (component.Chance is null)
      {
        component.Chance = ContextValues.Constant(0);
      }
      component.DispelWithAChance = dispelWithAChance ?? component.DispelWithAChance;
      component.NotDispellAfterOffensiveAction = notDispellAfterOffensiveAction ?? component.NotDispellAfterOffensiveAction;
      component.m_StealthBonus = stealthBonus ?? component.m_StealthBonus;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: BuffMechanics/Add Random Stat Penalty
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyDerakniPoisonBuff</term><description>6b18ce2ffdac4d3c93620f7bcee3de1b</description></item>
    /// <item><term>DiseaseMindFireBuff</term><description>2e13b4ac81ae4a745989a0e78a4c44e4</description></item>
    /// <item><term>WyvernPoisonBuff</term><description>b5d9dc8671f8c9c4dab37f0ba52ab9d1</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBuffPoisonStatDamage(
        int? bonus = null,
        ModifierDescriptor? descriptor = null,
        bool? noEffectOnFirstTick = null,
        SavingThrowType? saveType = null,
        StatType? stat = null,
        int? succesfullSaves = null,
        int? ticks = null,
        DiceFormula? value = null)
    {
      var component = new BuffPoisonStatDamage();
      component.Bonus = bonus ?? component.Bonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.NoEffectOnFirstTick = noEffectOnFirstTick ?? component.NoEffectOnFirstTick;
      component.SaveType = saveType ?? component.SaveType;
      component.Stat = stat ?? component.Stat;
      component.SuccesfullSaves = succesfullSaves ?? component.SuccesfullSaves;
      component.Ticks = ticks ?? component.Ticks;
      component.Value = value ?? component.Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamageContext"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: BuffMechanics/Add Random Stat Penalty
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AssassinCreatePoisonAbilityConBuffEffect</term><description>6542e025d84501a41b652bcdc57f6901</description></item>
    /// <item><term>AssassinCreatePoisonAbilityDexBuffEffect</term><description>c766f0606ac12e24e8a9fdb8beabc6c2</description></item>
    /// <item><term>AssassinCreatePoisonAbilityStrBuffEffect</term><description>285290cc80941bc4c97461d6f50aaad9</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBuffPoisonStatDamageContext(
        ContextValue? bonus = null,
        ModifierDescriptor? descriptor = null,
        bool? noEffectOnFirstTick = null,
        SavingThrowType? saveType = null,
        StatType? stat = null,
        ContextValue? succesfullSaves = null,
        ContextValue? ticks = null,
        ContextDiceValue? value = null)
    {
      var component = new BuffPoisonStatDamageContext();
      component.Bonus = bonus ?? component.Bonus;
      if (component.Bonus is null)
      {
        component.Bonus = ContextValues.Constant(0);
      }
      component.Descriptor = descriptor ?? component.Descriptor;
      component.NoEffectOnFirstTick = noEffectOnFirstTick ?? component.NoEffectOnFirstTick;
      component.SaveType = saveType ?? component.SaveType;
      component.Stat = stat ?? component.Stat;
      component.SuccesfullSaves = succesfullSaves ?? component.SuccesfullSaves;
      if (component.SuccesfullSaves is null)
      {
        component.SuccesfullSaves = ContextValues.Constant(0);
      }
      component.Ticks = ticks ?? component.Ticks;
      if (component.Ticks is null)
      {
        component.Ticks = ContextValues.Constant(0);
      }
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = Utils.Constants.Empty.DiceValue;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSleeping"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Sleeping</term><description>5e0cd801bac0e95429bb7e4d1bc61a23</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddBuffSleeping(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? wakeupPerceptionDC = null)
    {
      var component = new BuffSleeping();
      component.WakeupPerceptionDC = wakeupPerceptionDC ?? component.WakeupPerceptionDC;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ControlledProjectileHolder"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BoneSpearProjectileBuff</term><description>a99e1f16c3f614b419e7722ae71a7459</description></item>
    /// <item><term>HasControllableProjectileBuff</term><description>0e92c82297202bd4abac2c5a2ce2f9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddControlledProjectileHolder(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ControlledProjectileHolder();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyChallengeBuff</term><description>8cd456875ab94e16a3b51d4c6e9fe7b7</description></item>
    /// <item><term>FreebootersBaneBuff</term><description>76dabd40a1c1c644c86ce30e41ad5cab</description></item>
    /// <item><term>VanguardAlliesStudyTargetBuff</term><description>261d47a0e2df6cf4fa6f02ec2cfb528a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDamageBonusAgainstTarget(
        bool? applyToSpellDamage = null,
        bool? checkCaster = null,
        bool? checkCasterFriend = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextValue? value = null)
    {
      var component = new DamageBonusAgainstTarget();
      component.ApplyToSpellDamage = applyToSpellDamage ?? component.ApplyToSpellDamage;
      component.CheckCaster = checkCaster ?? component.CheckCaster;
      component.CheckCasterFriend = checkCasterFriend ?? component.CheckCasterFriend;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDR"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmySmiteChaosBuff</term><description>61d753b863aa449e85fa34fb0374f071</description></item>
    /// <item><term>FaithHunterSwornEnemySmiteBuff</term><description>6774a8017c0f8fa4bb14a3dc04276e8b</description></item>
    /// <item><term>StudentOfWarDeadlyBlowBuff</term><description>7795183a0e72ec14cb2e4d51acc53773</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddIgnoreTargetDR(
        bool? checkCaster = null,
        bool? checkCasterFriend = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new IgnoreTargetDR();
      component.CheckCaster = checkCaster ?? component.CheckCaster;
      component.CheckCasterFriend = checkCasterFriend ?? component.CheckCasterFriend;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="OverrideLocoMotion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Anevia_BrokenLeg</term><description>13e59e6d056c3ba4e8b44b9dce3b641a</description></item>
    /// <item><term>Crusader_RamAnimationBuff</term><description>0c8e461902aeccc419092b9897ed1fab</description></item>
    /// <item><term>DLC2_Player_Wounded_Buff</term><description>6f408add25eb4c6ca4d40d7e9f809d62</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddOverrideLocoMotion(
        UnitAnimationActionLocoMotion? locoMotion = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new OverrideLocoMotion();
      Validate(locoMotion);
      component.LocoMotion = locoMotion ?? component.LocoMotion;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RemovedByHeal"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyBloodLustAuraEnemyBuff</term><description>da30e66cd0144a04ab8275666d34254d</description></item>
    /// <item><term>DebilitatingInjuryHamperedEffectBuff</term><description>5bfefc22a68e736488b0c309d9c1c1d4</description></item>
    /// <item><term>Gallu_Buff_RainOfBlood</term><description>1abd01485cd76784f8ca078e80132a76</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRemovedByHeal(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RemovedByHeal();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="HalfOfPairComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HalfOfPairedPendantBuff</term><description>066229a41ae97d6439fea81ebf141528</description></item>
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
    public TBuilder AddHalfOfPairComponent(
        Blueprint<BlueprintBuffReference>? buff = null,
        int? distanceToActivateInFeet = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? sqrDistance = null)
    {
      var component = new HalfOfPairComponent();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_DistanceToActivateInFeet = distanceToActivateInFeet ?? component.m_DistanceToActivateInFeet;
      component.m_SqrDistance = sqrDistance ?? component.m_SqrDistance;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.FxOnStart is null)
      {
        Blueprint.FxOnStart = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.FxOnRemove is null)
      {
        Blueprint.FxOnRemove = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.ResourceAssetIds is null)
      {
        Blueprint.ResourceAssetIds = new string[0];
      }
    }
  }
}

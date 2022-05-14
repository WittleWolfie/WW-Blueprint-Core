//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAbilityAreaEffect"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAbilityAreaEffectConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAbilityAreaEffect
    where TBuilder : BaseAbilityAreaEffectConfigurator<T, TBuilder>
  {
    protected BaseAbilityAreaEffectConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="SpellDescriptorComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abrikandilu_Frozen_Buff</term><description>b2df7031cdad480caddf962c894ca484</description></item>
    /// <item><term>HagboundWitchVileCurseFeebleBodyCast</term><description>90df316c3dd66004f8f7944229369b54</description></item>
    /// <item><term>ZachariusFearAuraBuff</term><description>4d9144b465bbefe4786cfe86c745ea4e</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddSpellDescriptorComponent(
        SpellDescriptorWrapper? descriptor = null)
    {
      var component = new SpellDescriptorComponent();
      component.Descriptor = descriptor ?? component.Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UniqueAreaEffect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CloudBlizzardBlastArea</term><description>6ea87a0ff5df41c459d641326f9973d5</description></item>
    /// <item><term>WallChargedWaterBlastArea</term><description>724d174829a1c1949a4a7ba99cfb06a0</description></item>
    /// <item><term>WallWaterBlastArea</term><description>bb4ddd5e7d64a4a49ba71fe8275d1552</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddUniqueAreaEffect(
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? feature = null)
    {
      var component = new UniqueAreaEffect();
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddComponent(component);
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
    /// <item><term>DeathAttackAbility</term><description>14f11007d016ec94682af6de83959a83</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddContextCalculateAbilityParams(
        ContextValue? casterLevel = null,
        Blueprint<BlueprintUnitProperty, BlueprintUnitPropertyReference>? customProperty = null,
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
      return AddComponent(component);
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
    /// <item><term>PlasmaBlastBladeDamage</term><description>fc22c06d63a95154291272577daa0b4d</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddContextCalculateAbilityParamsBasedOnClass(
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? characterClass = null,
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
      return AddComponent(component);
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
    /// <item><term>JaethalCampBuff</term><description>e9cc770ccca8b73488196e1f508e2675</description></item>
    /// <item><term>WreckingBlowsEffectBuff</term><description>15dd42009de61334692b22fd7a576b79</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddContextCalculateSharedValue(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextRankConfig"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>5_DeadStage_AcidBuff</term><description>96afbbab53c34c549a5313a1f7aed13b</description></item>
    /// <item><term>HellsSealVariantDevouringFlamesBuff</term><description>5617dbbb3890e2f4b96b47318c5c438b</description></item>
    /// <item><term>ZoneOfPredeterminationArea</term><description>1ff4dfed4f7eb504fa0447e93d1bcf64</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="additionalArchetypes">
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="archetype">
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// <param name="buffRankMultiplier">
    /// <para>
    /// InfoBox: Multiplies Buff's Rank before progression calculation.
    /// </para>
    /// </param>
    /// <param name="clazz">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="customProperty">
    /// <para>
    /// Blueprint of type BlueprintUnitProperty. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="customPropertyList">
    /// <para>
    /// Blueprint of type BlueprintUnitProperty. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="feature">
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
    /// <param name="featureList">
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="specificModifier">
    /// <para>
    /// Tooltip: If set to a specific modifier then only bonus from that modifier is used. Use "None" value for bonus from all modifiers.
    /// </para>
    /// </param>
    /// <param name="type">
    /// <para>
    /// Tooltip: Symbolic link to corresponding field in <DealDamage> components. Has no intrinsic meaning
    /// </para>
    /// </param>
    /// <param name="useMax">
    /// <para>
    /// Tooltip: Allows to set maximum value. When calculated result is greater then set maximum, maximum value will be used
    /// </para>
    /// </param>
    /// <param name="useMin">
    /// <para>
    /// Tooltip: Allows to set minimum value. When calculated result is less then set minimum, minumum value will be used
    /// </para>
    /// </param>
    public TBuilder AddContextRankConfig(
        List<Blueprint<BlueprintArchetype, BlueprintArchetypeReference>>? additionalArchetypes = null,
        Blueprint<BlueprintArchetype, BlueprintArchetypeReference>? archetype = null,
        ContextRankBaseValueType? baseValueType = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        int? buffRankMultiplier = null,
        List<Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>>? clazz = null,
        ContextRankConfig.CustomProgressionItem[]? customProgression = null,
        Blueprint<BlueprintUnitProperty, BlueprintUnitPropertyReference>? customProperty = null,
        List<Blueprint<BlueprintUnitProperty, BlueprintUnitPropertyReference>>? customPropertyList = null,
        bool? exceptClasses = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null,
        List<Blueprint<BlueprintFeature, BlueprintFeatureReference>>? featureList = null,
        int? max = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? min = null,
        ContextRankProgression? progression = null,
        ModifierDescriptor? specificModifier = null,
        int? startLevel = null,
        StatType? stat = null,
        int? stepLevel = null,
        AbilityRankType? type = null,
        bool? useMax = null,
        bool? useMin = null)
    {
      var component = new ContextRankConfig();
      component.m_AdditionalArchetypes = additionalArchetypes?.Select(bp => bp.Reference)?.ToArray() ?? component.m_AdditionalArchetypes;
      if (component.m_AdditionalArchetypes is null)
      {
        component.m_AdditionalArchetypes = new BlueprintArchetypeReference[0];
      }
      component.Archetype = archetype?.Reference ?? component.Archetype;
      if (component.Archetype is null)
      {
        component.Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(null);
      }
      component.m_BaseValueType = baseValueType ?? component.m_BaseValueType;
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_BuffRankMultiplier = buffRankMultiplier ?? component.m_BuffRankMultiplier;
      component.m_Class = clazz?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Class;
      if (component.m_Class is null)
      {
        component.m_Class = new BlueprintCharacterClassReference[0];
      }
      foreach (var item in customProgression) { Validate(item); }
      component.m_CustomProgression = customProgression ?? component.m_CustomProgression;
      if (component.m_CustomProgression is null)
      {
        component.m_CustomProgression = new ContextRankConfig.CustomProgressionItem[0];
      }
      component.m_CustomProperty = customProperty?.Reference ?? component.m_CustomProperty;
      if (component.m_CustomProperty is null)
      {
        component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(null);
      }
      component.m_CustomPropertyList = customPropertyList?.Select(bp => bp.Reference)?.ToArray() ?? component.m_CustomPropertyList;
      if (component.m_CustomPropertyList is null)
      {
        component.m_CustomPropertyList = new BlueprintUnitPropertyReference[0];
      }
      component.m_ExceptClasses = exceptClasses ?? component.m_ExceptClasses;
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.m_FeatureList = featureList?.Select(bp => bp.Reference)?.ToArray() ?? component.m_FeatureList;
      if (component.m_FeatureList is null)
      {
        component.m_FeatureList = new BlueprintFeatureReference[0];
      }
      component.m_Max = max ?? component.m_Max;
      component.m_Min = min ?? component.m_Min;
      component.m_Progression = progression ?? component.m_Progression;
      component.m_SpecificModifier = specificModifier ?? component.m_SpecificModifier;
      component.m_StartLevel = startLevel ?? component.m_StartLevel;
      component.m_Stat = stat ?? component.m_Stat;
      component.m_StepLevel = stepLevel ?? component.m_StepLevel;
      component.m_Type = type ?? component.m_Type;
      component.m_UseMax = useMax ?? component.m_UseMax;
      component.m_UseMin = useMin ?? component.m_UseMin;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>HermitKnightBracersFeature</term><description>489fd6aff7ad28d4699718392397fb2e</description></item>
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
      return AddComponent(component);
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
    public TBuilder AddAbilityDifficultyLimitDC()
    {
      return AddComponent(new AbilityDifficultyLimitDC());
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidFogArea</term><description>f4dc3f53090627945b83f16ebf3146a6</description></item>
    /// <item><term>InspireCourageArea</term><description>5d4308fa344af0243b2dd3b1e500b2cc</description></item>
    /// <item><term>ZoneOfPredeterminationArea</term><description>1ff4dfed4f7eb504fa0447e93d1bcf64</description></item>
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
    public TBuilder AddAbilityAreaEffectBuff(
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool? checkConditionEveryRound = null,
        ConditionsBuilder? condition = null)
    {
      var component = new AbilityAreaEffectBuff();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.CheckConditionEveryRound = checkConditionEveryRound ?? component.CheckConditionEveryRound;
      component.Condition = condition?.Build() ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = Utils.Constants.Empty.Conditions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectMovement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CloudkillArea</term><description>6df1ac314d4e6e9418e34470b79f90d8</description></item>
    /// <item><term>PlagueStormCackleFeverArea</term><description>6cae3c64989f3684bb078efcfa9021a1</description></item>
    /// <item><term>TsunamiArea</term><description>800daf41c11463742ad24efd71ab1916</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityAreaEffectMovement(
        Feet? distancePerRound = null)
    {
      var component = new AbilityAreaEffectMovement();
      component.DistancePerRound = distancePerRound ?? component.DistancePerRound;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectRunAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidFogArea</term><description>f4dc3f53090627945b83f16ebf3146a6</description></item>
    /// <item><term>IronGolemCloudArea</term><description>29a6878221001f94f930bdc7e7755469</description></item>
    /// <item><term>ZeorisDaggerRing_BetrayalArea</term><description>ccce3891532741ee91800c01b2304f53</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityAreaEffectRunAction(
        ActionsBuilder? round = null,
        ActionsBuilder? unitEnter = null,
        ActionsBuilder? unitExit = null,
        ActionsBuilder? unitMove = null)
    {
      var component = new AbilityAreaEffectRunAction();
      component.Round = round?.Build() ?? component.Round;
      if (component.Round is null)
      {
        component.Round = Utils.Constants.Empty.Actions;
      }
      component.UnitEnter = unitEnter?.Build() ?? component.UnitEnter;
      if (component.UnitEnter is null)
      {
        component.UnitEnter = Utils.Constants.Empty.Actions;
      }
      component.UnitExit = unitExit?.Build() ?? component.UnitExit;
      if (component.UnitExit is null)
      {
        component.UnitExit = Utils.Constants.Empty.Actions;
      }
      component.UnitMove = unitMove?.Build() ?? component.UnitMove;
      if (component.UnitMove is null)
      {
        component.UnitMove = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectSpecialBehaviour"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DoombringingAura</term><description>9c1c22ea222df984388bc8b803033e10</description></item>
    /// <item><term>TreantAura</term><description>11e046f425592df4db61c31e1429db19</description></item>
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
    public TBuilder AddAbilityAreaEffectSpecialBehaviour(
        SpecialBehaviour? behaviour = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        Buff? buffFact = null,
        int? count = null)
    {
      var component = new AbilityAreaEffectSpecialBehaviour();
      component.Behaviour = behaviour ?? component.Behaviour;
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      Validate(buffFact);
      component.m_BuffFact = buffFact ?? component.m_BuffFact;
      component.m_Count = count ?? component.m_Count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbillityAreaEffectRoundFX"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RuneOfJandelayArea</term><description>b2394fd9423c44a0a8bdb518b66e9266</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbillityAreaEffectRoundFX(
        PrefabLink? prefabLink = null)
    {
      var component = new AbillityAreaEffectRoundFX();
      component.PrefabLink = prefabLink ?? component.PrefabLink;
      if (component.PrefabLink is null)
      {
        component.PrefabLink = Utils.Constants.Empty.PrefabLink;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaEffectPit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidPitArea</term><description>e122151e93e44e0488521aed9e51b617</description></item>
    /// <item><term>PitOfDespairArea</term><description>b905a3c987f22cb49a246f0ab211f34c</description></item>
    /// <item><term>TricksterRecreationalPitArea</term><description>bf68ec704dc186549a7c6fbf22d3d661</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="effectsImmunityFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="evadingImmunityFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="unitOnEdgeBuff">
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
    /// <param name="visualSettings">
    /// <para>
    /// Blueprint of type BlueprintAreaEffectPitVisualSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAreaEffectPit(
        ContextValue? climbDC = null,
        bool? disableClimb = null,
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? effectsImmunityFacts = null,
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? evadingImmunityFacts = null,
        ActionsBuilder? everyRoundAction = null,
        Size? maxUnitSize = null,
        ActionsBuilder? onEndedActionForUnitsInside = null,
        ActionsBuilder? onFallAction = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? unitOnEdgeBuff = null,
        Blueprint<BlueprintAreaEffectPitVisualSettings, BlueprintAreaEffectPitVisualSettingsReference>? visualSettings = null)
    {
      var component = new AreaEffectPit();
      component.ClimbDC = climbDC ?? component.ClimbDC;
      if (component.ClimbDC is null)
      {
        component.ClimbDC = ContextValues.Constant(0);
      }
      component.DisableClimb = disableClimb ?? component.DisableClimb;
      component.m_EffectsImmunityFacts = effectsImmunityFacts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_EffectsImmunityFacts;
      if (component.m_EffectsImmunityFacts is null)
      {
        component.m_EffectsImmunityFacts = new BlueprintUnitFactReference[0];
      }
      component.m_EvadingImmunityFacts = evadingImmunityFacts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_EvadingImmunityFacts;
      if (component.m_EvadingImmunityFacts is null)
      {
        component.m_EvadingImmunityFacts = new BlueprintUnitFactReference[0];
      }
      component.EveryRoundAction = everyRoundAction?.Build() ?? component.EveryRoundAction;
      if (component.EveryRoundAction is null)
      {
        component.EveryRoundAction = Utils.Constants.Empty.Actions;
      }
      component.MaxUnitSize = maxUnitSize ?? component.MaxUnitSize;
      component.OnEndedActionForUnitsInside = onEndedActionForUnitsInside?.Build() ?? component.OnEndedActionForUnitsInside;
      if (component.OnEndedActionForUnitsInside is null)
      {
        component.OnEndedActionForUnitsInside = Utils.Constants.Empty.Actions;
      }
      component.OnFallAction = onFallAction?.Build() ?? component.OnFallAction;
      if (component.OnFallAction is null)
      {
        component.OnFallAction = Utils.Constants.Empty.Actions;
      }
      component.UnitOnEdgeBuff = unitOnEdgeBuff?.Reference ?? component.UnitOnEdgeBuff;
      if (component.UnitOnEdgeBuff is null)
      {
        component.UnitOnEdgeBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_VisualSettings = visualSettings?.Reference ?? component.m_VisualSettings;
      if (component.m_VisualSettings is null)
      {
        component.m_VisualSettings = BlueprintTool.GetRef<BlueprintAreaEffectPitVisualSettingsReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomAreaOnGrid"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmySummonGlabrezu</term><description>7453306a53e94766aad9fa716acaaada</description></item>
    /// <item><term>RangerExplosivesTrapAbility</term><description>8f684342b757e0f47adfb5edaaabc488</description></item>
    /// <item><term>RangerWeakeningTrapArea</term><description>f3c79a96342c37e4d9ec7cbe35dcbda0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="affectedCells">
    /// <para>
    /// InfoBox: In relative coordinates where left-bottom cell is (0, 0)
    /// </para>
    /// </param>
    public TBuilder AddCustomAreaOnGrid(
        List<Vector2Int>? affectedCells = null,
        bool? ignoreObstaclesAndUnits = null,
        bool? spawnFxInEveryCell = null)
    {
      var component = new CustomAreaOnGrid();
      component.AffectedCells = affectedCells ?? component.AffectedCells;
      if (component.AffectedCells is null)
      {
        component.AffectedCells = new();
      }
      component.IgnoreObstaclesAndUnits = ignoreObstaclesAndUnits ?? component.IgnoreObstaclesAndUnits;
      component.SpawnFxInEveryCell = spawnFxInEveryCell ?? component.SpawnFxInEveryCell;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatCellsProviderLink"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyReachingStrikeActivatableAbility</term><description>6e8cad7fbb534154a0b3c83102e37323</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilityWithCellsProvider">
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
    public TBuilder AddTacticalCombatCellsProviderLink(
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? abilityWithCellsProvider = null)
    {
      var component = new TacticalCombatCellsProviderLink();
      component.m_AbilityWithCellsProvider = abilityWithCellsProvider?.Reference ?? component.m_AbilityWithCellsProvider;
      if (component.m_AbilityWithCellsProvider is null)
      {
        component.m_AbilityWithCellsProvider = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatResurrection"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyChannelNegativeEnergyHealAbility</term><description>fe3524be49f748aa80f809778999bf59</description></item>
    /// <item><term>ArmyVampiricTouchOnHitNinjaPirates</term><description>540f87a0ae7d4caaa17596307b3586a6</description></item>
    /// <item><term>RitualJudgementDayAbility</term><description>814a31b50da1434aa9f8622b87157fda</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddTacticalCombatResurrection()
    {
      return AddComponent(new TacticalCombatResurrection());
    }
  }
}

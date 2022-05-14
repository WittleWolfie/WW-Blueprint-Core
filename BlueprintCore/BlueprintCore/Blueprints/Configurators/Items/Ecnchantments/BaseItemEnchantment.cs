//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEnchantmentConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintItemEnchantment
    where TBuilder : BaseItemEnchantmentConfigurator<T, TBuilder>
  {
    protected BaseItemEnchantmentConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// Adds <see cref="ACBonusAgainstFactOwnerEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbyssWalkersEnchantment</term><description>502459ea2f9390745864dbd27ef6677a</description></item>
    /// <item><term>HelmetFullplateCyclopsGroetusEnchantment</term><description>54f2d3e3eb228614fbd47a555d31fdfb</description></item>
    /// <item><term>WhiteKnightCloakEnchantment</term><description>6a37e931c20406e488be6250b5d79a44</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddACBonusAgainstFactOwnerEquipment(
        int? bonus = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? checkedFact = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new ACBonusAgainstFactOwnerEquipment();
      component.Bonus = bonus ?? component.Bonus;
      component.m_CheckedFact = checkedFact?.Reference ?? component.m_CheckedFact;
      if (component.m_CheckedFact is null)
      {
        component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.Descriptor = descriptor ?? component.Descriptor;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Caster level bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcerbicRingEnchant</term><description>b8549618404bfd648ac38e6d9f4927f4</description></item>
    /// <item><term>BlessedHandsGlovesEnchant</term><description>46bc0f2392ef2a040af9d27f325626d3</description></item>
    /// <item><term>DeathbedServantEnchantment</term><description>6cca68e0ac90e7c45a7fa0a19879f545</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="spell">
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
    public TBuilder AddCasterLevelEquipment(
        int? bonus = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? spell = null)
    {
      var component = new AddCasterLevelEquipment();
      component.Bonus = bonus ?? component.Bonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_Spell = spell?.Reference ?? component.m_Spell;
      if (component.m_Spell is null)
      {
        component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddConditionImmunityEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Add condition immunity
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneProtectorEnchant</term><description>d3118dd2796883645a56c888880ecfba</description></item>
    /// <item><term>PermanentFreedomHoldImmun</term><description>1bc0bb7cef5ee4c4c81294ead983dbf3</description></item>
    /// <item><term>StabilityStanceEnhancement5</term><description>a1a88d4009945de47922944ebbece28d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddConditionImmunityEquipment(
        UnitCondition? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AddConditionImmunityEquipment();
      component.Condition = condition ?? component.Condition;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmagsBladeSpellsEnchant</term><description>379d6169631ca244fab1df99830cec5d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="spellbook">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSpellbookEquipment(
        int? casterLevel = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>? spellbook = null)
    {
      var component = new AddSpellbookEquipment();
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      component.m_Spellbook = spellbook?.Reference ?? component.m_Spellbook;
      if (component.m_Spellbook is null)
      {
        component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Stat bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ALR_GlovesEnchantment</term><description>2b6a3d0a74d740faa06a2e0ad266b4a9</description></item>
    /// <item><term>HelmetNobleEnchantment</term><description>7af296090755c7b4e9758e22097a3142</description></item>
    /// <item><term>WoundBearerAthletic5</term><description>1eac86bba153a204395fadcbb991b95c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddStatBonusEquipment(
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        StatType? stat = null,
        int? value = null)
    {
      var component = new AddStatBonusEquipment();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Stat = stat ?? component.Stat;
      component.Value = value ?? component.Value;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusEquipmentUnlessEnchant"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Stat bonus
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MovementSpeedPenalty</term><description>d89a972aff5ea224db0ac73cd04422cf</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkedEnchantment">
    /// <para>
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
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
    public TBuilder AddStatBonusEquipmentUnlessEnchant(
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? checkedEnchantment = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        StatType? stat = null,
        int? value = null)
    {
      var component = new AddStatBonusEquipmentUnlessEnchant();
      component.m_CheckedEnchantment = checkedEnchantment?.Reference ?? component.m_CheckedEnchantment;
      if (component.m_CheckedEnchantment is null)
      {
        component.m_CheckedEnchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(null);
      }
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Stat = stat ?? component.Stat;
      component.Value = value ?? component.Value;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddUnitFactEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlchemistsClothEnchantment</term><description>5ac1350dbddabd745baad8170d4e9c05</description></item>
    /// <item><term>HerbalRingEnchantment</term><description>bc5c63a3270c9f542b94c16f4a359347</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningEnchantment</term><description>2a4e61dcd2b74da3b742e1e67837b825</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprint">
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddUnitFactEquipment(
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? blueprint = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AddUnitFactEquipment();
      component.m_Blueprint = blueprint?.Reference ?? component.m_Blueprint;
      if (component.m_Blueprint is null)
      {
        component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddUnitFeatureEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2DCagainstNecroticPlus2Enchant</term><description>0bc09adac665a7647b39ca76b897ddd5</description></item>
    /// <item><term>HeadbandOfSubjugatorEnchantment</term><description>b63c8c303b673864eb14c13740ae2b63</description></item>
    /// <item><term>ZeorisDaggerHeadband_GoverningEnchantment</term><description>fe29f7cf83a7449282b7f97d541dc575</description></item>
    /// </list>
    /// </remarks>
    ///
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddUnitFeatureEquipment(
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AddUnitFeatureEquipment();
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFactOwnerEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Attack bonus against fact owner
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ButcherOfUndeadEnchantment</term><description>97052dac8d5eb6742a2f6a4e5c02289d</description></item>
    /// <item><term>EternalHunter</term><description>8c663b3511c9f854ab69b2d51f0fca50</description></item>
    /// <item><term>MonsterHunterFirstEnchantment</term><description>8d3823c8ab9e0d74bab9ff9e2269d42a</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddAttackBonusAgainstFactOwnerEquipment(
        int? attackBonus = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? checkedFact = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AttackBonusAgainstFactOwnerEquipment();
      component.AttackBonus = attackBonus ?? component.AttackBonus;
      component.m_CheckedFact = checkedFact?.Reference ?? component.m_CheckedFact;
      if (component.m_CheckedFact is null)
      {
        component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.Descriptor = descriptor ?? component.Descriptor;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstFactOwnerEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Damage bonus against fact owner
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlackKnightCloakEnchantment</term><description>1ad2e26850bfef7409199c2fa23e1fa3</description></item>
    /// <item><term>FinalPacifierEnchantment</term><description>b5325493e73e6834391218b932567e2b</description></item>
    /// <item><term>PatchworkHide</term><description>f7d08bc5e5182ab4bb500681196cc3d6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkedFact">
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddDamageBonusAgainstFactOwnerEquipment(
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? checkedFact = null,
        int? damageBonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new DamageBonusAgainstFactOwnerEquipment();
      component.m_CheckedFact = checkedFact?.Reference ?? component.m_CheckedFact;
      if (component.m_CheckedFact is null)
      {
        component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.DamageBonus = damageBonus ?? component.DamageBonus;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="IgnoreResistanceForDamageFromEnchantment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ElderBrass</term><description>0a8f3559cfcc4d38961bd9658d026cc8</description></item>
    /// <item><term>ElderFrost</term><description>c9c2580b9b6c43e992acae157615deb5</description></item>
    /// <item><term>ElderShockingBurst</term><description>a30a16ee048e4d1fb186c5cf4a0984b0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddIgnoreResistanceForDamageFromEnchantment(
        IgnoreResistanceForDamageFromEnchantment.IgnoreType? type = null)
    {
      var component = new IgnoreResistanceForDamageFromEnchantment();
      component.m_Type = type ?? component.m_Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseMaxStatEnchantment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Increase max stat
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>VellexiasMagnifyingAmuletEnchantment</term><description>10dc2a5b8d834dc5937fc7f37186dfc3</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddIncreaseMaxStatEnchantment(
        int? value = null)
    {
      var component = new IncreaseMaxStatEnchantment();
      component.Value = value ?? component.Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseStatEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Increase stat
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SneakAttack1</term><description>00bd514cdf5195f49be17d1313156636</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddIncreaseStatEquipment(
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        StatType? stat = null,
        int? value = null)
    {
      var component = new IncreaseStatEquipment();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Stat = stat ?? component.Stat;
      component.Value = value ?? component.Value;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MithralEnchantment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MithralArmorEnchant</term><description>7b95a819181574a4799d93939aa99aff</description></item>
    /// <item><term>SingingSteelEnchant</term><description>451601816a45311419b77b83f253b75b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddMithralEnchantment(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new MithralEnchantment();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PreventAbilityInterruption"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ChainshirtOfBrightPerformanceEnchantment</term><description>31cac1cb3a674ca18bd84ce0235ab0df</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilities">
    /// <para>
    /// Blueprint of type BlueprintActivatableAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddPreventAbilityInterruption(
        List<Blueprint<BlueprintActivatableAbility, BlueprintActivatableAbilityReference>>? abilities = null)
    {
      var component = new PreventAbilityInterruption();
      component.m_Abilities = abilities?.Select(bp => bp.Reference)?.ToList() ?? component.m_Abilities;
      if (component.m_Abilities is null)
      {
        component.m_Abilities = new();
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeAttackEnchant"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Type Attack Enchant
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BombAttack2</term><description>22cef8e691a75674d8bc33ea986ea4fa</description></item>
    /// <item><term>OverwhelmingSoulOverwhelmingPowerFeature</term><description>6c24bf7cc2266f24f9b0c652799f1d91</description></item>
    /// <item><term>TouchEnchant2</term><description>2431f5f8d2ffe854784429b989d1e8a3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="type">
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
    public TBuilder AddWeaponTypeAttackEnchant(
        int? bonus = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintWeaponType, BlueprintWeaponTypeReference>? type = null)
    {
      var component = new WeaponTypeAttackEnchant();
      component.Bonus = bonus ?? component.Bonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_Type = type?.Reference ?? component.m_Type;
      if (component.m_Type is null)
      {
        component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Crusade.GlobalMagic.Actions;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Prerequisites;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFeature"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFeatureConfigurator<T, TBuilder>
    : BaseFeatureBaseConfigurator<T, TBuilder>
    where T : BlueprintFeature
    where TBuilder : BaseFeatureConfigurator<T, TBuilder>
  {
    protected BaseFeatureConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// <item><term>AbyssalSkinBuff</term><description>4b51d5e45b4fcce47b84b451068f3fcf</description></item>
    /// <item><term>HandlingTheCrowdEffectBuff</term><description>b0b0edfbbc951ac4da69c5caa81cf19e</description></item>
    /// <item><term>XantirOnlySwarm_MidnightFaneInThePastACFeature</term><description>5c0ef576cc68f374c96a0070fd3b047c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddContextStatBonus(
        StatType stat,
        ContextValue value,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextRankConfig"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Use <see cref="ContextRankConfigs"/> to create the ContextRankConfig component.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>5_DeadStage_AcidBuff</term><description>96afbbab53c34c549a5313a1f7aed13b</description></item>
    /// <item><term>HellsSealVariantDevouringFlamesBuff</term><description>5617dbbb3890e2f4b96b47318c5c438b</description></item>
    /// <item><term>ZoneOfPredeterminationArea</term><description>1ff4dfed4f7eb504fa0447e93d1bcf64</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextRankConfig(ContextRankConfig component)
    {
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGlobalMapSpellFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GlobalSpellAeonTimeManipulationFeature</term><description>60cdaaa1492d45cbb05dfbad44f04486</description></item>
    /// <item><term>GlobalSpellDragonPowerOfGoldFeature</term><description>89095749e42748dc86fb741738e74b91</description></item>
    /// <item><term>GlobalSpellTricksterMassHideousLaughterFeature</term><description>a6ebcb784f3b40ed8f092845455db562</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spell">
    /// <para>
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddGlobalMapSpellFeature(
        Blueprint<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference>? spell = null)
    {
      var component = new AddGlobalMapSpellFeature();
      component.m_Spell = spell?.Reference ?? component.m_Spell;
      if (component.m_Spell is null)
      {
        component.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FeatureSurvivesRespec"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LateMythicRespecFeature</term><description>67e436d11f5e4e40919bc84d425d8c37</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddFeatureSurvivesRespec()
    {
      return AddComponent(new FeatureSurvivesRespec());
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
    /// Adds <see cref="PrerequisiteAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbadarFeature</term><description>6122dacf418611540a3c91e67197ee4e</description></item>
    /// <item><term>GozrehFeature</term><description>4af983eec2d821b40a3065eb5e8c3a72</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisiteAlignment(
        AlignmentMaskType? alignment = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteAlignment();
      component.Alignment = alignment ?? component.Alignment;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteArchetypeLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneTricksterArcanistEldritchFont</term><description>a732797826db0b54ea123d91b4cdaad5</description></item>
    /// <item><term>HellknightSigniferSwordSaint</term><description>7f7acf3e53b7b6240a93c634b2c02926</description></item>
    /// <item><term>WreckingBlowsFeature</term><description>5bccc86dd1f187a4a99f092dc054c755</description></item>
    /// </list>
    /// </remarks>
    ///
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisiteArchetypeLevel(
        Blueprint<BlueprintArchetype, BlueprintArchetypeReference>? archetype = null,
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? characterClass = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        int? level = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new PrerequisiteArchetypeLevel();
      component.m_Archetype = archetype?.Reference ?? component.m_Archetype;
      if (component.m_Archetype is null)
      {
        component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(null);
      }
      component.m_CharacterClass = characterClass?.Reference ?? component.m_CharacterClass;
      if (component.m_CharacterClass is null)
      {
        component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.Level = level ?? component.Level;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteCasterType"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisiteCasterType(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isArcane = null)
    {
      var component = new PrerequisiteCasterType();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsArcane = isArcane ?? component.IsArcane;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteCasterTypeSpellLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneTricksterClass</term><description>9c935a076d4fe4d4999fd48d853e3cf3</description></item>
    /// <item><term>LoremasterClass</term><description>4a7c05adfbaf05446a6bf664d28fb103</description></item>
    /// <item><term>WinterWitchClass</term><description>eb24ca44debf6714aabe1af1fd905a07</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isArcane">
    /// <para>
    /// InfoBox: Mythic & Alchemist Spellbooks don't cound
    /// </para>
    /// </param>
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisiteCasterTypeSpellLevel(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isArcane = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? onlySpontaneous = null,
        int? requiredSpellLevel = null)
    {
      var component = new PrerequisiteCasterTypeSpellLevel();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsArcane = isArcane ?? component.IsArcane;
      component.OnlySpontaneous = onlySpontaneous ?? component.OnlySpontaneous;
      component.RequiredSpellLevel = requiredSpellLevel ?? component.RequiredSpellLevel;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteCharacterLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlindingStrike</term><description>fd01c15d9e74cd247b1fdbd6eb4d4713</description></item>
    /// <item><term>FeatureWingsAngel</term><description>d9bd0fde6deb2e44a93268f2dfb3e169</description></item>
    /// <item><term>MurmursOfEarth</term><description>94be54cd152d1c94396754de7bf0105f</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisiteCharacterLevel(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        int? level = null)
    {
      var component = new PrerequisiteCharacterLevel();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.Level = level ?? component.Level;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteClassLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdvancedWeaponTraining1</term><description>3aa4cbdd4af5ba54888b0dc7f07f80c4</description></item>
    /// <item><term>OracleRevelationSoulSiphon</term><description>226c053a75fd7c34cab1b493f5847787</description></item>
    /// <item><term>WreckingBlowsFeature</term><description>5bccc86dd1f187a4a99f092dc054c755</description></item>
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisiteClassLevel(
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? characterClass = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        int? level = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? not = null)
    {
      var component = new PrerequisiteClassLevel();
      component.m_CharacterClass = characterClass?.Reference ?? component.m_CharacterClass;
      if (component.m_CharacterClass is null)
      {
        component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.Level = level ?? component.Level;
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteClassSpellLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneTricksterArcanist</term><description>7cab956d45dc51c4ea9e71bba366a250</description></item>
    /// <item><term>HellknightSigniferThassilonianEvocation</term><description>f8ed1800725b3e74ebb86783dbde933a</description></item>
    /// <item><term>WinterWitchWitchLeyLineGuardian</term><description>56adf819599827f4695395924a060996</description></item>
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
    public TBuilder AddPrerequisiteClassSpellLevel(
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? characterClass = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        int? requiredSpellLevel = null)
    {
      var component = new PrerequisiteClassSpellLevel();
      component.m_CharacterClass = characterClass?.Reference ?? component.m_CharacterClass;
      if (component.m_CharacterClass is null)
      {
        component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.RequiredSpellLevel = requiredSpellLevel ?? component.RequiredSpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>GoldenDragonClass</term><description>daf1235b6217787499c14e4e32142523</description></item>
    /// <item><term>SwarmThatWalksClass</term><description>5295b8e13c2303f4c88bdb3d7760a757</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisiteCondition(
        bool? checkInProgression = null,
        Condition? condition = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        LocalizedString? uIText = null)
    {
      var component = new PrerequisiteCondition();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.UIText = uIText ?? component.UIText;
      if (component.UIText is null)
      {
        component.UIText = Utils.Constants.Empty.String;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteEtude"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>FakeLegendClass</term><description>b82f1fbd191e1f2498266ca41f05027f</description></item>
    /// <item><term>TricksterMythicClass</term><description>8df873a8c6e48294abdb78c45834aa0a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="etude">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
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
    public TBuilder AddPrerequisiteEtude(
        bool? checkInProgression = null,
        Blueprint<BlueprintEtude, BlueprintEtudeReference>? etude = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? notPlaying = null,
        LocalizedString? uIText = null)
    {
      var component = new PrerequisiteEtude();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Etude = etude?.Reference ?? component.Etude;
      if (component.Etude is null)
      {
        component.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.NotPlaying = notPlaying ?? component.NotPlaying;
      component.UIText = uIText ?? component.UIText;
      if (component.UIText is null)
      {
        component.UIText = Utils.Constants.Empty.String;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbundantArcanePool</term><description>8acebba92ada26043873cae5b92cef7b</description></item>
    /// <item><term>MagicBlessingFeature</term><description>1754ff61a0805714fa2b89c8c1bb87ad</description></item>
    /// <item><term>WreckingBlowsFeature</term><description>5bccc86dd1f187a4a99f092dc054c755</description></item>
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
    public TBuilder AddPrerequisiteFeature(
        bool? checkInProgression = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new PrerequisiteFeature();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFeaturesFromList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AerialAdaptationFeature</term><description>c8719b3c5c0d4694cb13abcc3b7e893b</description></item>
    /// <item><term>LoremasterWizardSecretSorcerer</term><description>a26834acd0f797c4e948660f4eb6ccd9</description></item>
    /// <item><term>WinterWitchWitchHexSelection</term><description>b921af3627142bd4d9cf3aefb5e2610a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="features">
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
    public TBuilder AddPrerequisiteFeaturesFromList(
        int? amount = null,
        bool? checkInProgression = null,
        List<Blueprint<BlueprintFeature, BlueprintFeatureReference>>? features = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new PrerequisiteFeaturesFromList();
      component.Amount = amount ?? component.Amount;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Features;
      if (component.m_Features is null)
      {
        component.m_Features = new BlueprintFeatureReference[0];
      }
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteIsPet"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlchemistClass</term><description>0937bec61c0dabc468428f496580c721</description></item>
    /// <item><term>InquisitorClass</term><description>f1a70d9e1b0b41e49874e1fa9052a1ce</description></item>
    /// <item><term>WizardClass</term><description>ba34257984f4c41408ce1dc2004e342e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisiteIsPet(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? not = null)
    {
      var component = new PrerequisiteIsPet();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteMainCharacter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>GoldenDragonClass</term><description>daf1235b6217787499c14e4e32142523</description></item>
    /// <item><term>TricksterMythicClass</term><description>8df873a8c6e48294abdb78c45834aa0a</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisiteMainCharacter(
        bool? checkInProgression = null,
        bool? companion = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteMainCharacter();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Companion = companion ?? component.Companion;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteMythicLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DevilMythicClass</term><description>211f49705f478b3468db6daa802452a2</description></item>
    /// <item><term>GoldenDragonClass</term><description>daf1235b6217787499c14e4e32142523</description></item>
    /// <item><term>SwarmThatWalksClass</term><description>5295b8e13c2303f4c88bdb3d7760a757</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisiteMythicLevel(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        int? level = null)
    {
      var component = new PrerequisiteMythicLevel();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.Level = level ?? component.Level;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoArchetype"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbadarFeature</term><description>6122dacf418611540a3c91e67197ee4e</description></item>
    /// <item><term>BloodlineSerpentineSpellLevel7</term><description>7b442d746153bad49b855226b9e0b64e</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
    /// </list>
    /// </remarks>
    ///
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisiteNoArchetype(
        Blueprint<BlueprintArchetype, BlueprintArchetypeReference>? archetype = null,
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? characterClass = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new PrerequisiteNoArchetype();
      component.m_Archetype = archetype?.Reference ?? component.m_Archetype;
      if (component.m_Archetype is null)
      {
        component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(null);
      }
      component.m_CharacterClass = characterClass?.Reference ?? component.m_CharacterClass;
      if (component.m_CharacterClass is null)
      {
        component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoClassLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>GozrehFeature</term><description>4af983eec2d821b40a3065eb5e8c3a72</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisiteNoClassLevel(
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? characterClass = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new PrerequisiteNoClassLevel();
      component.m_CharacterClass = characterClass?.Reference ?? component.m_CharacterClass;
      if (component.m_CharacterClass is null)
      {
        component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AccomplishedSneakAttacker</term><description>9f0187869dc23744292c0e5bb364464e</description></item>
    /// <item><term>HealingDomainProgressionSecondary</term><description>599fb0d60358c354d8c5c4304a73e19a</description></item>
    /// <item><term>WolfScarredFaceCurseNoPenaltyProgression</term><description>b6c775555bade694e8b8c7e82c7a71fb</description></item>
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
    public TBuilder AddPrerequisiteNoFeature(
        bool? checkInProgression = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new PrerequisiteNoFeature();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNotProficient"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BastardSwordProficiency</term><description>57299a78b2256604dadf1ab9a42e2873</description></item>
    /// <item><term>LightArmorProficiency</term><description>6d3728d4e9c9898458fe5e9532951132</description></item>
    /// <item><term>UrgroshProficiency</term><description>d24f7545b1aa3b34e8216f8cb3140563</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisiteNotProficient(
        ArmorProficiencyGroup[]? armorProficiencies = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        WeaponCategory[]? weaponProficiencies = null)
    {
      var component = new PrerequisiteNotProficient();
      component.ArmorProficiencies = armorProficiencies ?? component.ArmorProficiencies;
      if (component.ArmorProficiencies is null)
      {
        component.ArmorProficiencies = new ArmorProficiencyGroup[0];
      }
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.WeaponProficiencies = weaponProficiencies ?? component.WeaponProficiencies;
      if (component.WeaponProficiencies is null)
      {
        component.WeaponProficiencies = new WeaponCategory[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AugmentSummoning</term><description>38155ca9e4055bb48a89240a2055dcc3</description></item>
    /// <item><term>DuelingMastery</term><description>c3a66c1bbd2fb65498b130802d5f183a</description></item>
    /// <item><term>SwordlordClass</term><description>90e4d7da3ccd1a8478411e07e91d5750</description></item>
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
    public TBuilder AddPrerequisiteParametrizedFeature(
        bool? checkInProgression = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        FeatureParameterType? parameterType = null,
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? spell = null,
        SpellSchool? spellSchool = null,
        WeaponCategory? weaponCategory = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.ParameterType = parameterType ?? component.ParameterType;
      component.m_Spell = spell?.Reference ?? component.m_Spell;
      if (component.m_Spell is null)
      {
        component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      component.SpellSchool = spellSchool ?? component.SpellSchool;
      component.WeaponCategory = weaponCategory ?? component.WeaponCategory;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedWeaponSubcategory"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FencingGrace</term><description>47b352ea0f73c354aba777945760b441</description></item>
    /// <item><term>PointBlankMaster</term><description>05a3b543b0a0a0346a5061e90f293f0b</description></item>
    /// <item><term>SlashingGrace</term><description>697d64669eb2c0543abb9c9b07998a38</description></item>
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
    public TBuilder AddPrerequisiteParametrizedWeaponSubcategory(
        bool? checkInProgression = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        WeaponSubCategory? subCategory = null)
    {
      var component = new PrerequisiteParametrizedWeaponSubcategory();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.SubCategory = subCategory ?? component.SubCategory;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisitePet"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalCompanionEmptyCompanion</term><description>472091361cf118049a2b4339c4ea836a</description></item>
    /// <item><term>AnimalCompanionFeatureLeopard</term><description>2ee2ba60850dd064e8b98bf5c2c946ba</description></item>
    /// <item><term>MythicalBeastMaster</term><description>89096871a6fdadd43ad31f5046696727</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisitePet(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? noCompanion = null,
        PetType? type = null)
    {
      var component = new PrerequisitePet();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.NoCompanion = noCompanion ?? component.NoCompanion;
      component.Type = type ?? component.Type;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisitePlayerHasFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CompletelyNormalSpellFeat</term><description>094b6278f7b570f42aeaa98379f07cf2</description></item>
    /// <item><term>TricksterImprovedImprovedImprovedCritical</term><description>006a966007802a0478c9e21007207aac</description></item>
    /// <item><term>TricksterStatFocusFeatSelection</term><description>0d1d80bd3820a78488412581da3ad9c7</description></item>
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
    public TBuilder AddPrerequisitePlayerHasFeature(
        bool? checkInProgression = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new PrerequisitePlayerHasFeature();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteProficiency"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmorFocusHeavy</term><description>c27e6d2b0d33d42439f512c6d9a6a601</description></item>
    /// <item><term>HellknightClass</term><description>ed246f1680e667b47b7427d51e651059</description></item>
    /// <item><term>SwordlordClass</term><description>90e4d7da3ccd1a8478411e07e91d5750</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisiteProficiency(
        ArmorProficiencyGroup[]? armorProficiencies = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        WeaponCategory[]? weaponProficiencies = null)
    {
      var component = new PrerequisiteProficiency();
      component.ArmorProficiencies = armorProficiencies ?? component.ArmorProficiencies;
      if (component.ArmorProficiencies is null)
      {
        component.ArmorProficiencies = new ArmorProficiencyGroup[0];
      }
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.WeaponProficiencies = weaponProficiencies ?? component.WeaponProficiencies;
      if (component.WeaponProficiencies is null)
      {
        component.WeaponProficiencies = new WeaponCategory[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteStatValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlliedSpellcaster</term><description>9093ceeefe9b84746a5993d619d7c86f</description></item>
    /// <item><term>ImprovedCriticalKukri</term><description>45482376f0d543a4d9ba1aa6b78c9c0a</description></item>
    /// <item><term>WinterWitchClass</term><description>eb24ca44debf6714aabe1af1fd905a07</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisiteStatValue(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        StatType? stat = null,
        int? value = null)
    {
      var component = new PrerequisiteStatValue();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.Stat = stat ?? component.Stat;
      component.Value = value ?? component.Value;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddFeaturesFromSelectionToDescription"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LoremasterSecretSelection</term><description>beeb25d7a7732e14f9986cdb79acecfc</description></item>
    /// <item><term>ShamanBonesSpiritWanderingProgression</term><description>004eb31f1217d444b91a5404f3c0a385</description></item>
    /// <item><term>ShamanWindSpiritWanderingProgression</term><description>11a92d0a44576e4439b745ab00f298b5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="featureSelection">
    /// <para>
    /// Blueprint of type BlueprintFeatureSelection. You can pass in the blueprint using:
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
    public TBuilder AddFeaturesFromSelectionToDescription(
        Blueprint<BlueprintFeatureSelection, BlueprintFeatureSelectionReference>? featureSelection = null,
        LocalizedString? introduction = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? onlyIfRequiresThisFeature = null)
    {
      var component = new AddFeaturesFromSelectionToDescription();
      component.m_FeatureSelection = featureSelection?.Reference ?? component.m_FeatureSelection;
      if (component.m_FeatureSelection is null)
      {
        component.m_FeatureSelection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(null);
      }
      component.Introduction = introduction ?? component.Introduction;
      if (component.Introduction is null)
      {
        component.Introduction = Utils.Constants.Empty.String;
      }
      component.OnlyIfRequiresThisFeature = onlyIfRequiresThisFeature ?? component.OnlyIfRequiresThisFeature;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddLocustSwarmMechanicPart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HostFeature</term><description>4cb605c6099397d41ab91ad6dd43a5e7</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddLocustSwarmMechanicPart(
        int? swarmStartStrength = null)
    {
      var component = new AddLocustSwarmMechanicPart();
      component.m_SwarmStartStrength = swarmStartStrength ?? component.m_SwarmStartStrength;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMagusMechanicPart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Counterstrike</term><description>cd96b7275c206da4899c69ae127ffda6</description></item>
    /// <item><term>EldritchWandWielder</term><description>83ca7d2b7ae56354b96148caa1c3f3de</description></item>
    /// <item><term>WandWielder</term><description>5826562b74d529e41af2d60feeca093d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddMagusMechanicPart(
        AddMagusMechanicPart.Feature? feature = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AddMagusMechanicPart();
      component.m_Feature = feature ?? component.m_Feature;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddNocticulaBonus(
        ModifierDescriptor? descriptor = null,
        StatType? highestStat = null,
        ContextValue? highestStatBonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
    public TBuilder AddRestTrigger(
        ActionsBuilder? action = null)
    {
      var component = new AddRestTrigger();
      component.Action = action?.Build() ?? component.Action;
      if (component.Action is null)
      {
        component.Action = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellsToDescription"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>OracleAncestorsSpells</term><description>a5d8db569c9c62042b1f35d68ed31232</description></item>
    /// <item><term>ShamanNatureSpiritWanderingProgression</term><description>f3e19b0d6d82e2a4d98957af591f5d36</description></item>
    /// <item><term>WitchWinterPatronProgression</term><description>e98d8d9f907c1814aa7376d6cdaac012</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="spellLists">
    /// <para>
    /// Blueprint of type BlueprintSpellList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    public TBuilder AddSpellsToDescription(
        LocalizedString? introduction = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        List<Blueprint<BlueprintSpellList, BlueprintSpellListReference>>? spellLists = null,
        List<Blueprint<BlueprintAbility, BlueprintAbilityReference>>? spells = null)
    {
      var component = new AddSpellsToDescription();
      component.Introduction = introduction ?? component.Introduction;
      if (component.Introduction is null)
      {
        component.Introduction = Utils.Constants.Empty.String;
      }
      component.m_SpellLists = spellLists?.Select(bp => bp.Reference)?.ToArray() ?? component.m_SpellLists;
      if (component.m_SpellLists is null)
      {
        component.m_SpellLists = new BlueprintSpellListReference[0];
      }
      component.m_Spells = spells?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Spells;
      if (component.m_Spells is null)
      {
        component.m_Spells = new BlueprintAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddTricksterAthleticBonus(
        ModifierDescriptor? descriptor = null,
        bool? isAdded = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AddTricksterAthleticBonus();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_IsAdded = isAdded ?? component.m_IsAdded;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddWeaponEnhancementBonusToStat(
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? multiplier = null,
        StatType? stat = null)
    {
      var component = new AddWeaponEnhancementBonusToStat();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Multiplier = multiplier ?? component.Multiplier;
      component.Stat = stat ?? component.Stat;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    public TBuilder AddMountedShield(
        ModifierDescriptor? descriptor = null,
        StatType? stat = null)
    {
      var component = new MountedShield();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Stat = stat ?? component.Stat;
      return AddComponent(component);
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="upgradeFeature">
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
    public TBuilder AddShroudOfWater(
        ContextValue? baseValue = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        StatType? stat = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? upgradeFeature = null)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddDispelMagicSuccessTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DestructiveDispel</term><description>d298e64e14398e848a54db5a2619ba42</description></item>
    /// <item><term>DispelSynergy</term><description>f3e3e29608ba07844ab3cafc4c8e4343</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="triggerOnAreaEffectsDispell">
    /// <para>
    /// InfoBox: Use this bool if you want to trigger action on a caster of an AOE effect. Eg: Ember cast Grease, Nenio dispells it -> Ember is target, hence received 1d6 damage 
    /// </para>
    /// </param>
    public TBuilder AddDispelMagicSuccessTrigger(
        ActionsBuilder? actionOnTarget = null,
        bool? triggerOnAreaEffectsDispell = null)
    {
      var component = new AddDispelMagicSuccessTrigger();
      component.ActionOnTarget = actionOnTarget?.Build() ?? component.ActionOnTarget;
      if (component.ActionOnTarget is null)
      {
        component.ActionOnTarget = Utils.Constants.Empty.Actions;
      }
      component.TriggerOnAreaEffectsDispell = triggerOnAreaEffectsDispell ?? component.TriggerOnAreaEffectsDispell;
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
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PureRecommendation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BashingFinish</term><description>0b442a7b4aa598d4e912a4ecee0500ff</description></item>
    /// <item><term>GreaterSunder</term><description>54d824028117e884a8f9356c7c66149b</description></item>
    /// <item><term>TwoWeaponFightingImproved</term><description>9af88f3ed8a017b45a6837eab7437629</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPureRecommendation(
        RecommendationPriority? priority = null)
    {
      var component = new PureRecommendation();
      component.Priority = priority ?? component.Priority;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationAccomplishedSneakAttacker"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AccomplishedSneakAttacker</term><description>9f0187869dc23744292c0e5bb364464e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddRecommendationAccomplishedSneakAttacker(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new RecommendationAccomplishedSneakAttacker();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// <item><term>PowerAttackFeature</term><description>9972f33f977fc724c838e59641b2fca5</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRecommendationBaseAttackPart(
        float? minPart = null,
        bool? notRecommendIfHigher = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.MinPart = minPart ?? component.MinPart;
      component.NotRecommendIfHigher = notRecommendIfHigher ?? component.NotRecommendIfHigher;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationCompanionBoon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CompanionBoon</term><description>8fc01f06eab4dd946baa5bc658cac556</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companionRank">
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
    public TBuilder AddRecommendationCompanionBoon(
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? companionRank = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new RecommendationCompanionBoon();
      component.m_CompanionRank = companionRank?.Reference ?? component.m_CompanionRank;
      if (component.m_CompanionRank is null)
      {
        component.m_CompanionRank = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationHasFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AgileManeuvers</term><description>197306972c98bb843af738dc7529a7ac</description></item>
    /// <item><term>ShieldBashFeature</term><description>121811173a614534e8720d7550aae253</description></item>
    /// <item><term>WeaponSpecializationGreater</term><description>7cf5edc65e785a24f9cf93af987d66b3</description></item>
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddRecommendationHasFeature(
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? feature = null,
        bool? mandatory = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new RecommendationHasFeature();
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.Mandatory = mandatory ?? component.Mandatory;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationNoFeatFromGroup"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidArrow</term><description>9a46dfd390f943647ab4395fc997936d</description></item>
    /// <item><term>HoldPersonMass</term><description>defbbeaef79eda64abc645036228a31b</description></item>
    /// <item><term>WhiteMageCureLightWoundsCast</term><description>83d6d8f4c4d296941838086f60485fb7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="features">
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
    public TBuilder AddRecommendationNoFeatFromGroup(
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? features = null,
        bool? goodIfNoFeature = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new RecommendationNoFeatFromGroup();
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Features;
      if (component.m_Features is null)
      {
        component.m_Features = new BlueprintUnitFactReference[0];
      }
      component.GoodIfNoFeature = goodIfNoFeature ?? component.GoodIfNoFeature;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbook"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlliedSpellcaster</term><description>9093ceeefe9b84746a5993d619d7c86f</description></item>
    /// <item><term>HeightenSpellFeat</term><description>2f5d1e705c7967546b72ad8218ccf99c</description></item>
    /// <item><term>SpellPenetration</term><description>ee7dc126939e4d9438357fbd5980d459</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRecommendationRequiresSpellbook()
    {
      return AddComponent(new RecommendationRequiresSpellbook());
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbookSource"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneArmorMastery</term><description>453f5181a5ed3a445abfa3bcd3f4ac0c</description></item>
    /// <item><term>ArcaneArmorTraining</term><description>1a0298abacb6e0f45b7e28553e99e76c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRecommendationRequiresSpellbookSource(
        bool? alchemist = null,
        bool? arcane = null,
        bool? divine = null)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Alchemist = alchemist ?? component.Alchemist;
      component.Arcane = arcane ?? component.Arcane;
      component.Divine = divine ?? component.Divine;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatComparison"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DragonStyle</term><description>87ec6541cddfa394ab540dd13399d319</description></item>
    /// <item><term>SlashingGrace</term><description>697d64669eb2c0543abb9c9b07998a38</description></item>
    /// <item><term>WeaponFinesse</term><description>90e54424d682d104ab36436bd527af09</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRecommendationStatComparison(
        int? diff = null,
        StatType? higherStat = null,
        StatType? lowerStat = null)
    {
      var component = new RecommendationStatComparison();
      component.Diff = diff ?? component.Diff;
      component.HigherStat = higherStat ?? component.HigherStat;
      component.LowerStat = lowerStat ?? component.LowerStat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatMiminum"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CombatReflexes</term><description>0f8939ae6f220984e8fb568abbdfba95</description></item>
    /// <item><term>SnapShot</term><description>7115a6c08bd101247b70d72a4ff99453</description></item>
    /// <item><term>WeaponFinesse</term><description>90e54424d682d104ab36436bd527af09</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddRecommendationStatMiminum(
        bool? goodIfHigher = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? minimalValue = null,
        StatType? stat = null)
    {
      var component = new RecommendationStatMiminum();
      component.GoodIfHigher = goodIfHigher ?? component.GoodIfHigher;
      component.MinimalValue = minimalValue ?? component.MinimalValue;
      component.Stat = stat ?? component.Stat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponSubcategoryFocus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FencingGrace</term><description>47b352ea0f73c354aba777945760b441</description></item>
    /// <item><term>PowerAttackFeature</term><description>9972f33f977fc724c838e59641b2fca5</description></item>
    /// <item><term>TwoWeaponFighting</term><description>ac8aaf29054f5b74eb18f2af950e752d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddRecommendationWeaponSubcategoryFocus(
        bool? badIfNoFocus = null,
        bool? hasFocus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        WeaponSubCategory? subcategory = null)
    {
      var component = new RecommendationWeaponSubcategoryFocus();
      component.BadIfNoFocus = badIfNoFocus ?? component.BadIfNoFocus;
      component.HasFocus = hasFocus ?? component.HasFocus;
      component.Subcategory = subcategory ?? component.Subcategory;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponTypeFocus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ClusteredShots</term><description>f7de245bb20f12f47864c7cb8b1d1abb</description></item>
    /// <item><term>PointBlankShot</term><description>0da0c194d6e1d43419eb8d990b28e0ab</description></item>
    /// <item><term>WeaponFinesse</term><description>90e54424d682d104ab36436bd527af09</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRecommendationWeaponTypeFocus(
        bool? hasFocus = null,
        WeaponRangeType? weaponRangeType = null)
    {
      var component = new RecommendationWeaponTypeFocus();
      component.HasFocus = hasFocus ?? component.HasFocus;
      component.WeaponRangeType = weaponRangeType ?? component.WeaponRangeType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatRecommendationChange"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Camelia_FeatureList</term><description>c84c2f0728cc18f46a9e2796fcc08ac4</description></item>
    /// <item><term>CameliaPregenFeatureList</term><description>e88190db18af8d54f99ea9e649632957</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddStatRecommendationChange(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? recommended = null,
        StatType? stat = null)
    {
      var component = new StatRecommendationChange();
      component.Recommended = recommended ?? component.Recommended;
      component.Stat = stat ?? component.Stat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFullStatValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AccomplishedSneakAttacker</term><description>9f0187869dc23744292c0e5bb364464e</description></item>
    /// <item><term>SnapShot</term><description>7115a6c08bd101247b70d72a4ff99453</description></item>
    /// <item><term>VulpinePounce</term><description>cd258f1bce80ef54580f6b236c82608c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddPrerequisiteFullStatValue(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        StatType? stat = null,
        int? value = null)
    {
      var component = new PrerequisiteFullStatValue();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.Stat = stat ?? component.Stat;
      component.Value = value ?? component.Value;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LichSkeletalBardSpellFeature</term><description>fda623f52b4a00c44b78d28cc0b05697</description></item>
    /// <item><term>LichSkeletalInquisitorSpellFeature</term><description>54e079b74c9301947a870207680dc980</description></item>
    /// <item><term>LichSkeletalMagusSpellbookMinorFeature</term><description>0f3bab6beefd666498efdd88656c2a2f</description></item>
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
    public TBuilder AddSpellbookFeature(
        int? casterLevel = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>? spellbook = null)
    {
      var component = new AddSpellbookFeature();
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      component.m_Spellbook = spellbook?.Reference ?? component.m_Spellbook;
      if (component.m_Spellbook is null)
      {
        component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HellknightSigniferAngelfireApostleLevelUp</term><description>e23f94ccb99a86442bd101c415767235</description></item>
    /// <item><term>LoremasterOracleLevelUp</term><description>0f5c3d9d29ef9ed40ad35cb16c6f0b3b</description></item>
    /// <item><term>WinterWitchShamanLevelUp</term><description>2076161c9131d3f4ca76a0d5f5fde8d6</description></item>
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
    public TBuilder AddSpellbookLevel(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>? spellbook = null)
    {
      var component = new AddSpellbookLevel();
      component.m_Spellbook = spellbook?.Reference ?? component.m_Spellbook;
      if (component.m_Spellbook is null)
      {
        component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddSpellsPerDay"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbundantCasting</term><description>cf594fa8871332a4ba861c6002480ec2</description></item>
    /// <item><term>Artifact_DragonCloakFeature</term><description>d4c507301e47431ca5b992aecfd7b313</description></item>
    /// <item><term>OldGrimoireFeature</term><description>686897b0be1b481bad6570a2b95d4d1a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddSpellsPerDay(
        int? amount = null,
        int[]? levels = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AddSpellsPerDay();
      component.Amount = amount ?? component.Amount;
      component.Levels = levels ?? component.Levels;
      if (component.Levels is null)
      {
        component.Levels = new int[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ArmorSpeedPenaltyRemoval"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmorTraining</term><description>3c380607706f209499d951b29d3c44f3</description></item>
    /// <item><term>StrengthBlessingMajorBuff</term><description>833cdb09f6fc62f4888b3459f48b5854</description></item>
    /// <item><term>WarpriestAspectOfWarBuff</term><description>27d14b07b52c2df42a4dcd6bfb840425</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddArmorSpeedPenaltyRemoval(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new ArmorSpeedPenaltyRemoval();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="exceptionFact">
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
    /// <param name="extraEffectBuff">
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
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddBuffExtraEffects(
        Blueprint<BlueprintBuff, BlueprintBuffReference>? checkedBuff = null,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? exceptionFact = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? extraEffectBuff = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerRecalculate"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Alertness</term><description>1c04fe9a13a22bc499ffac03e6f79153</description></item>
    /// <item><term>DeftHands</term><description>ab5fbcd092c860d46a2e62d9dac272e8</description></item>
    /// <item><term>Stealthy</term><description>c7e1d5ef809325943af97f093e149c4f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="version">
    /// <para>
    /// InfoBox: If component just added then Version must be equals 1. Increase Version by 1 if component already exists and you need to reapply feature.
    /// </para>
    /// </param>
    public TBuilder AddSavesFixerRecalculate(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? version = null)
    {
      var component = new SavesFixerRecalculate();
      component.Version = version ?? component.Version;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
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
using Kingmaker.Designers.Mechanics.Facts.Restrictions;
using Kingmaker.Designers.Mechanics.Prerequisites;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
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
using Kingmaker.Utility;
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
    protected BaseFeatureConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFeature>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.IsClassFeature = copyFrom.IsClassFeature;
          bp.Groups = copyFrom.Groups;
          bp.Ranks = copyFrom.Ranks;
          bp.ReapplyOnLevelUp = copyFrom.ReapplyOnLevelUp;
          bp.IsPrerequisiteFor = copyFrom.IsPrerequisiteFor;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFeature>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.IsClassFeature = copyFrom.IsClassFeature;
          bp.Groups = copyFrom.Groups;
          bp.Ranks = copyFrom.Ranks;
          bp.ReapplyOnLevelUp = copyFrom.ReapplyOnLevelUp;
          bp.IsPrerequisiteFor = copyFrom.IsPrerequisiteFor;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeature.IsClassFeature"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When set to true the feature is removed during respec.
    /// </para>
    /// </remarks>
    public TBuilder SetIsClassFeature(bool isClassFeature = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsClassFeature = isClassFeature;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeature.Groups"/>
    /// </summary>
    public TBuilder SetGroups(params FeatureGroup[] groups)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Groups = groups;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintFeature.Groups"/>
    /// </summary>
    public TBuilder AddToGroups(params FeatureGroup[] groups)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Groups = bp.Groups ?? new FeatureGroup[0];
          bp.Groups = CommonTool.Append(bp.Groups, groups);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeature.Groups"/>
    /// </summary>
    public TBuilder RemoveFromGroups(params FeatureGroup[] groups)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Groups is null) { return; }
          bp.Groups = bp.Groups.Where(val => !groups.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeature.Groups"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromGroups(Func<FeatureGroup, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Groups is null) { return; }
          bp.Groups = bp.Groups.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFeature.Groups"/>
    /// </summary>
    public TBuilder ClearGroups()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Groups = new FeatureGroup[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeature.Groups"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyGroups(Action<FeatureGroup> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Groups is null) { return; }
          bp.Groups.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeature.Ranks"/>
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
    /// Sets the value of <see cref="BlueprintFeature.ReapplyOnLevelUp"/>
    /// </summary>
    public TBuilder SetReapplyOnLevelUp(bool reapplyOnLevelUp = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ReapplyOnLevelUp = reapplyOnLevelUp;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeature.IsPrerequisiteFor"/>
    /// </summary>
    ///
    /// <param name="isPrerequisiteFor">
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
    public TBuilder SetIsPrerequisiteFor(params Blueprint<BlueprintFeatureReference>[] isPrerequisiteFor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsPrerequisiteFor = isPrerequisiteFor.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintFeature.IsPrerequisiteFor"/>
    /// </summary>
    ///
    /// <param name="isPrerequisiteFor">
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
    public TBuilder AddToIsPrerequisiteFor(params Blueprint<BlueprintFeatureReference>[] isPrerequisiteFor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsPrerequisiteFor = bp.IsPrerequisiteFor ?? new();
          bp.IsPrerequisiteFor.AddRange(isPrerequisiteFor.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeature.IsPrerequisiteFor"/>
    /// </summary>
    ///
    /// <param name="isPrerequisiteFor">
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
    public TBuilder RemoveFromIsPrerequisiteFor(params Blueprint<BlueprintFeatureReference>[] isPrerequisiteFor)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.IsPrerequisiteFor is null) { return; }
          bp.IsPrerequisiteFor = bp.IsPrerequisiteFor.Where(val => !isPrerequisiteFor.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeature.IsPrerequisiteFor"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIsPrerequisiteFor(Func<BlueprintFeatureReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.IsPrerequisiteFor is null) { return; }
          bp.IsPrerequisiteFor = bp.IsPrerequisiteFor.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFeature.IsPrerequisiteFor"/>
    /// </summary>
    public TBuilder ClearIsPrerequisiteFor()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsPrerequisiteFor = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeature.IsPrerequisiteFor"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIsPrerequisiteFor(Action<BlueprintFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.IsPrerequisiteFor is null) { return; }
          bp.IsPrerequisiteFor.ForEach(action);
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
    /// <item><term>FinalWyrmshifterBlackBreathPenaltyBuff</term><description>4d6ccea8444744e88f5b3bd42e8538ab</description></item>
    /// <item><term>ZonKuthonScarHalfHPBuff</term><description>9a47f56d0a1f42d9bf820da1d78919a7</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextStatBonus(
        StatType stat,
        ContextValue value,
        ModifierDescriptor? descriptor = null,
        int? minimal = null,
        int? multiplier = null,
        RestrictionCalculator? restrictions = null)
    {
      var component = new AddContextStatBonus();
      component.Stat = stat;
      component.Value = value;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Minimal = minimal ?? component.Minimal;
      component.HasMinimal = minimal is null;
      component.Multiplier = multiplier ?? component.Multiplier;
      Validate(restrictions);
      component.Restrictions = restrictions ?? component.Restrictions;
      return AddComponent(component);
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
    /// <item><term>5_DeadStage_AcidBuff</term><description>b730dbbb5e8143abbba6a066bc82c19a</description></item>
    /// <item><term>HellsDecreeAbilityMagicNecromancyBuff</term><description>c695587d5307d234cb34f62750ff7616</description></item>
    /// <item><term>ZonKuthonScarBuff</term><description>fbb677d91f924b99a3610ae79f6468fa</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextRankConfig(ContextRankConfig component)
    {
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
    /// <item><term>GoodDomainProgressionSecondary</term><description>efc4219c7894afc438180737adc0b7ac</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="archetypeAlignment">
    /// <para>
    /// InfoBox: PF-485644 - ограничение мировоззрения для архетипа всегда заменяет ограничение класса.
    /// </para>
    /// </param>
    /// <param name="ingorePrerequisiteCheck">
    /// <para>
    /// InfoBox: PF-470784 - игнорируем проверку на доступность во время создания персонажа.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteAlignment(
        AlignmentMaskType alignment,
        bool? archetypeAlignment = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? ingorePrerequisiteCheck = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteAlignment();
      component.Alignment = alignment;
      component.ArchetypeAlignment = archetypeAlignment ?? component.ArchetypeAlignment;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IngorePrerequisiteCheck = ingorePrerequisiteCheck ?? component.IngorePrerequisiteCheck;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>LoremasterArcanistMagicDeceiver</term><description>d20206c5e91942399e76eb366c026ca9</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteArchetypeLevel(
        Blueprint<BlueprintArchetypeReference> archetype,
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        int? level = null)
    {
      var component = new PrerequisiteArchetypeLevel();
      component.m_Archetype = archetype?.Reference;
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.Level = level ?? component.Level;
      return AddComponent(component);
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
    /// <item><term>SuperiorityOfCold</term><description>803d7327658b441286d15b3fa6a49963</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteCasterType(
        bool isArcane,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteCasterType();
      component.IsArcane = isArcane;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// InfoBox: Mythic &amp; Alchemist Spellbooks don&amp;apos;t cound
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteCasterTypeSpellLevel(
        bool isArcane,
        bool onlySpontaneous,
        int requiredSpellLevel,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteCasterTypeSpellLevel();
      component.IsArcane = isArcane;
      component.OnlySpontaneous = onlySpontaneous;
      component.RequiredSpellLevel = requiredSpellLevel;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
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
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteCharacterLevel(
        int level,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteCharacterLevel();
      component.Level = level;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>MythicStartingClass</term><description>247aa787806d5da4f89cfc3dff0b217f</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteClassLevel(
        Blueprint<BlueprintCharacterClassReference> characterClass,
        int level,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? not = null)
    {
      var component = new PrerequisiteClassLevel();
      component.m_CharacterClass = characterClass?.Reference;
      component.Level = level;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.Not = not ?? component.Not;
      return AddComponent(component);
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
    /// <item><term>HellknightSigniferThassilonianIllusion</term><description>444211da5e9592f41a4334825eb7ea2c</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteClassSpellLevel(
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? requiredSpellLevel = null)
    {
      var component = new PrerequisiteClassSpellLevel();
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.RequiredSpellLevel = requiredSpellLevel ?? component.RequiredSpellLevel;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="uIText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddPrerequisiteEtude(
        Blueprint<BlueprintEtudeReference> etude,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? notPlaying = null,
        LocalString? uIText = null)
    {
      var component = new PrerequisiteEtude();
      component.Etude = etude?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.NotPlaying = notPlaying ?? component.NotPlaying;
      component.UIText = uIText?.LocalizedString ?? component.UIText;
      if (component.UIText is null)
      {
        component.UIText = Utils.Constants.Empty.String;
      }
      return AddComponent(component);
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
    /// <item><term>MasterOfAllArchetype</term><description>bd4e70bfb89a452b876713d61b9b8eb2</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteFeature(
        Blueprint<BlueprintFeatureReference> feature,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteFeature();
      component.m_Feature = feature?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
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
    /// <item><term>LoremasterWizardSecretShaman</term><description>291b1cabaa3405c4991c892204546bcb</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteFeaturesFromList(
        List<Blueprint<BlueprintFeatureReference>> features,
        int? amount = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? restrictIfNot = null)
    {
      var component = new PrerequisiteFeaturesFromList();
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray();
      component.Amount = amount ?? component.Amount;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.m_RestrictIfNot = restrictIfNot ?? component.m_RestrictIfNot;
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
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteMythicLevel(
        int level,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteMythicLevel();
      component.Level = level;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>BloodragerCelestialFeatSelectionGreenrager</term><description>0c96650e80e712f439c2a4da8a4272d9</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteNoArchetype(
        Blueprint<BlueprintArchetypeReference> archetype,
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteNoArchetype();
      component.m_Archetype = archetype?.Reference;
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoClassLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AchaekekFeature</term><description>a3189d5b7c4d4d91beaa8bfffac3e38e</description></item>
    /// <item><term>GreenFaithCameliaFeature</term><description>ca763809e01f4247a3639965364c26cb</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteNoClassLevel(
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteNoClassLevel();
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbadarFeature</term><description>6122dacf418611540a3c91e67197ee4e</description></item>
    /// <item><term>LiberationDomainProgression</term><description>df2f14ced8710664ba7db914880c4a02</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteNoFeature(
        Blueprint<BlueprintFeatureReference> feature,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteNoFeature();
      component.m_Feature = feature?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
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
    /// <item><term>LightBardingProficiency</term><description>c62ba548b1a34b94b9802925b35737c2</description></item>
    /// <item><term>UrgroshProficiency</term><description>d24f7545b1aa3b34e8216f8cb3140563</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteNotProficient(
        ArmorProficiencyGroup[] armorProficiencies,
        WeaponCategory[] weaponProficiencies,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteNotProficient();
      component.ArmorProficiencies = armorProficiencies;
      component.WeaponProficiencies = weaponProficiencies;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteParametrizedSpellFeature(
        Blueprint<BlueprintFeatureReference> feature,
        Blueprint<BlueprintAbilityReference> spell,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.m_Feature = feature?.Reference;
      component.m_Spell = spell?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.ParameterType = FeatureParameterType.LearnSpell;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteParametrizedWeaponFeature(
        Blueprint<BlueprintFeatureReference> feature,
        WeaponCategory weaponCategory,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.m_Feature = feature?.Reference;
      component.WeaponCategory = weaponCategory;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.ParameterType = FeatureParameterType.WeaponCategory;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteParametrizedSpellSchoolFeature(
        Blueprint<BlueprintFeatureReference> feature,
        SpellSchool spellSchool,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.m_Feature = feature?.Reference;
      component.SpellSchool = spellSchool;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.ParameterType = FeatureParameterType.SpellSchool;
      return AddComponent(component);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteParametrizedWeaponSubcategory(
        Blueprint<BlueprintFeatureReference> feature,
        WeaponSubCategory subCategory,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteParametrizedWeaponSubcategory();
      component.m_Feature = feature?.Reference;
      component.SubCategory = subCategory;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteIsPet(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? not = null)
    {
      var component = new PrerequisiteIsPet();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.Not = not ?? component.Not;
      return AddComponent(component);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisitePlayerHasFeature(
        Blueprint<BlueprintFeatureReference> feature,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisitePlayerHasFeature();
      component.m_Feature = feature?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
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
    /// <item><term>FinesseTrainingPunchingDagger</term><description>a591ea5d2af6a9c4eac84ddeac0e204e</description></item>
    /// <item><term>SwordlordClass</term><description>90e4d7da3ccd1a8478411e07e91d5750</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteProficiency(
        ArmorProficiencyGroup[] armorProficiencies,
        WeaponCategory[] weaponProficiencies,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteProficiency();
      component.ArmorProficiencies = armorProficiencies;
      component.WeaponProficiencies = weaponProficiencies;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>ImprovedCriticalHeavyCrossbow</term><description>19558bb038d2b3a4eaf4f0800d011bda</description></item>
    /// <item><term>WinterWitchClass</term><description>eb24ca44debf6714aabe1af1fd905a07</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteStatValue(
        StatType stat,
        int value,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteStatValue();
      component.Stat = stat;
      component.Value = value;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
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
    /// <item><term>Manyshot</term><description>adf54af2a681792489826f7fd1b62889</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationBAB(
        float minPart,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notRecommendIfHigher = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.MinPart = minPart;
      component.NotRecommendIfHigher = notRecommendIfHigher ?? component.NotRecommendIfHigher;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Sets MinPart to 0.45
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// <item><term>Manyshot</term><description>adf54af2a681792489826f7fd1b62889</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationHalfBAB(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notRecommendIfHigher = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.NotRecommendIfHigher = notRecommendIfHigher ?? component.NotRecommendIfHigher;
      component.MinPart = 0.45f;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Sets MinPart to 0.7
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// <item><term>Manyshot</term><description>adf54af2a681792489826f7fd1b62889</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationThreeQuartersBAB(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notRecommendIfHigher = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.NotRecommendIfHigher = notRecommendIfHigher ?? component.NotRecommendIfHigher;
      component.MinPart = 0.7f;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Sets MinPart to 0.95
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// <item><term>Manyshot</term><description>adf54af2a681792489826f7fd1b62889</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationFullBAB(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notRecommendIfHigher = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.NotRecommendIfHigher = notRecommendIfHigher ?? component.NotRecommendIfHigher;
      component.MinPart = 0.95f;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddRecommendationCompanionBoon(
        Blueprint<BlueprintFeatureReference> companionRank)
    {
      var component = new RecommendationCompanionBoon();
      component.m_CompanionRank = companionRank?.Reference;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationHasFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AccomplishedSneakAttacker</term><description>9f0187869dc23744292c0e5bb364464e</description></item>
    /// <item><term>MagicalTail</term><description>febb8fe9a2d142fb80c1be6b0b539d9d</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddRecommendationHasFeature(
        Blueprint<BlueprintUnitFactReference> feature,
        bool? mandatory = null)
    {
      var component = new RecommendationHasFeature();
      component.m_Feature = feature?.Reference;
      component.Mandatory = mandatory ?? component.Mandatory;
      return AddComponent(component);
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
    /// <item><term>Hypnotism</term><description>88367310478c10b47903463c5d0152b0</description></item>
    /// <item><term>WindsOfVengeance</term><description>5d8f1da2fdc0b9242af9f326f9e507be</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="featuresExlude">
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
    public TBuilder AddRecommendationNoFeatFromGroup(
        List<Blueprint<BlueprintUnitFactReference>> features,
        List<Blueprint<BlueprintUnitFactReference>>? featuresExlude = null,
        bool? goodIfNoFeature = null)
    {
      var component = new RecommendationNoFeatFromGroup();
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray();
      component.m_FeaturesExlude = featuresExlude?.Select(bp => bp.Reference)?.ToArray() ?? component.m_FeaturesExlude;
      if (component.m_FeaturesExlude is null)
      {
        component.m_FeaturesExlude = new BlueprintUnitFactReference[0];
      }
      component.GoodIfNoFeature = goodIfNoFeature ?? component.GoodIfNoFeature;
      return AddComponent(component);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder RecommendationRequiresSpellbookSource(
        bool? alchemist = null,
        bool? arcane = null,
        bool? divine = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Alchemist = alchemist ?? component.Alchemist;
      component.Arcane = arcane ?? component.Arcane;
      component.Divine = divine ?? component.Divine;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder RecommendationAlchemistSpells(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Alchemist = true;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder RecommendationArcaneSpells(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Arcane = true;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder RecommendationDivineSpells(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Divine = true;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationStatComparison(
        StatType higherStat,
        StatType lowerStat,
        int? diff = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationStatComparison();
      component.HigherStat = higherStat;
      component.LowerStat = lowerStat;
      component.Diff = diff ?? component.Diff;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>ShiftersEdgeFeature</term><description>0e7ec9a341ca46fcaf4d49759e047c83</description></item>
    /// <item><term>WeaponFinesse</term><description>90e54424d682d104ab36436bd527af09</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRecommendationStatMiminum(
        int minimalValue,
        StatType stat,
        bool? goodIfHigher = null)
    {
      var component = new RecommendationStatMiminum();
      component.MinimalValue = minimalValue;
      component.Stat = stat;
      component.GoodIfHigher = goodIfHigher ?? component.GoodIfHigher;
      return AddComponent(component);
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
    public TBuilder AddRecommendationWeaponSubcategoryFocus(
        WeaponSubCategory subcategory,
        bool? badIfNoFocus = null,
        bool? hasFocus = null)
    {
      var component = new RecommendationWeaponSubcategoryFocus();
      component.Subcategory = subcategory;
      component.BadIfNoFocus = badIfNoFocus ?? component.BadIfNoFocus;
      component.HasFocus = hasFocus ?? component.HasFocus;
      return AddComponent(component);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationWeaponTypeFocus(
        WeaponRangeType weaponRangeType,
        bool? hasFocus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationWeaponTypeFocus();
      component.WeaponRangeType = weaponRangeType;
      component.HasFocus = hasFocus ?? component.HasFocus;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>Halaseliax_FireBreathWeapon</term><description>cef56b3867604e7394e61fcbeb51dae5</description></item>
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spell">
    /// <para>
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddGlobalMapSpellFeature(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintGlobalMagicSpell.Reference>? spell = null)
    {
      var component = new AddGlobalMapSpellFeature();
      component.m_Spell = spell?.Reference ?? component.m_Spell;
      if (component.m_Spell is null)
      {
        component.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddFeatureSurvivesRespec(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new FeatureSurvivesRespec();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="LevelUpRecommendation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SpellPenetration</term><description>ee7dc126939e4d9438357fbd5980d459</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddLevelUpRecommendation(
        ClassesPriority[]? classPriorities = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new LevelUpRecommendation();
      Validate(classPriorities);
      component.ClassPriorities = classPriorities ?? component.ClassPriorities;
      if (component.ClassPriorities is null)
      {
        component.ClassPriorities = new ClassesPriority[0];
      }
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
    /// Adds <see cref="PrerequisiteCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>CrossbloodedSecondaryBloodlineDraconicSilverProgression</term><description>076d1648e1341f841a222de5b89ba215</description></item>
    /// <item><term>SylvanSorcererArchetype</term><description>711d5024ecc75f346b9cda609c3a1f83</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="uIText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddPrerequisiteCondition(
        bool? checkInProgression = null,
        Condition? condition = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        LocalString? uIText = null)
    {
      var component = new PrerequisiteCondition();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.UIText = uIText?.LocalizedString ?? component.UIText;
      if (component.UIText is null)
      {
        component.UIText = Utils.Constants.Empty.String;
      }
      return AddComponent(component);
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
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteMainCharacter(
        bool? checkInProgression = null,
        bool? companion = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteMainCharacter();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Companion = companion ?? component.Companion;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
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
    /// <item><term>AnimalCompanionFeatureSmilodon</term><description>126712ef923ab204983d6f107629c895</description></item>
    /// <item><term>UnholyBeast</term><description>2101bf9664ce4012b8011da12b4797e5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisitePet(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? noCompanion = null,
        PetType? type = null)
    {
      var component = new PrerequisitePet();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.NoCompanion = noCompanion ?? component.NoCompanion;
      component.Type = type ?? component.Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteAnySpellsInSpellbook"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SpellSpecialization1</term><description>e69a85f633ae8ca4398abeb6fa11b1fe</description></item>
    /// <item><term>SpellSpecialization19</term><description>09a6ff29f55dad544b9949702f2ed2c8</description></item>
    /// <item><term>SpellSpecializationFirst</term><description>f327a765a4353d04f872482ef3e48c35</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="shouldHaveSpellText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="spellSpecializationFeat">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteAnySpellsInSpellbook(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        LocalString? shouldHaveSpellText = null,
        Blueprint<BlueprintParametrizedFeatureReference>? spellSpecializationFeat = null)
    {
      var component = new PrerequisiteAnySpellsInSpellbook();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.m_ShouldHaveSpellText = shouldHaveSpellText?.LocalizedString ?? component.m_ShouldHaveSpellText;
      if (component.m_ShouldHaveSpellText is null)
      {
        component.m_ShouldHaveSpellText = Utils.Constants.Empty.String;
      }
      component.m_SpellSpecializationFeat = spellSpecializationFeat?.Reference ?? component.m_SpellSpecializationFeat;
      if (component.m_SpellSpecializationFeat is null)
      {
        component.m_SpellSpecializationFeat = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="introduction">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddFeaturesFromSelectionToDescription(
        Blueprint<BlueprintFeatureSelectionReference>? featureSelection = null,
        LocalString? introduction = null,
        bool? onlyIfRequiresThisFeature = null)
    {
      var component = new AddFeaturesFromSelectionToDescription();
      component.m_FeatureSelection = featureSelection?.Reference ?? component.m_FeatureSelection;
      if (component.m_FeatureSelection is null)
      {
        component.m_FeatureSelection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(null);
      }
      component.Introduction = introduction?.LocalizedString ?? component.Introduction;
      if (component.Introduction is null)
      {
        component.Introduction = Utils.Constants.Empty.String;
      }
      component.OnlyIfRequiresThisFeature = onlyIfRequiresThisFeature ?? component.OnlyIfRequiresThisFeature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGoldenDragonSkillBonus"/>
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
    /// <item><term>GoldenDragonSharedSkillUMD</term><description>4e0b919e4fbd85142bce959fae129d1a</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddGoldenDragonSkillBonus(
        ModifierDescriptor? descriptor = null,
        StatType? stat = null)
    {
      var component = new AddGoldenDragonSkillBonus();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.Stat = stat ?? component.Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistMechanicalPart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>KineticSharpshootterMainMechanicalHiddenFeature</term><description>a62d155ca5b5458abde794ef5bee93cb</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddKineticistMechanicalPart(
        AddKineticistMechanicalPart.Feature? feature = null)
    {
      var component = new AddKineticistMechanicalPart();
      component.m_Feature = feature ?? component.m_Feature;
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
    public TBuilder AddMagusMechanicPart(
        AddMagusMechanicPart.Feature? feature = null)
    {
      var component = new AddMagusMechanicPart();
      component.m_Feature = feature ?? component.m_Feature;
      return AddComponent(component);
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
    /// <item><term>MaskOfAreshkagalHeadband_TabulaRasaFeature</term><description>edf05f7d96dc4d59b7242c5985b2e6f7</description></item>
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
    /// Adds <see cref="AddSpellsToDescription"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ImprovedCantripsFeature</term><description>d26fb54b74d44a45b84ef7150a460348</description></item>
    /// <item><term>ShamanNatureSpiritWanderingProgression</term><description>f3e19b0d6d82e2a4d98957af591f5d36</description></item>
    /// <item><term>WitchWinterPatronProgression</term><description>e98d8d9f907c1814aa7376d6cdaac012</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="introduction">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="spellLists">
    /// <para>
    /// Blueprint of type BlueprintSpellList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    public TBuilder AddSpellsToDescription(
        LocalString? introduction = null,
        List<Blueprint<BlueprintSpellListReference>>? spellLists = null,
        List<Blueprint<BlueprintAbilityReference>>? spells = null)
    {
      var component = new AddSpellsToDescription();
      component.Introduction = introduction?.LocalizedString ?? component.Introduction;
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
    /// Adds <see cref="ChangeMythicClassArtComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CorruptedGoldenDragonFeature</term><description>1e66cfb4f351466fb05636082bce50d6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilityFrame">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="commonFrame">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="commonFrameDecor">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="emblem">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="portraitFrame">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="portraits">
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
    /// <param name="selectorFrame">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="selectorPortrait">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="selectorPortraitLineart">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder AddChangeMythicClassArtComponent(
        AssetLink<SpriteLink>? abilityFrame = null,
        AssetLink<SpriteLink>? commonFrame = null,
        AssetLink<SpriteLink>? commonFrameDecor = null,
        AssetLink<SpriteLink>? emblem = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        AssetLink<SpriteLink>? portraitFrame = null,
        List<Blueprint<BlueprintPortraitReference>>? portraits = null,
        AssetLink<SpriteLink>? selectorFrame = null,
        AssetLink<SpriteLink>? selectorPortrait = null,
        AssetLink<SpriteLink>? selectorPortraitLineart = null)
    {
      var component = new ChangeMythicClassArtComponent();
      component.m_AbilityFrame = abilityFrame?.Get() ?? component.m_AbilityFrame;
      component.m_CommonFrame = commonFrame?.Get() ?? component.m_CommonFrame;
      component.m_CommonFrameDecor = commonFrameDecor?.Get() ?? component.m_CommonFrameDecor;
      component.m_Emblem = emblem?.Get() ?? component.m_Emblem;
      component.m_PortraitFrame = portraitFrame?.Get() ?? component.m_PortraitFrame;
      component.m_Portraits = portraits?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Portraits;
      if (component.m_Portraits is null)
      {
        component.m_Portraits = new BlueprintPortraitReference[0];
      }
      component.m_SelectorFrame = selectorFrame?.Get() ?? component.m_SelectorFrame;
      component.m_SelectorPortrait = selectorPortrait?.Get() ?? component.m_SelectorPortrait;
      component.m_SelectorPortraitLineart = selectorPortraitLineart?.Get() ?? component.m_SelectorPortraitLineart;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CustomKnowledgeCheck"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AberrationType</term><description>3bec99efd9a363242a6c8d9957b75e91</description></item>
    /// <item><term>SubtypeAzata</term><description>e422746933151f3469f4c2484f9263db</description></item>
    /// <item><term>VerminType</term><description>09478937695300944a179530664e42ec</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCustomKnowledgeCheck(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        StatType? stat = null)
    {
      var component = new CustomKnowledgeCheck();
      component.m_Stat = stat ?? component.m_Stat;
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="triggerOnAreaEffectsDispell">
    /// <para>
    /// InfoBox: Use this bool if you want to trigger action on a caster of an AOE effect. Eg: Ember cast Grease, Nenio dispells it -&amp;gt; Ember is target, hence received 1d6 damage 
    /// </para>
    /// </param>
    public TBuilder AddDispelMagicSuccessTrigger(
        ActionsBuilder? actionOnTarget = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? triggerOnAreaEffectsDispell = null)
    {
      var component = new AddDispelMagicSuccessTrigger();
      component.ActionOnTarget = actionOnTarget?.Build() ?? component.ActionOnTarget;
      if (component.ActionOnTarget is null)
      {
        component.ActionOnTarget = Utils.Constants.Empty.Actions;
      }
      component.TriggerOnAreaEffectsDispell = triggerOnAreaEffectsDispell ?? component.TriggerOnAreaEffectsDispell;
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
    /// <item><term>DemonPlagueFeature</term><description>096156df0b5aa4f458d35db066b27f35</description></item>
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
    /// <item><term>NereidBeguilingAuraBuff</term><description>ab6181f9447a4d945bdcbe6466c42189</description></item>
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
    /// <item><term>InspireTranquilitySavingThrowBuffMythic</term><description>60b646069fa949d8983b4d74fc55218b</description></item>
    /// <item><term>WrackBloodBlastAbility</term><description>0199d49f59833104198e2c0196235a45</description></item>
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
    /// <item><term>HeartOfIcebergEnchantment</term><description>719881e400d980f4da1bf7361c1903db</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
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
    /// Adds <see cref="PureRecommendation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CleavingFinish</term><description>59bd93899149fa44687ff4121389b3a9</description></item>
    /// <item><term>GreaterDirtyTrick</term><description>52c6b07a68940af41b270b3710682dc7</description></item>
    /// <item><term>PreciseShot</term><description>8f3d1e6b4be006f4d896081f2f889665</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPureRecommendation(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        RecommendationPriority? priority = null)
    {
      var component = new PureRecommendation();
      component.Priority = priority ?? component.Priority;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationHasClasses"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BolsteredSpellFeat</term><description>fbf5d9ce931f47f3a0c818b3f8ef8414</description></item>
    /// <item><term>PiercingSpell</term><description>c101ad6879a94204a780506f7a554865</description></item>
    /// <item><term>ShiftersRushFeature</term><description>4ddc88f422a84f76a952e24bec7b53e1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="contraditionClasses">
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
    /// <param name="recommendedClasses">
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
    public TBuilder AddRecommendationHasClasses(
        List<Blueprint<BlueprintCharacterClassReference>>? contraditionClasses = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintCharacterClassReference>>? recommendedClasses = null)
    {
      var component = new RecommendationHasClasses();
      component.m_ContraditionClasses = contraditionClasses?.Select(bp => bp.Reference)?.ToArray() ?? component.m_ContraditionClasses;
      if (component.m_ContraditionClasses is null)
      {
        component.m_ContraditionClasses = new BlueprintCharacterClassReference[0];
      }
      component.m_RecommendedClasses = recommendedClasses?.Select(bp => bp.Reference)?.ToArray() ?? component.m_RecommendedClasses;
      if (component.m_RecommendedClasses is null)
      {
        component.m_RecommendedClasses = new BlueprintCharacterClassReference[0];
      }
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
    /// <item><term>IntensifiedSpell</term><description>8ad7fd39abea4722b39eb5a67d606a41</description></item>
    /// <item><term>SpellPenetration</term><description>ee7dc126939e4d9438357fbd5980d459</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationRequiresSpellbook(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbook();
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    public TBuilder AddStatRecommendationChange(
        bool? recommended = null,
        StatType? stat = null)
    {
      var component = new StatRecommendationChange();
      component.Recommended = recommended ?? component.Recommended;
      component.Stat = stat ?? component.Stat;
      return AddComponent(component);
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteFullStatValue(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        StatType? stat = null,
        int? value = null)
    {
      var component = new PrerequisiteFullStatValue();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.Stat = stat ?? component.Stat;
      component.Value = value ?? component.Value;
      return AddComponent(component);
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
    /// <param name="spellbook">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSpellbookFeature(
        int? casterLevel = null,
        Blueprint<BlueprintSpellbookReference>? spellbook = null)
    {
      var component = new AddSpellbookFeature();
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      component.m_Spellbook = spellbook?.Reference ?? component.m_Spellbook;
      if (component.m_Spellbook is null)
      {
        component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
      return AddComponent(component);
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
    /// <item><term>WinterWitchWinterChildLevelUp</term><description>8146ffda8c4f4bb795db89341a16324a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spellbook">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSpellbookLevel(
        Blueprint<BlueprintSpellbookReference>? spellbook = null)
    {
      var component = new AddSpellbookLevel();
      component.m_Spellbook = spellbook?.Reference ?? component.m_Spellbook;
      if (component.m_Spellbook is null)
      {
        component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
      return AddComponent(component);
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
    /// <item><term>CastersDreamFeature</term><description>bbc53c234b304feaac91574bb4b427e1</description></item>
    /// <item><term>OldGrimoireFeature</term><description>686897b0be1b481bad6570a2b95d4d1a</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddSpellsPerDay(
        int? amount = null,
        int[]? levels = null)
    {
      var component = new AddSpellsPerDay();
      component.Amount = amount ?? component.Amount;
      component.Levels = levels ?? component.Levels;
      if (component.Levels is null)
      {
        component.Levels = new int[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorSpeedPenaltyRemoval"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmorFocusMediumMythicFeatureVar2SubBuff</term><description>457d5cde294c435ea7b4ee66f4949956</description></item>
    /// <item><term>PurifierCelestialArmorFeature</term><description>7dc8d7dede2704640956f7bc4102760a</description></item>
    /// <item><term>StrengthBlessingMajorBuff</term><description>833cdb09f6fc62f4888b3459f48b5854</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddArmorSpeedPenaltyRemoval()
    {
      return AddComponent(new ArmorSpeedPenaltyRemoval());
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
    /// <item><term>HeartOfEarthShifterFeature</term><description>0b09ce94b5fe48dfa81b9a6f9d55a351</description></item>
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
    /// <param name="checkedBuffList">
    /// <para>
    /// Tooltip: If you need more than 1 buff to check - additional field bc of compatibility issues. First fill in the first field, only then additional!
    /// </para>
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
        List<Blueprint<BlueprintBuffReference>>? checkedBuffList = null,
        Blueprint<BlueprintUnitFactReference>? exceptionFact = null,
        Blueprint<BlueprintBuffReference>? extraEffectBuff = null,
        bool? useBaffContext = null)
    {
      var component = new BuffExtraEffects();
      component.m_CheckedBuff = checkedBuff?.Reference ?? component.m_CheckedBuff;
      if (component.m_CheckedBuff is null)
      {
        component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_CheckedBuffList = checkedBuffList?.Select(bp => bp.Reference)?.ToArray() ?? component.m_CheckedBuffList;
      if (component.m_CheckedBuffList is null)
      {
        component.m_CheckedBuffList = new BlueprintBuffReference[0];
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
      component.m_UseBaffContext = useBaffContext ?? component.m_UseBaffContext;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EncumbranceSpeedPenaltyRemoval"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LameCurseFeatureLevel1</term><description>077dd0c839f5dfd498cb2e34835fb06d</description></item>
    /// <item><term>LameCurseNoPenaltyFeatureLevel1</term><description>e7c9639c7b27bef4d930ce9df877bc4e</description></item>
    /// <item><term>WarpriestAspectOfWarBuff</term><description>27d14b07b52c2df42a4dcd6bfb840425</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEncumbranceSpeedPenaltyRemoval()
    {
      return AddComponent(new EncumbranceSpeedPenaltyRemoval());
    }

    /// <summary>
    /// Adds <see cref="SavesFixerRecalculate"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlchemistBombsFeature</term><description>c59b2f256f5a70a4d896568658315b7d</description></item>
    /// <item><term>GoldDragonBreathEmpowering</term><description>d6fa1c8aead34a2ba2c18fc7a41a649c</description></item>
    /// <item><term>ZenArcherKiArrowsFeature</term><description>604a24b659bb69a4796ddb9fbf957504</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="version">
    /// <para>
    /// InfoBox: If component just added then Version must be equals 1. Increase Version by 1 if component already exists and you need to reapply feature.
    /// </para>
    /// </param>
    public TBuilder AddSavesFixerRecalculate(
        int? version = null)
    {
      var component = new SavesFixerRecalculate();
      component.Version = version ?? component.Version;
      return AddComponent(component);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Groups is null)
      {
        Blueprint.Groups = new FeatureGroup[0];
      }
      if (Blueprint.IsPrerequisiteFor is null)
      {
        Blueprint.IsPrerequisiteFor = new();
      }
    }
  }
}

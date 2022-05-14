//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Prerequisites;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCharacterClass"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCharacterClassConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCharacterClass
    where TBuilder : BaseCharacterClassConfigurator<T, TBuilder>
  {
    protected BaseCharacterClassConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="DeityDependencyClass"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ClericClass</term><description>67819271767a9dd4fbfd4ae700befea0</description></item>
    /// <item><term>InquisitorClass</term><description>f1a70d9e1b0b41e49874e1fa9052a1ce</description></item>
    /// <item><term>WarpriestClass</term><description>30b5e47d47a0e37438cc5a80c96cfb99</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddDeityDependencyClass(
        bool? isDeityDependencyClass = null)
    {
      var component = new DeityDependencyClass();
      component.IsDeityDependencyClass = isDeityDependencyClass ?? component.IsDeityDependencyClass;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HideClassIfPrerequisitesRequiredComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FakeLegendClass</term><description>b82f1fbd191e1f2498266ca41f05027f</description></item>
    /// <item><term>MythicCompanionClass</term><description>530b6a79cb691c24ba99e1577b4beb6d</description></item>
    /// <item><term>MythicStartingClass</term><description>247aa787806d5da4f89cfc3dff0b217f</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddHideClassIfPrerequisitesRequiredComponent()
    {
      return AddComponent(new HideClassIfPrerequisitesRequiredComponent());
    }

    /// <summary>
    /// Adds <see cref="MythicClassArtComponent"/>
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
    /// <param name="portraits">
    /// <para>
    /// Blueprint of type BlueprintPortrait. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddMythicClassArtComponent(
        SpriteLink? abilityFrame = null,
        SpriteLink? commonFrame = null,
        SpriteLink? commonFrameDecor = null,
        SpriteLink? emblem = null,
        SpriteLink? portraitFrame = null,
        List<Blueprint<BlueprintPortrait, BlueprintPortraitReference>>? portraits = null,
        SpriteLink? selectorFrame = null,
        SpriteLink? selectorPortrait = null,
        SpriteLink? selectorPortraitLineart = null)
    {
      var component = new MythicClassArtComponent();
      Validate(abilityFrame);
      component.m_AbilityFrame = abilityFrame ?? component.m_AbilityFrame;
      Validate(commonFrame);
      component.m_CommonFrame = commonFrame ?? component.m_CommonFrame;
      Validate(commonFrameDecor);
      component.m_CommonFrameDecor = commonFrameDecor ?? component.m_CommonFrameDecor;
      Validate(emblem);
      component.m_Emblem = emblem ?? component.m_Emblem;
      Validate(portraitFrame);
      component.m_PortraitFrame = portraitFrame ?? component.m_PortraitFrame;
      component.m_Portraits = portraits?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Portraits;
      if (component.m_Portraits is null)
      {
        component.m_Portraits = new BlueprintPortraitReference[0];
      }
      Validate(selectorFrame);
      component.m_SelectorFrame = selectorFrame ?? component.m_SelectorFrame;
      Validate(selectorPortrait);
      component.m_SelectorPortrait = selectorPortrait ?? component.m_SelectorPortrait;
      Validate(selectorPortraitLineart);
      component.m_SelectorPortraitLineart = selectorPortraitLineart ?? component.m_SelectorPortraitLineart;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicClassLockComponent"/>
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
    public TBuilder AddMythicClassLockComponent(
        Mythic[]? locks = null)
    {
      var component = new MythicClassLockComponent();
      component.Locks = locks ?? component.Locks;
      if (component.Locks is null)
      {
        component.Locks = new Mythic[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkipLevelsForSpellProgression"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DragonDiscipleClass</term><description>72051275b1dbb2d42ba9118237794f7c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddSkipLevelsForSpellProgression(
        int[]? levels = null)
    {
      var component = new SkipLevelsForSpellProgression();
      component.Levels = levels ?? component.Levels;
      if (component.Levels is null)
      {
        component.Levels = new int[0];
      }
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
  }
}

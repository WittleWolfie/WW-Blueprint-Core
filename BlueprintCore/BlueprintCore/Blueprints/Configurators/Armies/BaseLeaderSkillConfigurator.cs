//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLeaderSkill"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLeaderSkillConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintLeaderSkill
    where TBuilder : BaseLeaderSkillConfigurator<T, TBuilder>
  {
    protected BaseLeaderSkillConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderSkill.Icon"/>
    /// </summary>
    public TBuilder SetIcon(Asset<Sprite> icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Icon = icon?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderSkill.Icon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Icon is null) { return; }
          action.Invoke(bp.Icon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderSkill.LocalizedName"/>
    /// </summary>
    ///
    /// <param name="localizedName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedName(LocalString localizedName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedName = localizedName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderSkill.LocalizedName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedName is null) { return; }
          action.Invoke(bp.LocalizedName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderSkill.LocalizedDescription"/>
    /// </summary>
    ///
    /// <param name="localizedDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedDescription(LocalString localizedDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedDescription = localizedDescription?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderSkill.LocalizedDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedDescription is null) { return; }
          action.Invoke(bp.LocalizedDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderSkill.BonusAttributes"/>
    /// </summary>
    public TBuilder SetBonusAttributes(LeaderAttributes bonusAttributes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(bonusAttributes);
          bp.BonusAttributes = bonusAttributes;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderSkill.BonusAttributes"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBonusAttributes(Action<LeaderAttributes> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BonusAttributes is null) { return; }
          action.Invoke(bp.BonusAttributes);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderSkill.Type"/>
    /// </summary>
    public TBuilder SetType(ArmyLeaderSkillType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderSkill.StackTag"/>
    /// </summary>
    public TBuilder SetStackTag(StackTag stackTag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StackTag = stackTag;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderSkill.m_PrerequisiteLevel"/>
    /// </summary>
    public TBuilder SetPrerequisiteLevel(int prerequisiteLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PrerequisiteLevel = prerequisiteLevel;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderSkill.m_Prerequisites"/>
    /// </summary>
    ///
    /// <param name="prerequisites">
    /// <para>
    /// Blueprint of type BlueprintLeaderSkill. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPrerequisites(params Blueprint<BlueprintLeaderSkillReference>[] prerequisites)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Prerequisites = prerequisites.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintLeaderSkill.m_Prerequisites"/>
    /// </summary>
    ///
    /// <param name="prerequisites">
    /// <para>
    /// Blueprint of type BlueprintLeaderSkill. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPrerequisites(params Blueprint<BlueprintLeaderSkillReference>[] prerequisites)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Prerequisites = bp.m_Prerequisites ?? new BlueprintLeaderSkillReference[0];
          bp.m_Prerequisites = CommonTool.Append(bp.m_Prerequisites, prerequisites.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLeaderSkill.m_Prerequisites"/>
    /// </summary>
    ///
    /// <param name="prerequisites">
    /// <para>
    /// Blueprint of type BlueprintLeaderSkill. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPrerequisites(params Blueprint<BlueprintLeaderSkillReference>[] prerequisites)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Prerequisites is null) { return; }
          bp.m_Prerequisites = bp.m_Prerequisites.Where(val => !prerequisites.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLeaderSkill.m_Prerequisites"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPrerequisites(Func<BlueprintLeaderSkillReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Prerequisites is null) { return; }
          bp.m_Prerequisites = bp.m_Prerequisites.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintLeaderSkill.m_Prerequisites"/>
    /// </summary>
    public TBuilder ClearPrerequisites()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Prerequisites = new BlueprintLeaderSkillReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderSkill.m_Prerequisites"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPrerequisites(Action<BlueprintLeaderSkillReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Prerequisites is null) { return; }
          bp.m_Prerequisites.ForEach(action);
        });
    }

    /// <summary>
    /// Adds <see cref="AddFactOnLeaderUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel4BladeOfTheSun</term><description>03709f1c0bf543c2b20cbe7b6b6f35b8</description></item>
    /// <item><term>RangerFlare</term><description>c9cc76add2274ce897f1f0e03f5a7767</description></item>
    /// <item><term>Twincast</term><description>c89ae5f2f37f4a37ae76938010bab8f3</description></item>
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
    public TBuilder AddFactOnLeaderUnit(
        List<Blueprint<BlueprintUnitFactReference>>? facts = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddFactOnLeaderUnit();
      component.m_Facts = facts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Facts;
      if (component.m_Facts is null)
      {
        component.m_Facts = new BlueprintUnitFactReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddFactOnTacticalUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon3Spikes</term><description>c8f8bc842512415a85d233417e03f698</description></item>
    /// <item><term>LineOfSteel</term><description>7ffb41491cf57ab4db98b5f403921af8</description></item>
    /// <item><term>WoundedLeaderSkill</term><description>3091a59090c84b0bb61aba642d6b5309</description></item>
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
    public TBuilder AddFactOnTacticalUnit(
        List<Blueprint<BlueprintUnitFactReference>>? facts = null,
        TargetFilter? targetController = null)
    {
      var component = new AddFactOnTacticalUnit();
      component.m_Facts = facts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Facts;
      if (component.m_Facts is null)
      {
        component.m_Facts = new BlueprintUnitFactReference[0];
      }
      Validate(targetController);
      component.m_TargetController = targetController ?? component.m_TargetController;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CastOnTacticalCombatStart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon5BaneOfDemons</term><description>6f939176228c4866bc86d55eba6484db</description></item>
    /// <item><term>Trickster3KillOrder</term><description>917aed4bb2c947a080b3076832454788</description></item>
    /// <item><term>Trickster3PlaceOfPower</term><description>9d6543ea99704324920f49cbf56d12cc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spellToCast">
    /// <para>
    /// InfoBox: Can be any skill not only from leader abilities
    /// </para>
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
    public TBuilder AddCastOnTacticalCombatStart(
        List<int>? allowedColumns = null,
        Blueprint<BlueprintAbilityReference>? spellToCast = null,
        bool? targetCell = null)
    {
      var component = new CastOnTacticalCombatStart();
      component.m_AllowedColumns = allowedColumns ?? component.m_AllowedColumns;
      if (component.m_AllowedColumns is null)
      {
        component.m_AllowedColumns = new();
      }
      component.m_SpellToCast = spellToCast?.Reference ?? component.m_SpellToCast;
      if (component.m_SpellToCast is null)
      {
        component.m_SpellToCast = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      component.m_TargetCell = targetCell ?? component.m_TargetCell;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LeaderExpBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ExampleForSoldiersLeaderSkill</term><description>c5c8fbdc2c634838a63cba35ef419c97</description></item>
    /// <item><term>StrivingForDistinctionLevel2</term><description>7cb21436cf904d57a399cf5d12e918e7</description></item>
    /// <item><term>ZealousLearnerRank2</term><description>665cb61bfcba4a2697f95b21f4249220</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="bonusSkills">
    /// <para>
    /// Blueprint of type BlueprintLeaderSkillsList. You can pass in the blueprint using:
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
    public TBuilder AddLeaderExpBonus(
        int? bonusPercent = null,
        Blueprint<BlueprintLeaderSkillsList.Reference>? bonusSkills = null,
        int? levelForBonusSkills = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new LeaderExpBonus();
      component.m_BonusPercent = bonusPercent ?? component.m_BonusPercent;
      component.m_BonusSkills = bonusSkills?.Reference ?? component.m_BonusSkills;
      if (component.m_BonusSkills is null)
      {
        component.m_BonusSkills = BlueprintTool.GetRef<BlueprintLeaderSkillsList.Reference>(null);
      }
      component.m_LevelForBonusSkills = levelForBonusSkills ?? component.m_LevelForBonusSkills;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="LeaderPercentAttributeBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel4Infirmary</term><description>bae2503e267c4ed0aaef4b3daa9a6df1</description></item>
    /// <item><term>BuildingHospitalSkill8</term><description>23b8f6b44add4c4c9ebc2c3d342caecb</description></item>
    /// <item><term>ReductionOfLosses9</term><description>d331fe09237c4c8682740cac957b02aa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="percentBonuses">
    /// <para>
    /// InfoBox: Add bonus as percent of base stat value (that is setup in level progression)
    /// </para>
    /// </param>
    public TBuilder AddLeaderPercentAttributeBonus(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        LeaderAttributes? percentBonuses = null)
    {
      var component = new LeaderPercentAttributeBonus();
      Validate(percentBonuses);
      component.m_PercentBonuses = percentBonuses ?? component.m_PercentBonuses;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MaxArmySquadsBonusLeaderComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmySupervisionRank1</term><description>a3d140d99d62480e92db5fe20bf2e8dd</description></item>
    /// <item><term>ArmySupervisionRank3</term><description>0adc1e6332624c3b89bea894467858fc</description></item>
    /// <item><term>ArmySupervisionRank4</term><description>f07aad87a5b0435ea1a343f6f5bfb5a4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="armySizeBonus">
    /// <para>
    /// InfoBox: Extend current army size by this value (stackable bonus)
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddMaxArmySquadsBonusLeaderComponent(
        int? armySizeBonus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new MaxArmySquadsBonusLeaderComponent();
      component.m_ArmySizeBonus = armySizeBonus ?? component.m_ArmySizeBonus;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PlaceLeaderTrapOnCombatStart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Preparation</term><description>3b3451bc430049328dbeba0c61d93252</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="possibleTrapSkills">
    /// <para>
    /// Blueprint of type BlueprintLeaderSkill. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddPlaceLeaderTrapOnCombatStart(
        List<int>? allowedColumns = null,
        List<Blueprint<BlueprintLeaderSkillReference>>? possibleTrapSkills = null)
    {
      var component = new PlaceLeaderTrapOnCombatStart();
      component.m_AllowedColumns = allowedColumns ?? component.m_AllowedColumns;
      if (component.m_AllowedColumns is null)
      {
        component.m_AllowedColumns = new();
      }
      component.m_PossibleTrapSkills = possibleTrapSkills?.Select(bp => bp.Reference)?.ToArray() ?? component.m_PossibleTrapSkills;
      if (component.m_PossibleTrapSkills is null)
      {
        component.m_PossibleTrapSkills = new BlueprintLeaderSkillReference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveFactFromTacticalUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DeepDefences</term><description>8af2d1255a824b9ea1ad08e236f84dd7</description></item>
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
    public TBuilder AddRemoveFactFromTacticalUnit(
        List<Blueprint<BlueprintUnitFactReference>>? facts = null,
        TargetFilter? targetController = null)
    {
      var component = new RemoveFactFromTacticalUnit();
      component.m_Facts = facts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Facts;
      if (component.m_Facts is null)
      {
        component.m_Facts = new BlueprintUnitFactReference[0];
      }
      Validate(targetController);
      component.m_TargetController = targetController ?? component.m_TargetController;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SquadsActionOnTacticalCombatStart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BuildingDragon0Skill</term><description>3cd1a7d459324680ba82d6ea6cf4ed9c</description></item>
    /// <item><term>TacticianRank2</term><description>0ff5d350a002455b92628fa52569ef77</description></item>
    /// <item><term>TacticianRank3</term><description>5234a68ecf404794a3aee34c9416aecb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="bannedFacts">
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
    /// <param name="maxSquadsCount">
    /// <para>
    /// InfoBox: Action will be applied on random MaxSquadsCount filtered squads without banned facts.
    /// </para>
    /// </param>
    public TBuilder AddSquadsActionOnTacticalCombatStart(
        ActionsBuilder? actions = null,
        List<Blueprint<BlueprintUnitFactReference>>? bannedFacts = null,
        TargetFilter? filter = null,
        int? maxSquadsCount = null)
    {
      var component = new SquadsActionOnTacticalCombatStart();
      component.m_Actions = actions?.Build() ?? component.m_Actions;
      if (component.m_Actions is null)
      {
        component.m_Actions = Utils.Constants.Empty.Actions;
      }
      component.m_BannedFacts = bannedFacts?.Select(bp => bp.Reference)?.ToList() ?? component.m_BannedFacts;
      if (component.m_BannedFacts is null)
      {
        component.m_BannedFacts = new();
      }
      Validate(filter);
      component.m_Filter = filter ?? component.m_Filter;
      component.m_MaxSquadsCount = maxSquadsCount ?? component.m_MaxSquadsCount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalLeaderRitualComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel3BoltOfJustice</term><description>685a47c6bd594a62968b4ab3a4baa5a4</description></item>
    /// <item><term>RangerFrostBlastTrap</term><description>f9a9eac13a0ef774eb33d7cadeb00a8d</description></item>
    /// <item><term>RitualTrueStrike</term><description>fdc4b6a9aeb44c3f9b0b4a224c7a69fb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="ability">
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
    public TBuilder AddTacticalLeaderRitualComponent(
        Blueprint<BlueprintAbilityReference>? ability = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TacticalLeaderRitualComponent();
      component.m_Ability = ability?.Reference ?? component.m_Ability;
      if (component.m_Ability is null)
      {
        component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ArmyLeaderAddResourcesOnBattleEnd"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Pillage</term><description>d4e55c26520a4aa399b63e9e78481cc3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="onlyOnVictory">
    /// <para>
    /// InfoBox: Triggers on lose too if false
    /// </para>
    /// </param>
    public TBuilder AddArmyLeaderAddResourcesOnBattleEnd(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? onlyOnVictory = null,
        KingdomResourcesAmount? resourcesAmount = null)
    {
      var component = new ArmyLeaderAddResourcesOnBattleEnd();
      component.OnlyOnVictory = onlyOnVictory ?? component.OnlyOnVictory;
      component.m_ResourcesAmount = resourcesAmount ?? component.m_ResourcesAmount;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleModifier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BuildingSpiritualGardenSkill</term><description>923f02023f5f49f6842aabf3d3cf0e44</description></item>
    /// <item><term>IntimidationRank1</term><description>c465debec287c4f448050cda26a27b77</description></item>
    /// <item><term>Leadership6IncreaseMorale</term><description>796c4868365243cface2d36f997135a9</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddTacticalMoraleModifier(
        TacticalMoraleModifier.FactionTarget? factionTarget = null,
        int? modValue = null,
        TargetFilter? targetFilter = null)
    {
      var component = new TacticalMoraleModifier();
      component.m_FactionTarget = factionTarget ?? component.m_FactionTarget;
      component.m_ModValue = modValue ?? component.m_ModValue;
      Validate(targetFilter);
      component.m_TargetFilter = targetFilter ?? component.m_TargetFilter;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyGlobalMapMovementBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon1SpeedStats</term><description>62fcd9d0cdb54b59930c9b9bbb30a870</description></item>
    /// <item><term>Logistics4MovementPoints</term><description>177c84d3733a4ef2865694736714f2d7</description></item>
    /// <item><term>QuartermasterMaps</term><description>8830aeff4cc742f4a9f43fb152d8bfdb</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddArmyGlobalMapMovementBonus(
        int? dailyMovementPoints = null,
        int? maxMovementPoints = null)
    {
      var component = new ArmyGlobalMapMovementBonus();
      component.DailyMovementPoints = dailyMovementPoints ?? component.DailyMovementPoints;
      component.MaxMovementPoints = maxMovementPoints ?? component.MaxMovementPoints;
      return AddComponent(component);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.LocalizedName is null)
      {
        Blueprint.LocalizedName = Utils.Constants.Empty.String;
      }
      if (Blueprint.LocalizedDescription is null)
      {
        Blueprint.LocalizedDescription = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Prerequisites is null)
      {
        Blueprint.m_Prerequisites = new BlueprintLeaderSkillReference[0];
      }
    }
  }
}

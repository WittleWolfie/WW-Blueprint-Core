//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="LeadersRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLeadersRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : LeadersRoot
    where TBuilder : BaseLeadersRootConfigurator<T, TBuilder>
  {
    protected BaseLeadersRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_ExpTable"/>
    /// </summary>
    ///
    /// <param name="expTable">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExpTable(Blueprint<BlueprintStatProgression, BlueprintStatProgressionReference> expTable)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExpTable = expTable?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_ExpTable"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="expTable">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyExpTable(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExpTable is null) { return; }
          action.Invoke(bp.m_ExpTable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_Leaders"/>
    /// </summary>
    ///
    /// <param name="leaders">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLeaders(params Blueprint<BlueprintArmyLeader, BlueprintArmyLeaderReference>[] leaders)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Leaders = leaders.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="LeadersRoot.m_Leaders"/>
    /// </summary>
    ///
    /// <param name="leaders">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToLeaders(params Blueprint<BlueprintArmyLeader, BlueprintArmyLeaderReference>[] leaders)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Leaders = bp.m_Leaders ?? new BlueprintArmyLeaderReference[0];
          bp.m_Leaders = CommonTool.Append(bp.m_Leaders, leaders.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="LeadersRoot.m_Leaders"/>
    /// </summary>
    ///
    /// <param name="leaders">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLeaders(params Blueprint<BlueprintArmyLeader, BlueprintArmyLeaderReference>[] leaders)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Leaders is null) { return; }
          bp.m_Leaders = bp.m_Leaders.Where(val => !leaders.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="LeadersRoot.m_Leaders"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="leaders">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLeaders(Func<BlueprintArmyLeaderReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Leaders is null) { return; }
          bp.m_Leaders = bp.m_Leaders.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="LeadersRoot.m_Leaders"/>
    /// </summary>
    ///
    /// <param name="leaders">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearLeaders()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Leaders = new BlueprintArmyLeaderReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_Leaders"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="leaders">
    /// <para>
    /// Blueprint of type BlueprintArmyLeader. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyLeaders(Action<BlueprintArmyLeaderReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Leaders is null) { return; }
          bp.m_Leaders.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_AttackLeaderFeature"/>
    /// </summary>
    ///
    /// <param name="attackLeaderFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAttackLeaderFeature(Blueprint<BlueprintFeature, BlueprintFeatureReference> attackLeaderFeature)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AttackLeaderFeature = attackLeaderFeature?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_AttackLeaderFeature"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="attackLeaderFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAttackLeaderFeature(Action<BlueprintFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AttackLeaderFeature is null) { return; }
          action.Invoke(bp.m_AttackLeaderFeature);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_DeffenceLeaderFeature"/>
    /// </summary>
    ///
    /// <param name="deffenceLeaderFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDeffenceLeaderFeature(Blueprint<BlueprintFeature, BlueprintFeatureReference> deffenceLeaderFeature)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DeffenceLeaderFeature = deffenceLeaderFeature?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_DeffenceLeaderFeature"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="deffenceLeaderFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyDeffenceLeaderFeature(Action<BlueprintFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DeffenceLeaderFeature is null) { return; }
          action.Invoke(bp.m_DeffenceLeaderFeature);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_BaseManaRegen"/>
    /// </summary>
    public TBuilder SetBaseManaRegen(int baseManaRegen)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BaseManaRegen = baseManaRegen;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_BaseManaRegen"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaseManaRegen(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_BaseManaRegen);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.FirstLeadCost"/>
    /// </summary>
    public TBuilder SetFirstLeadCost(int firstLeadCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FirstLeadCost = firstLeadCost;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.FirstLeadCost"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFirstLeadCost(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FirstLeadCost);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.ReducedLeadCost"/>
    /// </summary>
    public TBuilder SetReducedLeadCost(int reducedLeadCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ReducedLeadCost = reducedLeadCost;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.ReducedLeadCost"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyReducedLeadCost(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ReducedLeadCost);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.LeadCostMultiply"/>
    /// </summary>
    public TBuilder SetLeadCostMultiply(float leadCostMultiply)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeadCostMultiply = leadCostMultiply;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.LeadCostMultiply"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeadCostMultiply(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.LeadCostMultiply);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_ArmyLeaderAssignmentCooldownDays"/>
    /// </summary>
    public TBuilder SetArmyLeaderAssignmentCooldownDays(int armyLeaderAssignmentCooldownDays)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmyLeaderAssignmentCooldownDays = armyLeaderAssignmentCooldownDays;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_ArmyLeaderAssignmentCooldownDays"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArmyLeaderAssignmentCooldownDays(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ArmyLeaderAssignmentCooldownDays);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_CheaperLeadersProject"/>
    /// </summary>
    ///
    /// <param name="cheaperLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCheaperLeadersProject(Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference> cheaperLeadersProject)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CheaperLeadersProject = cheaperLeadersProject?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_CheaperLeadersProject"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="cheaperLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyCheaperLeadersProject(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CheaperLeadersProject is null) { return; }
          action.Invoke(bp.m_CheaperLeadersProject);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_TalentedLeadersProject"/>
    /// </summary>
    ///
    /// <param name="talentedLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTalentedLeadersProject(Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference> talentedLeadersProject)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TalentedLeadersProject = talentedLeadersProject?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_TalentedLeadersProject"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="talentedLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyTalentedLeadersProject(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TalentedLeadersProject is null) { return; }
          action.Invoke(bp.m_TalentedLeadersProject);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_ExperiencedLeadersProject"/>
    /// </summary>
    ///
    /// <param name="experiencedLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExperiencedLeadersProject(Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference> experiencedLeadersProject)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExperiencedLeadersProject = experiencedLeadersProject?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_ExperiencedLeadersProject"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="experiencedLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyExperiencedLeadersProject(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExperiencedLeadersProject is null) { return; }
          action.Invoke(bp.m_ExperiencedLeadersProject);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.m_ExcellentLeadersProject"/>
    /// </summary>
    ///
    /// <param name="excellentLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExcellentLeadersProject(Blueprint<BlueprintKingdomProject, BlueprintKingdomProjectReference> excellentLeadersProject)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExcellentLeadersProject = excellentLeadersProject?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.m_ExcellentLeadersProject"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="excellentLeadersProject">
    /// <para>
    /// Blueprint of type BlueprintKingdomProject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyExcellentLeadersProject(Action<BlueprintKingdomProjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExcellentLeadersProject is null) { return; }
          action.Invoke(bp.m_ExcellentLeadersProject);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.SkillsListName"/>
    /// </summary>
    public TBuilder SetSkillsListName(LocalizedString skillsListName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SkillsListName = skillsListName;
          if (bp.SkillsListName is null)
          {
            bp.SkillsListName = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.SkillsListName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySkillsListName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SkillsListName is null) { return; }
          action.Invoke(bp.SkillsListName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.ManaName"/>
    /// </summary>
    public TBuilder SetManaName(LocalizedString manaName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ManaName = manaName;
          if (bp.ManaName is null)
          {
            bp.ManaName = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.ManaName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyManaName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ManaName is null) { return; }
          action.Invoke(bp.ManaName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.AttackBonusName"/>
    /// </summary>
    public TBuilder SetAttackBonusName(LocalizedString attackBonusName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AttackBonusName = attackBonusName;
          if (bp.AttackBonusName is null)
          {
            bp.AttackBonusName = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.AttackBonusName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAttackBonusName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AttackBonusName is null) { return; }
          action.Invoke(bp.AttackBonusName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.DeffBonusName"/>
    /// </summary>
    public TBuilder SetDeffBonusName(LocalizedString deffBonusName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeffBonusName = deffBonusName;
          if (bp.DeffBonusName is null)
          {
            bp.DeffBonusName = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.DeffBonusName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDeffBonusName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DeffBonusName is null) { return; }
          action.Invoke(bp.DeffBonusName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.SpellStrengthName"/>
    /// </summary>
    public TBuilder SetSpellStrengthName(LocalizedString spellStrengthName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellStrengthName = spellStrengthName;
          if (bp.SpellStrengthName is null)
          {
            bp.SpellStrengthName = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.SpellStrengthName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellStrengthName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpellStrengthName is null) { return; }
          action.Invoke(bp.SpellStrengthName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="LeadersRoot.LeaderHireText"/>
    /// </summary>
    public TBuilder SetLeaderHireText(LocalizedString leaderHireText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderHireText = leaderHireText;
          if (bp.LeaderHireText is null)
          {
            bp.LeaderHireText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="LeadersRoot.LeaderHireText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLeaderHireText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderHireText is null) { return; }
          action.Invoke(bp.LeaderHireText);
        });
    }
  }
}

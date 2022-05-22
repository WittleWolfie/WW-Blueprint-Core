//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomProject"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomProjectConfigurator<T, TBuilder>
    : BaseKingdomEventBaseConfigurator<T, TBuilder>
    where T : BlueprintKingdomProject
    where TBuilder : BaseKingdomProjectConfigurator<T, TBuilder>
  {
    protected BaseKingdomProjectConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomProject.ProjectType"/>
    /// </summary>
    public TBuilder SetProjectType(KingdomProjectType projectType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ProjectType = projectType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomProject.ProjectType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProjectType(Action<KingdomProjectType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ProjectType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomProject.ProjectStartCost"/>
    /// </summary>
    public TBuilder SetProjectStartCost(KingdomResourcesAmount projectStartCost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ProjectStartCost = projectStartCost;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomProject.ProjectStartCost"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProjectStartCost(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ProjectStartCost);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomProject.m_MechanicalDescription"/>
    /// </summary>
    public TBuilder SetMechanicalDescription(LocalizedString mechanicalDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MechanicalDescription = mechanicalDescription;
          if (bp.m_MechanicalDescription is null)
          {
            bp.m_MechanicalDescription = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomProject.m_MechanicalDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMechanicalDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MechanicalDescription is null) { return; }
          action.Invoke(bp.m_MechanicalDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomProject.SpendRulerTimeDays"/>
    /// </summary>
    public TBuilder SetSpendRulerTimeDays(int spendRulerTimeDays)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpendRulerTimeDays = spendRulerTimeDays;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomProject.SpendRulerTimeDays"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpendRulerTimeDays(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SpendRulerTimeDays);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomProject.Repeatable"/>
    /// </summary>
    public TBuilder SetRepeatable(bool repeatable = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Repeatable = repeatable;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomProject.Repeatable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRepeatable(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Repeatable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomProject.Cooldown"/>
    /// </summary>
    ///
    /// <param name="cooldown">
    /// <para>
    /// InfoBox: For UI only!!!
    /// </para>
    /// </param>
    public TBuilder SetCooldown(int cooldown)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Cooldown = cooldown;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomProject.Cooldown"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCooldown(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Cooldown);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomProject.IsRankUpProject"/>
    /// </summary>
    public TBuilder SetIsRankUpProject(bool isRankUpProject = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsRankUpProject = isRankUpProject;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomProject.IsRankUpProject"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsRankUpProject(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsRankUpProject);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomProject.RankupProjectFor"/>
    /// </summary>
    public TBuilder SetRankupProjectFor(KingdomStats.Type rankupProjectFor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RankupProjectFor = rankupProjectFor;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomProject.RankupProjectFor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRankupProjectFor(Action<KingdomStats.Type> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.RankupProjectFor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomProject.AIPriority"/>
    /// </summary>
    public TBuilder SetAIPriority(int aIPriority)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AIPriority = aIPriority;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomProject.AIPriority"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAIPriority(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AIPriority);
        });
    }

    /// <summary>
    /// Adds <see cref="EventItemCost"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Amber_ReforgeProject</term><description>3b4b2c6077fab6741b63b55a274bf18c</description></item>
    /// <item><term>KnightsEmblemChainmailProject_Enchanting</term><description>bde56061db6047f9bd5db9ed3f97beb7</description></item>
    /// <item><term>ZeorisDaggerRingProject_Enchanting</term><description>0dc3a4e036064970857b3c3e296a7d94</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="items">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEventItemCost(
        int? amount = null,
        List<Blueprint<BlueprintItemReference>>? items = null)
    {
      var component = new EventItemCost();
      component.Amount = amount ?? component.Amount;
      component.m_Items = items?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Items;
      if (component.m_Items is null)
      {
        component.m_Items = new BlueprintItemReference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FinishObjectiveOnTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DiplomacyRankUp2Project</term><description>eec2844333716044680b3e7c4f34d638</description></item>
    /// <item><term>LeadershipRankUp2Project</term><description>cb734f3fb88db0748876f2786fe6ae0d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="objective">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddFinishObjectiveOnTrigger(
        Blueprint<BlueprintQuestObjectiveReference>? objective = null)
    {
      var component = new FinishObjectiveOnTrigger();
      component.m_Objective = objective?.Reference ?? component.m_Objective;
      if (component.m_Objective is null)
      {
        component.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      return AddComponent(component);
    }
  }
}

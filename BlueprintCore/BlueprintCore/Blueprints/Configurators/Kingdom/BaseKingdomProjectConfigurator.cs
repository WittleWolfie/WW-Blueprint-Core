//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintKingdomProject>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.ProjectType = copyFrom.ProjectType;
          bp.ProjectStartCost = copyFrom.ProjectStartCost;
          bp.m_MechanicalDescription = copyFrom.m_MechanicalDescription;
          bp.SpendRulerTimeDays = copyFrom.SpendRulerTimeDays;
          bp.Repeatable = copyFrom.Repeatable;
          bp.Cooldown = copyFrom.Cooldown;
          bp.IsRankUpProject = copyFrom.IsRankUpProject;
          bp.RankupProjectFor = copyFrom.RankupProjectFor;
          bp.AIPriority = copyFrom.AIPriority;
        });
    }

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
    ///
    /// <param name="mechanicalDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetMechanicalDescription(LocalString mechanicalDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MechanicalDescription = mechanicalDescription?.LocalizedString;
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEventItemCost(
        int? amount = null,
        List<Blueprint<BlueprintItemReference>>? items = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new EventItemCost();
      component.Amount = amount ?? component.Amount;
      component.m_Items = items?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Items;
      if (component.m_Items is null)
      {
        component.m_Items = new BlueprintItemReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
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
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintQuestObjectiveReference>? objective = null)
    {
      var component = new FinishObjectiveOnTrigger();
      component.m_Objective = objective?.Reference ?? component.m_Objective;
      if (component.m_Objective is null)
      {
        component.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_MechanicalDescription is null)
      {
        Blueprint.m_MechanicalDescription = Utils.Constants.Empty.String;
      }
    }
  }
}

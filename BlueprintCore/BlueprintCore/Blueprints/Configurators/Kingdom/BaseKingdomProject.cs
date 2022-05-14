//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Kingdom.Blueprints;
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
    protected BaseKingdomProjectConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEventItemCost(
        int? amount = null,
        List<Blueprint<BlueprintItem, BlueprintItemReference>>? items = null)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddFinishObjectiveOnTrigger(
        Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>? objective = null)
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

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.RandomEncounters;
using Kingmaker.RandomEncounters.Settings;
using System;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaConfigurator<T, TBuilder>
    : BaseAreaPartConfigurator<T, TBuilder>
    where T : BlueprintArea
    where TBuilder : BaseAreaConfigurator<T, TBuilder>
  {
    protected BaseAreaConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="CampingEncounterIncreaseDifficulty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC2_Graveyard</term><description>cda59ec4352849febaf0bf52fd55074d</description></item>
    /// <item><term>DLC2_RichQuarter</term><description>caf98d57bafa456d9a0afc98f25fe720</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddCampingEncounterIncreaseDifficulty(
        float? increaseChance = null,
        int? increaseDifficulty = null)
    {
      var component = new CampingEncounterIncreaseDifficulty();
      component.m_IncreaseChance = increaseChance ?? component.m_IncreaseChance;
      component.m_IncreaseDifficulty = increaseDifficulty ?? component.m_IncreaseDifficulty;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RE_KareliaCanyon</term><description>03fca664fc43fb040aae42bb0f41c23c</description></item>
    /// <item><term>RE_SarkorisDisaster_2</term><description>c7125176689d3814199266e2ad2c3077</description></item>
    /// <item><term>RE_WoundedForest</term><description>da702e8d79c6046439c17e7e9cbfd758</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="defaultEnterPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="goodAvoidanceEnterPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCombatRandomEncounterAreaSettings(
        GlobalMapZone[]? allowedNaturalSettings = null,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? defaultEnterPoint = null,
        CombatRandomEncounterAreaSettings.Formation[]? formations = null,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? goodAvoidanceEnterPoint = null)
    {
      var component = new CombatRandomEncounterAreaSettings();
      component.AllowedNaturalSettings = allowedNaturalSettings ?? component.AllowedNaturalSettings;
      if (component.AllowedNaturalSettings is null)
      {
        component.AllowedNaturalSettings = new GlobalMapZone[0];
      }
      component.m_DefaultEnterPoint = defaultEnterPoint?.Reference ?? component.m_DefaultEnterPoint;
      if (component.m_DefaultEnterPoint is null)
      {
        component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      foreach (var item in formations) { Validate(item); }
      component.Formations = formations ?? component.Formations;
      if (component.Formations is null)
      {
        component.Formations = new CombatRandomEncounterAreaSettings.Formation[0];
      }
      component.m_GoodAvoidanceEnterPoint = goodAvoidanceEnterPoint?.Reference ?? component.m_GoodAvoidanceEnterPoint;
      if (component.m_GoodAvoidanceEnterPoint is null)
      {
        component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AzataIsland</term><description>31bab5549f7ea384186159a238360c8d</description></item>
    /// <item><term>DLC2_Tavern</term><description>dec10943d88040d0962f530cb4f2be63</description></item>
    /// <item><term>WarCamp</term><description>7a25c101fe6f7aa46b192db13373d03b</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddOverrideCampingAction(
        ActionsBuilder? onRestActions = null,
        bool? skipRest = null)
    {
      var component = new OverrideCampingAction();
      component.OnRestActions = onRestActions?.Build() ?? component.OnRestActions;
      if (component.OnRestActions is null)
      {
        component.OnRestActions = Utils.Constants.Empty.Actions;
      }
      component.SkipRest = skipRest ?? component.SkipRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AutoKingdomProjectsControllerCh3</term><description>b31b96dd34f8415382c8ec26787364d3</description></item>
    /// <item><term>FlagTrickster3Economy</term><description>4b833c6fcdfa47918927d80edf7ef9ae</description></item>
    /// <item><term>SettlementsTracker_buff</term><description>71dd611cd70443fcb04f0dce3bda76ef</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEveryDayTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? skipDays = null)
    {
      var component = new EveryDayTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Condition = condition?.Build() ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = Utils.Constants.Empty.Conditions;
      }
      component.SkipDays = skipDays ?? component.SkipDays;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagTrickster1Money</term><description>6c97784129e5492fa08496f2d4139f22</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEveryWeekTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? skipWeeks = null)
    {
      var component = new EveryWeekTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Condition = condition?.Build() ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = Utils.Constants.Empty.Conditions;
      }
      component.SkipWeeks = skipWeeks ?? component.SkipWeeks;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DireNarlmarches</term><description>2324df9aed3e41941823f4431ccabe48</description></item>
    /// <item><term>Outskirts</term><description>b383f239d93c0854eafde50bc583226f</description></item>
    /// <item><term>Varnhold_Water</term><description>8928e6ab3ff319d458453f1e037d2205</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="aIBuildListCity">
    /// <para>
    /// Blueprint of type SettlementBuildList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="aIBuildListTown">
    /// <para>
    /// Blueprint of type SettlementBuildList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="aIBuildListVillage">
    /// <para>
    /// Blueprint of type SettlementBuildList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSettlementAISettings(
        Blueprint<SettlementBuildList, SettlementBuildListReference>? aIBuildListCity = null,
        Blueprint<SettlementBuildList, SettlementBuildListReference>? aIBuildListTown = null,
        Blueprint<SettlementBuildList, SettlementBuildListReference>? aIBuildListVillage = null)
    {
      var component = new SettlementAISettings();
      component.m_AIBuildListCity = aIBuildListCity?.Reference ?? component.m_AIBuildListCity;
      if (component.m_AIBuildListCity is null)
      {
        component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(null);
      }
      component.m_AIBuildListTown = aIBuildListTown?.Reference ?? component.m_AIBuildListTown;
      if (component.m_AIBuildListTown is null)
      {
        component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(null);
      }
      component.m_AIBuildListVillage = aIBuildListVillage?.Reference ?? component.m_AIBuildListVillage;
      if (component.m_AIBuildListVillage is null)
      {
        component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(null);
      }
      return AddComponent(component);
    }
  }
}

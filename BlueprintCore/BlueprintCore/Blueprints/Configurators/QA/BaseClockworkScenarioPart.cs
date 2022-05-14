//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.QA.Clockwork;
using System;

namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintClockworkScenarioPart"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseClockworkScenarioPartConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintClockworkScenarioPart
    where TBuilder : BaseClockworkScenarioPartConfigurator<T, TBuilder>
  {
    protected BaseClockworkScenarioPartConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="AreaTest"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/Area Test
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>123</term><description>535217378b8a4ca3ba5a45f0002de07c</description></item>
    /// <item><term>Drezen_Prison</term><description>eab84d625d847bf48864dbe56d30e0b6</description></item>
    /// <item><term>WarCamp_Start_Simple</term><description>cc9b472d6185c754f9f7f8090aef6c8b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="areaPart">
    /// <para>
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAreaTest(
        Blueprint<BlueprintArea, BlueprintAreaReference>? area = null,
        Blueprint<BlueprintAreaPart, BlueprintAreaPartReference>? areaPart = null,
        ClockworkCommandList? commandList = null,
        Condition? condition = null,
        bool? everyVisit = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AreaTest();
      component.Area = area?.Reference ?? component.Area;
      if (component.Area is null)
      {
        component.Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      component.AreaPart = areaPart?.Reference ?? component.AreaPart;
      if (component.AreaPart is null)
      {
        component.AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(null);
      }
      Validate(commandList);
      component.CommandList = commandList ?? component.CommandList;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      component.EveryVisit = everyVisit ?? component.EveryVisit;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ConditionalCommandList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/Conditional Command List
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>chap0</term><description>95c4212a36594186b509e87d00d2d480</description></item>
    /// <item><term>mDemon3chap</term><description>6383f35b37eb4a83a8a8458f2937156c</description></item>
    /// <item><term>WoljifQ</term><description>d79f05dbd35b468fa16312f30d61a5e1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddConditionalCommandList(
        ClockworkCommandList? commandList = null,
        Condition? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new ConditionalCommandList();
      Validate(commandList);
      component.CommandList = commandList ?? component.CommandList;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MythicLevelUpPlan"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/MythicLevelUpPlan
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_Fighter</term><description>de62074c6cc24ce89073a349aebefef6</description></item>
    /// <item><term>Lich_Fighter</term><description>b0ec7b4817594e7aa941d4c2cd6d04a6</description></item>
    /// <item><term>Trickster_Fighter</term><description>3e0f32cbd70a4773aff644efc48451ab</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="beginnerMythic">
    /// <para>
    /// InfoBox: Первые 2 уровня доступен только Mythic Hero
    /// </para>
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
    /// <param name="earlyMythic">
    /// <para>
    /// InfoBox: План срабатывает при левелапе на 3 уровень
    /// </para>
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
    /// <param name="lateMythic">
    /// <para>
    /// InfoBox: План срабатывает при левелапе на 9 уровень
    /// </para>
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
    public TBuilder AddMythicLevelUpPlan(
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? beginnerMythic = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? earlyMythic = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? lateMythic = null)
    {
      var component = new MythicLevelUpPlan();
      component.BeginnerMythic = beginnerMythic?.Reference ?? component.BeginnerMythic;
      if (component.BeginnerMythic is null)
      {
        component.BeginnerMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.EarlyMythic = earlyMythic?.Reference ?? component.EarlyMythic;
      if (component.EarlyMythic is null)
      {
        component.EarlyMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.LateMythic = lateMythic?.Reference ?? component.LateMythic;
      if (component.LateMythic is null)
      {
        component.LateMythic = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NavmeshHolesChecker"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Clockwork/NavmeshHolesChecker
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_Fighter</term><description>de62074c6cc24ce89073a349aebefef6</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddNavmeshHolesChecker(
        bool? isInit = null,
        float? lastHeight = null,
        float? maxDeltaHeightPerFrame = null)
    {
      var component = new NavmeshHolesChecker();
      component.m_IsInit = isInit ?? component.m_IsInit;
      component.m_LastHeight = lastHeight ?? component.m_LastHeight;
      component.MaxDeltaHeightPerFrame = maxDeltaHeightPerFrame ?? component.MaxDeltaHeightPerFrame;
      return AddComponent(component);
    }
  }
}

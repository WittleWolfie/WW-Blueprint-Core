//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;

namespace BlueprintCore.Blueprints.Configurators.Facts
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFact"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFactConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintFact
    where TBuilder : BaseFactConfigurator<T, TBuilder>
  {
    protected BaseFactConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="ComponentsList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GibberingSwarmCave</term><description>d663f351f18b27846a30970a635a73fa</description></item>
    /// <item><term>LostChapel</term><description>2183cc056a7b5d647ad475c8bc6c2074</description></item>
    /// <item><term>Wintersun_Default</term><description>87839550c801db944b102f61084fd245</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="list">
    /// <para>
    /// Blueprint of type BlueprintComponentList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddComponentsList(
        Blueprint<BlueprintComponentList, BlueprintComponentListReference>? list = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ComponentsList();
      component.m_List = list?.Reference ?? component.m_List;
      if (component.m_List is null)
      {
        component.m_List = BlueprintTool.GetRef<BlueprintComponentListReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddBuffActions"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Artifact_HornsOfNaragaUnsummonBuff</term><description>bf24f9a2ae9047029f53ef8c797c50cf</description></item>
    /// <item><term>DLC3_HasteIslandBuff</term><description>5ebf1f33e08f47f89d83bb951248fffa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddBuffActions(
        ActionsBuilder? activated = null,
        ActionsBuilder? deactivated = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ActionsBuilder? newRound = null)
    {
      var component = new AddBuffActions();
      component.Activated = activated?.Build() ?? component.Activated;
      if (component.Activated is null)
      {
        component.Activated = Utils.Constants.Empty.Actions;
      }
      component.Deactivated = deactivated?.Build() ?? component.Deactivated;
      if (component.Deactivated is null)
      {
        component.Deactivated = Utils.Constants.Empty.Actions;
      }
      component.NewRound = newRound?.Build() ?? component.NewRound;
      if (component.NewRound is null)
      {
        component.NewRound = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddFactContextActions"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>GreaterMutagenDexterityStrengthBuff</term><description>d0a5cedfd497f3b4f9581b6066d9043b</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningFeature</term><description>0faee0a55f634902895b4e1faf828502</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddFactContextActions(
        ActionsBuilder? activated = null,
        ActionsBuilder? deactivated = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ActionsBuilder? newRound = null)
    {
      var component = new AddFactContextActions();
      component.Activated = activated?.Build() ?? component.Activated;
      if (component.Activated is null)
      {
        component.Activated = Utils.Constants.Empty.Actions;
      }
      component.Deactivated = deactivated?.Build() ?? component.Deactivated;
      if (component.Deactivated is null)
      {
        component.Deactivated = Utils.Constants.Empty.Actions;
      }
      component.NewRound = newRound?.Build() ?? component.NewRound;
      if (component.NewRound is null)
      {
        component.NewRound = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}

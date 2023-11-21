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
    protected BaseFactConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFact>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFact>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    return Self;
    }

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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddComponentsList(
        Blueprint<BlueprintComponentListReference>? list = null)
    {
      var component = new ComponentsList();
      component.m_List = list?.Reference ?? component.m_List;
      if (component.m_List is null)
      {
        component.m_List = BlueprintTool.GetRef<BlueprintComponentListReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffActions"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArchaeologistLuckActivatableBuff</term><description>176b86df542146ee81fe7d2f11920862</description></item>
    /// <item><term>DLC4_TimerKostil</term><description>cf1a37b4f4fb4b9d9ab4a002b6bda877</description></item>
    /// <item><term>StorastaIceGround</term><description>1fd0d50453d84f68b3528779920acf38</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBuffActions(
        ActionsBuilder? activated = null,
        ActionsBuilder? deactivated = null,
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
      return AddComponent(component);
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
    /// <item><term>HealingJudgmentBuff</term><description>b1b7eeb49d703b047a3a534f17863001</description></item>
    /// <item><term>ZonKuthonScarHalfHPTriggerBuff</term><description>b5eb1d0094f744889ca22bb4cfc1e648</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddFactContextActions(
        ActionsBuilder? activated = null,
        ActionsBuilder? deactivated = null,
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
      return AddComponent(component);
    }
  }
}

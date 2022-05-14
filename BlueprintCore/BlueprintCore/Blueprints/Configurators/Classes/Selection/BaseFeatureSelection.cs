//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes.Selection
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFeatureSelection"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFeatureSelectionConfigurator<T, TBuilder>
    : BaseFeatureConfigurator<T, TBuilder>
    where T : BlueprintFeatureSelection
    where TBuilder : BaseFeatureSelectionConfigurator<T, TBuilder>
  {
    protected BaseFeatureSelectionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="NoSelectionIfAlreadyHasFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodOfDragonsSelection</term><description>da48f9d7f697ae44ca891bfc50727988</description></item>
    /// <item><term>DomainsSelection</term><description>48525e5da45c9c243a343fc6545dbdb9</description></item>
    /// <item><term>SorcererBloodlineSelection</term><description>24bef8d1bee12274686f6da6ccbc8914</description></item>
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
    public TBuilder AddNoSelectionIfAlreadyHasFeature(
        bool? anyFeatureFromSelection = null,
        List<Blueprint<BlueprintFeature, BlueprintFeatureReference>>? features = null)
    {
      var component = new NoSelectionIfAlreadyHasFeature();
      component.AnyFeatureFromSelection = anyFeatureFromSelection ?? component.AnyFeatureFromSelection;
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Features;
      if (component.m_Features is null)
      {
        component.m_Features = new BlueprintFeatureReference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteSelectionPossible"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ExpandedDefense</term><description>d741f298dfae8fc40b4615aaf83b6548</description></item>
    /// <item><term>WildTalentBonusFeatEarth3</term><description>f593346da04badb4185a47af8e4c4f7f</description></item>
    /// <item><term>WildTalentBonusFeatWater5</term><description>40a4fb42aafa7ee4991d3e3140e98856</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// <param name="thisFeature">
    /// <para>
    /// Blueprint of type BlueprintFeatureSelection. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteSelectionPossible(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintFeatureSelection, BlueprintFeatureSelectionReference>? thisFeature = null)
    {
      var component = new PrerequisiteSelectionPossible();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.m_ThisFeature = thisFeature?.Reference ?? component.m_ThisFeature;
      if (component.m_ThisFeature is null)
      {
        component.m_ThisFeature = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}

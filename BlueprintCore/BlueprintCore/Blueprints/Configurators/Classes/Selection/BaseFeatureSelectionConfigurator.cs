//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Utility;
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
    protected BaseFeatureSelectionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelection.IgnorePrerequisites"/>
    /// </summary>
    public TBuilder SetIgnorePrerequisites(bool ignorePrerequisites = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnorePrerequisites = ignorePrerequisites;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelection.Obligatory"/>
    /// </summary>
    public TBuilder SetObligatory(bool obligatory = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Obligatory = obligatory;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelection.Mode"/>
    /// </summary>
    public TBuilder SetMode(SelectionMode mode)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Mode = mode;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelection.Group"/>
    /// </summary>
    public TBuilder SetGroup(FeatureGroup group)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Group = group;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelection.Group2"/>
    /// </summary>
    public TBuilder SetGroup2(FeatureGroup group2)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Group2 = group2;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    ///
    /// <param name="allFeatures">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAllFeatures(params Blueprint<BlueprintFeatureReference>[] allFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllFeatures = allFeatures.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    ///
    /// <param name="allFeatures">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAllFeatures(params Blueprint<BlueprintFeatureReference>[] allFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllFeatures = bp.m_AllFeatures ?? new BlueprintFeatureReference[0];
          bp.m_AllFeatures = CommonTool.Append(bp.m_AllFeatures, allFeatures.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    ///
    /// <param name="allFeatures">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAllFeatures(params Blueprint<BlueprintFeatureReference>[] allFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllFeatures is null) { return; }
          bp.m_AllFeatures = bp.m_AllFeatures.Where(val => !allFeatures.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeatureSelection.m_AllFeatures"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAllFeatures(Func<BlueprintFeatureReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllFeatures is null) { return; }
          bp.m_AllFeatures = bp.m_AllFeatures.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    public TBuilder ClearAllFeatures()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllFeatures = new BlueprintFeatureReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelection.m_AllFeatures"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAllFeatures(Action<BlueprintFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllFeatures is null) { return; }
          bp.m_AllFeatures.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelection.ShowThisSelection"/>
    /// </summary>
    public TBuilder SetShowThisSelection(bool showThisSelection = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShowThisSelection = showThisSelection;
        });
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteSelectionPossible"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// A feature selection with this component only shows up if the character is eligible for at least one feature.
    /// </para>
    /// <para>
    /// This is useful when a character has access to different feature selections based on some criteria.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ExpandedDefense</term><description>d741f298dfae8fc40b4615aaf83b6548</description></item>
    /// <item><term>WildTalentBonusFeatEarth3</term><description>f593346da04badb4185a47af8e4c4f7f</description></item>
    /// <item><term>WildTalentBonusFeatWater5</term><description>40a4fb42aafa7ee4991d3e3140e98856</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="thisFeature">
    /// <para>
    /// Blueprint of type BlueprintFeatureSelection. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteSelectionPossible(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Blueprint<BlueprintFeatureSelectionReference>? thisFeature = null)
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
      return AddComponent(component);
    }

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
    public TBuilder AddNoSelectionIfAlreadyHasFeature(
        bool? anyFeatureFromSelection = null,
        List<Blueprint<BlueprintFeatureReference>>? features = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new NoSelectionIfAlreadyHasFeature();
      component.AnyFeatureFromSelection = anyFeatureFromSelection ?? component.AnyFeatureFromSelection;
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Features;
      if (component.m_Features is null)
      {
        component.m_Features = new BlueprintFeatureReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_AllFeatures is null)
      {
        Blueprint.m_AllFeatures = new BlueprintFeatureReference[0];
      }
    }
  }
}

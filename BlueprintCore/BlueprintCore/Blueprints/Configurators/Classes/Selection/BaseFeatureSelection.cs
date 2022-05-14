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
    protected BaseFeatureSelectionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// Modifies <see cref="BlueprintFeatureSelection.IgnorePrerequisites"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIgnorePrerequisites(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IgnorePrerequisites);
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
    /// Modifies <see cref="BlueprintFeatureSelection.Obligatory"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyObligatory(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Obligatory);
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
    /// Modifies <see cref="BlueprintFeatureSelection.Mode"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMode(Action<SelectionMode> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Mode);
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
    /// Modifies <see cref="BlueprintFeatureSelection.Group"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGroup(Action<FeatureGroup> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Group);
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
    /// Modifies <see cref="BlueprintFeatureSelection.Group2"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGroup2(Action<FeatureGroup> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Group2);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureSelection.m_Features"/>
    /// </summary>
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
    public TBuilder SetFeatures(List<Blueprint<BlueprintFeature, BlueprintFeatureReference>> features)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Features = features?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintFeatureSelection.m_Features"/>
    /// </summary>
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
    public TBuilder AddToFeatures(params Blueprint<BlueprintFeature, BlueprintFeatureReference>[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Features = bp.m_Features ?? new BlueprintFeatureReference[0];
          bp.m_Features = CommonTool.Append(bp.m_Features, features.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeatureSelection.m_Features"/>
    /// </summary>
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
    public TBuilder RemoveFromFeatures(params Blueprint<BlueprintFeature, BlueprintFeatureReference>[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Features is null) { return; }
          bp.m_Features = bp.m_Features.Where(val => !features.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFeatureSelection.m_Features"/> that match the provided predicate.
    /// </summary>
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
    public TBuilder RemoveFromFeatures(Func<BlueprintFeatureReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Features is null) { return; }
          bp.m_Features = bp.m_Features.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFeatureSelection.m_Features"/>
    /// </summary>
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
    public TBuilder ClearFeatures()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Features = new BlueprintFeatureReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeatureSelection.m_Features"/> by invoking the provided action on each element.
    /// </summary>
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
    public TBuilder ModifyFeatures(Action<BlueprintFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Features is null) { return; }
          bp.m_Features.ForEach(action);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAllFeatures(List<Blueprint<BlueprintFeature, BlueprintFeatureReference>> allFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllFeatures = allFeatures?.Select(bp => bp.Reference)?.ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAllFeatures(params Blueprint<BlueprintFeature, BlueprintFeatureReference>[] allFeatures)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAllFeatures(params Blueprint<BlueprintFeature, BlueprintFeatureReference>[] allFeatures)
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
    ///
    /// <param name="allFeatures">
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
    public TBuilder RemoveFromAllFeatures(Func<BlueprintFeatureReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllFeatures is null) { return; }
          bp.m_AllFeatures = bp.m_AllFeatures.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    ///
    /// <param name="allFeatures">
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
    ///
    /// <param name="allFeatures">
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
    /// Modifies <see cref="BlueprintFeatureSelection.ShowThisSelection"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShowThisSelection(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ShowThisSelection);
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
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
  }
}

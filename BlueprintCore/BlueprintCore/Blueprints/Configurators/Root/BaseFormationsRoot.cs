//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Formations;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="FormationsRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFormationsRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : FormationsRoot
    where TBuilder : BaseFormationsRootConfigurator<T, TBuilder>
  {
    protected BaseFormationsRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="FormationsRoot.m_PredefinedFormations"/>
    /// </summary>
    ///
    /// <param name="predefinedFormations">
    /// <para>
    /// Blueprint of type BlueprintPartyFormation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPredefinedFormations(List<Blueprint<BlueprintPartyFormation, BlueprintPartyFormationReference>> predefinedFormations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PredefinedFormations = predefinedFormations?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="FormationsRoot.m_PredefinedFormations"/>
    /// </summary>
    ///
    /// <param name="predefinedFormations">
    /// <para>
    /// Blueprint of type BlueprintPartyFormation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPredefinedFormations(params Blueprint<BlueprintPartyFormation, BlueprintPartyFormationReference>[] predefinedFormations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PredefinedFormations = bp.m_PredefinedFormations ?? new BlueprintPartyFormationReference[0];
          bp.m_PredefinedFormations = CommonTool.Append(bp.m_PredefinedFormations, predefinedFormations.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FormationsRoot.m_PredefinedFormations"/>
    /// </summary>
    ///
    /// <param name="predefinedFormations">
    /// <para>
    /// Blueprint of type BlueprintPartyFormation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPredefinedFormations(params Blueprint<BlueprintPartyFormation, BlueprintPartyFormationReference>[] predefinedFormations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PredefinedFormations is null) { return; }
          bp.m_PredefinedFormations = bp.m_PredefinedFormations.Where(val => !predefinedFormations.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FormationsRoot.m_PredefinedFormations"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="predefinedFormations">
    /// <para>
    /// Blueprint of type BlueprintPartyFormation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPredefinedFormations(Func<BlueprintPartyFormationReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PredefinedFormations is null) { return; }
          bp.m_PredefinedFormations = bp.m_PredefinedFormations.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="FormationsRoot.m_PredefinedFormations"/>
    /// </summary>
    ///
    /// <param name="predefinedFormations">
    /// <para>
    /// Blueprint of type BlueprintPartyFormation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearPredefinedFormations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PredefinedFormations = new BlueprintPartyFormationReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="FormationsRoot.m_PredefinedFormations"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="predefinedFormations">
    /// <para>
    /// Blueprint of type BlueprintPartyFormation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyPredefinedFormations(Action<BlueprintPartyFormationReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PredefinedFormations is null) { return; }
          bp.m_PredefinedFormations.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FormationsRoot.m_FollowersFormation"/>
    /// </summary>
    ///
    /// <param name="followersFormation">
    /// <para>
    /// Blueprint of type FollowersFormation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFollowersFormation(Blueprint<FollowersFormation, BlueprintFollowersFormationReference> followersFormation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FollowersFormation = followersFormation?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="FormationsRoot.m_FollowersFormation"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="followersFormation">
    /// <para>
    /// Blueprint of type FollowersFormation. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyFollowersFormation(Action<BlueprintFollowersFormationReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FollowersFormation is null) { return; }
          action.Invoke(bp.m_FollowersFormation);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FormationsRoot.FormationsScale"/>
    /// </summary>
    public TBuilder SetFormationsScale(float formationsScale)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FormationsScale = formationsScale;
        });
    }

    /// <summary>
    /// Modifies <see cref="FormationsRoot.FormationsScale"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFormationsScale(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FormationsScale);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FormationsRoot.MinSpaceFactor"/>
    /// </summary>
    public TBuilder SetMinSpaceFactor(float minSpaceFactor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinSpaceFactor = minSpaceFactor;
        });
    }

    /// <summary>
    /// Modifies <see cref="FormationsRoot.MinSpaceFactor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinSpaceFactor(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinSpaceFactor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FormationsRoot.AutoFormation"/>
    /// </summary>
    public TBuilder SetAutoFormation(FormationsRoot.AutoFormationSettings autoFormation)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(autoFormation);
          bp.AutoFormation = autoFormation;
        });
    }

    /// <summary>
    /// Modifies <see cref="FormationsRoot.AutoFormation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAutoFormation(Action<FormationsRoot.AutoFormationSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AutoFormation is null) { return; }
          action.Invoke(bp.AutoFormation);
        });
    }
  }
}

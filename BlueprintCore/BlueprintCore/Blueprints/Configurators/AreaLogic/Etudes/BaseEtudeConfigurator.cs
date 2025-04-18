//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Capital;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Root;
using Kingmaker.Controllers.Combat;
using Kingmaker.Controllers.Rest;
using Kingmaker.Corruption;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Localization;
using Kingmaker.Sound;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Etudes;
using Kingmaker.Utility;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Etudes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintEtude"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseEtudeConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintEtude
    where TBuilder : BaseEtudeConfigurator<T, TBuilder>
  {
    protected BaseEtudeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintEtude>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Parent = copyFrom.m_Parent;
          bp.ActivationCondition = copyFrom.ActivationCondition;
          bp.CompletionCondition = copyFrom.CompletionCondition;
          bp.m_Synchronized = copyFrom.m_Synchronized;
          bp.m_AllowActionStart = copyFrom.m_AllowActionStart;
          bp.m_LinkedAreaPart = copyFrom.m_LinkedAreaPart;
          bp.m_LinkedCampaigns = copyFrom.m_LinkedCampaigns;
          bp.m_IncludeAreaParts = copyFrom.m_IncludeAreaParts;
          bp.m_AddedAreaMechanics = copyFrom.m_AddedAreaMechanics;
          bp.m_StartsWith = copyFrom.m_StartsWith;
          bp.m_StartsOnComplete = copyFrom.m_StartsOnComplete;
          bp.m_StartsParent = copyFrom.m_StartsParent;
          bp.m_CompletesParent = copyFrom.m_CompletesParent;
          bp.m_ConflictingGroups = copyFrom.m_ConflictingGroups;
          bp.Priority = copyFrom.Priority;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintEtude>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Parent = copyFrom.m_Parent;
          bp.ActivationCondition = copyFrom.ActivationCondition;
          bp.CompletionCondition = copyFrom.CompletionCondition;
          bp.m_Synchronized = copyFrom.m_Synchronized;
          bp.m_AllowActionStart = copyFrom.m_AllowActionStart;
          bp.m_LinkedAreaPart = copyFrom.m_LinkedAreaPart;
          bp.m_LinkedCampaigns = copyFrom.m_LinkedCampaigns;
          bp.m_IncludeAreaParts = copyFrom.m_IncludeAreaParts;
          bp.m_AddedAreaMechanics = copyFrom.m_AddedAreaMechanics;
          bp.m_StartsWith = copyFrom.m_StartsWith;
          bp.m_StartsOnComplete = copyFrom.m_StartsOnComplete;
          bp.m_StartsParent = copyFrom.m_StartsParent;
          bp.m_CompletesParent = copyFrom.m_CompletesParent;
          bp.m_ConflictingGroups = copyFrom.m_ConflictingGroups;
          bp.Priority = copyFrom.Priority;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_Parent"/>
    /// </summary>
    ///
    /// <param name="parent">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetParent(Blueprint<BlueprintEtudeReference> parent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Parent = parent?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.m_Parent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyParent(Action<BlueprintEtudeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Parent is null) { return; }
          action.Invoke(bp.m_Parent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.ActivationCondition"/>
    /// </summary>
    public TBuilder SetActivationCondition(ConditionsBuilder activationCondition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActivationCondition = activationCondition?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.ActivationCondition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActivationCondition(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ActivationCondition is null) { return; }
          action.Invoke(bp.ActivationCondition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.CompletionCondition"/>
    /// </summary>
    public TBuilder SetCompletionCondition(ConditionsBuilder completionCondition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CompletionCondition = completionCondition?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.CompletionCondition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCompletionCondition(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CompletionCondition is null) { return; }
          action.Invoke(bp.CompletionCondition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_Synchronized"/>
    /// </summary>
    ///
    /// <param name="synchronized">
    /// <para>
    /// Tooltip: Этот этюд не будет активироваться, если не активны этюды из этого списка. Если этот список не пуст, в этюде нельзя использовать актеров.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSynchronized(params Blueprint<BlueprintEtudeReference>[] synchronized)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Synchronized = synchronized.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEtude.m_Synchronized"/>
    /// </summary>
    ///
    /// <param name="synchronized">
    /// <para>
    /// Tooltip: Этот этюд не будет активироваться, если не активны этюды из этого списка. Если этот список не пуст, в этюде нельзя использовать актеров.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToSynchronized(params Blueprint<BlueprintEtudeReference>[] synchronized)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Synchronized = bp.m_Synchronized ?? new();
          bp.m_Synchronized.AddRange(synchronized.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_Synchronized"/>
    /// </summary>
    ///
    /// <param name="synchronized">
    /// <para>
    /// Tooltip: Этот этюд не будет активироваться, если не активны этюды из этого списка. Если этот список не пуст, в этюде нельзя использовать актеров.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSynchronized(params Blueprint<BlueprintEtudeReference>[] synchronized)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Synchronized is null) { return; }
          bp.m_Synchronized = bp.m_Synchronized.Where(val => !synchronized.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_Synchronized"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSynchronized(Func<BlueprintEtudeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Synchronized is null) { return; }
          bp.m_Synchronized = bp.m_Synchronized.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEtude.m_Synchronized"/>
    /// </summary>
    public TBuilder ClearSynchronized()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Synchronized = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.m_Synchronized"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySynchronized(Action<BlueprintEtudeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Synchronized is null) { return; }
          bp.m_Synchronized.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_AllowActionStart"/>
    /// </summary>
    public TBuilder SetAllowActionStart(bool allowActionStart = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllowActionStart = allowActionStart;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_LinkedAreaPart"/>
    /// </summary>
    ///
    /// <param name="linkedAreaPart">
    /// <para>
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLinkedAreaPart(Blueprint<BlueprintAreaPartReference> linkedAreaPart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LinkedAreaPart = linkedAreaPart?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.m_LinkedAreaPart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLinkedAreaPart(Action<BlueprintAreaPartReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LinkedAreaPart is null) { return; }
          action.Invoke(bp.m_LinkedAreaPart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_LinkedCampaigns"/>
    /// </summary>
    ///
    /// <param name="linkedCampaigns">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetLinkedCampaigns(params Blueprint<BlueprintCampaignReference>[] linkedCampaigns)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LinkedCampaigns = linkedCampaigns.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEtude.m_LinkedCampaigns"/>
    /// </summary>
    ///
    /// <param name="linkedCampaigns">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToLinkedCampaigns(params Blueprint<BlueprintCampaignReference>[] linkedCampaigns)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LinkedCampaigns = bp.m_LinkedCampaigns ?? new();
          bp.m_LinkedCampaigns.AddRange(linkedCampaigns.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_LinkedCampaigns"/>
    /// </summary>
    ///
    /// <param name="linkedCampaigns">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromLinkedCampaigns(params Blueprint<BlueprintCampaignReference>[] linkedCampaigns)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LinkedCampaigns is null) { return; }
          bp.m_LinkedCampaigns = bp.m_LinkedCampaigns.Where(val => !linkedCampaigns.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_LinkedCampaigns"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLinkedCampaigns(Func<BlueprintCampaignReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LinkedCampaigns is null) { return; }
          bp.m_LinkedCampaigns = bp.m_LinkedCampaigns.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEtude.m_LinkedCampaigns"/>
    /// </summary>
    public TBuilder ClearLinkedCampaigns()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LinkedCampaigns = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.m_LinkedCampaigns"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLinkedCampaigns(Action<BlueprintCampaignReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LinkedCampaigns is null) { return; }
          bp.m_LinkedCampaigns.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_IncludeAreaParts"/>
    /// </summary>
    public TBuilder SetIncludeAreaParts(bool includeAreaParts = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeAreaParts = includeAreaParts;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_AddedAreaMechanics"/>
    /// </summary>
    ///
    /// <param name="addedAreaMechanics">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAddedAreaMechanics(params Blueprint<BlueprintAreaMechanicsReference>[] addedAreaMechanics)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddedAreaMechanics = addedAreaMechanics.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEtude.m_AddedAreaMechanics"/>
    /// </summary>
    ///
    /// <param name="addedAreaMechanics">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAddedAreaMechanics(params Blueprint<BlueprintAreaMechanicsReference>[] addedAreaMechanics)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddedAreaMechanics = bp.m_AddedAreaMechanics ?? new();
          bp.m_AddedAreaMechanics.AddRange(addedAreaMechanics.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_AddedAreaMechanics"/>
    /// </summary>
    ///
    /// <param name="addedAreaMechanics">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAddedAreaMechanics(params Blueprint<BlueprintAreaMechanicsReference>[] addedAreaMechanics)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddedAreaMechanics is null) { return; }
          bp.m_AddedAreaMechanics = bp.m_AddedAreaMechanics.Where(val => !addedAreaMechanics.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_AddedAreaMechanics"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAddedAreaMechanics(Func<BlueprintAreaMechanicsReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddedAreaMechanics is null) { return; }
          bp.m_AddedAreaMechanics = bp.m_AddedAreaMechanics.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEtude.m_AddedAreaMechanics"/>
    /// </summary>
    public TBuilder ClearAddedAreaMechanics()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddedAreaMechanics = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.m_AddedAreaMechanics"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAddedAreaMechanics(Action<BlueprintAreaMechanicsReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddedAreaMechanics is null) { return; }
          bp.m_AddedAreaMechanics.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_StartsWith"/>
    /// </summary>
    ///
    /// <param name="startsWith">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartsWith(params Blueprint<BlueprintEtudeReference>[] startsWith)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartsWith = startsWith.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEtude.m_StartsWith"/>
    /// </summary>
    ///
    /// <param name="startsWith">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToStartsWith(params Blueprint<BlueprintEtudeReference>[] startsWith)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartsWith = bp.m_StartsWith ?? new();
          bp.m_StartsWith.AddRange(startsWith.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_StartsWith"/>
    /// </summary>
    ///
    /// <param name="startsWith">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartsWith(params Blueprint<BlueprintEtudeReference>[] startsWith)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartsWith is null) { return; }
          bp.m_StartsWith = bp.m_StartsWith.Where(val => !startsWith.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_StartsWith"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStartsWith(Func<BlueprintEtudeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartsWith is null) { return; }
          bp.m_StartsWith = bp.m_StartsWith.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEtude.m_StartsWith"/>
    /// </summary>
    public TBuilder ClearStartsWith()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartsWith = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.m_StartsWith"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStartsWith(Action<BlueprintEtudeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartsWith is null) { return; }
          bp.m_StartsWith.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_StartsOnComplete"/>
    /// </summary>
    ///
    /// <param name="startsOnComplete">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartsOnComplete(params Blueprint<BlueprintEtudeReference>[] startsOnComplete)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartsOnComplete = startsOnComplete.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEtude.m_StartsOnComplete"/>
    /// </summary>
    ///
    /// <param name="startsOnComplete">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToStartsOnComplete(params Blueprint<BlueprintEtudeReference>[] startsOnComplete)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartsOnComplete = bp.m_StartsOnComplete ?? new();
          bp.m_StartsOnComplete.AddRange(startsOnComplete.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_StartsOnComplete"/>
    /// </summary>
    ///
    /// <param name="startsOnComplete">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartsOnComplete(params Blueprint<BlueprintEtudeReference>[] startsOnComplete)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartsOnComplete is null) { return; }
          bp.m_StartsOnComplete = bp.m_StartsOnComplete.Where(val => !startsOnComplete.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_StartsOnComplete"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStartsOnComplete(Func<BlueprintEtudeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartsOnComplete is null) { return; }
          bp.m_StartsOnComplete = bp.m_StartsOnComplete.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEtude.m_StartsOnComplete"/>
    /// </summary>
    public TBuilder ClearStartsOnComplete()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartsOnComplete = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.m_StartsOnComplete"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStartsOnComplete(Action<BlueprintEtudeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartsOnComplete is null) { return; }
          bp.m_StartsOnComplete.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_StartsParent"/>
    /// </summary>
    ///
    /// <param name="startsParent">
    /// <para>
    /// Tooltip: Start parent etude when current etude starts.
    /// </para>
    /// </param>
    public TBuilder SetStartsParent(bool startsParent = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartsParent = startsParent;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_CompletesParent"/>
    /// </summary>
    public TBuilder SetCompletesParent(bool completesParent = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CompletesParent = completesParent;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.m_ConflictingGroups"/>
    /// </summary>
    ///
    /// <param name="conflictingGroups">
    /// <para>
    /// Blueprint of type BlueprintEtudeConflictingGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetConflictingGroups(params Blueprint<BlueprintEtudeConflictingGroupReference>[] conflictingGroups)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ConflictingGroups = conflictingGroups.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintEtude.m_ConflictingGroups"/>
    /// </summary>
    ///
    /// <param name="conflictingGroups">
    /// <para>
    /// Blueprint of type BlueprintEtudeConflictingGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToConflictingGroups(params Blueprint<BlueprintEtudeConflictingGroupReference>[] conflictingGroups)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ConflictingGroups = bp.m_ConflictingGroups ?? new();
          bp.m_ConflictingGroups.AddRange(conflictingGroups.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_ConflictingGroups"/>
    /// </summary>
    ///
    /// <param name="conflictingGroups">
    /// <para>
    /// Blueprint of type BlueprintEtudeConflictingGroup. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromConflictingGroups(params Blueprint<BlueprintEtudeConflictingGroupReference>[] conflictingGroups)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ConflictingGroups is null) { return; }
          bp.m_ConflictingGroups = bp.m_ConflictingGroups.Where(val => !conflictingGroups.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintEtude.m_ConflictingGroups"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromConflictingGroups(Func<BlueprintEtudeConflictingGroupReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ConflictingGroups is null) { return; }
          bp.m_ConflictingGroups = bp.m_ConflictingGroups.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintEtude.m_ConflictingGroups"/>
    /// </summary>
    public TBuilder ClearConflictingGroups()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ConflictingGroups = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintEtude.m_ConflictingGroups"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyConflictingGroups(Action<BlueprintEtudeConflictingGroupReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ConflictingGroups is null) { return; }
          bp.m_ConflictingGroups.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintEtude.Priority"/>
    /// </summary>
    public TBuilder SetPriority(int priority)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Priority = priority;
        });
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorialSingle"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TutorAC</term><description>5436bba9ec6c6bc48b8ee9a59a4d9a9f</description></item>
    /// <item><term>TutorDamage</term><description>67d1119ed39e3e34f9846643657f88cd</description></item>
    /// <item><term>TutorDiceRollGlobalMap</term><description>a65f6be4e4dd4de4af425c46edb054c2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="tutorial">
    /// <para>
    /// Blueprint of type BlueprintTutorial. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketEnableTutorialSingle(
        Blueprint<BlueprintTutorial.Reference>? tutorial = null)
    {
      var component = new EtudeBracketEnableTutorialSingle();
      component.m_Tutorial = tutorial?.Reference ?? component.m_Tutorial;
      if (component.m_Tutorial is null)
      {
        component.m_Tutorial = BlueprintTool.GetRef<BlueprintTutorial.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableTutorials"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CampingTrigger</term><description>6601a017a5dc33a4f8af119b1611fc69</description></item>
    /// <item><term>Tutorials_Chapter02</term><description>b21b9dcb071cb2e4eaf91c66c0431e6d</description></item>
    /// <item><term>Tutorials_Prologue</term><description>148f8a3289094484e827dce6eed48ad5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="tutorials">
    /// <para>
    /// Blueprint of type BlueprintTutorial. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketEnableTutorials(params Blueprint<BlueprintTutorial.Reference>[] tutorials)
    {
      var component = new EtudeBracketEnableTutorials();
      component.m_Tutorials = tutorials.Select(bp => bp.Reference).ToArray();
      if (component.m_Tutorials is null)
      {
        component.m_Tutorials = new BlueprintTutorial.Reference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCorruptionFreeZone"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DHOutdoorDefault</term><description>0ad51df6001a4f8479cd1efa2506ea54</description></item>
    /// <item><term>DLC6_WenduagLabyrinth</term><description>d6534b86b1d34038aaa9be12f8540580</description></item>
    /// <item><term>WarCamp_GorgoyleAttack</term><description>29990bd61e5e3d84195f4f0d0ae81ec8</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeCorruptionFreeZone(
        bool? clearAllCorruption = null)
    {
      var component = new EtudeCorruptionFreeZone();
      component.m_ClearAllCorruption = clearAllCorruption ?? component.m_ClearAllCorruption;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeDisableCraft"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Caves_1</term><description>fb8827a1b4515af408f92e1ac1bdf794</description></item>
    /// <item><term>Labyrinth</term><description>6522a51898a9b014a805a5802e97e91e</description></item>
    /// <item><term>Neathholm</term><description>1ec30c09b7ccabb4f856365af7d57a49</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeDisableCraft()
    {
      return AddComponent(new EtudeDisableCraft());
    }

    /// <summary>
    /// Adds <see cref="EtudeOverrideCorruptionGrowth"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Kenabres_CorruptionFree</term><description>24671efbec02423b923a32d471c3e0d1</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeOverrideCorruptionGrowth(
        int? corruptionGrowth = null)
    {
      var component = new EtudeOverrideCorruptionGrowth();
      component.m_CorruptionGrowth = corruptionGrowth ?? component.m_CorruptionGrowth;
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
    public TBuilder AddEveryDayTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
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
      return AddComponent(component);
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
    public TBuilder AddEveryWeekTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
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
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeCompleteTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/EtudeCompleteTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>0Prologue</term><description>cee461e88e5d62b4ebdfc1f4cecc13c5</description></item>
    /// <item><term>KTC_TricksterRankUp3</term><description>7fe484200d2477c458eb79f6a2410331</description></item>
    /// <item><term>ZigguratUnderAttackAfterRitual</term><description>9ad4fceef50d9fe4ba346054e812e04c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeCompleteTrigger(
        ActionsBuilder? actions = null)
    {
      var component = new EtudeCompleteTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeInvokeActionsDelayed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/EtudeInvokeActionsDelayed
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAutoKingdomDelay</term><description>7e50ed6c545e4fc486680348003de3cd</description></item>
    /// <item><term>Timer_Before_AzataRankUp_02</term><description>d815fb5a208ce05469d120067f02b3de</description></item>
    /// <item><term>ZigguratDeadRomanceTimer</term><description>587df869a564f7046a48bbf27f017619</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="actionList">
    /// <para>
    /// Tooltip: Actions to invoke after required amount of days has passed
    /// </para>
    /// </param>
    /// <param name="days">
    /// <para>
    /// Tooltip: How much in-game days should pass for ActionList to be invoked
    /// </para>
    /// </param>
    public TBuilder AddEtudeInvokeActionsDelayed(
        ActionsBuilder? actionList = null,
        int? days = null)
    {
      var component = new EtudeInvokeActionsDelayed();
      component.m_ActionList = actionList?.Build() ?? component.m_ActionList;
      if (component.m_ActionList is null)
      {
        component.m_ActionList = Utils.Constants.Empty.Actions;
      }
      component.m_Days = days ?? component.m_Days;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudePlayTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/EtudePlayTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>01_DevouredByDarkness</term><description>67d3321ed01a4e58a9ed3e13f94f1d04</description></item>
    /// <item><term>GreenPuzzleMechanic</term><description>b9ade12b203f92d4ba286bba5e8aa68e</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudePlayTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        bool? isActivateOnLoadArea = null,
        bool? once = null)
    {
      var component = new EtudePlayTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      component.IsActivateOnLoadArea = isActivateOnLoadArea ?? component.IsActivateOnLoadArea;
      component.m_Once = once ?? component.m_Once;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableCompanionPartyChecks"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Daeran_Q2_Stage_0</term><description>162afa0be21e6f84dbaac42696b3ea17</description></item>
    /// <item><term>Daeran_Q2_Stage_3_SkillchecksBlocker</term><description>8c2981a2486c40d0b87c2e481b07c495</description></item>
    /// <item><term>Daeran_Q2_Stage_5</term><description>d63ef3e130688d94ba5a976830aae5de</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companions">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddDisableCompanionPartyChecks(
        List<Blueprint<BlueprintUnitReference>>? companions = null,
        DisableCompanionPartyChecks.ModeType? mode = null)
    {
      var component = new DisableCompanionPartyChecks();
      component.m_Companions = companions?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Companions;
      if (component.m_Companions is null)
      {
        component.m_Companions = new BlueprintUnitReference[0];
      }
      component.m_Mode = mode ?? component.m_Mode;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableMountRiding"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLab_InIllusion</term><description>bbe6e346380ca6b4abba758b9b304727</description></item>
    /// <item><term>KohhDungeon_disableMount_InCutscene</term><description>1cb612bc6945441b96d7fc27208ca080</description></item>
    /// <item><term>Woljif_AbandonedMansion_CutScenePat</term><description>1bbf7d9eff0f47ea9bc50f2d88ae39fc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDisableMountRiding(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DisableMountRiding();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAllowMythicPortrait"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AllowedToChangeMythicVisual</term><description>3c8d242ff4974629a3f097e58c9cd3a8</description></item>
    /// <item><term>DLC1_Megaepic</term><description>99622b80d692457890f58f73ed864f30</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketAllowMythicPortrait()
    {
      return AddComponent(new EtudeBracketAllowMythicPortrait());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioEvents"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_KenabresInThePast_DemonAttack_Audio</term><description>889de41c810a460d979da3f5a21cbca3</description></item>
    /// <item><term>DLC5_Tavern_State0_Audio</term><description>44e36a18b7a1415f8a5ab1101c5974d7</description></item>
    /// <item><term>WarCamp_Peaceful_Audio</term><description>aa31ae323e6e54341bc59ce6fba7c08e</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketAudioEvents(
        AkEventReference[]? onEtudeStart = null,
        AkEventReference[]? onEtudeStop = null)
    {
      var component = new EtudeBracketAudioEvents();
      Validate(onEtudeStart);
      component.OnEtudeStart = onEtudeStart ?? component.OnEtudeStart;
      if (component.OnEtudeStart is null)
      {
        component.OnEtudeStart = new AkEventReference[0];
      }
      Validate(onEtudeStop);
      component.OnEtudeStop = onEtudeStop ?? component.OnEtudeStop;
      if (component.OnEtudeStop is null)
      {
        component.OnEtudeStop = new AkEventReference[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketAudioObjects"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_KenabresInThePast_Peaceful_Audio</term><description>958e97c093f2405caf2ee25ee23974bb</description></item>
    /// <item><term>DLC6_TavernRebuilded_SecondStage_Audio</term><description>84691b7d84a84e12ae9e1f3d6a909b05</description></item>
    /// <item><term>ZigguratSound</term><description>f2035ebb6d074f33aaa1ec362d0f1929</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketAudioObjects(
        string? connectedObjectName = null)
    {
      var component = new EtudeBracketAudioObjects();
      component.ConnectedObjectName = connectedObjectName ?? component.ConnectedObjectName;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketCampingAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreshkagalDungeon_Arena</term><description>67fb6b5c69c149ecb2aed1b38d299fb7</description></item>
    /// <item><term>IvoryLabyrinth_Prison</term><description>f97f4de6a5073df49b9cac68859f05ae</description></item>
    /// <item><term>Threshold</term><description>207fad718f41237449b0acf414cc991a</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketCampingAction(
        ActionsBuilder? actions = null,
        bool? skipRest = null)
    {
      var component = new EtudeBracketCampingAction();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.SkipRest = skipRest ?? component.SkipRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDetachPet"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AzataChanged_DragonDetach</term><description>ab819e3a5ef50824da38424ec7dba195</description></item>
    /// <item><term>DreamFirstVisit</term><description>82c30aaad229dd146bbe3615608c3e34</description></item>
    /// <item><term>TricksterCouncilDefault</term><description>d3306da844810c74984e37a41d6d6f99</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketDetachPet(
        UnitEvaluator? master = null,
        PetType? petType = null)
    {
      var component = new EtudeBracketDetachPet();
      Validate(master);
      component.Master = master ?? component.Master;
      component.PetType = petType ?? component.PetType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDetachPetsOnUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CamelliaQ1_CombatState</term><description>845183b29ac053745a0e1a12ee826795</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketDetachPetsOnUnit(
        UnitEvaluator? target = null)
    {
      var component = new EtudeBracketDetachPetsOnUnit();
      Validate(target);
      component.Target = target ?? component.Target;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisableCampingEncounters"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC2_Catacombs_For_RE</term><description>cb95b10bc71448bbbf9773e0d19eb5e2</description></item>
    /// <item><term>DLC2_Stop_RE</term><description>8b91b3737c444cf2a1cfb2177a6af2f0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketDisableCampingEncounters()
    {
      return AddComponent(new EtudeBracketDisableCampingEncounters());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisablePlayerRespec"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NoDragon</term><description>39008f5a372a6dc42bddfcf4f334bd95</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketDisablePlayerRespec()
    {
      return AddComponent(new EtudeBracketDisablePlayerRespec());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketDisableRandomEncounters"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Disable_KenabresRE_AfterCh2</term><description>a9d6a5d7f329469da1a7475a0d7b8f1f</description></item>
    /// <item><term>LegendGarrisonGM_NoRE</term><description>1b60bc29f8a24d08a8af2c276aee38eb</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketDisableRandomEncounters()
    {
      return AddComponent(new EtudeBracketDisableRandomEncounters());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableAzataIsland"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AzataIsland_GlobalSpell</term><description>765b5d6d0e6f4505a6471db58b3fa6ce</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="globalMapSpell">
    /// <para>
    /// Blueprint of type BlueprintGlobalMagicSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketEnableAzataIsland(
        Blueprint<BlueprintGlobalMap.Reference>? globalMap = null,
        Blueprint<BlueprintGlobalMagicSpell.Reference>? globalMapSpell = null)
    {
      var component = new EtudeBracketEnableAzataIsland();
      component.m_GlobalMap = globalMap?.Reference ?? component.m_GlobalMap;
      if (component.m_GlobalMap is null)
      {
        component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      component.m_GlobalMapSpell = globalMapSpell?.Reference ?? component.m_GlobalMapSpell;
      if (component.m_GlobalMapSpell is null)
      {
        component.m_GlobalMapSpell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnableWarcamp"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketEnableWarcamp(
        Blueprint<BlueprintGlobalMap.Reference>? globalMap = null)
    {
      var component = new EtudeBracketEnableWarcamp();
      component.m_GlobalMap = globalMap?.Reference ?? component.m_GlobalMap;
      if (component.m_GlobalMap is null)
      {
        component.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMap.Reference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketEnsureAudio"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter01</term><description>df17ab913c348644b9bd3fe3f9781a84</description></item>
    /// <item><term>DLC1_Megaepic</term><description>99622b80d692457890f58f73ed864f30</description></item>
    /// <item><term>DLC6_DanceOfMasks</term><description>3fdcad8348254e08ad94e9a5742d1da2</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketEnsureAudio(
        AudioFilePackagesSettings.AudioChunk? chunk = null)
    {
      var component = new EtudeBracketEnsureAudio();
      component.Chunk = chunk ?? component.Chunk;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketFollowUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AneviaFollow</term><description>b5f1df4ce72c8cd459eb18a1cffc091b</description></item>
    /// <item><term>LatimasFollow</term><description>5d4d883a918142a9bebfc22f6625f1f5</description></item>
    /// <item><term>Wintersun_Default</term><description>87839550c801db944b102f61084fd245</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="leader">
    /// <para>
    /// Tooltip: Main character if not specified
    /// </para>
    /// </param>
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketFollowUnit(
        bool? alwaysRun = null,
        bool? canBeSlowerThanLeader = null,
        UnitEvaluator? leader = null,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null,
        UnitEvaluator? unit = null,
        bool? useSummonPool = null)
    {
      var component = new EtudeBracketFollowUnit();
      component.AlwaysRun = alwaysRun ?? component.AlwaysRun;
      component.CanBeSlowerThanLeader = canBeSlowerThanLeader ?? component.CanBeSlowerThanLeader;
      Validate(leader);
      component.Leader = leader ?? component.Leader;
      component.SummonPool = summonPool?.Reference ?? component.SummonPool;
      if (component.SummonPool is null)
      {
        component.SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      component.UseSummonPool = useSummonPool ?? component.UseSummonPool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketForceCombatMode"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>XCOM_Battle</term><description>f830cff9020aa434c8b8a49980af4035</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketForceCombatMode()
    {
      return AddComponent(new EtudeBracketForceCombatMode());
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketIgnoreGameover"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC5_WatcherFightStarted</term><description>f0a2c61c07c14c4388db77c122282e55</description></item>
    /// <item><term>SuppressGameOver</term><description>ce50ca45416742f09ac11ecb85fe6212</description></item>
    /// <item><term>ThresholdCamp_Attack</term><description>2598fbc6c16e7ec4abc5ec50f484fd4f</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketIgnoreGameover(
        ActionsBuilder? actionList = null,
        EtudeBracketGameModeWaiter? gameModeWaiter = null,
        GameOverController? gameOverController = null)
    {
      var component = new EtudeBracketIgnoreGameover();
      component.ActionList = actionList?.Build() ?? component.ActionList;
      if (component.ActionList is null)
      {
        component.ActionList = Utils.Constants.Empty.Actions;
      }
      Validate(gameModeWaiter);
      component.m_GameModeWaiter = gameModeWaiter ?? component.m_GameModeWaiter;
      Validate(gameOverController);
      component.m_GameOverController = gameOverController ?? component.m_GameOverController;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMakePassive"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreshkagalArena_NenioIgnoreCombat</term><description>35399489cd494583af28e059e5726d6c</description></item>
    /// <item><term>LichCiar_Nexus_EXRemotePassive</term><description>688c6a9a56fd4614852b0e2ee7708d88</description></item>
    /// <item><term>Woljif_Nexus_EXRemotePassive</term><description>e6055ae3cde11e9418628e1d446ac193</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketMakePassive(
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketMakePassive();
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMarkUnitEssential"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArehskagalArena_NenioFight</term><description>ff6e6564583c4757bb5759ec3f41827b</description></item>
    /// <item><term>GreyborPreparations</term><description>221bed1c8e52f8c4bb194c82b8e16548</description></item>
    /// <item><term>ZosielQ0</term><description>6d1bb3f8743892a4aaf498f7fc5212f0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketMarkUnitEssential(
        UnitEvaluator? target = null)
    {
      var component = new EtudeBracketMarkUnitEssential();
      Validate(target);
      component.Target = target ?? component.Target;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketMusic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AssaultFinished_Audio</term><description>6851b9b86373937429e7bf68079c2501</description></item>
    /// <item><term>Drezen1_SiegeSoundEtude</term><description>c99a1bae98fb35c46b4e335ae8cdbda0</description></item>
    /// <item><term>WarCamp_GorgoyleAttack</term><description>29990bd61e5e3d84195f4f0d0ae81ec8</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketMusic(
        AkEventReference? startTheme = null,
        AkEventReference? stopTheme = null)
    {
      var component = new EtudeBracketMusic();
      Validate(startTheme);
      component.StartTheme = startTheme ?? component.StartTheme;
      Validate(stopTheme);
      component.StopTheme = stopTheme ?? component.StopTheme;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideActionsOnClick"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_BeforeQuest</term><description>a271248ab27e0be49bbc08a423214a16</description></item>
    /// <item><term>ExoticCapitalTraderInCapital</term><description>f5d08d5c41d6b584ca59081039a19f20</description></item>
    /// <item><term>WarCamp_DefaultPeaceful_Outdoor</term><description>27d07416c620e0e48865bd88d74cbb82</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketOverrideActionsOnClick(
        ActionsBuilder? actions = null,
        float? distance = null,
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketOverrideActionsOnClick();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.m_Distance = distance ?? component.m_Distance;
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideBark"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_AfterQuest</term><description>d40a0634e36e06f4fa674d3cb273c60a</description></item>
    /// <item><term>AeonQ9_AfterQuest_LellanInPrison</term><description>409e0dc5a2c767e4286c921152f18b96</description></item>
    /// <item><term>MutasafenLab_BarksAfter</term><description>137bd44a0ba94b778bbd077c51301861</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="barkDurationByText">
    /// <para>
    /// Tooltip: Bark duration depends on text length
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketOverrideBark(
        bool? barkDurationByText = null,
        float? distance = null,
        UnitEvaluator? unit = null,
        SharedStringAsset? whatToBarkShared = null)
    {
      var component = new EtudeBracketOverrideBark();
      component.BarkDurationByText = barkDurationByText ?? component.BarkDurationByText;
      component.m_Distance = distance ?? component.m_Distance;
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      Validate(whatToBarkShared);
      component.WhatToBarkShared = whatToBarkShared ?? component.WhatToBarkShared;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideDialog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_DuringQuest</term><description>fb99a426b8bf1f247a2272920a1fd13d</description></item>
    /// <item><term>PetDragonAzata_Nexus</term><description>8ec49bab42a211e4f85f593718ecc536</description></item>
    /// <item><term>ZigguratZachariusInZiggurat</term><description>2844d387f27a0bb468f72603dd15eda2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dialog">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketOverrideDialog(
        Blueprint<BlueprintDialogReference>? dialog = null,
        float? distance = null,
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketOverrideDialog();
      component.Dialog = dialog?.Reference ?? component.Dialog;
      if (component.Dialog is null)
      {
        component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      component.m_Distance = distance ?? component.m_Distance;
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherInclemency"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Coronation_LocustUltimate</term><description>026bc6aeff8f4b6180822db75115a66d</description></item>
    /// <item><term>DLC5_TavernIndoor_Weather</term><description>e1ef2e05c0e84ab0b313dda9fa2d4712</description></item>
    /// <item><term>TEST_ReflectionWeather_HeavyInstant</term><description>700db55747ec498cb8b8494c3d9933df</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketOverrideWeatherInclemency(
        EtudeBracketGameModeWaiter? gameModeWaiter = null,
        InclemencyType? inclemency = null,
        bool? instantly = null)
    {
      var component = new EtudeBracketOverrideWeatherInclemency();
      Validate(gameModeWaiter);
      component.m_GameModeWaiter = gameModeWaiter ?? component.m_GameModeWaiter;
      component.Inclemency = inclemency ?? component.Inclemency;
      component.m_Instantly = instantly ?? component.m_Instantly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketOverrideWeatherProfile"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DeskariHasArrived</term><description>9daf0401427a8e444941bdd1a8c6e301</description></item>
    /// <item><term>Prologue_Kenabres_Weather</term><description>f7fa92f20aa04f1f8d3a33575bbf3c67</description></item>
    /// <item><term>WeatherTrickster</term><description>3347811084da4f3fb342e4c17a7c4ccb</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketOverrideWeatherProfile(
        EtudeBracketGameModeWaiter? gameModeWaiter = null,
        WeatherProfileExtended? weatherProfile = null)
    {
      var component = new EtudeBracketOverrideWeatherProfile();
      Validate(gameModeWaiter);
      component.m_GameModeWaiter = gameModeWaiter ?? component.m_GameModeWaiter;
      Validate(weatherProfile);
      component.m_WeatherProfile = weatherProfile ?? component.m_WeatherProfile;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPinCompanionInParty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC5_PentaNonRemovable</term><description>efbaa24d9f6442a797784840e4586cee</description></item>
    /// <item><term>DLC5_SendriNonRemovable</term><description>e3d950c8bb864ad5ba68b0a20e0a1dad</description></item>
    /// <item><term>RegillLockedInParty</term><description>9079a2dd777d415d869d4b58665d200c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketPinCompanionInParty(
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketPinCompanionInParty();
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketPreventDirectControl"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC6_AivuInKenabres</term><description>b92ed1f4f7f54c38a5523f619e0abd1e</description></item>
    /// <item><term>Nexus02Camp_CapitalCompanionLogic</term><description>875e1da9c2dcabb45b301b8c15b40660</description></item>
    /// <item><term>PetDragonAzata_ThroneRoom</term><description>e4a1eb7ccc927bb41afbe8b20f00861f</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketPreventDirectControl(
        UnitEvaluator? unit = null)
    {
      var component = new EtudeBracketPreventDirectControl();
      Validate(unit);
      component.Unit = unit ?? component.Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketProgressBar"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DH_ProgressBar</term><description>4d82ae4995764612a08163fe14ab36b5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="title">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddEtudeBracketProgressBar(
        int? maxProgress = null,
        LocalString? title = null)
    {
      var component = new EtudeBracketProgressBar();
      component.MaxProgress = maxProgress ?? component.MaxProgress;
      component.Title = title?.LocalizedString ?? component.Title;
      if (component.Title is null)
      {
        component.Title = Utils.Constants.Empty.String;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketRestPhase"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC2_Survive_Grave_RstInsOn</term><description>86a6fe903cd84b7ea3a7d50373e4d694</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="multiplePhases">
    /// <para>
    /// Tooltip: Использовать разные фазы реста для начальных экшенов и для конечных.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketRestPhase(
        RestPhase? firstPhase = null,
        bool? hasStarted = null,
        RestPhase? lastPhase = null,
        bool? multiplePhases = null,
        ActionsBuilder? onStart = null,
        ActionsBuilder? onStop = null,
        RestPhase? phase = null)
    {
      var component = new EtudeBracketRestPhase();
      component.FirstPhase = firstPhase ?? component.FirstPhase;
      component.HasStarted = hasStarted ?? component.HasStarted;
      component.LastPhase = lastPhase ?? component.LastPhase;
      component.MultiplePhases = multiplePhases ?? component.MultiplePhases;
      component.OnStart = onStart?.Build() ?? component.OnStart;
      if (component.OnStart is null)
      {
        component.OnStart = Utils.Constants.Empty.Actions;
      }
      component.OnStop = onStop?.Build() ?? component.OnStop;
      if (component.OnStop is null)
      {
        component.OnStop = Utils.Constants.Empty.Actions;
      }
      component.Phase = phase ?? component.Phase;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSetCompanionPosition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DaeranRomance_BarksAfterSex</term><description>54998634e0121484c8f2de44b09f3766</description></item>
    /// <item><term>MilitaryRegillRankUpPosition</term><description>bf635b68081010c49b9039bfe0d25624</description></item>
    /// <item><term>UlbrigWaitsForTheCommanderByTheFire_WarCamp</term><description>8249dba9e71a4f7795331c1508ed4e75</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companion">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="ignoreWhenEx">
    /// <para>
    /// InfoBox: Don&amp;apos;t do anything if companion is Ex
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketSetCompanionPosition(
        Blueprint<BlueprintUnitReference>? companion = null,
        bool? ignoreWhenEx = null,
        EntityReference? locator = null)
    {
      var component = new EtudeBracketSetCompanionPosition();
      component.m_Companion = companion?.Reference ?? component.m_Companion;
      if (component.m_Companion is null)
      {
        component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      component.m_IgnoreWhenEx = ignoreWhenEx ?? component.m_IgnoreWhenEx;
      Validate(locator);
      component.m_Locator = locator ?? component.m_Locator;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSkipTimeAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC6_DaeranUnusualDate</term><description>cbcb7376b21441c7a4d5dc7b740085a9</description></item>
    /// <item><term>DLC6_FestiveKenabres_DefaultPeaceful</term><description>4def8ef7e75e483382365a8f144afc79</description></item>
    /// <item><term>DLC6_KenabresRitualHouse</term><description>42783bfc91cc4424a9b103b455b531de</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketSkipTimeAction(
        ActionsBuilder? actions = null,
        bool? preventSkipTime = null)
    {
      var component = new EtudeBracketSkipTimeAction();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.PreventSkipTime = preventSkipTime ?? component.PreventSkipTime;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketSummonpoolOverrideDialog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BribeSummonpoolInteractions</term><description>1a7f6d97ee806d1469bee16129ee23c8</description></item>
    /// <item><term>LooterSummonpoolInteractions</term><description>264f738049ac8eb409e7f9eeb228e972</description></item>
    /// <item><term>ThiefSummonpoolInteractions</term><description>e8315e9e744c3ca48b1674350c386b96</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dialog">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEtudeBracketSummonpoolOverrideDialog(
        Blueprint<BlueprintDialogReference>? dialog = null,
        float? distance = null,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null)
    {
      var component = new EtudeBracketSummonpoolOverrideDialog();
      component.Dialog = dialog?.Reference ?? component.Dialog;
      if (component.Dialog is null)
      {
        component.Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      component.m_Distance = distance ?? component.m_Distance;
      component.m_SummonPool = summonPool?.Reference ?? component.m_SummonPool;
      if (component.m_SummonPool is null)
      {
        component.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeBracketTriggerAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLabFalseName</term><description>2bbe2729cac14033a4aa094f2df60fdc</description></item>
    /// <item><term>TricksterCouncil_Council_Lexicon2</term><description>e57f6011fd7d3694681f195960cea161</description></item>
    /// <item><term>Woljif_Q2_VoetielMeeting</term><description>70707ba408d17784e8cbf59d3fe25e18</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeBracketTriggerAction(
        ActionsBuilder? onActivated = null,
        ActionsBuilder? onDeactivated = null)
    {
      var component = new EtudeBracketTriggerAction();
      component.OnActivated = onActivated?.Build() ?? component.OnActivated;
      if (component.OnActivated is null)
      {
        component.OnActivated = Utils.Constants.Empty.Actions;
      }
      component.OnDeactivated = onDeactivated?.Build() ?? component.OnDeactivated;
      if (component.OnDeactivated is null)
      {
        component.OnDeactivated = Utils.Constants.Empty.Actions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EtudeGameOverTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DarkBalorFight_HideUnits</term><description>5bc605a8f4624ec08d857dcc52378eb5</description></item>
    /// <item><term>DLC3_DemonsHeart</term><description>15cc71ca8c954bdb97ed5bf2b140fcb6</description></item>
    /// <item><term>DLC3_TheFirstCleric</term><description>812c1f9133214a78b35669c6627898a9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEtudeGameOverTrigger(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ActionsBuilder? onGameOver = null)
    {
      var component = new EtudeGameOverTrigger();
      component.OnGameOver = onGameOver?.Build() ?? component.OnGameOver;
      if (component.OnGameOver is null)
      {
        component.OnGameOver = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePartyEncumbrance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLab_InIllusion</term><description>bbe6e346380ca6b4abba758b9b304727</description></item>
    /// <item><term>Dream_InFire</term><description>b97643e712f2fbb40959de464a357ac6</description></item>
    /// <item><term>WarCamp_GorgoyleAttack</term><description>29990bd61e5e3d84195f4f0d0ae81ec8</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeIgnorePartyEncumbrance()
    {
      return AddComponent(new EtudeIgnorePartyEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudeIgnorePersonalEncumbrance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLab_InIllusion</term><description>bbe6e346380ca6b4abba758b9b304727</description></item>
    /// <item><term>DLC6_WenduagLabyrinth</term><description>d6534b86b1d34038aaa9be12f8540580</description></item>
    /// <item><term>WarCamp_EarlyBeginning</term><description>4be1dcbb5f0a05f43b8915e14251b76c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudeIgnorePersonalEncumbrance()
    {
      return AddComponent(new EtudeIgnorePersonalEncumbrance());
    }

    /// <summary>
    /// Adds <see cref="EtudePeacefulZone"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_KenabresInThePast_Peaceful_Audio</term><description>958e97c093f2405caf2ee25ee23974bb</description></item>
    /// <item><term>DLC6_WenduagLabyrinth</term><description>d6534b86b1d34038aaa9be12f8540580</description></item>
    /// <item><term>WarCamp_EarlyBeginning</term><description>4be1dcbb5f0a05f43b8915e14251b76c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEtudePeacefulZone()
    {
      return AddComponent(new EtudePeacefulZone());
    }

    /// <summary>
    /// Adds <see cref="HideAllPets"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLab_InIllusion</term><description>bbe6e346380ca6b4abba758b9b304727</description></item>
    /// <item><term>Dream_InFire</term><description>b97643e712f2fbb40959de464a357ac6</description></item>
    /// <item><term>Woljif_AbandonedMansion_CutScenePat</term><description>1bbf7d9eff0f47ea9bc50f2d88ae39fc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="hideOnRemoteAndEx">
    /// <para>
    /// InfoBox: Should we hide also pets from remote companions (in hub for example) and from ex companions for duels
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddHideAllPets(
        bool? hideOnRemoteAndEx = null,
        bool? leaveAzataDragon = null,
        bool? leavePetOfMainCharacter = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new HideAllPets();
      component.HideOnRemoteAndEx = hideOnRemoteAndEx ?? component.HideOnRemoteAndEx;
      component.LeaveAzataDragon = leaveAzataDragon ?? component.LeaveAzataDragon;
      component.LeavePetOfMainCharacter = leavePetOfMainCharacter ?? component.LeavePetOfMainCharacter;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KeepCompanionHidden"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DiplomacyLannRankUp_Hide</term><description>362929592a154a56a6b40bd1c5159dbf</description></item>
    /// <item><term>LogisticsWenduagRankUp_Hide</term><description>9ce0dca7e0624042a00b3f115ef23c6a</description></item>
    /// <item><term>MilitaryWenduagRankUp_Hide</term><description>44247994f44e4e5d88f3f739616af1dc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddKeepCompanionHidden(
        CompanionInParty? companion = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new KeepCompanionHidden();
      Validate(companion);
      component.Companion = companion ?? component.Companion;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CapitalCompanionLogic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AllowCombat</term><description>0704c7b789ce4ddaa2fd29d43abc92d3</description></item>
    /// <item><term>Dream_InFire</term><description>b97643e712f2fbb40959de464a357ac6</description></item>
    /// <item><term>WarCamp_EarlyBeginning</term><description>4be1dcbb5f0a05f43b8915e14251b76c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="restAllRemoteCompanions">
    /// <para>
    /// InfoBox: Use rest on all remote companions for every days from last rest (party was away fighting and they were resting)
    /// </para>
    /// </param>
    public TBuilder AddCapitalCompanionLogic(
        bool? restAllRemoteCompanions = null)
    {
      var component = new CapitalCompanionLogic();
      component.m_RestAllRemoteCompanions = restAllRemoteCompanions ?? component.m_RestAllRemoteCompanions;
      return AddComponent(component);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Parent is null)
      {
        Blueprint.m_Parent = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      if (Blueprint.ActivationCondition is null)
      {
        Blueprint.ActivationCondition = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.CompletionCondition is null)
      {
        Blueprint.CompletionCondition = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.m_Synchronized is null)
      {
        Blueprint.m_Synchronized = new();
      }
      if (Blueprint.m_LinkedAreaPart is null)
      {
        Blueprint.m_LinkedAreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(null);
      }
      if (Blueprint.m_LinkedCampaigns is null)
      {
        Blueprint.m_LinkedCampaigns = new();
      }
      if (Blueprint.m_AddedAreaMechanics is null)
      {
        Blueprint.m_AddedAreaMechanics = new();
      }
      if (Blueprint.m_StartsWith is null)
      {
        Blueprint.m_StartsWith = new();
      }
      if (Blueprint.m_StartsOnComplete is null)
      {
        Blueprint.m_StartsOnComplete = new();
      }
      if (Blueprint.m_ConflictingGroups is null)
      {
        Blueprint.m_ConflictingGroups = new();
      }
    }
  }
}

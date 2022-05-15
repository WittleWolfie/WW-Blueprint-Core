//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="CustomAiConsiderationsRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCustomAiConsiderationsRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : CustomAiConsiderationsRoot
    where TBuilder : BaseCustomAiConsiderationsRootConfigurator<T, TBuilder>
  {
    protected BaseCustomAiConsiderationsRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/>
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTargetConsiderations(List<Blueprint<ConsiderationCustom, ConsiderationCustom.Reference>> targetConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetConsiderations = targetConsiderations?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/>
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTargetConsiderations(params Blueprint<ConsiderationCustom, ConsiderationCustom.Reference>[] targetConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetConsiderations = bp.m_TargetConsiderations ?? new ConsiderationCustom.Reference[0];
          bp.m_TargetConsiderations = CommonTool.Append(bp.m_TargetConsiderations, targetConsiderations.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/>
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTargetConsiderations(params Blueprint<ConsiderationCustom, ConsiderationCustom.Reference>[] targetConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TargetConsiderations is null) { return; }
          bp.m_TargetConsiderations = bp.m_TargetConsiderations.Where(val => !targetConsiderations.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTargetConsiderations(Func<ConsiderationCustom.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TargetConsiderations is null) { return; }
          bp.m_TargetConsiderations = bp.m_TargetConsiderations.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/>
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearTargetConsiderations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetConsiderations = new ConsiderationCustom.Reference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyTargetConsiderations(Action<ConsiderationCustom.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TargetConsiderations is null) { return; }
          bp.m_TargetConsiderations.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/>
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetActorConsiderations(List<Blueprint<ConsiderationCustom, ConsiderationCustom.Reference>> actorConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActorConsiderations = actorConsiderations?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/>
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToActorConsiderations(params Blueprint<ConsiderationCustom, ConsiderationCustom.Reference>[] actorConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActorConsiderations = bp.m_ActorConsiderations ?? new ConsiderationCustom.Reference[0];
          bp.m_ActorConsiderations = CommonTool.Append(bp.m_ActorConsiderations, actorConsiderations.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/>
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromActorConsiderations(params Blueprint<ConsiderationCustom, ConsiderationCustom.Reference>[] actorConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActorConsiderations is null) { return; }
          bp.m_ActorConsiderations = bp.m_ActorConsiderations.Where(val => !actorConsiderations.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromActorConsiderations(Func<ConsiderationCustom.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActorConsiderations is null) { return; }
          bp.m_ActorConsiderations = bp.m_ActorConsiderations.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/>
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearActorConsiderations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActorConsiderations = new ConsiderationCustom.Reference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Blueprint of type ConsiderationCustom. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyActorConsiderations(Action<ConsiderationCustom.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActorConsiderations is null) { return; }
          bp.m_ActorConsiderations.ForEach(action);
        });
    }
  }
}

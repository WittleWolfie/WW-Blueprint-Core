//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
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
    protected BaseCustomAiConsiderationsRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<CustomAiConsiderationsRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_TargetConsiderations = copyFrom.m_TargetConsiderations;
          bp.m_ActorConsiderations = copyFrom.m_ActorConsiderations;
        });
    }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTargetConsiderations(params Blueprint<ConsiderationCustom.Reference>[] targetConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetConsiderations = targetConsiderations.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTargetConsiderations(params Blueprint<ConsiderationCustom.Reference>[] targetConsiderations)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTargetConsiderations(params Blueprint<ConsiderationCustom.Reference>[] targetConsiderations)
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
    public TBuilder RemoveFromTargetConsiderations(Func<ConsiderationCustom.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TargetConsiderations is null) { return; }
          bp.m_TargetConsiderations = bp.m_TargetConsiderations.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CustomAiConsiderationsRoot.m_TargetConsiderations"/>
    /// </summary>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetActorConsiderations(params Blueprint<ConsiderationCustom.Reference>[] actorConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActorConsiderations = actorConsiderations.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToActorConsiderations(params Blueprint<ConsiderationCustom.Reference>[] actorConsiderations)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromActorConsiderations(params Blueprint<ConsiderationCustom.Reference>[] actorConsiderations)
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
    public TBuilder RemoveFromActorConsiderations(Func<ConsiderationCustom.Reference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActorConsiderations is null) { return; }
          bp.m_ActorConsiderations = bp.m_ActorConsiderations.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CustomAiConsiderationsRoot.m_ActorConsiderations"/>
    /// </summary>
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
    public TBuilder ModifyActorConsiderations(Action<ConsiderationCustom.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActorConsiderations is null) { return; }
          bp.m_ActorConsiderations.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_TargetConsiderations is null)
      {
        Blueprint.m_TargetConsiderations = new ConsiderationCustom.Reference[0];
      }
      if (Blueprint.m_ActorConsiderations is null)
      {
        Blueprint.m_ActorConsiderations = new ConsiderationCustom.Reference[0];
      }
    }
  }
}

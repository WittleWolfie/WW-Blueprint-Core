//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.DialogSystem;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCueSequence"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCueSequenceConfigurator<T, TBuilder>
    : BaseCueBaseConfigurator<T, TBuilder>
    where T : BlueprintCueSequence
    where TBuilder : BaseCueSequenceConfigurator<T, TBuilder>
  {
    protected BaseCueSequenceConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCueSequence>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Cues = copyFrom.Cues;
          bp.m_Exit = copyFrom.m_Exit;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCueSequence>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Cues = copyFrom.Cues;
          bp.m_Exit = copyFrom.m_Exit;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCueSequence.Cues"/>
    /// </summary>
    ///
    /// <param name="cues">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCues(params Blueprint<BlueprintCueBaseReference>[] cues)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Cues = cues.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCueSequence.Cues"/>
    /// </summary>
    ///
    /// <param name="cues">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToCues(params Blueprint<BlueprintCueBaseReference>[] cues)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Cues = bp.Cues ?? new();
          bp.Cues.AddRange(cues.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCueSequence.Cues"/>
    /// </summary>
    ///
    /// <param name="cues">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCues(params Blueprint<BlueprintCueBaseReference>[] cues)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Cues is null) { return; }
          bp.Cues = bp.Cues.Where(val => !cues.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCueSequence.Cues"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCues(Func<BlueprintCueBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Cues is null) { return; }
          bp.Cues = bp.Cues.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCueSequence.Cues"/>
    /// </summary>
    public TBuilder ClearCues()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Cues = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCueSequence.Cues"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCues(Action<BlueprintCueBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Cues is null) { return; }
          bp.Cues.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCueSequence.m_Exit"/>
    /// </summary>
    ///
    /// <param name="exit">
    /// <para>
    /// Blueprint of type BlueprintSequenceExit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExit(Blueprint<BlueprintSequenceExitReference> exit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Exit = exit?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCueSequence.m_Exit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExit(Action<BlueprintSequenceExitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Exit is null) { return; }
          action.Invoke(bp.m_Exit);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Cues is null)
      {
        Blueprint.Cues = new();
      }
      if (Blueprint.m_Exit is null)
      {
        Blueprint.m_Exit = BlueprintTool.GetRef<BlueprintSequenceExitReference>(null);
      }
    }
  }
}

//***** AUTO-GENERATED - DO NOT EDIT *****//

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
    protected BaseCueSequenceConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCues(List<Blueprint<BlueprintCueBase, BlueprintCueBaseReference>> cues)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Cues = cues?.Select(bp => bp.Reference)?.ToList();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToCues(params Blueprint<BlueprintCueBase, BlueprintCueBaseReference>[] cues)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCues(params Blueprint<BlueprintCueBase, BlueprintCueBaseReference>[] cues)
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
    ///
    /// <param name="cues">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCues(Func<BlueprintCueBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Cues is null) { return; }
          bp.Cues = bp.Cues.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCueSequence.Cues"/>
    /// </summary>
    ///
    /// <param name="cues">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    ///
    /// <param name="cues">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExit(Blueprint<BlueprintSequenceExit, BlueprintSequenceExitReference> exit)
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
    ///
    /// <param name="exit">
    /// <para>
    /// Blueprint of type BlueprintSequenceExit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyExit(Action<BlueprintSequenceExitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Exit is null) { return; }
          action.Invoke(bp.m_Exit);
        });
    }
  }
}

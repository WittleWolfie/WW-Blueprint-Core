//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BuffNotFromCasterConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBuffNotFromCasterConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : BuffNotFromCasterConsideration
    where TBuilder : BaseBuffNotFromCasterConsiderationConfigurator<T, TBuilder>
  {
    protected BaseBuffNotFromCasterConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BuffNotFromCasterConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Check if target has at least one of Buffs that is NOT casted by brain owner
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBuffs(List<Blueprint<BlueprintBuff, BlueprintBuffReference>> buffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Buffs = buffs?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BuffNotFromCasterConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Check if target has at least one of Buffs that is NOT casted by brain owner
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToBuffs(params Blueprint<BlueprintBuff, BlueprintBuffReference>[] buffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Buffs = bp.m_Buffs ?? new BlueprintBuffReference[0];
          bp.m_Buffs = CommonTool.Append(bp.m_Buffs, buffs.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BuffNotFromCasterConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Check if target has at least one of Buffs that is NOT casted by brain owner
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromBuffs(params Blueprint<BlueprintBuff, BlueprintBuffReference>[] buffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Buffs is null) { return; }
          bp.m_Buffs = bp.m_Buffs.Where(val => !buffs.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BuffNotFromCasterConsideration.m_Buffs"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Check if target has at least one of Buffs that is NOT casted by brain owner
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromBuffs(Func<BlueprintBuffReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Buffs is null) { return; }
          bp.m_Buffs = bp.m_Buffs.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BuffNotFromCasterConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Check if target has at least one of Buffs that is NOT casted by brain owner
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearBuffs()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Buffs = new BlueprintBuffReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffNotFromCasterConsideration.m_Buffs"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Check if target has at least one of Buffs that is NOT casted by brain owner
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyBuffs(Action<BlueprintBuffReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Buffs is null) { return; }
          bp.m_Buffs.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BuffNotFromCasterConsideration.HasBuffNotFromCasterScore"/>
    /// </summary>
    public TBuilder SetHasBuffNotFromCasterScore(float hasBuffNotFromCasterScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasBuffNotFromCasterScore = hasBuffNotFromCasterScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffNotFromCasterConsideration.HasBuffNotFromCasterScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasBuffNotFromCasterScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasBuffNotFromCasterScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BuffNotFromCasterConsideration.ElseScore"/>
    /// </summary>
    ///
    /// <param name="elseScore">
    /// <para>
    /// InfoBox: Use these option for swarms
    /// </para>
    /// </param>
    public TBuilder SetElseScore(float elseScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ElseScore = elseScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffNotFromCasterConsideration.ElseScore"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="elseScore">
    /// <para>
    /// InfoBox: Use these option for swarms
    /// </para>
    /// </param>
    public TBuilder ModifyElseScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ElseScore);
        });
    }
  }
}

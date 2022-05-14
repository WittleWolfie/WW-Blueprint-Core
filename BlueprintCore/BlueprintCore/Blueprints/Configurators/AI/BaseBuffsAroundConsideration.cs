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
  /// Implements common fields and components for blueprints inheriting from <see cref="BuffsAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBuffsAroundConsiderationConfigurator<T, TBuilder>
    : BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
    where T : BuffsAroundConsideration
    where TBuilder : BaseBuffsAroundConsiderationConfigurator<T, TBuilder>
  {
    protected BaseBuffsAroundConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BuffsAroundConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Counts unit if it has at least one buff from list
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
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
    /// Adds to the contents of <see cref="BuffsAroundConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Counts unit if it has at least one buff from list
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
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
    /// Removes elements from <see cref="BuffsAroundConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Counts unit if it has at least one buff from list
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
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
    /// Removes elements from <see cref="BuffsAroundConsideration.m_Buffs"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Counts unit if it has at least one buff from list
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
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
    /// Removes all elements from <see cref="BuffsAroundConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Counts unit if it has at least one buff from list
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
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
    /// Modifies <see cref="BuffsAroundConsideration.m_Buffs"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// InfoBox: Counts unit if it has at least one buff from list
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
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
    /// Sets the value of <see cref="BuffsAroundConsideration.CheckAbsence"/>
    /// </summary>
    public TBuilder SetCheckAbsence(bool checkAbsence = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CheckAbsence = checkAbsence;
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffsAroundConsideration.CheckAbsence"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCheckAbsence(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CheckAbsence);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BuffsAroundConsideration.FromCaster"/>
    /// </summary>
    ///
    /// <param name="fromCaster">
    /// <para>
    /// InfoBox: If true listed buffs should be applied by caster
    /// </para>
    /// </param>
    public TBuilder SetFromCaster(bool fromCaster = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FromCaster = fromCaster;
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffsAroundConsideration.FromCaster"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="fromCaster">
    /// <para>
    /// InfoBox: If true listed buffs should be applied by caster
    /// </para>
    /// </param>
    public TBuilder ModifyFromCaster(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FromCaster);
        });
    }
  }
}

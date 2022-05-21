//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BuffConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBuffConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : BuffConsideration
    where TBuilder : BaseBuffConsiderationConfigurator<T, TBuilder>
  {
    protected BaseBuffConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BuffConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBuffs(params Blueprint<BlueprintBuff, BlueprintBuffReference>[] buffs)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Buffs = buffs.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BuffConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
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
    /// Removes elements from <see cref="BuffConsideration.m_Buffs"/>
    /// </summary>
    ///
    /// <param name="buffs">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
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
    /// Removes elements from <see cref="BuffConsideration.m_Buffs"/> that match the provided predicate.
    /// </summary>
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
    /// Removes all elements from <see cref="BuffConsideration.m_Buffs"/>
    /// </summary>
    public TBuilder ClearBuffs()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Buffs = new BlueprintBuffReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffConsideration.m_Buffs"/> by invoking the provided action on each element.
    /// </summary>
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
    /// Sets the value of <see cref="BuffConsideration.HasBuffScore"/>
    /// </summary>
    public TBuilder SetHasBuffScore(float hasBuffScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasBuffScore = hasBuffScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffConsideration.HasBuffScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasBuffScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasBuffScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BuffConsideration.NoBuffScore"/>
    /// </summary>
    public TBuilder SetNoBuffScore(float noBuffScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoBuffScore = noBuffScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffConsideration.NoBuffScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoBuffScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoBuffScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BuffConsideration.FromCaster"/>
    /// </summary>
    public TBuilder SetFromCaster(bool fromCaster = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FromCaster = fromCaster;
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffConsideration.FromCaster"/> by invoking the provided action.
    /// </summary>
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

//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="FactConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFactConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : FactConsideration
    where TBuilder : BaseFactConsiderationConfigurator<T, TBuilder>
  {
    protected BaseFactConsiderationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="FactConsideration.m_Fact"/>
    /// </summary>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFact(params Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>[] fact)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Fact = fact.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="FactConsideration.m_Fact"/>
    /// </summary>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToFact(params Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>[] fact)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Fact = bp.m_Fact ?? new BlueprintUnitFactReference[0];
          bp.m_Fact = CommonTool.Append(bp.m_Fact, fact.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FactConsideration.m_Fact"/>
    /// </summary>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFact(params Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>[] fact)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Fact is null) { return; }
          bp.m_Fact = bp.m_Fact.Where(val => !fact.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FactConsideration.m_Fact"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFact(Func<BlueprintUnitFactReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Fact is null) { return; }
          bp.m_Fact = bp.m_Fact.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="FactConsideration.m_Fact"/>
    /// </summary>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearFact()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Fact = new BlueprintUnitFactReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="FactConsideration.m_Fact"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyFact(Action<BlueprintUnitFactReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Fact is null) { return; }
          bp.m_Fact.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FactConsideration.HasFactScore"/>
    /// </summary>
    public TBuilder SetHasFactScore(float hasFactScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasFactScore = hasFactScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="FactConsideration.HasFactScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasFactScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasFactScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FactConsideration.NoFactScore"/>
    /// </summary>
    public TBuilder SetNoFactScore(float noFactScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoFactScore = noFactScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="FactConsideration.NoFactScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoFactScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoFactScore);
        });
    }
  }
}

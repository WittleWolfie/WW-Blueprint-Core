//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
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
    protected BaseFactConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<FactConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Fact = copyFrom.m_Fact;
          bp.HasFactScore = copyFrom.HasFactScore;
          bp.NoFactScore = copyFrom.NoFactScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<FactConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Fact = copyFrom.m_Fact;
          bp.HasFactScore = copyFrom.HasFactScore;
          bp.NoFactScore = copyFrom.NoFactScore;
        });
    }

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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFact(params Blueprint<BlueprintUnitFactReference>[] fact)
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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToFact(params Blueprint<BlueprintUnitFactReference>[] fact)
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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFact(params Blueprint<BlueprintUnitFactReference>[] fact)
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
    public TBuilder RemoveFromFact(Func<BlueprintUnitFactReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Fact is null) { return; }
          bp.m_Fact = bp.m_Fact.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="FactConsideration.m_Fact"/>
    /// </summary>
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Fact is null)
      {
        Blueprint.m_Fact = new BlueprintUnitFactReference[0];
      }
    }
  }
}

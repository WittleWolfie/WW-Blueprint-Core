//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ComplexConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseComplexConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ComplexConsideration
    where TBuilder : BaseComplexConsiderationConfigurator<T, TBuilder>
  {
    protected BaseComplexConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ComplexConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Considerations = copyFrom.m_Considerations;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ComplexConsideration.m_Considerations"/>
    /// </summary>
    ///
    /// <param name="considerations">
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetConsiderations(params Blueprint<ConsiderationReference>[] considerations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Considerations = considerations.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="ComplexConsideration.m_Considerations"/>
    /// </summary>
    ///
    /// <param name="considerations">
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToConsiderations(params Blueprint<ConsiderationReference>[] considerations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Considerations = bp.m_Considerations ?? new ConsiderationReference[0];
          bp.m_Considerations = CommonTool.Append(bp.m_Considerations, considerations.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="ComplexConsideration.m_Considerations"/>
    /// </summary>
    ///
    /// <param name="considerations">
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromConsiderations(params Blueprint<ConsiderationReference>[] considerations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Considerations is null) { return; }
          bp.m_Considerations = bp.m_Considerations.Where(val => !considerations.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="ComplexConsideration.m_Considerations"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromConsiderations(Func<ConsiderationReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Considerations is null) { return; }
          bp.m_Considerations = bp.m_Considerations.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="ComplexConsideration.m_Considerations"/>
    /// </summary>
    public TBuilder ClearConsiderations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Considerations = new ConsiderationReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="ComplexConsideration.m_Considerations"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyConsiderations(Action<ConsiderationReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Considerations is null) { return; }
          bp.m_Considerations.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Considerations is null)
      {
        Blueprint.m_Considerations = new ConsiderationReference[0];
      }
    }
  }
}

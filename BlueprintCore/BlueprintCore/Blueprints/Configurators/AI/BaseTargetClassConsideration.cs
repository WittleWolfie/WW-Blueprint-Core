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
  /// Implements common fields and components for blueprints inheriting from <see cref="TargetClassConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTargetClassConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : TargetClassConsideration
    where TBuilder : BaseTargetClassConsiderationConfigurator<T, TBuilder>
  {
    protected BaseTargetClassConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="TargetClassConsideration.m_FirstPriorityClasses"/>
    /// </summary>
    ///
    /// <param name="firstPriorityClasses">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFirstPriorityClasses(params Blueprint<BlueprintCharacterClassReference>[] firstPriorityClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FirstPriorityClasses = firstPriorityClasses.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="TargetClassConsideration.m_FirstPriorityClasses"/>
    /// </summary>
    ///
    /// <param name="firstPriorityClasses">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToFirstPriorityClasses(params Blueprint<BlueprintCharacterClassReference>[] firstPriorityClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FirstPriorityClasses = bp.m_FirstPriorityClasses ?? new BlueprintCharacterClassReference[0];
          bp.m_FirstPriorityClasses = CommonTool.Append(bp.m_FirstPriorityClasses, firstPriorityClasses.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TargetClassConsideration.m_FirstPriorityClasses"/>
    /// </summary>
    ///
    /// <param name="firstPriorityClasses">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFirstPriorityClasses(params Blueprint<BlueprintCharacterClassReference>[] firstPriorityClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FirstPriorityClasses is null) { return; }
          bp.m_FirstPriorityClasses = bp.m_FirstPriorityClasses.Where(val => !firstPriorityClasses.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TargetClassConsideration.m_FirstPriorityClasses"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFirstPriorityClasses(Func<BlueprintCharacterClassReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FirstPriorityClasses is null) { return; }
          bp.m_FirstPriorityClasses = bp.m_FirstPriorityClasses.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="TargetClassConsideration.m_FirstPriorityClasses"/>
    /// </summary>
    public TBuilder ClearFirstPriorityClasses()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FirstPriorityClasses = new BlueprintCharacterClassReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="TargetClassConsideration.m_FirstPriorityClasses"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFirstPriorityClasses(Action<BlueprintCharacterClassReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FirstPriorityClasses is null) { return; }
          bp.m_FirstPriorityClasses.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetClassConsideration.FirstPriorityScore"/>
    /// </summary>
    public TBuilder SetFirstPriorityScore(float firstPriorityScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FirstPriorityScore = firstPriorityScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="TargetClassConsideration.FirstPriorityScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFirstPriorityScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FirstPriorityScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetClassConsideration.m_SecondPriorityClasses"/>
    /// </summary>
    ///
    /// <param name="secondPriorityClasses">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSecondPriorityClasses(params Blueprint<BlueprintCharacterClassReference>[] secondPriorityClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SecondPriorityClasses = secondPriorityClasses.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="TargetClassConsideration.m_SecondPriorityClasses"/>
    /// </summary>
    ///
    /// <param name="secondPriorityClasses">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToSecondPriorityClasses(params Blueprint<BlueprintCharacterClassReference>[] secondPriorityClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SecondPriorityClasses = bp.m_SecondPriorityClasses ?? new BlueprintCharacterClassReference[0];
          bp.m_SecondPriorityClasses = CommonTool.Append(bp.m_SecondPriorityClasses, secondPriorityClasses.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TargetClassConsideration.m_SecondPriorityClasses"/>
    /// </summary>
    ///
    /// <param name="secondPriorityClasses">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSecondPriorityClasses(params Blueprint<BlueprintCharacterClassReference>[] secondPriorityClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SecondPriorityClasses is null) { return; }
          bp.m_SecondPriorityClasses = bp.m_SecondPriorityClasses.Where(val => !secondPriorityClasses.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="TargetClassConsideration.m_SecondPriorityClasses"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSecondPriorityClasses(Func<BlueprintCharacterClassReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SecondPriorityClasses is null) { return; }
          bp.m_SecondPriorityClasses = bp.m_SecondPriorityClasses.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="TargetClassConsideration.m_SecondPriorityClasses"/>
    /// </summary>
    public TBuilder ClearSecondPriorityClasses()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SecondPriorityClasses = new BlueprintCharacterClassReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="TargetClassConsideration.m_SecondPriorityClasses"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySecondPriorityClasses(Action<BlueprintCharacterClassReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SecondPriorityClasses is null) { return; }
          bp.m_SecondPriorityClasses.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetClassConsideration.SecondPriorityScore"/>
    /// </summary>
    public TBuilder SetSecondPriorityScore(float secondPriorityScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SecondPriorityScore = secondPriorityScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="TargetClassConsideration.SecondPriorityScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySecondPriorityScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SecondPriorityScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="TargetClassConsideration.NoPriorityScore"/>
    /// </summary>
    public TBuilder SetNoPriorityScore(float noPriorityScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NoPriorityScore = noPriorityScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="TargetClassConsideration.NoPriorityScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNoPriorityScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NoPriorityScore);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_FirstPriorityClasses is null)
      {
        Blueprint.m_FirstPriorityClasses = new BlueprintCharacterClassReference[0];
      }
      if (Blueprint.m_SecondPriorityClasses is null)
      {
        Blueprint.m_SecondPriorityClasses = new BlueprintCharacterClassReference[0];
      }
    }
  }
}

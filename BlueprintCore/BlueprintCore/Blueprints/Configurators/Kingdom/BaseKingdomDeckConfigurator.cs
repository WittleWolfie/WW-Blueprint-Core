//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomDeck"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomDeckConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintKingdomDeck
    where TBuilder : BaseKingdomDeckConfigurator<T, TBuilder>
  {
    protected BaseKingdomDeckConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintKingdomDeck>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Events = copyFrom.Events;
          bp.IsPriority = copyFrom.IsPriority;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintKingdomDeck>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Events = copyFrom.Events;
          bp.IsPriority = copyFrom.IsPriority;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomDeck.Events"/>
    /// </summary>
    ///
    /// <param name="events">
    /// <para>
    /// Blueprint of type BlueprintKingdomEvent. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEvents(params Blueprint<BlueprintKingdomEventReference>[] events)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Events = events.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintKingdomDeck.Events"/>
    /// </summary>
    ///
    /// <param name="events">
    /// <para>
    /// Blueprint of type BlueprintKingdomEvent. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEvents(params Blueprint<BlueprintKingdomEventReference>[] events)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Events = bp.Events ?? new();
          bp.Events.AddRange(events.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintKingdomDeck.Events"/>
    /// </summary>
    ///
    /// <param name="events">
    /// <para>
    /// Blueprint of type BlueprintKingdomEvent. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEvents(params Blueprint<BlueprintKingdomEventReference>[] events)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Events is null) { return; }
          bp.Events = bp.Events.Where(val => !events.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintKingdomDeck.Events"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEvents(Func<BlueprintKingdomEventReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Events is null) { return; }
          bp.Events = bp.Events.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintKingdomDeck.Events"/>
    /// </summary>
    public TBuilder ClearEvents()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Events = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomDeck.Events"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEvents(Action<BlueprintKingdomEventReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Events is null) { return; }
          bp.Events.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomDeck.IsPriority"/>
    /// </summary>
    public TBuilder SetIsPriority(bool isPriority = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsPriority = isPriority;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Events is null)
      {
        Blueprint.Events = new();
      }
    }
  }
}

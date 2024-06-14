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
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomEventTimeline"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomEventTimelineConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintKingdomEventTimeline
    where TBuilder : BaseKingdomEventTimelineConfigurator<T, TBuilder>
  {
    protected BaseKingdomEventTimelineConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintKingdomEventTimeline>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Entries = copyFrom.Entries;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintKingdomEventTimeline>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Entries = copyFrom.Entries;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventTimeline.Entries"/>
    /// </summary>
    public TBuilder SetEntries(BlueprintKingdomEventTimeline.EntryList entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(entries);
          bp.Entries = entries;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventTimeline.Entries"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEntries(Action<BlueprintKingdomEventTimeline.EntryList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Entries is null) { return; }
          action.Invoke(bp.Entries);
        });
    }
  }
}
